// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeMoneyCheckBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeMoneyCheck;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class TradeMoneyCheckBiz
  {
    public static List<TradeMoneyCheckList> GetTradeMoneyCheckList(TradeMoneyCheckFilter? filter)
    {
      return TradeMoneyCheckService.FindTradeMoneyCheckList(SqlTool.Build<TradeMoneyCheckFilter>(filter).Must("trade_money_check.type = 0").Must("trade_money_check.state = 0"));
    }

    public static TradeMoneyCheckDto Get(int pk) => TradeMoneyCheckService.Find(pk);

    public static void PostCreate(TradeMoneyCheckDto req)
    {
      if (TradeMoneyCheckService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeMoneyCheckDto req)
    {
      if (TradeMoneyCheckService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => TradeMoneyCheckService.Remove(pk);

    public static TradeMoneyCheckReview GetReview(int pk)
    {
      return TradeMoneyCheckService.FindTradeMoneyCheckReview(pk);
    }

    public static bool WithdrawVerify(int pk, bool verifyStatus)
    {
      TradeMoneyCheckDto tradeMoneyCheckDto = TradeMoneyCheckService.Find(pk);
      VwTradeAccountDto accountBySubAccount = TradeMoneyCheckService.GetVwTradeAccountBySubAccount(tradeMoneyCheckDto.sub_account);
      if (accountBySubAccount.balance - tradeMoneyCheckDto.frozen <= (accountBySubAccount.warningline + accountBySubAccount.breakline) / 2M)
        throw new AppException(3020, "not_enough_trade_money");
      if (tradeMoneyCheckDto.state != 0)
        throw new AppException(3021, "verify_withdraw_status_incorrect");
      TradeAccountService.UpdateTradeAccountVolume(verifyStatus, tradeMoneyCheckDto.sub_account, tradeMoneyCheckDto.frozen);
      TradeFrozenService.DelTradeFrozen(tradeMoneyCheckDto.pk);
      TradeMoneyCheckService.UpdateWithdraw(Convert.ToInt32(pk), verifyStatus ? VerifyStatusType.Successful : VerifyStatusType.Fail);
      if (verifyStatus)
      {
        int temp_id = 49;
        TradeMoneyRecordDto byAccount = TradeMoneyRecordService.GetByAccount(tradeMoneyCheckDto.sub_account);
        TradeMoneyRecordService.Insert(new TradeMoneyRecordDto()
        {
          sub_account = tradeMoneyCheckDto.sub_account,
          member_fk = Convert.ToInt32(accountBySubAccount.member_fk),
          trade_deal_fk = new int?(),
          sn = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") ?? "",
          temp_id = temp_id,
          op = 1,
          currency = tradeMoneyCheckDto.currency,
          balance = byAccount.wallet_amount,
          affect = tradeMoneyCheckDto.frozen,
          exchange = tradeMoneyCheckDto.exchange,
          wallet_amount = byAccount.wallet_amount - tradeMoneyCheckDto.amount,
          info = "",
          reviewer = (string) null,
          create_datetime = DateTime.UtcNow,
          market = accountBySubAccount.market,
          stock_code = (string) null,
          stock_name = (string) null
        });
        WalletDto walletDto = WalletService.Find(accountBySubAccount.member_fk);
        WalletLib.WithdrawTradePass(accountBySubAccount.member_fk, tradeMoneyCheckDto.sn, tradeMoneyCheckDto.amount, tradeMoneyCheckDto.sn, tradeMoneyCheckDto.frozen, tradeMoneyCheckDto.currency);
        ExchangeLib.Convert(tradeMoneyCheckDto.amount, tradeMoneyCheckDto.currency, walletDto.currency);
        MemberTaskLib.MemberTaskFinish(accountBySubAccount.member_fk, 8);
        SendMessageLib.Send(accountBySubAccount.member_fk, temp_id, (object) tradeMoneyCheckDto.sn, (object) tradeMoneyCheckDto.sub_account, (object) PublicTool.AddNumberSeparation(new Decimal?(tradeMoneyCheckDto.frozen), tradeMoneyCheckDto.currency), (object) tradeMoneyCheckDto.currency, (object) PublicTool.AddNumberSeparation(new Decimal?(tradeMoneyCheckDto.amount), walletDto.currency), (object) walletDto.currency);
      }
      else
      {
        int temp_id = 50;
        SendMessageLib.Send(accountBySubAccount.member_fk, temp_id, (object) tradeMoneyCheckDto.sn, (object) tradeMoneyCheckDto.sub_account);
      }
      return true;
    }
  }
}
