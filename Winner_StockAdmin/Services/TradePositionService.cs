// Decompiled with JetBrains decompiler
// Type: DB.Services.TradePositionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.TradePosition;
using stockadmin.ViewModels.UserTradePosition;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class TradePositionService
  {
    public static TradePositionDto Find(string sub_account)
    {
      string sql = "SELECT * FROM `trade_position` WHERE `sub_account` = " + sub_account;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<TradePositionDto>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][Find]" + ex.Message);
        return (TradePositionDto) null;
      }
    }

    public static List<TradePositionDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_position`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradePositionDto>(sql).AsList<TradePositionDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][FindAll]" + ex.Message);
        return (List<TradePositionDto>) null;
      }
    }

    public static int Insert(TradePositionDto model)
    {
      string sql = "INSERT INTO `trade_position` (\n\t\t\t\t`sub_account`, `stock_code`, `stock_name`, `stock_type`, `market`, `holding_volume`, `stop_lose_pos`, `new_pos`, `close_pos`, `lastprice`, `total`, `cost_purchase`, `cost_volume`, `cost_price`, `live_volume`, `live_cost`)\n\t\t\t\tVALUES (@sub_account, @stock_code, @stock_name, @stock_type, @market, @holding_volume, @stop_lose_pos, @new_pos, @close_pos, @lastprice, @total, @cost_purchase, @cost_volume, @cost_price, @live_volume, @live_cost); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradePositionDto model)
    {
      string sql = "UPDATE `trade_position` SET \n\t\t\t\t`stock_name` = @stock_name,\n\t\t\t\t`stock_type` = @stock_type,\n\t\t\t\t`market` = @market,\n\t\t\t\t`holding_volume` = @holding_volume,\n\t\t\t\t`stop_lose_pos` = @stop_lose_pos,\n\t\t\t\t`new_pos` = @new_pos,\n\t\t\t\t`close_pos` = @close_pos,\n\t\t\t\t`lastprice` = @lastprice,\n\t\t\t\t`total` = @total,\n\t\t\t\t`cost_purchase` = @cost_purchase,\n\t\t\t\t`cost_volume` = @cost_volume,\n\t\t\t\t`cost_price` = @cost_price,\n\t\t\t\t`live_volume` = @live_volume,\n\t\t\t\t`live_cost` = @live_cost\n\t\t\t\t WHERE `sub_account` = @sub_account AND `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string sub_account, string stock_code)
    {
      string sql = "DELETE FROM `trade_position` WHERE `sub_account` = @sub_account AND `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account,
            stock_code = stock_code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static TradePositionDto FindByCode(string sub_account, string stock_code)
    {
      string sql = "SELECT * FROM `trade_position` WHERE `sub_account` = @sub_account AND `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = sub_account,
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<TradePositionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][Find]" + ex.Message);
        return (TradePositionDto) null;
      }
    }

    public static List<UserTradePositionList> FindUserTradePositionList(string whereSql = "")
    {
      string sql = "SELECT trade_position.sub_account, trade_position.stock_code, trade_position.stock_name, trade_position.stock_type, \n                    trade_position.holding_volume, trade_position.lastprice, trade_position.cost_price, trade_position.new_pos, \n                    trade_position.close_pos, trade_position.stop_lose_pos, trade_position.total,\n                    (stock_type*(total-cost_purchase)) as profit\n                    FROM `trade_position`\n                    INNER JOIN vw_trade_account on vw_trade_account.sub_account = trade_position.sub_account\n                    " + whereSql + " order by trade_position.stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<UserTradePositionList>(sql).AsList<UserTradePositionList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][FindUserTradePositionList]" + ex.Message);
        return (List<UserTradePositionList>) null;
      }
    }

    public static DataCountBase<TradePositionList> FindTradePositionList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\nSELECT \n    COUNT(*) AS count\nFROM `trade_position` t\nINNER JOIN vw_trade_account vwt ON vwt.sub_account = t.sub_account\nLEFT JOIN member m ON m.pk=vwt.member_fk\n" + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(676, 3);
      interpolatedStringHandler.AppendLiteral("\nSELECT \n    t.sub_account, t.market, t.stock_code, t.stock_name, \n    t.stock_type, t.holding_volume, t.lastprice, t.cost_price, \n    t.new_pos, t.close_pos, t.stop_lose_pos, t.total, vwt.loan_type, \n    vwt.end_time, vwt.member_fk, vwt.account, vwt.member_name,\n    (stock_type*(total-cost_purchase)) as profit, (SELECT MAX(create_datetime) from trade_deal WHERE trade_deal.sub_account = t.sub_account AND trade_deal.stock_code = t.stock_code) AS last_buy_time,\n    m.is_test_account\nFROM `trade_position` t\nINNER JOIN vw_trade_account vwt ON vwt.sub_account = t.sub_account\nLEFT JOIN member m ON m.pk=vwt.member_fk\n");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\nORDER BY last_buy_time DESC, t.stock_code\nLIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\nOFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<TradePositionList>(readConnection.QuerySingle<int>(sql), (IEnumerable<TradePositionList>) readConnection.Query<TradePositionList>(stringAndClear).AsList<TradePositionList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[TradePositionService][FindTradePositionList]" + ex.Message);
        return new DataCountBase<TradePositionList>();
      }
    }

    public static int UpdateSellVolume(TradeOrderDto order)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_account = order.sub_account,
            free_volume = order.free_volume,
            stock_code = order.stock_code
          });
          return writeConntion.Execute("UPDATE trade_position\nSET sell_volume = sell_volume - @free_volume\nWHERE sub_account = @sub_account AND stock_code = @stock_code;", (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][UpdateSellVolume]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int GetPositionBySubAccount(string sub_account)
    {
      string sql = "SELECT COUNT(*) FROM trade_position WHERE sub_account = @sub_account;";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql, (object) new
          {
            sub_account = sub_account
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradePositionService][GetPositionBySubAccount]" + ex.Message);
        return 0;
      }
    }
  }
}
