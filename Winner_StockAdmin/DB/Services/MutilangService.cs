// Decompiled with JetBrains decompiler
// Type: DB.Services.MutilangService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.MultiLang;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class MutilangService
  {
    public static MutilangDto Find(string key)
    {
      string sql = "SELECT * FROM `mutilang` WHERE `key` = @key";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key
          });
          return readConnection.QueryFirstOrDefault<MutilangDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][Find]" + ex.Message);
        return (MutilangDto) null;
      }
    }

    public static List<MutilangDto> FindAll()
    {
      string sql = "SELECT * FROM `mutilang`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MutilangDto>(sql).AsList<MutilangDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][FindAll]" + ex.Message);
        return (List<MutilangDto>) null;
      }
    }

    public static int Insert(MutilangDto model)
    {
      string sql = "INSERT INTO `mutilang` (\n\t\t\t\t`key`, `application`, `module`, `description`, `path`, `template`)\n\t\t\t\tVALUES (@key, @application, @module, @description, @path, @template); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MutilangDto model)
    {
      string sql = "UPDATE `mutilang` SET \n\t\t\t\t`application` = @application,\n\t\t\t\t`module` = @module,\n\t\t\t\t`description` = @description,\n\t\t\t\t`path` = @path,\n\t\t\t\t`template` = @template\n\t\t\t\t WHERE `key` = @key";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string key)
    {
      string sql = "DELETE FROM `mutilang` WHERE `key` = @key";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    internal static List<MultilangList> FindMutilangList(string whereSql = "")
    {
      string sql = "SELECT `key`, description, application FROM `mutilang` " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MultilangList>(sql).AsList<MultilangList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][FindMutilangList]" + ex.Message);
        return (List<MultilangList>) null;
      }
    }

    internal static string FindJson(string key)
    {
      string sql = "SELECT template FROM `mutilang` WHERE `key` = @key";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            key = key
          });
          return readConnection.QueryFirstOrDefault<string>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangService][FindJson]" + ex.Message);
        return (string) null;
      }
    }
  }
}
