// Decompiled with JetBrains decompiler
// Type: DB.Services.StockUsService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockUs;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class StockUsService
  {
    public static StockUsDto Find(string stock_code)
    {
      string sql = "SELECT * FROM `stock_us` WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<StockUsDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][Find]" + ex.Message);
        return (StockUsDto) null;
      }
    }

    public static List<StockUsDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_us`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockUsDto>(sql).AsList<StockUsDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][FindAll]" + ex.Message);
        return (List<StockUsDto>) null;
      }
    }

    public static int Insert(StockUsDto model)
    {
      string sql = "INSERT INTO `stock_us` (\n                `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `program_enable`, `program_msg`, `main_switch`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`)\n                VALUES (@stock_code, @stock_name, @market, @enable, @disable_alwayse, @program_enable, @program_msg, @main_switch, @close_reason, @opentrade, @update_datetime, @yclose, @limitbuy, @limitsell, @final_price, @volume, @full_info); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockUsDto> FindEnableList()
    {
      using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
      {
        string sql = "\nSELECT `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `program_enable`, `main_switch`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`\nFROM `stock_us`\nWHERE `main_switch` = 1\nORDER BY `stock_code`\n";
        return readConnection.Query<StockUsDto>(sql).AsList<StockUsDto>();
      }
    }

    public static int UpdateFull(StockUsDto model)
    {
      model.main_switch = model.enable && !model.disable_alwayse && model.program_enable;
      string sql = "UPDATE `stock_us` SET \n                `stock_name` = @stock_name,\n                `market` = @market,\n                `enable` = @enable,\n                `disable_alwayse` = @disable_alwayse,\n                `program_enable` = @program_enable,\n                `program_msg` = @program_msg,\n                `main_switch` = @main_switch,\n                `close_reason` = @close_reason,\n                `opentrade` = @opentrade,\n                `update_datetime` = @update_datetime,\n                `yclose` = @yclose,\n                `limitbuy` = @limitbuy,\n                `limitsell` = @limitsell,\n                `final_price` = @final_price,\n                `volume` = @volume,\n                `full_info` = @full_info\n                 WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string stock_code)
    {
      string sql = "DELETE FROM `stock_us` WHERE `stock_code` = @stock_code";
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
        LogLib.Log("[StockUsService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockUsList> FindStockUsList(string whereSql = "")
    {
      string sql = "SELECT stock_us.stock_code, stock_us.stock_name, stock_us.enable, stock_us.disable_alwayse, stock_us.program_enable, stock_us.main_switch, stock_us.program_msg, stock_us.opentrade, stock_us.update_datetime, stock_us.yclose, stock_us.final_price, stock_us.volume, stock_us.limitbuy, stock_us.limitsell FROM `stock_us`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockUsList>(sql).AsList<StockUsList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][FindStockUsList]" + ex.Message);
        return (List<StockUsList>) null;
      }
    }

    public static int UpdateStockUsSetting(string stock_code, bool enabled, string info)
    {
      string sql = "UPDATE stock_us SET program_enable = @enabled, program_msg = @info WHERE stock_code = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            enabled = enabled,
            info = info,
            stock_code = stock_code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][UpdateStockUsSetting]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateTradingSwitch(bool main_switch, string stock_code)
    {
      string sql = "UPDATE stock_us SET main_switch = @main_switch,  update_datetime = UTC_TIMESTAMP WHERE stock_code = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            main_switch = main_switch,
            stock_code = stock_code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockUsService][UpdateTradingSwitch]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
