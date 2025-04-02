// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsMenuService
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
  public class CmsMenuService
  {
    public static CmsMenuDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_menu` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsMenuDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMenuService][Find]" + ex.Message);
        return (CmsMenuDto) null;
      }
    }

    public static List<CmsMenuDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_menu`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsMenuDto>(sql).AsList<CmsMenuDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMenuService][FindAll]" + ex.Message);
        return (List<CmsMenuDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsMenuDto source)
    {
      string sql = "INSERT INTO `cms_menu` (\n\t\t\t\t`nid`, `pid`, `column`, `page`, `type`, `title`, `url`, `css`, `rel`, `target`, `sort`, `status`)\n\t\t\t\tVALUES (@nid, @pid, @column, @page, @type, @title, @url, @css, @rel, @target, @sort, @status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMenuService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsMenuDto model)
    {
      string sql = "UPDATE `cms_menu` SET \n\t\t\t\t`nid` = @nid,\n\t\t\t\t`pid` = @pid,\n\t\t\t\t`column` = @column,\n\t\t\t\t`page` = @page,\n\t\t\t\t`type` = @type,\n\t\t\t\t`title` = @title,\n\t\t\t\t`url` = @url,\n\t\t\t\t`css` = @css,\n\t\t\t\t`rel` = @rel,\n\t\t\t\t`target` = @target,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsMenuService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_menu` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsMenuService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
