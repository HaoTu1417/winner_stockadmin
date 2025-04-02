// Decompiled with JetBrains decompiler
// Type: DB.Services.MutilangCacheService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

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
  public class MutilangCacheService
  {
    public static MutilangCacheDto Find(string key, string lang)
    {
      string sql = "SELECT * FROM `mutilang_cache` WHERE `key` = @key AND `lang` = @lang";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key,
            lang = lang
          });
          return readConnection.QueryFirstOrDefault<MutilangCacheDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][Find]" + ex.Message);
        return (MutilangCacheDto) null;
      }
    }

    public static List<MutilangCacheDto> FindAll()
    {
      string sql = "SELECT * FROM `mutilang_cache`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MutilangCacheDto>(sql).AsList<MutilangCacheDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][FindAll]" + ex.Message);
        return (List<MutilangCacheDto>) null;
      }
    }

    public static int Insert(MutilangCacheDto model)
    {
      string sql = "INSERT INTO `mutilang_cache` (\n\t\t\t\t`key`, `lang`, `value`)\n\t\t\t\tVALUES (@key, @lang, @value); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MutilangCacheDto model)
    {
      string sql = "UPDATE `mutilang_cache` SET \n\t\t\t\t`value` = @value\n\t\t\t\t WHERE `key` = @key AND `lang` = @lang";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Update(MutilangCacheDto model)
    {
      string sql = "UPDATE `mutilang_cache` SET \n\t\t\t\t`value` = @value\n\t\t\t\t WHERE `key` = @key AND `lang` = @lang";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string key, string lang)
    {
      string sql = "DELETE FROM `mutilang_cache` WHERE `key` = @key AND `lang` = @lang";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key,
            lang = lang
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<MutilangCacheDto> GetMultiLangCacheList(string where)
    {
      string sql = "SELECT * FROM `mutilang_cache` " + where;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MutilangCacheDto>(sql).AsList<MutilangCacheDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][GetMultiLangCacheList]" + ex.Message);
        return (List<MutilangCacheDto>) null;
      }
    }

    public static string FindJson(string key, string lang)
    {
      string sql = "SELECT value FROM `mutilang_cache` WHERE `key` = @key AND `lang` = @lang";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key,
            lang = lang
          });
          return readConnection.QueryFirstOrDefault<string>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangCacheService][Find]" + ex.Message);
        return (string) null;
      }
    }
  }
}
