// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RequestRenewBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.RequestRenew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class RequestRenewBiz
  {
    public static List<RequestRenewList> GetRequestRenewList(RequestRenewFilter? filter)
    {
      List<RequestRenewList> requestRenewList = BorrowRequestService.FindRequestRenewList(SqlTool.Build<RequestRenewFilter>(filter).Must("borrow_request.type = 1").Must("borrow_request.status = 0"));
      return requestRenewList == null ? (List<RequestRenewList>) null : requestRenewList.Select<RequestRenewList, RequestRenewList>((Func<RequestRenewList, RequestRenewList>) (findRequest => PublicTool.convertUtcToLocalTime<RequestRenewList>(findRequest))).ToList<RequestRenewList>();
    }

    public static BorrowRequestDto Get(int pk) => BorrowRequestService.Find(pk);

    public static void PostCreate(BorrowRequestDto req)
    {
      if (BorrowRequestService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<BorrowRequestDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowRequestDto req, AdminSession adminUser)
    {
      if (BorrowRequestService.UpdateFull(PublicTool.convertLocalToUtcTime<BorrowRequestDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 355,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static void Delete(int pk) => BorrowRequestService.Remove(pk);

    public static RequestRenewReview GetReview(int pk)
    {
      return BorrowRequestService.FindRequestRenewReview(pk);
    }

    public static void RenewalVerify(int borrowRequestId, bool verifyStatus)
    {
      BorrowRequestDto borrowRequestDto = BorrowRequestService.Find(borrowRequestId);
      TradeAccountDto tradeAccountDto = borrowRequestDto.status == 0 ? TradeAccountService.Find(borrowRequestDto.sub_account) : throw new AppException(3010, "verify_status_incorrect");
      BorrowRequestService.UpdateState(borrowRequestId, verifyStatus);
      WalletDto walletDto = WalletService.Find(borrowRequestDto.member_fk);
      int temp_id = verifyStatus ? 42 : 43;
      if (verifyStatus)
      {
        if (tradeAccountDto.mem_money - tradeAccountDto.frozen_money <= tradeAccountDto.breakline)
          throw new AppException(3041, "trade_account_balance_not_enough");
        BorrowFeeService.Insert(new BorrowFeeDto()
        {
          sub_account = borrowRequestDto.sub_account,
          member_fk = borrowRequestDto.member_fk,
          borrow_fk = borrowRequestDto.pk,
          type = 2,
          borrow_fee = borrowRequestDto.borrow_fee,
          use_coupon = borrowRequestDto.use_coupon,
          fee_received = borrowRequestDto.fee_received,
          borrow_duration = borrowRequestDto.borrow_duration,
          create_time = DateTime.UtcNow
        });
        int memberFk = borrowRequestDto.member_fk;
        Decimal feeReceived = borrowRequestDto.fee_received;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowRequestDto.pk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        string subAccount = borrowRequestDto.sub_account;
        WalletLib.BorrowRenewalPass(memberFk, feeReceived, stringAndClear, subAccount);
        TradeAccountService.UpdateAccountRenewal(borrowRequestDto.sub_account, AccountStatusType.Tradable, borrowRequestDto.new_end_time);
        SendMessageLib.Send(borrowRequestDto.member_fk, temp_id, (object) borrowRequestDto.pk, (object) borrowRequestDto.sub_account, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowRequestDto.fee_received), walletDto.currency), (object) walletDto.currency, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowRequestDto.fee_received), walletDto.currency), (object) walletDto.currency);
      }
      else
      {
        int memberFk = borrowRequestDto.member_fk;
        Decimal feeReceived = borrowRequestDto.fee_received;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowRequestDto.pk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        WalletLib.BorrowRenewalFail(memberFk, feeReceived, stringAndClear);
        SendMessageLib.Send(borrowRequestDto.member_fk, temp_id, (object) borrowRequestDto.pk, (object) borrowRequestDto.sub_account);
      }
    }
  }
}
