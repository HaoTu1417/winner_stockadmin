// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminAttachmentService
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
  public class AdminAttachmentService
  {
    public static AdminAttachmentDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_attachment` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminAttachmentDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminAttachmentService][Find]" + ex.Message);
        return (AdminAttachmentDto) null;
      }
    }

    public static List<AdminAttachmentDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_attachment`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminAttachmentDto>(sql).AsList<AdminAttachmentDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminAttachmentService][FindAll]" + ex.Message);
        return (List<AdminAttachmentDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminAttachmentDto source)
    {
      string sql = "INSERT INTO `admin_attachment` (\n\t\t\t\t`member_fk`, `name`, `module`, `path`, `thumb`, `url`, `mime`, `ext`, `size`, `md5`, `sha1`, `driver`, `download`, `sort`, `status`)\n\t\t\t\tVALUES (@member_fk, @name, @module, @path, @thumb, @url, @mime, @ext, @size, @md5, @sha1, @driver, @download, @sort, @status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminAttachmentService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminAttachmentDto model)
    {
      string sql = "UPDATE `admin_attachment` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`name` = @name,\n\t\t\t\t`module` = @module,\n\t\t\t\t`path` = @path,\n\t\t\t\t`thumb` = @thumb,\n\t\t\t\t`url` = @url,\n\t\t\t\t`mime` = @mime,\n\t\t\t\t`ext` = @ext,\n\t\t\t\t`size` = @size,\n\t\t\t\t`md5` = @md5,\n\t\t\t\t`sha1` = @sha1,\n\t\t\t\t`driver` = @driver,\n\t\t\t\t`download` = @download,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminAttachmentService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_attachment` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminAttachmentService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
