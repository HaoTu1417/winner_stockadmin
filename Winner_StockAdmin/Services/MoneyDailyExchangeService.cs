// Decompiled with JetBrains decompiler
// Type: DB.Services.MoneyDailyExchangeService
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
  public class MoneyDailyExchangeService
  {
    public static MoneyDailyExchangeDto Find(int pk)
    {
      string sql = "SELECT * FROM `money_daily_exchange` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MoneyDailyExchangeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MoneyDailyExchangeService][Find]" + ex.Message);
        return (MoneyDailyExchangeDto) null;
      }
    }

    public static List<MoneyDailyExchangeDto> FindAll()
    {
      string sql = "SELECT * FROM `money_daily_exchange`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MoneyDailyExchangeDto>(sql).AsList<MoneyDailyExchangeDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MoneyDailyExchangeService][FindAll]" + ex.Message);
        return (List<MoneyDailyExchangeDto>) null;
      }
    }

    public static int FindPkAfterInsert(MoneyDailyExchangeDto source)
    {
      string sql = "INSERT INTO `money_daily_exchange` (\n\t\t\t\t`date`, `currency_symbol`, `base_symbol`, `inward_rate`, `outward_rate`, `create_time`)\n\t\t\t\tVALUES (@date, @currency_symbol, @base_symbol, @inward_rate, @outward_rate, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MoneyDailyExchangeService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MoneyDailyExchangeDto model)
    {
      string sql = "UPDATE `money_daily_exchange` SET \n\t\t\t\t`date` = @date,\n\t\t\t\t`currency_symbol` = @currency_symbol,\n\t\t\t\t`base_symbol` = @base_symbol,\n\t\t\t\t`inward_rate` = @inward_rate,\n\t\t\t\t`outward_rate` = @outward_rate,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MoneyDailyExchangeService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `money_daily_exchange` WHERE `pk` = @pk";
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
        LogLib.Log("[MoneyDailyExchangeService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
