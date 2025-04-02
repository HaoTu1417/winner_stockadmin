// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsColumnService
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
  public class CmsColumnService
  {
    public static CmsColumnDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_column` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsColumnDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsColumnService][Find]" + ex.Message);
        return (CmsColumnDto) null;
      }
    }

    public static List<CmsColumnDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_column`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsColumnDto>(sql).AsList<CmsColumnDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsColumnService][FindAll]" + ex.Message);
        return (List<CmsColumnDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsColumnDto source)
    {
      string sql = "INSERT INTO `cms_column` (\n\t\t\t\t`pid`, `name`, `model`, `url`, `target`, `content`, `icon`, `index_template`, `list_template`, `detail_template`, `post_auth`, `sort`, `status`, `hide`, `rank_auth`, `type`)\n\t\t\t\tVALUES (@pid, @name, @model, @url, @target, @content, @icon, @index_template, @list_template, @detail_template, @post_auth, @sort, @status, @hide, @rank_auth, @type);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsColumnService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsColumnDto model)
    {
      string sql = "UPDATE `cms_column` SET \n\t\t\t\t`pid` = @pid,\n\t\t\t\t`name` = @name,\n\t\t\t\t`model` = @model,\n\t\t\t\t`url` = @url,\n\t\t\t\t`target` = @target,\n\t\t\t\t`content` = @content,\n\t\t\t\t`icon` = @icon,\n\t\t\t\t`index_template` = @index_template,\n\t\t\t\t`list_template` = @list_template,\n\t\t\t\t`detail_template` = @detail_template,\n\t\t\t\t`post_auth` = @post_auth,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status,\n\t\t\t\t`hide` = @hide,\n\t\t\t\t`rank_auth` = @rank_auth,\n\t\t\t\t`type` = @type\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsColumnService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_column` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsColumnService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
