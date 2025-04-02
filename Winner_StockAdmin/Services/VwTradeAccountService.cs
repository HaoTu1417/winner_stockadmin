// Decompiled with JetBrains decompiler
// Type: DB.Services.VwTradeAccountService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.DailyFinanceReport;
using stockadmin.ViewModels.EndTradeAccount;
using stockadmin.ViewModels.StatTradeAccount;
using stockadmin.ViewModels.TradingAccount;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class VwTradeAccountService
  {
    public static VwTradeAccountDto Find(string sub_account)
    {
      string sql = "SELECT * FROM `vw_trade_account` where sub_account = '" + sub_account + "' ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
          });
          return readConnection.QueryFirstOrDefault<VwTradeAccountDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[VwTradeAccountService][Find]" + ex.Message);
        return (VwTradeAccountDto) null;
      }
    }

    public static List<VwTradeAccountDto> FindAll()
    {
      string sql = "SELECT * FROM `vw_trade_account`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<VwTradeAccountDto>(sql).AsList<VwTradeAccountDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[VwTradeAccountService][FindAll]" + ex.Message);
        return (List<VwTradeAccountDto>) null;
      }
    }

    public static List<StatTradeAccountList> FindStatTradeAccountList(string whereSql = "")
    {
      string sql = "SELECT vw_trade_account.market, vw_trade_account.loan_type, vw_trade_account.margin, vw_trade_account.loan_money, COUNT(*) AS dcount\n                        FROM `vw_trade_account`\n                        INNER JOIN `member` ON (`member_fk` = `member`.pk AND `member`.is_test_account = 0)\n                        " + whereSql + "\n                        GROUP BY vw_trade_account.market, vw_trade_account.loan_type";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StatTradeAccountList>(sql).AsList<StatTradeAccountList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[VwTradeAccountService][FindStatTradeAccountList]" + ex.Message);
        return (List<StatTradeAccountList>) null;
      }
    }

    public static List<DailyFinanceReportList> FindDailyFinanceReportList(string whereSql = "")
    {
      string sql = "SELECT vw_trade_account.market, vw_trade_account.loan_type, vw_trade_account.margin, vw_trade_account.loan_money, COUNT(*) AS dcount\n                        FROM `vw_trade_account`\n                        INNER JOIN `member` ON (`member_fk` = `member`.pk AND `member`.is_test_account = 0)\n                        " + whereSql + "\n                        GROUP BY vw_trade_account.market, vw_trade_account.loan_type";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<DailyFinanceReportList>(sql).AsList<DailyFinanceReportList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[VwTradeAccountService][FindDailyFinanceReportList]" + ex.Message);
        return (List<DailyFinanceReportList>) null;
      }
    }

    public static (Decimal totalProfit, DataCountBase<EndTradeAccountList>) FindEndTradeAccountList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql1 = "\nSELECT \n    IFNULL(SUM(trade_deal.profit), 0) AS total_profit\nFROM `vw_trade_account` t\nLEFT JOIN trade_deal ON trade_deal.sub_account=t.sub_account\nLEFT JOIN borrow_plan ON borrow_plan.market=t.market AND borrow_plan.name=t.loan_type\nLEFT JOIN member m ON m.pk=t.member_fk and m.is_test_account = 0\n" + whereSql + ";";
      string sql2 = "\nSELECT \n    COUNT(*) AS count\nFROM `vw_trade_account` t\nLEFT JOIN trade_deal ON trade_deal.sub_account=t.sub_account\nLEFT JOIN borrow_plan ON borrow_plan.market=t.market AND borrow_plan.name=t.loan_type\nLEFT JOIN member m ON m.pk=t.member_fk\n" + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(640, 4);
      interpolatedStringHandler.AppendLiteral("\nSELECT\n  t.market,\n  t.sub_account AS sub_account,\n  t.balance,\n  t.STATUS,\n  t.borrow_type AS loan_type,\n  t.warningline,\n  t.breakline,\n  t.position_value,\n  t.begin_time,\n  t.end_time,\n  t.member_fk,\n  t.account,\n  t.member_name,\n  (\n  100 + 100 * (( t.balance - t.init_money ) / t.margin )) AS profit_percent,\n  borrow_plan.warning_line AS warningline_percent,\n  t.balance - t.init_money AS total_profit,\n  m.is_test_account,\n  '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' AS lang\nFROM\n  `vw_trade_account` t\n  LEFT JOIN borrow_plan ON borrow_plan.pk = t.borrow_plan_fk\n  INNER JOIN member m ON m.pk = t.member_fk\n");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\nGROUP BY sub_account\nORDER BY t.close_time DESC\nLIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\nOFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return (readConnection.QuerySingle<CountAndTotalProfit>(sql1).total_profit, new DataCountBase<EndTradeAccountList>(readConnection.QuerySingle<int>(sql2), (IEnumerable<EndTradeAccountList>) readConnection.Query<EndTradeAccountList>(stringAndClear).AsList<EndTradeAccountList>()));
      }
      catch (Exception ex)
      {
        LogLib.Log("[VwTradeAccountService][FindEndTradeAccountList]" + ex.Message);
        return (0M, new DataCountBase<EndTradeAccountList>());
      }
    }
  }
}
