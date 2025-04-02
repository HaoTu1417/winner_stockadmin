// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeAccountService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.TradeAccount;
using stockadmin.ViewModels.TradingAccount;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class TradeAccountService
  {
    public static TradeAccountDto Find(string sub_account)
    {
      string sql = "SELECT * FROM `trade_account` WHERE `sub_account` = @sub_account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account
          });
          return readConnection.QueryFirstOrDefault<TradeAccountDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][Find]" + ex.Message);
        return (TradeAccountDto) null;
      }
    }

    public static List<TradeAccountDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_account`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeAccountDto>(sql).AsList<TradeAccountDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][FindAll]" + ex.Message);
        return (List<TradeAccountDto>) null;
      }
    }

    public static int Insert(TradeAccountDto model)
    {
      string sql = "INSERT INTO `trade_account` (\n\t\t\t\t`sub_account`, `member_fk`, `borrow_plan_fk`, `type`, `market`, `loan_type`, `currency`, `mem_money`, `frozen_money`, `margin`, `margin_float`, `loan_money`, `time_zone`, `begin_time`, `end_time`, `close_time`, `status`, `warningline`, `breakline`, `notice_warning`, `notice_close`, `live_state`, `live_balance`, `live_breakline`, `live_Broker`, `live_account_fk`, `multiple`, `borrow_duration`)\n\t\t\t\tVALUES (@sub_account, @member_fk, @borrow_plan_fk, @type, @market, @loan_type, @currency, @mem_money, @frozen_money, @margin, @margin_float, @loan_money, @time_zone, @begin_time, @end_time, @close_time, @status, @warningline, @breakline, @notice_warning, @notice_close, @live_state, @live_balance, @live_breakline, @live_Broker, @live_account_fk, @multiple, @borrow_duration); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeAccountDto model)
    {
      string sql = "UPDATE `trade_account` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`borrow_plan_fk` = @borrow_plan_fk,\n\t\t\t\t`type` = @type,\n\t\t\t\t`market` = @market,\n\t\t\t\t`loan_type` = @loan_type,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`mem_money` = @mem_money,\n\t\t\t\t`frozen_money` = @frozen_money,\n\t\t\t\t`margin` = @margin,\n\t\t\t\t`margin_float` = @margin_float,\n\t\t\t\t`loan_money` = @loan_money,\n\t\t\t\t`time_zone` = @time_zone,\n\t\t\t\t`begin_time` = @begin_time,\n\t\t\t\t`end_time` = @end_time,\n\t\t\t\t`close_time` = @close_time,\n\t\t\t\t`status` = @status,\n\t\t\t\t`warningline` = @warningline,\n\t\t\t\t`breakline` = @breakline,\n\t\t\t\t`notice_warning` = @notice_warning,\n\t\t\t\t`notice_close` = @notice_close,\n\t\t\t\t`live_state` = @live_state,\n\t\t\t\t`live_balance` = @live_balance,\n\t\t\t\t`live_breakline` = @live_breakline,\n\t\t\t\t`live_Broker` = @live_Broker,\n\t\t\t\t`live_account_fk` = @live_account_fk\n\t\t\t\t WHERE `sub_account` = @sub_account";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string sub_account)
    {
      string sql = "DELETE FROM `trade_account` WHERE `sub_account` = @sub_account";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static (Decimal totalProfit, DataCountBase<TradingAccountList> list) FindTradingAccountList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "\nSELECT \n    COUNT(*) AS count, SUM(t.balance - t.init_money) AS total_profit\nFROM `vw_trade_account` t\nLEFT JOIN borrow_plan ON borrow_plan.market=t.market AND borrow_plan.name=t.loan_type\nINNER JOIN member m ON m.pk=t.member_fk\n" + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(660, 4);
      interpolatedStringHandler.AppendLiteral("\nSELECT\n  t.market,\n  t.sub_account AS sub_account,\n  t.balance,\n  t.STATUS,\n  t.borrow_type AS loan_type,\n  t.warningline,\n  t.breakline,\n  t.position_value,\n  t.begin_time,\n  t.end_time,\n  t.member_fk,\n  t.account,\n  t.member_name,\n  (\n  100 + 100 * (( t.balance - t.init_money ) / t.margin )) AS profit_percent,\n  borrow_plan.warning_line AS warningline_percent,\n  t.balance - t.init_money AS total_profit,\n  m.is_test_account,\n  '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' AS lang\nFROM\n  `vw_trade_account` t\n  LEFT JOIN borrow_plan ON borrow_plan.pk = t.borrow_plan_fk\n  INNER JOIN member m ON m.pk = t.member_fk\n");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\nORDER BY ((t.balance - t.init_money) / t.margin), t.begin_time DESC\nLIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\nOFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          CountAndTotalProfit countAndTotalProfit = readConnection.QuerySingle<CountAndTotalProfit>(sql);
          IEnumerable<TradingAccountList> data = readConnection.Query<TradingAccountList>(stringAndClear);
          return (countAndTotalProfit.total_profit, new DataCountBase<TradingAccountList>(countAndTotalProfit.count, data));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[TradeAccountService][FindTradingAccountList]" + ex.Message);
        return (0M, new DataCountBase<TradingAccountList>());
      }
    }

    public static List<TradeAccountSearchList> FindTradeAccountSearch(string where = "")
    {
      string sql = "SELECT\na.sub_account AS sub_account, a.`status` AS status, a.`type` AS type,\nm.account AS member_name, m.nickname AS member_username, m.mobile AS member_mobile,\na.loan_type AS loan_type, a.market AS market, a.currency AS currency,\na.begin_time as begin_time, a.end_time AS end_time, a.loan_money AS loan_money,\na.margin AS margin, a.mem_money AS mem_money, a.frozen_money AS frozen_money,\na.warningline AS warningline , a.breakline AS breakline, SUM(p.total) AS total\nFROM `trade_account` AS a\nLEFT JOIN `member` AS m ON a.member_fk = m.pk\nLEFT JOIN `trade_position` AS p ON a.sub_account = p.sub_account " + where + " GROUP BY a.sub_account;";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeAccountSearchList>(sql).AsList<TradeAccountSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][FindTradeAccountSearch]" + ex.Message);
        return (List<TradeAccountSearchList>) null;
      }
    }

    public static int InAdvanceClose(string subAccount, int status, DateTime closeTime)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE trade_account SET status = @status, close_time=@close_time WHERE sub_account = @subAccount;", (object) new
          {
            subAccount = subAccount,
            status = status,
            close_time = closeTime
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][InAdvanceClose]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int BatchInAdvanceClose(string whereSql, int status, DateTime closeTime)
    {
      string sql = "UPDATE trade_account SET status = @status, close_time=@close_time " + whereSql;
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            status = status,
            close_time = closeTime
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][BatchInAdvanceClose]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateAccountRenewal(
      string subAccount,
      AccountStatusType status,
      DateTime endDate)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE trade_account SET status = @status ,end_time=@endDate,close_time=null\nWHERE sub_account=@sub_account;", (object) new
          {
            sub_account = subAccount,
            status = (int) status,
            endDate = endDate
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateAccountRenewal]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateExpandBorrow(
      string subAccount,
      Decimal effectMoney,
      Decimal multiple,
      Decimal warninglineMultiple,
      Decimal breaklineMultiple)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE trade_account SET mem_money = mem_money + @effectMoney + @finance, margin = margin + @effectMoney, margin_float = margin_float + @effectMoney, loan_money = loan_money + @finance, warningline = (loan_money + @finance) + ((margin + @effectMoney) * @warninglineMultiple), breakline = (loan_money + @finance) + ((margin + @effectMoney) * @breaklineMultiple) WHERE sub_account = @subAccount;", (object) new
          {
            subAccount = subAccount,
            effectMoney = effectMoney,
            finance = (effectMoney * multiple),
            warninglineMultiple = warninglineMultiple,
            breaklineMultiple = breaklineMultiple
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateExpandBorrow]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateMoney(string subAccount, Decimal money)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE trade_account SET mem_money = mem_money + @money\nWHERE sub_account = @sub_account;", (object) new
          {
            sub_account = subAccount,
            money = Convert.ToInt32(money)
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateMoney]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateTradeAccountVolume(
      bool verifyStatus,
      string subAccount,
      Decimal frozen)
    {
      string sql = !verifyStatus ? "UPDATE trade_account AS t SET t.mem_money = frozen_money = t.frozen_money - @frozen WHERE t.sub_account = @sub_account " : "UPDATE trade_account AS t SET t.mem_money = t.mem_money - @frozen, frozen_money = t.frozen_money - @frozen WHERE t.sub_account = @sub_account ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            sub_account = subAccount,
            frozen = frozen
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateTradeAccountVolume]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateAccountFrozenMoney(TradeOrderDto order)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = order.sub_account,
            free_volume = order.free_volume,
            price = order.price
          });
          return writeConntion.Execute("UPDATE trade_account\nSET frozen_money = frozen_money - @free_volume * @price\nWHERE sub_account=@sub_account;", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][UpdateAccountFrozenMoney]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static Decimal GetInitMoney(int member_fk)
    {
      string sql = "SELECT init_money FROM `vw_trade_account` WHERE `member_fk` = @member_fk AND status = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirst<Decimal>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][GetInitMoney]" + ex.Message);
        return 0M;
      }
    }

    public static Decimal GetTradeBalance(int member_fk)
    {
      string sql = "SELECT balance FROM `vw_trade_account` WHERE `member_fk` = @member_fk AND status = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirst<Decimal>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][GetInitMoney]" + ex.Message);
        return 0M;
      }
    }

    public static List<TradeAccountDto> GetActiveTradeAccountByMember(int member_fk)
    {
      string sql = "SELECT * FROM `trade_account` WHERE `member_fk` = @member_fk AND status = 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.Query<TradeAccountDto>(sql, (object) parameters).AsList<TradeAccountDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeAccountService][GetInitMoney]" + ex.Message);
        return (List<TradeAccountDto>) null;
      }
    }
  }
}
