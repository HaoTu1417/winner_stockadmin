// Decompiled with JetBrains decompiler
// Type: DB.Services.HistoryDailyUsService
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
  public class HistoryDailyUsService
  {
    public static HistoryDailyUsDto Find(int pk)
    {
      string sql = "SELECT * FROM `history_daily_us` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<HistoryDailyUsDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[HistoryDailyUsService][Find]" + ex.Message);
        return (HistoryDailyUsDto) null;
      }
    }

    public static List<HistoryDailyUsDto> FindAll()
    {
      string sql = "SELECT * FROM `history_daily_us`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<HistoryDailyUsDto>(sql).AsList<HistoryDailyUsDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[HistoryDailyUsService][FindAll]" + ex.Message);
        return (List<HistoryDailyUsDto>) null;
      }
    }

    public static int FindPkAfterInsert(HistoryDailyUsDto source)
    {
      string sql = "INSERT INTO `history_daily_us` (\n                `date`, `stock_code`, `open`, `high`, `low`, `close`, `volume`)\n                VALUES (@date, @stock_code, @open, @high, @low, @close, @volume);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[HistoryDailyUsService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(HistoryDailyUsDto model)
    {
      string sql = "UPDATE `history_daily_us` SET \n                `date` = @date,\n                `stock_code` = @stock_code,\n                `open` = @open,\n                `high` = @high,\n                `low` = @low,\n                `close` = @close,\n                `volume` = @volume\n                 WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[HistoryDailyUsService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `history_daily_us` WHERE `pk` = @pk";
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
        LogLib.Log("[HistoryDailyUsService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static HistoryDailyUsDto GetLastDaily(string stock_code)
    {
      string sql = "SELECT * FROM `history_daily_us` WHERE `stock_code` = @stock_code ORDER BY date DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<HistoryDailyUsDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[GetLastDaily][Find]" + ex.Message);
        return (HistoryDailyUsDto) null;
      }
    }

    public static int GetMonthVolume(string stock_code)
    {
      string sql = "SELECT SUM(volume) FROM `history_daily_us` WHERE `stock_code` = @stock_code  ORDER BY date DESC LIMIT 21";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            stock_code = stock_code
          });
          return readConnection.QueryFirstOrDefault<int>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[HistoryDailyUsService][Find]" + ex.Message);
        return 0;
      }
    }
  }
}
