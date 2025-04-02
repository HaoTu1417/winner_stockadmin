// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StatisticsBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.Addfinancing;

#nullable disable
namespace stockadmin.Business
{
  public class StatisticsBiz
  {
    public static int GetRechargeApplyCount()
    {
      return StatisticsService.Count("wallet_recharge", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 0"));
    }

    public static int GetWithdrawApplyCount()
    {
      return StatisticsService.Count("wallet_withdraw", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 0"));
    }

    public static int GetBorrowCount()
    {
      return StatisticsService.Count("borrow", "borrow_fee", "borrow.pk = borrow_fee.borrow_fk", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("borrow.status = -1").Must("borrow_fee.type = 1"));
    }

    public static int GetBorrowAddMoneyCount()
    {
      return StatisticsService.Count("borrow_addmoney", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 0"));
    }

    public static int GetBorrowRenewCount()
    {
      return StatisticsService.Count("borrow_request", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("type = 1").Must("status = 0"));
    }

    public static int GetBorrowAddFinanceCount()
    {
      return StatisticsService.Count("borrow_addfinancing", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 0"));
    }

    public static int GetBorrowStopCount()
    {
      return StatisticsService.Count("borrow_request", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("type = 2").Must("status = 0"));
    }

    public static int GetTradeProfitWithdrawCount()
    {
      return StatisticsService.Count("trade_money_check", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("type = 1").Must("state = 0"));
    }

    public static int GetTradeAccountCount()
    {
      return StatisticsService.Count("trade_account", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 0"));
    }

    public static int GetAlertTradeAccountCount()
    {
      return StatisticsService.Count("trade_account", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 1"));
    }

    public static int GetTradeAccountEndTodayCount()
    {
      return StatisticsService.Count("trade_account", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("date(end_time) = utc_date()"));
    }

    public static int GetMemberBankVerifyCount()
    {
      return StatisticsService.Count("member_bank", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("is_confirm = 0").Must("is_delete = 0"));
    }

    public static int GetLiquidatedAccountTodayCount()
    {
      return StatisticsService.Count("vw_trade_account", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("date(notice_close) = utc_date()").Must("status = 2").Must("balance <= breakline"));
    }

    public static int GetTradeAccountFreeFeeCount()
    {
      return StatisticsService.Count("trade_account", "borrow_plan", "trade_account.borrow_plan_fk = borrow_plan.pk", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("trade_account.status = 0").Must("borrow_plan.borrow_type = 'free'"));
    }

    public static int GetBorrowDepositMoney()
    {
      return StatisticsService.Sum("borrow", "deposit_money", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()));
    }

    public static int GetBorrowMoneyToday()
    {
      return StatisticsService.Sum("borrow", "deposit_money", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 1").Must("date(verify_time) = utc_date()"));
    }

    public static int GetRechargeToday()
    {
      return StatisticsService.Sum("wallet_recharge", "money", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 1").Must("date(verify_time) = utc_date()"));
    }

    public static int GetWithdrawToday()
    {
      return StatisticsService.Sum("wallet_withdraw", "money", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("status = 1").Must("date(verify_time) = utc_date()"));
    }

    public static int GetMemberRegisterToday()
    {
      return StatisticsService.Count("member", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("date(create_time) = utc_date()"));
    }

    public static int GetMemberVerifying()
    {
      return StatisticsService.Count("member", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("id_auth = 3"));
    }

    public static int GetTotalMember()
    {
      return StatisticsService.Count("member", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()));
    }

    public static int GetUnreadMessages()
    {
      return StatisticsService.Count("message_record", SqlTool.Build<StatisticsFilter>(new StatisticsFilter()).Must("classify = 2 AND send_status = 1 AND read_status = 0"));
    }
  }
}
