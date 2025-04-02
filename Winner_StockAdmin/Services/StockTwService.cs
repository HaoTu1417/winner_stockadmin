// Decompiled with JetBrains decompiler
// Type: DB.Services.StockTwService
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
  public class StockTwService
  {
    public static StockTwDto Find(string stock_code)
    {
      string sql = "SELECT * FROM `stock_tw` WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<StockTwDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockTwService][Find]" + ex.Message);
        return (StockTwDto) null;
      }
    }

    public static List<StockTwDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_tw`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockTwDto>(sql).AsList<StockTwDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockTwService][FindAll]" + ex.Message);
        return (List<StockTwDto>) null;
      }
    }

    public static int Insert(StockTwDto model)
    {
      string sql = "INSERT INTO `stock_tw` (\n                `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`)\n                VALUES (@stock_code, @stock_name, @market, @enable, @disable_alwayse, @close_reason, @opentrade, @update_datetime, @yclose, @limitbuy, @limitsell, @final_price, @volume, @full_info); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockTwService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockTwDto model)
    {
      string sql = "UPDATE `stock_tw` SET \n                `stock_name` = @stock_name,\n                `market` = @market,\n                `enable` = @enable,\n                `disable_alwayse` = @disable_alwayse,\n                `close_reason` = @close_reason,\n                `opentrade` = @opentrade,\n                `update_datetime` = @update_datetime,\n                `yclose` = @yclose,\n                `limitbuy` = @limitbuy,\n                `limitsell` = @limitsell,\n                `final_price` = @final_price,\n                `volume` = @volume,\n                `full_info` = @full_info\n                 WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockTwService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string stock_code)
    {
      string sql = "DELETE FROM `stock_tw` WHERE `stock_code` = @stock_code";
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
        LogLib.Log("[StockTwService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
