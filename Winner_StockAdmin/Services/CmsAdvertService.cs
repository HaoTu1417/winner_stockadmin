// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsAdvertService
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
  public class CmsAdvertService
  {
    public static CmsAdvertDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_advert` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsAdvertDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertService][Find]" + ex.Message);
        return (CmsAdvertDto) null;
      }
    }

    public static List<CmsAdvertDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_advert`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsAdvertDto>(sql).AsList<CmsAdvertDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertService][FindAll]" + ex.Message);
        return (List<CmsAdvertDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsAdvertDto source)
    {
      string sql = "INSERT INTO `cms_advert` (\n\t\t\t\t`typeid`, `tagname`, `ad_type`, `timeset`, `start_time`, `end_time`, `name`, `content`, `expcontent`, `status`, `bnr_id`, `marq_id`, `pop_msg`, `show_pop`, `lang`)\n\t\t\t\tVALUES (@typeid, @tagname, @ad_type, @timeset, @start_time, @end_time, @name, @content, @expcontent, @status, @bnr_id, @marq_id, @pop_msg, @show_pop, @lang);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsAdvertDto model)
    {
      string sql = "UPDATE `cms_advert` SET \n\t\t\t\t`typeid` = @typeid,\n\t\t\t\t`tagname` = @tagname,\n\t\t\t\t`ad_type` = @ad_type,\n\t\t\t\t`timeset` = @timeset,\n\t\t\t\t`start_time` = @start_time,\n\t\t\t\t`end_time` = @end_time,\n\t\t\t\t`name` = @name,\n\t\t\t\t`content` = @content,\n\t\t\t\t`expcontent` = @expcontent,\n\t\t\t\t`status` = @status,\n\t\t\t\t`bnr_id` = @bnr_id,\n\t\t\t\t`marq_id` = @marq_id,\n\t\t\t\t`pop_msg` = @pop_msg,\n\t\t\t\t`show_pop` = @show_pop,\n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_advert` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsAdvertService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
