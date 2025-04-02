// Decompiled with JetBrains decompiler
// Type: DB.Services.AppFilesService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AppFile;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AppFilesService
  {
    public static AppFileDto Find(int pk)
    {
      string sql = "SELECT * FROM `app_files` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AppFileDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppFilesService][Find]" + ex.Message);
        return (AppFileDto) null;
      }
    }

    public static List<AppFileDto> FindAll()
    {
      string sql = "SELECT * FROM `app_files`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AppFileDto>(sql).AsList<AppFileDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppFilesService][FindAll]" + ex.Message);
        return (List<AppFileDto>) null;
      }
    }

    public static int FindPkAfterInsert(AppFileDto source)
    {
      string sql = "INSERT INTO `app_files` (\n\t\t\t\t`path`, `code`, `version`, `device`)\n\t\t\t\tVALUES (@path, @code, @version, @device);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppFilesService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Update(AppFileDto model)
    {
      string sql = "UPDATE `app_files` SET \n\t\t\t\t`path` = @path,\n\t\t\t\t`code` = @code,\n\t\t\t\t`version` = @version,\n\t\t\t\t`device` = @device,\n                `upload_date` = @upload_date,\n                `active` = @active\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppFilesService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `app_files` WHERE `pk` = @pk";
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
        LogLib.Log("[AppFilesService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AppFileList> FindAppFileList(string whereSql = "")
    {
      string sql = "SELECT pk, path, code, version, device FROM `app_files` " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AppFileList>(sql).AsList<AppFileList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppFilesService][FindAppFileList]" + ex.Message);
        return (List<AppFileList>) null;
      }
    }
  }
}
