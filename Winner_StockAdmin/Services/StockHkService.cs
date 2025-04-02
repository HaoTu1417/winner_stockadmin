// Decompiled with JetBrains decompiler
// Type: DB.Services.StockHkService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class StockHkService
  {
    public static StockHkDto Find(string stock_code)
    {
      string sql = "SELECT * FROM `stock_hk` WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<StockHkDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHkService][Find]" + ex.Message);
        return (StockHkDto) null;
      }
    }

    public static List<StockHkDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_hk`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockHkDto>(sql).AsList<StockHkDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHkService][FindAll]" + ex.Message);
        return (List<StockHkDto>) null;
      }
    }

    public static int Insert(StockHkDto model)
    {
      string sql = "INSERT INTO `stock_hk` (\n                `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`)\n                VALUES (@stock_code, @stock_name, @market, @enable, @disable_alwayse, @close_reason, @opentrade, @update_datetime, @yclose, @limitbuy, @limitsell, @final_price, @volume, @full_info); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHkService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockHkDto model)
    {
      string sql = "UPDATE `stock_hk` SET \n                `stock_name` = @stock_name,\n                `market` = @market,\n                `enable` = @enable,\n                `disable_alwayse` = @disable_alwayse,\n                `close_reason` = @close_reason,\n                `opentrade` = @opentrade,\n                `update_datetime` = @update_datetime,\n                `yclose` = @yclose,\n                `limitbuy` = @limitbuy,\n                `limitsell` = @limitsell,\n                `final_price` = @final_price,\n                `volume` = @volume,\n                `full_info` = @full_info\n                 WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHkService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string stock_code)
    {
      string sql = "DELETE FROM `stock_hk` WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHkService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
