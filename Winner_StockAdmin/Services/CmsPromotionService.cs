// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsPromotionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Promotion;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsPromotionService
  {
    public static CmsPromotionDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_promotion` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsPromotionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPromotionService][Find]" + ex.Message);
        return (CmsPromotionDto) null;
      }
    }

    public static List<CmsPromotionDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_promotion`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsPromotionDto>(sql).AsList<CmsPromotionDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPromotionService][FindAll]" + ex.Message);
        return (List<CmsPromotionDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsPromotionDto source)
    {
      string sql = "INSERT INTO `cms_promotion` (\n\t\t\t\t`lang`, `title`, `sort`, `on_active`, `view`, `trash`, `show_activity_time`, `starttime`, `endtime`, `topic_content`, `img_url`, `outsite`, `url`, `summary`)\n\t\t\t\tVALUES (@lang, @title, @sort, @on_active, @view, @trash, @show_activity_time, @starttime, @endtime, @topic_content, @img_url, @outsite, @url, @summary);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPromotionService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsPromotionDto model)
    {
      string sql = "UPDATE `cms_promotion` SET \n\t\t\t\t`lang` = @lang,\n\t\t\t\t`title` = @title,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`on_active` = @on_active,\n\t\t\t\t`view` = @view,\n\t\t\t\t`trash` = @trash,\n                `show_activity_time` = @show_activity_time,\n\t\t\t\t`starttime` = @starttime,\n\t\t\t\t`endtime` = @endtime,\n\t\t\t\t`topic_content` = @topic_content,\n\t\t\t\t`img_url` = @img_url,\n\t\t\t\t`outsite` = @outsite,\n\t\t\t\t`url` = @url,\n\t\t\t\t`summary` = @summary\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPromotionService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_promotion` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsPromotionService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<PromotionList> FindPromotionList(string whereSql = "")
    {
      string sql = "SELECT cms_promotion.pk, cms_promotion.lang, cms_promotion.title, cms_promotion.view, cms_promotion.sort, cms_promotion.on_active, cms_promotion.trash, cms_promotion.show_activity_time, cms_promotion.starttime, cms_promotion.endtime FROM `cms_promotion` " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<PromotionList>(sql).AsList<PromotionList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPromotionService][FindPromotionList]" + ex.Message);
        return (List<PromotionList>) null;
      }
    }
  }
}
