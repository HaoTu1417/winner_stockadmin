// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeMoneyCheckService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.Demo;
using stockadmin.ViewModels.HisTradeMoneyCheck;
using stockadmin.ViewModels.TradeMoney;
using stockadmin.ViewModels.TradeMoneyCheck;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class TradeMoneyCheckService
  {
    public static TradeMoneyCheckDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_money_check` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeMoneyCheckDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][Find]" + ex.Message);
        return (TradeMoneyCheckDto) null;
      }
    }

    public static List<TradeMoneyCheckDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_money_check`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneyCheckDto>(sql).AsList<TradeMoneyCheckDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindAll]" + ex.Message);
        return (List<TradeMoneyCheckDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeMoneyCheckDto source)
    {
      string sql = "INSERT INTO `trade_money_check` (\n                `sub_account`, `sn`, `type`, `state`, `frozen`, `exchange`, `currency`, `amount`, `request_time`, `acccept_by`, `accept_time`)\n                VALUES (@sub_account, @sn, @type, @state, @frozen, @exchange, @currency, @amount, @request_time, @acccept_by, @accept_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static VwTradeAccountDto GetVwTradeAccountBySubAccount(string sub_account)
    {
      string sql = "SELECT * FROM `vw_trade_account` WHERE sub_account = @sub_account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account
          });
          return readConnection.QueryFirstOrDefault<VwTradeAccountDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][GetVwTradeAccountBySubAccount]" + ex.Message);
        return (VwTradeAccountDto) null;
      }
    }

    public static int UpdateFull(TradeMoneyCheckDto model)
    {
      string sql = "UPDATE `trade_money_check` SET \n                `sub_account` = @sub_account,\n                `sn` = @sn,\n                `type` = @type,\n                `state` = @state,\n                `frozen` = @frozen,\n                `exchange` = @exchange,\n                `currency` = @currency,\n                `amount` = @amount,\n                `request_time` = @request_time,\n                `acccept_by` = @acccept_by,\n                `accept_time` = @accept_time\n                 WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_money_check` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<HisTradeMoneyCheckList> FindHisTradeMoneyCheckList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\nSELECT \n    COUNT(*) AS count\nFROM `trade_money_check` t\nINNER JOIN vw_trade_account vwt ON vwt.sub_account = t.sub_account\nLEFT JOIN member m ON m.pk=vwt.member_fk\n" + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(358, 3);
      interpolatedStringHandler.AppendLiteral("\nSELECT \n    t.request_time, t.accept_time, vwt.account,\n    vwt.member_name, t.sub_account, t.currency, t.frozen,\n    vwt.init_money, vwt.loan_type, t.pk,\n    m.is_test_account\nFROM `trade_money_check` t\nINNER JOIN vw_trade_account vwt ON vwt.sub_account = t.sub_account\nLEFT JOIN member m ON m.pk=vwt.member_fk\n");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\nORDER BY t.request_time DESC\nLIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\nOFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<HisTradeMoneyCheckList>(readConnection.QuerySingle<int>(sql), (IEnumerable<HisTradeMoneyCheckList>) readConnection.Query<HisTradeMoneyCheckList>(stringAndClear).AsList<HisTradeMoneyCheckList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindHisTradeMoneyCheckList]" + ex.Message);
        return new DataCountBase<HisTradeMoneyCheckList>();
      }
    }

    public static HisTradeMoneyCheckReview FindHisTradeMoneyCheckReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(541, 1);
      interpolatedStringHandler.AppendLiteral("SELECT trade_money_check.request_time, trade_money_check.accept_time, vw_trade_account.account,\n                vw_trade_account.member_name, trade_money_check.sn, trade_money_check.sub_account, trade_money_check.currency,\n                trade_money_check.frozen, vw_trade_account.init_money, vw_trade_account.balance, vw_trade_account.loan_type\n                FROM `trade_money_check`\n                INNER JOIN vw_trade_account ON vw_trade_account.sub_account = trade_money_check.sub_account\n                WHERE trade_money_check.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<HisTradeMoneyCheckReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindHisTradeMoneyCheckReview]" + ex.Message);
        return (HisTradeMoneyCheckReview) null;
      }
    }

    public static List<TradeMoneyCheckList> FindTradeMoneyCheckList(string whereSql = "")
    {
      string sql = "SELECT trade_money_check.pk, vw_trade_account.account, vw_trade_account.member_name, trade_money_check.sn,\n                trade_money_check.sub_account, trade_money_check.currency, trade_money_check.frozen, vw_trade_account.balance,\n                vw_trade_account.loan_type\n                FROM `trade_money_check`\n                INNER JOIN vw_trade_account ON vw_trade_account.sub_account = trade_money_check.sub_account\n                " + whereSql + "\n                ORDER BY trade_money_check.request_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneyCheckList>(sql).AsList<TradeMoneyCheckList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindTradeMoneyCheckList]" + ex.Message);
        return (List<TradeMoneyCheckList>) null;
      }
    }

    public static TradeMoneyCheckReview FindTradeMoneyCheckReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(457, 1);
      interpolatedStringHandler.AppendLiteral("SELECT trade_money_check.pk, vw_trade_account.account, vw_trade_account.member_name, trade_money_check.sn, trade_money_check.sub_account, \n                trade_money_check.currency, trade_money_check.frozen, vw_trade_account.balance, vw_trade_account.loan_type \n                FROM `trade_money_check`\n                INNER JOIN vw_trade_account ON vw_trade_account.sub_account = trade_money_check.sub_account\n                WHERE trade_money_check.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<TradeMoneyCheckReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindTradeMoneyCheckReview]" + ex.Message);
        return (TradeMoneyCheckReview) null;
      }
    }

    public static List<DemoSearchList> FindDemoSearch(string where = "")
    {
      string sql = "SELECT pk, sn, sub_account, request_time FROM `trade_money_check` " + where;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<DemoSearchList>(sql).AsList<DemoSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][FindAll]" + ex.Message);
        return (List<DemoSearchList>) null;
      }
    }

    public static List<TradeMoneySearchList> GetTradeMoneyCheckApply(string where)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(521, 1);
      interpolatedStringHandler.AppendLiteral("SELECT t.pk AS pk, m.pk AS member_fk, m.real_name AS member_real_name, t.sub_account AS sub_account, ");
      interpolatedStringHandler.AppendLiteral("t.currency AS currency, t.frozen AS frozen, v.balance AS balance, v.warningline AS warningline, ");
      interpolatedStringHandler.AppendLiteral("v.breakline AS breakline, t.exchange AS exchange,t.amount AS amount, t.request_time AS request_time, ");
      interpolatedStringHandler.AppendLiteral("t.accept_time AS accept_time, t.acccept_by AS acccept_by, t.state AS state ");
      interpolatedStringHandler.AppendLiteral("FROM trade_money_check AS t ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN member AS m ON m.sub_account = t.sub_account ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN vw_trade_account AS v ON v.sub_account = t.sub_account ");
      interpolatedStringHandler.AppendFormatted(where);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeMoneySearchList>(stringAndClear).AsList<TradeMoneySearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][GetTradeMoneyCheckApply]" + ex.Message);
        return (List<TradeMoneySearchList>) null;
      }
    }

    public static int UpdateWithdraw(int pk, VerifyStatusType status)
    {
      string sql = "UPDATE trade_money_check SET state = @state, accept_time = @accept_time WHERE pk=@pk;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = pk,
            state = (int) status,
            accept_time = DateTime.Now
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeMoneyCheckService][UpdateWithdraw]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
