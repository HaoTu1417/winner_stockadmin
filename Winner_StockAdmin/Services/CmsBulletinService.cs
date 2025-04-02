// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsBulletinService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Bulletin;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsBulletinService
  {
    public static CmsBulletinDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_bulletin` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsBulletinDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBulletinService][Find]" + ex.Message);
        return (CmsBulletinDto) null;
      }
    }

    public static List<CmsBulletinDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_bulletin`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsBulletinDto>(sql).AsList<CmsBulletinDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBulletinService][FindAll]" + ex.Message);
        return (List<CmsBulletinDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsBulletinDto source)
    {
      string sql = "INSERT INTO `cms_bulletin` (\n\t\t\t\t`lang`, `title`, `sort`, `on_active`, `view`, `trash`, `starttime`, `endtime`, `topic_content`, `img_url`, `summary`, `outsite`, `url`)\n\t\t\t\tVALUES (@lang, @title, @sort, @on_active, @view, @trash, @starttime, @endtime, @topic_content, @img_url, @summary, @outsite, @url);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBulletinService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsBulletinDto model)
    {
      string sql = "UPDATE `cms_bulletin` SET \n\t\t\t\t`lang` = @lang,\n\t\t\t\t`title` = @title,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`on_active` = @on_active,\n\t\t\t\t`view` = @view,\n\t\t\t\t`trash` = @trash,\n\t\t\t\t`starttime` = @starttime,\n\t\t\t\t`endtime` = @endtime,\n\t\t\t\t`topic_content` = @topic_content,\n\t\t\t\t`img_url` = @img_url,\n\t\t\t\t`summary` = @summary,\n\t\t\t\t`outsite` = @outsite,\n\t\t\t\t`url` = @url\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBulletinService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_bulletin` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsBulletinService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<BulletinList> FindBulletinList(string whereSql = "")
    {
      string sql = "SELECT cms_bulletin.pk, cms_bulletin.lang, cms_bulletin.title, cms_bulletin.sort, cms_bulletin.on_active, cms_bulletin.view, cms_bulletin.trash, cms_bulletin.starttime FROM `cms_bulletin`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BulletinList>(sql).AsList<BulletinList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBulletinService][FindBulletinList]" + ex.Message);
        return (List<BulletinList>) null;
      }
    }
  }
}
