// Decompiled with JetBrains decompiler
// Type: DB.Services.MutilangSubjectService
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
  public class MutilangSubjectService
  {
    public static MutilangSubjectDto Find(string lang)
    {
      string sql = "SELECT * FROM `mutilang_subject` WHERE `lang` = @lang";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            lang = lang
          });
          return readConnection.QueryFirstOrDefault<MutilangSubjectDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][Find]" + ex.Message);
        return (MutilangSubjectDto) null;
      }
    }

    public static MutilangSubjectDto FindAdminDefault()
    {
      string sql = "SELECT * FROM `mutilang_subject` WHERE `admin_default` = 1";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<MutilangSubjectDto>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][FindAdminDefault]" + ex.Message);
        return (MutilangSubjectDto) null;
      }
    }

    public static List<MutilangSubjectDto> FindAll()
    {
      string sql = "SELECT * FROM `mutilang_subject`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MutilangSubjectDto>(sql).AsList<MutilangSubjectDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][FindAll]" + ex.Message);
        return (List<MutilangSubjectDto>) null;
      }
    }

    public static int Insert(MutilangSubjectDto model)
    {
      string sql = "INSERT INTO `mutilang_subject` (\n\t\t\t\t`lang`, `title`, `enable`, `icon`, `admin_default`, `app_default`)\n\t\t\t\tVALUES (@lang, @title, @enable, @icon, @admin_default, @app_default); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MutilangSubjectDto model)
    {
      string sql = "UPDATE `mutilang_subject` SET \n\t\t\t\t`title` = @title,\n\t\t\t\t`enable` = @enable,\n\t\t\t\t`icon` = @icon,\n\t\t\t\t`admin_default` = @admin_default,\n\t\t\t\t`app_default` = @app_default\n\t\t\t\t WHERE `lang` = @lang";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string lang)
    {
      string sql = "DELETE FROM `mutilang_subject` WHERE `lang` = @lang";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            lang = lang
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangSubjectService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
