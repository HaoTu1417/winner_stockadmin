// Decompiled with JetBrains decompiler
// Type: DB.Services.StockHolidayService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockHoliday;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class StockHolidayService
  {
    public static StockHolidayDto Find(int pk)
    {
      string sql = "SELECT * FROM `stock_holiday` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<StockHolidayDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][Find]" + ex.Message);
        return (StockHolidayDto) null;
      }
    }

    public static StockHolidayDto Find(string market, DateTime date)
    {
      string sql = "SELECT * FROM `stock_holiday` WHERE `market` = @market and `date` = @date";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            market = market.ToUpper(),
            date = date
          });
          return readConnection.QueryFirstOrDefault<StockHolidayDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][Find]" + ex.Message);
        return (StockHolidayDto) null;
      }
    }

    public static List<StockHolidayDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_holiday`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockHolidayDto>(sql).AsList<StockHolidayDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][FindAll]" + ex.Message);
        return (List<StockHolidayDto>) null;
      }
    }

    public static int FindPkAfterInsert(StockHolidayDto source)
    {
      string sql = "INSERT INTO `stock_holiday` (\n\t\t\t\t`market`, `name`, `year`, `date`, `is_allday`, `open`, `close`)\n\t\t\t\tVALUES (@market, @name, @year, @date, @is_allday, @open, @close);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockHolidayDto model)
    {
      string sql = "UPDATE `stock_holiday` SET \n\t\t\t\t`market` = @market,\n\t\t\t\t`name` = @name,\n\t\t\t\t`year` = @year,\n\t\t\t\t`date` = @date,\n\t\t\t\t`is_allday` = @is_allday,\n\t\t\t\t`open` = @open,\n\t\t\t\t`close` = @close\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `stock_holiday` WHERE `pk` = @pk";
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
        LogLib.Log("[StockHolidayService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockHolidayList> FindStockHolidayList(string whereSql = "")
    {
      string sql = "SELECT stock_holiday.pk, stock_holiday.market, stock_holiday.name, stock_holiday.year, stock_holiday.date, \n                stock_holiday.is_allday, stock_holiday.open, stock_holiday.close \n                FROM `stock_holiday`" + whereSql + "\n                order by year DESC, market, date";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockHolidayList>(sql).AsList<StockHolidayList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockHolidayService][FindStockHolidayList]" + ex.Message);
        return (List<StockHolidayList>) null;
      }
    }
  }
}
