// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.ReviewBorrowBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels;
using stockadmin.ViewModels.ReviewBorrow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class ReviewBorrowBiz
  {
    public static List<ReviewBorrowList> GetReviewBorrowList(ReviewBorrowFilter? filter)
    {
      List<ReviewBorrowList> reviewBorrowList = BorrowService.FindReviewBorrowList(SqlTool.Build<ReviewBorrowFilter>(filter).Must("`borrow`.`status` = -1"));
      return reviewBorrowList == null ? (List<ReviewBorrowList>) null : reviewBorrowList.Select<ReviewBorrowList, ReviewBorrowList>((Func<ReviewBorrowList, ReviewBorrowList>) (reviewBorrow => PublicTool.convertUtcToLocalTime<ReviewBorrowList>(reviewBorrow))).ToList<ReviewBorrowList>();
    }

    public static BorrowDto Get(int pk) => BorrowService.Find(pk);

    public static void PostCreate(BorrowDto req)
    {
      if (BorrowService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowDto req)
    {
      if (BorrowService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => BorrowService.Remove(pk);

    public static bool BorrowApplyVerify(int pk, bool verifyStatus, string input = "")
    {
      BorrowApply borrowApply = BorrowService.GetBorrowApply(pk);
      int temp_id = verifyStatus ? 32 : 33;
      WalletDto walletDto = borrowApply.status == (sbyte) -1 ? WalletService.Find(borrowApply.member_fk) : throw new AppException(3001, "borrow_verify_status_incorrect");
      if (verifyStatus)
      {
        DateTime dateTime = DateTime.UtcNow;
        DateTime date1 = dateTime.Date;
        dateTime = borrowApply.begin_time;
        DateTime date2 = dateTime.Date;
        if (date1 > date2)
        {
          BorrowService.UpdateStatus(pk, BorrowStatus.Expired);
          int memberFk = borrowApply.member_fk;
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
          interpolatedStringHandler.AppendFormatted<int>(borrowApply.pk);
          string stringAndClear = interpolatedStringHandler.ToStringAndClear();
          WalletLib.NewBorrowFail(memberFk, stringAndClear);
          SendMessageLib.Send(Convert.ToInt32(borrowApply.member_fk), temp_id, (object) pk, (object) "审核日期超过起始日期");
          throw new AppException(3000, "begindate_has_expired");
        }
        string empty = string.Empty;
        string str1;
        if (string.IsNullOrWhiteSpace(input))
        {
          do
          {
            string randomNum = PublicTool.GetRandomNum(8);
            str1 = borrowApply.market + randomNum;
          }
          while (TradeAccountService.Find(str1) != null);
        }
        else
        {
          str1 = input;
          if (TradeAccountService.Find(str1) != null)
            return false;
        }
        MemberDto memberDto = MemberService.Find(borrowApply.member_fk);
        if (string.IsNullOrWhiteSpace(memberDto.sub_account))
        {
          MemberService.UpdateSubAccount(memberDto.pk, str1);
          TokenModel token = TokenCatchLib.GetToken(memberDto.token);
          if (token != null)
          {
            token.sub_account = str1;
            token.market = borrowApply.market;
            TokenCatchLib.SetToken(memberDto.token, token);
          }
        }
        BorrowService.UpdateSubAccount(pk, str1);
        Decimal num1 = borrowApply.deposit_money * (Convert.ToDecimal((object) borrowApply.warning_line) / 100M) + borrowApply.borrow_money;
        Decimal num2 = borrowApply.deposit_money * (Convert.ToDecimal((object) borrowApply.break_line) / 100M) + borrowApply.borrow_money;
        Decimal change1 = ExchangeLib.Convert(borrowApply.borrow_interest, borrowApply.currency, walletDto.currency);
        Decimal num3 = ExchangeLib.Convert(borrowApply.total_coupon, borrowApply.currency, walletDto.currency);
        Decimal num4 = ExchangeLib.Convert(borrowApply.total_fee, borrowApply.currency, walletDto.currency);
        Decimal num5 = ExchangeLib.Convert(borrowApply.deposit_money, borrowApply.currency, walletDto.currency);
        TradeAccountService.Insert(new TradeAccountDto()
        {
          sub_account = str1,
          member_fk = borrowApply.member_fk,
          borrow_plan_fk = new int?(borrowApply.borrow_plan_fk),
          type = memberDto.is_test_account || borrowApply.borrow_type == "trial" ? 0 : 1,
          market = borrowApply.market,
          loan_type = borrowApply.borrow_type,
          currency = borrowApply.currency,
          mem_money = borrowApply.init_money,
          frozen_money = 0M,
          margin = borrowApply.deposit_money,
          margin_float = borrowApply.deposit_money,
          loan_money = borrowApply.borrow_money,
          time_zone = borrowApply.time_zone,
          begin_time = new DateTime?(borrowApply.begin_time),
          end_time = new DateTime?(borrowApply.end_time),
          close_time = new DateTime?(),
          status = 0,
          warningline = num1,
          breakline = num2,
          notice_warning = new DateTime?(),
          notice_close = new DateTime?(),
          multiple = new int?((int) borrowApply.multiple),
          borrow_duration = new int?(borrowApply.borrow_duration)
        });
        dateTime = DateTime.Now;
        string str2 = dateTime.ToString("yyyyMMdd");
        DateTime utcNow = DateTime.UtcNow;
        Decimal rate = ExchangeLib.GetRate(borrowApply.currency, walletDto.currency);
        TradeRecordLib.Save(new TradeMoneyRecoreRequest()
        {
          sub_account = str1,
          member_fk = borrowApply.member_fk,
          sn = str2 + PublicTool.GetRandomNum(6),
          currency = borrowApply.currency,
          create_datetime = utcNow,
          wallet_amount = num5,
          exchange = rate,
          balance = borrowApply.deposit_money,
          affect = borrowApply.deposit_money,
          op = 1,
          temp_id = 32,
          list = new object[4]
          {
            (object) borrowApply.deposit_money,
            (object) borrowApply.currency,
            (object) num5,
            (object) walletDto.currency
          }
        });
        TradeRecordLib.Save(new TradeMoneyRecoreRequest()
        {
          sub_account = str1,
          member_fk = borrowApply.member_fk,
          sn = str2 + PublicTool.GetRandomNum(6),
          currency = borrowApply.currency,
          create_datetime = utcNow,
          wallet_amount = 0M,
          affect = borrowApply.borrow_money,
          exchange = 0M,
          balance = borrowApply.borrow_money + borrowApply.deposit_money,
          temp_id = 201,
          op = 1,
          list = new object[4]
          {
            (object) borrowApply.borrow_money,
            (object) borrowApply.currency,
            (object) 0,
            (object) walletDto.currency
          }
        });
        if (borrowApply.borrow_type != "free" && borrowApply.borrow_type != "trial")
          BorrowFeeService.Insert(new BorrowFeeDto()
          {
            member_fk = memberDto.pk,
            sub_account = str1,
            borrow_fk = borrowApply.pk,
            type = 1,
            borrow_fee = change1,
            use_coupon = num3,
            fee_received = num4,
            borrow_duration = borrowApply.borrow_duration,
            create_time = utcNow
          });
        BorrowService.UpdateStatus(pk, BorrowStatus.Using);
        if (borrowApply.borrow_interest > 0M && borrowApply.borrow_type != "trial")
          MemberTaskLib.MemberTaskFinish(borrowApply.member_fk, 4);
        if (borrowApply.borrow_type != "free" && borrowApply.borrow_type != "trial")
          WalletLib.BorrowManagementFee(borrowApply.member_fk, change1, str1, borrowApply.borrow_interest, borrowApply.currency);
        int memberFk1 = borrowApply.member_fk;
        Decimal change2 = num5;
        DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler1.AppendFormatted<int>(borrowApply.pk);
        string stringAndClear1 = interpolatedStringHandler1.ToStringAndClear();
        string account = str1;
        Decimal depositMoney = borrowApply.deposit_money;
        string currency = borrowApply.currency;
        WalletLib.NewBorrowPass(memberFk1, change2, stringAndClear1, account, depositMoney, currency);
        RecommendRegisterDto model = RecommendRegisterService.Find(borrowApply.member_fk);
        if (model != null && !model.first_borrow_date.HasValue && borrowApply.borrow_type != "trial")
          RecommendRegisterService.UpdateFirstBorrowDate(model);
        SendMessageLib.Send(Convert.ToInt32(borrowApply.member_fk), temp_id, (object) pk, (object) str1, (object) PublicTool.AddNumberSeparation(new Decimal?(borrowApply.deposit_money), borrowApply.currency), (object) borrowApply.currency, (object) PublicTool.AddNumberSeparation(new Decimal?(num5), walletDto.currency), (object) walletDto.currency);
      }
      else
      {
        int memberFk = borrowApply.member_fk;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowApply.pk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        WalletLib.NewBorrowFail(memberFk, stringAndClear);
        BorrowService.UpdateStatus(pk, BorrowStatus.Forbid);
        SendMessageLib.Send(Convert.ToInt32(borrowApply.member_fk), temp_id, (object) pk, (object) "审核不通过");
      }
      return true;
    }
  }
}
