// Decompiled with JetBrains decompiler
// Type: DB.Services.SysMarketService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.SysMarket;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class SysMarketService
  {
    public static SysMarketDto Find(string code)
    {
      string sql = "SELECT * FROM `sys_market` WHERE `code` = @code";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            code = code
          });
          return readConnection.QueryFirstOrDefault<SysMarketDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][Find]" + ex.Message);
        return (SysMarketDto) null;
      }
    }

    public static List<SysMarketDto> FindAll()
    {
      string sql = "SELECT * FROM `sys_market`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<SysMarketDto>(sql).AsList<SysMarketDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][FindAll]" + ex.Message);
        return (List<SysMarketDto>) null;
      }
    }

    public static int Insert(SysMarketDto model)
    {
      string sql = "INSERT INTO `sys_market` (\n\t\t\t\t`code`, `exchange`, `currency`, `enable`, `rank_enable`, `name`, `sort`, `buy_fee`, `sell_fee`, `min_buy_fee`, `min_sell_fee`, `default_stock_code`)\n\t\t\t\tVALUES (@code, @exchange, @currency, @enable, @rank_enable, @name, @sort, @buy_fee, @sell_fee, @min_buy_fee, @min_sell_fee, @default_stock_code); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(SysMarketDto model)
    {
      string sql = "UPDATE `sys_market` SET \n\t\t\t\t`currency` = @currency,\n\t\t\t\t`enable` = @enable,\n                `exchange` = @exchange,\n\t\t\t\t`rank_enable` = @rank_enable,\n\t\t\t\t`name` = @name,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`buy_fee` = @buy_fee,\n\t\t\t\t`sell_fee` = @sell_fee,\n\t\t\t\t`min_buy_fee` = @min_buy_fee,\n\t\t\t\t`min_sell_fee` = @min_sell_fee,\n                `default_stock_code` = @default_stock_code\n\t\t\t\t WHERE `code` = @code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateSysByMarket(
      string code,
      Decimal min_stock_price,
      int min_stock_month_volume,
      bool capital_filter_enable,
      int capital_filter_number)
    {
      string sql = "UPDATE `sys_market` SET \n\t\t\t\t`min_stock_price` = @min_stock_price,\n                `min_stock_month_volume` = @min_stock_month_volume,\n                `capital_filter_enable` = @capital_filter_enable,\n                `capital_filter_number` = @capital_filter_number\n\t\t\t\t WHERE `code` = @code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            min_stock_price = min_stock_price,
            min_stock_month_volume = min_stock_month_volume,
            capital_filter_enable = capital_filter_enable,
            capital_filter_number = capital_filter_number,
            code = code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][UpdateSysByMarket]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string code)
    {
      string sql = "DELETE FROM `sys_market` WHERE `code` = @code";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            code = code
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<SysMarketList> FindSysMarketList()
    {
      string sql = "SELECT sys_market.code, sys_market.exchange, sys_market.currency, sys_market.enable, sys_market.rank_enable, sys_market.name, sys_market.sort, sys_market.buy_fee, sys_market.sell_fee, sys_market.min_buy_fee, sys_market.min_sell_fee FROM `sys_market`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<SysMarketList>(sql).AsList<SysMarketList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][FindSysMarketList]" + ex.Message);
        return (List<SysMarketList>) null;
      }
    }

    public static SysMarketDto FindByCurrency(string currency)
    {
      string sql = "SELECT * FROM `sys_market` WHERE `currency` = @currency";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            currency = currency.ToUpper()
          });
          return readConnection.QueryFirstOrDefault<SysMarketDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][Find]" + ex.Message);
        return (SysMarketDto) null;
      }
    }

    public static List<SysMarketDto> FindDropDown(string lang)
    {
      string sql = "SELECT `code`, `currency`, g.`value` AS `name` FROM sys_market\n                INNER JOIN mutilang_table g ON g.`key` = sys_market.`code`\n                WHERE g.`dbtable` = \"sys_market\" AND g.`field` = \"name\" \n                AND g.`lang` = @lang ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<SysMarketDto>(sql, (object) new
          {
            lang = lang.ToUpper()
          }).AsList<SysMarketDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysMarketService][FindAll]" + ex.Message);
        return (List<SysMarketDto>) null;
      }
    }
  }
}
