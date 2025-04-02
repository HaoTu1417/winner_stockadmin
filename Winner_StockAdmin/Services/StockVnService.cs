// Decompiled with JetBrains decompiler
// Type: DB.Services.StockVnService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockVn;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class StockVnService
  {
    public static StockVnDto Find(string stock_code)
    {
      string sql = "SELECT * FROM `stock_vn` WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<StockVnDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockVnService][Find]" + ex.Message);
        return (StockVnDto) null;
      }
    }

    public static List<StockVnDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_vn`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockVnDto>(sql).AsList<StockVnDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockVnService][FindAll]" + ex.Message);
        return (List<StockVnDto>) null;
      }
    }

    public static int Insert(StockVnDto model)
    {
      string sql = "INSERT INTO `stock_vn` (\n                `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `program_enable`, `program_msg`, `main_switch`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`)\n                VALUES (@stock_code, @stock_name, @market, @enable, @disable_alwayse, @program_enable, @program_msg, @main_switch, @close_reason, @opentrade, @update_datetime, @yclose, @limitbuy, @limitsell, @final_price, @volume, @full_info); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockVnService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockUsDto> FindEnableList()
    {
      using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
      {
        string sql = "\nSELECT `stock_code`, `stock_name`, `market`, `enable`, `disable_alwayse`, `program_enable`, `main_switch`, `close_reason`, `opentrade`, `update_datetime`, `yclose`, `limitbuy`, `limitsell`, `final_price`, `volume`, `full_info`\nFROM `stock_vn`\nWHERE `main_switch` = 1\nORDER BY `stock_code`\n";
        return readConnection.Query<StockUsDto>(sql).AsList<StockUsDto>();
      }
    }

    public static int UpdateFull(StockVnDto model)
    {
      model.main_switch = model.enable && !model.disable_alwayse && model.program_enable;
      string sql = "UPDATE `stock_vn` SET \n                `stock_name` = @stock_name,\n                `market` = @market,\n                `enable` = @enable,\n                `disable_alwayse` = @disable_alwayse,\n                `program_enable` = @program_enable,\n                `program_msg` = @program_msg,\n                `main_switch` = @main_switch,\n                `close_reason` = @close_reason,\n                `opentrade` = @opentrade,\n                `update_datetime` = @update_datetime,\n                `yclose` = @yclose,\n                `limitbuy` = @limitbuy,\n                `limitsell` = @limitsell,\n                `final_price` = @final_price,\n                `volume` = @volume,\n                `full_info` = @full_info\n                 WHERE `stock_code` = @stock_code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockVnService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string stock_code)
    {
      string sql = "DELETE FROM `stock_vn` WHERE `stock_code` = @stock_code";
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
        LogLib.Log("[StockVnService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockVnList> FindStockVnList(string whereSql = "")
    {
      string sql = "SELECT stock_vn.stock_code, stock_vn.stock_name, stock_vn.enable, stock_vn.disable_alwayse, stock_vn.program_enable, stock_vn.main_switch, stock_vn.program_msg, stock_vn.opentrade, stock_vn.update_datetime, stock_vn.yclose, stock_vn.final_price, stock_vn.volume, stock_vn.limitbuy, stock_vn.limitsell FROM `stock_vn`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockVnList>(sql).AsList<StockVnList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockVnService][FindStockVnList]" + ex.Message);
        return (List<StockVnList>) null;
      }
    }

    public static int UpdateStockVnSetting(string stock_code, bool enabled, string info)
    {
      string sql = "UPDATE stock_vn SET program_enable = @enabled, program_msg = @info WHERE stock_code = @stock_code";
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
        LogLib.Log("[StockVnService][UpdateStockUsSetting]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateTradingSwitch(bool main_switch, string stock_code)
    {
      string sql = "UPDATE stock_vn SET main_switch = @main_switch,  update_datetime = UTC_TIMESTAMP WHERE stock_code = @stock_code";
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
        LogLib.Log("[StockVnService][UpdateTradingSwitch]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
