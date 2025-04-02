// Decompiled with JetBrains decompiler
// Type: DB.Services.StatisticsService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.ClosedTradeAccount;
using stockadmin.ViewModels.DailyFinanceReport;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class StatisticsService
  {
    public static int Count(string table_name, string whereSql = "")
    {
      string sql = "SELECT COUNT(*) FROM `" + table_name + "` " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StatisticsService][Count]" + ex.Message);
        return 0;
      }
    }

    public static int Count(string table_name, string join, string on, string whereSql = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 4);
      interpolatedStringHandler.AppendLiteral("SELECT COUNT(*) FROM `");
      interpolatedStringHandler.AppendFormatted(table_name);
      interpolatedStringHandler.AppendLiteral("` INNER JOIN ");
      interpolatedStringHandler.AppendFormatted(join);
      interpolatedStringHandler.AppendLiteral(" ON ");
      interpolatedStringHandler.AppendFormatted(on);
      interpolatedStringHandler.AppendLiteral(" ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StatisticsService][JOIN Count]" + ex.Message);
        return 0;
      }
    }

    public static int Sum(string table_name, string column, string whereSql = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 3);
      interpolatedStringHandler.AppendLiteral("SELECT SUM(");
      interpolatedStringHandler.AppendFormatted(column);
      interpolatedStringHandler.AppendLiteral(") FROM `");
      interpolatedStringHandler.AppendFormatted(table_name);
      interpolatedStringHandler.AppendLiteral("` ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StatisticsService][Sum]" + ex.Message);
        return 0;
      }
    }

    public static (CountAndSummary, DataCountBase<DailyFinanceReportList>) GetDailyFinanceReport(
      string whereSql = "",
      bool getAll = false,
      int page = 1,
      int pageSize = 20)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      string str1;
      if (!getAll)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
        interpolatedStringHandler.AppendLiteral("LIMIT ");
        interpolatedStringHandler.AppendFormatted<int>(pageSize);
        interpolatedStringHandler.AppendLiteral(" OFFSET ");
        interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
        str1 = interpolatedStringHandler.ToStringAndClear();
      }
      else
        str1 = string.Empty;
      string str2 = str1;
      string sql = "\n                SELECT \n                    COUNT(*) AS count,\n                    SUM(t5.today_profit) AS total_profit_loss,\n                    SUM(t2.today_recharge) AS total_recharge,\n                    SUM(t3.today_withdraw) AS total_withdraw,\n                    SUM(t1.today_member) AS total_member,\n                    SUM(t4.today_management_fee) AS total_management_fee\n                FROM \n\t                (Select create_time From vw_member_summary\n                     UNION \n                     Select create_time From vw_recharge_summary\n                     UNION \n                     Select create_time From vw_withdraw_summary\n                     UNION\n                     Select create_time From vw_borrow_summary\n                     UNION   \n                     Select create_time From vw_trade_deal_summary\n                     UNION\n                     Select create_time From vw_used_coupon_summary\n                    ) all_date\n                Left JOIN vw_member_summary t1  ON all_date.create_time = t1.create_time\n                Left JOIN vw_recharge_summary t2  ON all_date.create_time = t2.create_time\n                Left JOIN vw_withdraw_summary t3  ON all_date.create_time = t3.create_time\n                Left JOIN vw_borrow_summary t4  ON all_date.create_time = t4.create_time\n                Left JOIN vw_trade_deal_summary t5  ON all_date.create_time = t5.create_time\n                Left JOIN vw_used_coupon_summary t6  ON all_date.create_time = t6.create_time\n                Left JOIN vw_first_recharge_summary t7  ON all_date.create_time = t7.create_time\n                " + whereSql + ";";
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(2018, 2);
      interpolatedStringHandler.AppendLiteral("SELECT \n\t                all_date.create_time AS create_time,\n\t                IFNULL(t1.today_member, 0) AS today_member,\n\t                IFNULL(t2.today_recharge, 0) AS today_recharge,\n\t                IFNULL(t2.total_recharge, 0) AS total_recharge,\n                    IFNULL(t3.today_withdraw, 0) AS today_withdraw,\n\t                IFNULL(t4.today_management_fee, 0) AS today_management_fee,\n\t                IFNULL(t5.today_profit, 0) AS today_profit_loss,\n\t                IFNULL(t5.today_handling_fee, 0) AS today_handling_fee,\n                    IFNULL(t6.today_used_coupon, 0) AS today_used_coupon,\n                    IFNULL(t7.today_first_recharge, 0) AS today_first_recharge\n                FROM \n\t                (Select create_time From vw_member_summary\n                     UNION \n                     Select create_time From vw_recharge_summary\n                     UNION \n                     Select create_time From vw_withdraw_summary\n                     UNION\n                     Select create_time From vw_borrow_summary\n                     UNION   \n                     Select create_time From vw_trade_deal_summary\n                     UNION\n                     Select create_time From vw_used_coupon_summary\n                    ) all_date\n                Left JOIN vw_member_summary t1  ON all_date.create_time = t1.create_time\n                Left JOIN vw_recharge_summary t2  ON all_date.create_time = t2.create_time\n                Left JOIN vw_withdraw_summary t3  ON all_date.create_time = t3.create_time\n                Left JOIN vw_borrow_summary t4  ON all_date.create_time = t4.create_time\n                Left JOIN vw_trade_deal_summary t5  ON all_date.create_time = t5.create_time\n                Left JOIN vw_used_coupon_summary t6  ON all_date.create_time = t6.create_time\n                Left JOIN vw_first_recharge_summary t7  ON all_date.create_time = t7.create_time\n                 ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY\n\t                all_date.create_time DESC\n                ");
      interpolatedStringHandler.AppendFormatted(str2);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          CountAndSummary countAndSummary = readConnection.QuerySingle<CountAndSummary>(sql);
          List<DailyFinanceReportList> data = readConnection.Query<DailyFinanceReportList>(stringAndClear).AsList<DailyFinanceReportList>();
          return (countAndSummary, new DataCountBase<DailyFinanceReportList>(countAndSummary.count, (IEnumerable<DailyFinanceReportList>) data));
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StatisticsService][GetDailyFinanceReport]" + ex.Message);
        return (new CountAndSummary(), new DataCountBase<DailyFinanceReportList>());
      }
    }

    public static DataCountBase<ClosedTradeAccountList> GetClosedTradeAccountList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      int int32 = Convert.ToInt32(ConfigLib.Get("time_zone_difference"));
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(653, 2);
      interpolatedStringHandler.AppendLiteral("\n                            SELECT COUNT(*) AS total_count\n                            FROM (\n                                SELECT \n                                    COUNT(0) AS count\n                                FROM `trade_account`\n                                JOIN `member` ON (`member`.`pk` = `trade_account`.`member_fk`)\n                                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" \n                                    AND `member`.`is_del` = 0\n                                    AND `member`.`is_test_account` = 0\n                                GROUP BY CAST(`trade_account`.`close_time` + INTERVAL ");
      interpolatedStringHandler.AppendFormatted<int>(int32);
      interpolatedStringHandler.AppendLiteral(" HOUR AS DATE)\n                            ) AS `grouped_data`;");
      string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
      interpolatedStringHandler = new DefaultInterpolatedStringHandler(1026, 5);
      interpolatedStringHandler.AppendLiteral("SELECT\n                            CAST(`trade_account`.`close_time` + INTERVAL ");
      interpolatedStringHandler.AppendFormatted<int>(int32);
      interpolatedStringHandler.AppendLiteral(" HOUR AS DATE) AS `close_time`,\n                            COALESCE(SUM(`trade_account`.`close_type` = 1), 0) AS `client_close`,\n                            COALESCE(SUM(`trade_account`.`close_type` = 2), 0) AS `due_close`,\n                            COALESCE(SUM(`trade_account`.`close_type` = 3), 0) AS `margin_call_close`,\n                            COALESCE(SUM(`trade_account`.`close_type` = 4), 0) AS `trial`\n                        FROM `trade_account`\n                        JOIN `member` ON (`member`.`pk` = `trade_account`.`member_fk`)\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral(" \n                            AND `member`.`is_del` = 0\n                            AND `member`.`is_test_account` = 0\n                        GROUP BY CAST(`trade_account`.`close_time` + INTERVAL ");
      interpolatedStringHandler.AppendFormatted<int>(int32);
      interpolatedStringHandler.AppendLiteral(" HOUR AS DATE)                        \n                        ORDER BY\n\t                        close_time DESC\n                        LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                        OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<ClosedTradeAccountList>(readConnection.QuerySingle<int>(stringAndClear1), (IEnumerable<ClosedTradeAccountList>) readConnection.Query<ClosedTradeAccountList>(stringAndClear2).AsList<ClosedTradeAccountList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[StatisticsService][GetClosedTradeAccountList]" + ex.Message);
        return new DataCountBase<ClosedTradeAccountList>();
      }
    }
  }
}
