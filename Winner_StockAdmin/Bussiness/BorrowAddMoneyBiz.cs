// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BorrowAddmoneyBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels.BorrowAddmoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class BorrowAddmoneyBiz
  {
    public static List<BorrowAddmoneyList> GetBorrowAddmoneyList(BorrowAddmoneyFilter? filter)
    {
      List<BorrowAddmoneyList> borrowAddmoneyList = BorrowAddmoneyService.FindBorrowAddmoneyList(SqlTool.Build<BorrowAddmoneyFilter>(filter).Must("borrow_addmoney.status = 0"));
      return borrowAddmoneyList == null ? (List<BorrowAddmoneyList>) null : borrowAddmoneyList.Select<BorrowAddmoneyList, BorrowAddmoneyList>((Func<BorrowAddmoneyList, BorrowAddmoneyList>) (borrowAddmoney => PublicTool.convertUtcToLocalTime<BorrowAddmoneyList>(borrowAddmoney))).ToList<BorrowAddmoneyList>();
    }

    public static BorrowAddmoneyDto Get(int pk) => BorrowAddmoneyService.Find(pk);

    public static void PostCreate(BorrowAddmoneyDto req)
    {
      if (BorrowAddmoneyService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowAddmoneyDto req)
    {
      if (BorrowAddmoneyService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowAddmoneyService.Remove(pk);

    public static BorrowAddmoneyReview GetReview(int pk)
    {
      return BorrowAddmoneyService.FindBorrowAddmoneyReview(pk);
    }

    public static bool ReviewApprove(int pk, bool verifyStatus, AdminSession adminUser)
    {
      BorrowAddmoneyDto borrowAddmoneyDto = BorrowAddmoneyService.Find(pk);
      VwTradeAccountDto accountBySubAccount = TradeMoneyCheckService.GetVwTradeAccountBySubAccount(borrowAddmoneyDto.sub_account);
      if (accountBySubAccount.margin + accountBySubAccount.loan_money - accountBySubAccount.balance < borrowAddmoneyDto.money)
        throw new AppException(3031, "not_match_condition");
      if (borrowAddmoneyDto.status != 0)
        throw new AppException(3032, "verify_status_incorrect");
      BorrowAddmoneyService.UpdateStatus(pk, verifyStatus);
      int temp_id = verifyStatus ? 38 : 39;
      if (verifyStatus)
      {
        WalletDto walletDto = WalletService.Find(accountBySubAccount.member_fk);
        Decimal rate = ExchangeLib.GetRate(borrowAddmoneyDto.currency, walletDto.currency);
        int memberFk = accountBySubAccount.member_fk;
        Decimal freeze = borrowAddmoneyDto.freeze;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowAddmoneyDto.pk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        string subAccount = accountBySubAccount.sub_account;
        Decimal money = borrowAddmoneyDto.money;
        string currency = borrowAddmoneyDto.currency;
        WalletLib.MaginCallPass(memberFk, freeze, stringAndClear, subAccount, money, currency);
        TradeMoneyRecordDto byAccount = TradeMoneyRecordService.GetByAccount(borrowAddmoneyDto.sub_account);
        object[] objArray = new object[4]
        {
          (object) borrowAddmoneyDto.money,
          (object) borrowAddmoneyDto.currency,
          (object) borrowAddmoneyDto.freeze,
          (object) walletDto.currency
        };
        TradeRecordLib.Save(new TradeMoneyRecoreRequest()
        {
          member_fk = borrowAddmoneyDto.member_fk,
          sub_account = borrowAddmoneyDto.sub_account,
          temp_id = temp_id,
          sn = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") ?? "",
          currency = borrowAddmoneyDto.currency,
          affect = borrowAddmoneyDto.money,
          balance = byAccount.balance + borrowAddmoneyDto.money,
          exchange = rate,
          wallet_amount = borrowAddmoneyDto.freeze,
          op = 1,
          reviewer = adminUser.account,
          list = objArray,
          create_datetime = DateTime.UtcNow
        });
        TradeAccountService.UpdateMoney(borrowAddmoneyDto.sub_account, borrowAddmoneyDto.money);
        MemberTaskLib.MemberTaskFinish(borrowAddmoneyDto.member_fk, 6);
        SendMessageLib.Send(accountBySubAccount.member_fk, temp_id, (object) borrowAddmoneyDto.pk, (object) accountBySubAccount.sub_account, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowAddmoneyDto.money), borrowAddmoneyDto.currency), (object) borrowAddmoneyDto.currency, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowAddmoneyDto.freeze), walletDto.currency), (object) walletDto.currency);
      }
      else
      {
        int memberFk = accountBySubAccount.member_fk;
        Decimal freeze = borrowAddmoneyDto.freeze;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowAddmoneyDto.pk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        WalletLib.MaginCallFail(memberFk, freeze, stringAndClear);
        SendMessageLib.Send(accountBySubAccount.member_fk, temp_id, (object) borrowAddmoneyDto.pk, (object) accountBySubAccount.sub_account);
      }
      return true;
    }
  }
}
