// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsFilesService
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
  public class CmsFilesService
  {
    public static CmsFilesDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_files` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsFilesDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][Find]" + ex.Message);
        return (CmsFilesDto) null;
      }
    }

    public static List<CmsFilesDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_files`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsFilesDto>(sql).AsList<CmsFilesDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][FindAll]" + ex.Message);
        return (List<CmsFilesDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsFilesDto source)
    {
      string sql = "INSERT INTO `cms_files` (\n\t\t\t\t`url`, `file_type`, `table`, `key`)\n\t\t\t\tVALUES (@url, @file_type, @table, @key);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Update(CmsFilesDto model)
    {
      string sql = "UPDATE `cms_files` SET \n\t\t\t\t`url` = @url,\n\t\t\t\t`file_type` = @file_type,\n\t\t\t\t`table` = @table\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateKey(int pk, int key)
    {
      string sql = "UPDATE `cms_files` SET \n\t\t\t\t`key` = @key\n\t\t\t\t WHERE `pk` = @pk";
      DynamicParameters parameters = DapperMysql.GetParameters((object) new
      {
        pk = pk,
        key = key
      });
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_files` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsFilesService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
