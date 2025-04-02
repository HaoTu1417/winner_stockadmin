// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AddfinancingBiz
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
using stockadmin.ViewModels.Addfinancing;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AddfinancingBiz
  {
    public static List<AddfinancingList> GetAddfinancingList(AddfinancingFilter? filter)
    {
      List<AddfinancingList> addfinancingList = BorrowAddfinancingService.FindAddfinancingList(SqlTool.Build<AddfinancingFilter>(filter).Must("borrow_addfinancing.status = 0"));
      return addfinancingList == null ? (List<AddfinancingList>) null : addfinancingList.Select<AddfinancingList, AddfinancingList>((Func<AddfinancingList, AddfinancingList>) (addfinancing => PublicTool.convertUtcToLocalTime<AddfinancingList>(addfinancing))).ToList<AddfinancingList>();
    }

    public static BorrowAddfinancingDto Get(int pk) => BorrowAddfinancingService.Find(pk);

    public static void PostCreate(BorrowAddfinancingDto req, AdminSession adminUser)
    {
      if (BorrowAddfinancingService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.member_fk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 325,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static void PostEdit(BorrowAddfinancingDto req, AdminSession adminUser)
    {
      if (BorrowAddfinancingService.UpdateFull(PublicTool.convertLocalToUtcTime<BorrowAddfinancingDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.member_fk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 325,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      BorrowAddfinancingService.Remove(pk);
      string account = MemberService.Find(pk).account;
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 325,
        list = objArray,
        member_account = account
      });
    }

    public static AddfinancingReview GetReview(int pk)
    {
      return BorrowAddfinancingService.FindAddfinancingReview(pk);
    }

    public static AddfinancingEditVm GetEditVm(int pk)
    {
      return BorrowAddfinancingService.FindAddfinancingEditVm(pk);
    }

    public static void ExpandBorrowVerify(int id, bool verifyStatus, AdminSession adminUser)
    {
      BorrowAddfinancingDto borrowAddfinancingDto = BorrowAddfinancingService.Find(id);
      TradeAccountDto tradeAccountDto = TradeAccountService.Find(borrowAddfinancingDto.sub_account);
      if (borrowAddfinancingDto.status != 0)
        throw new AppException(3010, "verify_status_incorrect");
      BorrowAddfinancingService.UpdateState(id, verifyStatus);
      WalletDto walletDto = WalletService.Find(borrowAddfinancingDto.member_fk);
      Decimal rate = ExchangeLib.GetRate(borrowAddfinancingDto.currency, walletDto.currency);
      int temp_id = verifyStatus ? 45 : 46;
      string str = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") ?? "";
      if (verifyStatus)
      {
        BorrowPlanDto borrowTypeMarket = BorrowPlanService.FindByBorrowTypeMarket(tradeAccountDto.loan_type, tradeAccountDto.market);
        TradeAccountService.UpdateExpandBorrow(borrowAddfinancingDto.sub_account, borrowAddfinancingDto.money, borrowAddfinancingDto.multiple, Convert.ToDecimal(borrowTypeMarket.warning_line / 100.0), Convert.ToDecimal(borrowTypeMarket.break_line / 100.0));
        TradeMoneyRecordDto byAccount = TradeMoneyRecordService.GetByAccount(borrowAddfinancingDto.sub_account);
        object[] objArray1 = new object[4]
        {
          (object) borrowAddfinancingDto.money,
          (object) borrowAddfinancingDto.currency,
          (object) borrowAddfinancingDto.freeze,
          (object) walletDto.currency
        };
        TradeRecordLib.Save(new TradeMoneyRecoreRequest()
        {
          member_fk = borrowAddfinancingDto.member_fk,
          sub_account = borrowAddfinancingDto.sub_account,
          temp_id = temp_id,
          sn = str,
          currency = borrowAddfinancingDto.currency,
          affect = borrowAddfinancingDto.money,
          balance = byAccount.balance + borrowAddfinancingDto.money,
          exchange = rate,
          wallet_amount = borrowAddfinancingDto.freeze,
          op = 1,
          reviewer = adminUser.account,
          list = objArray1,
          create_datetime = DateTime.UtcNow
        });
        Decimal num = borrowAddfinancingDto.money * borrowAddfinancingDto.multiple;
        object[] objArray2 = new object[4]
        {
          (object) num,
          (object) borrowAddfinancingDto.currency,
          (object) 0,
          (object) walletDto.currency
        };
        TradeRecordLib.Save(new TradeMoneyRecoreRequest()
        {
          sub_account = borrowAddfinancingDto.sub_account,
          member_fk = borrowAddfinancingDto.member_fk,
          sn = str,
          temp_id = 203,
          op = 1,
          currency = borrowAddfinancingDto.currency,
          balance = byAccount.balance + borrowAddfinancingDto.money + borrowAddfinancingDto.money * borrowAddfinancingDto.multiple,
          affect = num,
          exchange = 0M,
          wallet_amount = 0M,
          list = objArray2,
          reviewer = adminUser.account,
          create_datetime = DateTime.UtcNow
        });
        BorrowFeeService.Insert(new BorrowFeeDto()
        {
          sub_account = borrowAddfinancingDto.sub_account,
          member_fk = borrowAddfinancingDto.member_fk,
          borrow_fk = borrowAddfinancingDto.pk,
          type = 3,
          borrow_fee = borrowAddfinancingDto.borrow_interest,
          use_coupon = 0M,
          fee_received = borrowAddfinancingDto.borrow_interest,
          borrow_duration = 0,
          create_time = DateTime.UtcNow
        });
        WalletLib.ExpandBorrowManagementFee(borrowAddfinancingDto.member_fk, borrowAddfinancingDto.borrow_interest, Convert.ToString(borrowAddfinancingDto.pk), borrowAddfinancingDto.sub_account);
        WalletLib.ExpandBorrowPass(borrowAddfinancingDto.member_fk, borrowAddfinancingDto.freeze, Convert.ToString(borrowAddfinancingDto.pk), borrowAddfinancingDto.sub_account, borrowAddfinancingDto.money, borrowAddfinancingDto.currency);
        MemberTaskLib.MemberTaskFinish(borrowAddfinancingDto.member_fk, 5);
        SendMessageLib.Send(borrowAddfinancingDto.member_fk, temp_id, (object) borrowAddfinancingDto.pk, (object) borrowAddfinancingDto.sub_account, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowAddfinancingDto.freeze), walletDto.currency), (object) walletDto.currency, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowAddfinancingDto.money), borrowAddfinancingDto.currency), (object) borrowAddfinancingDto.currency);
      }
      else
      {
        WalletLib.ExpandBorrowFail(borrowAddfinancingDto.member_fk, borrowAddfinancingDto.borrow_interest + borrowAddfinancingDto.freeze, Convert.ToString(borrowAddfinancingDto.pk));
        SendMessageLib.Send(borrowAddfinancingDto.member_fk, temp_id, (object) borrowAddfinancingDto.pk, (object) borrowAddfinancingDto.sub_account);
      }
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) borrowAddfinancingDto.member_fk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 325,
        list = objArray,
        member_account = MemberService.Find(borrowAddfinancingDto.member_fk).account
      });
    }
  }
}
