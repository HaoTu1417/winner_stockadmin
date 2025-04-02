// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsPopinfoService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.CmsPopinfo;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsPopinfoService
  {
    public static CmsPopinfoDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_popinfo` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsPopinfoDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPopinfoService][Find]" + ex.Message);
        return (CmsPopinfoDto) null;
      }
    }

    public static List<CmsPopinfoDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_popinfo`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsPopinfoDto>(sql).AsList<CmsPopinfoDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPopinfoService][FindAll]" + ex.Message);
        return (List<CmsPopinfoDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsPopinfoDto source)
    {
      string sql = "INSERT INTO `cms_popinfo` (\n\t\t\t\t`lang`, `info`, `size`, `enable`)\n\t\t\t\tVALUES (@lang, @info, @size, @enable);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPopinfoService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsPopinfoDto model)
    {
      string sql = "UPDATE `cms_popinfo` SET \n\t\t\t\t`lang` = @lang,\n\t\t\t\t`info` = @info,\n\t\t\t\t`size` = @size,\n\t\t\t\t`enable` = @enable\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPopinfoService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_popinfo` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsPopinfoService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<CmsPopinfoList> FindCmsPopinfoList(string whereSql = "")
    {
      string sql = "SELECT cms_popinfo.pk, cms_popinfo.lang, cms_popinfo.info, cms_popinfo.size, cms_popinfo.enable FROM `cms_popinfo`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsPopinfoList>(sql).AsList<CmsPopinfoList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsPopinfoService][FindCmsPopinfoList]" + ex.Message);
        return (List<CmsPopinfoList>) null;
      }
    }
  }
}
