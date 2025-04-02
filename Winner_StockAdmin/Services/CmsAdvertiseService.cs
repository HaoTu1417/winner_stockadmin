// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsAdvertiseService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Advertise;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsAdvertiseService
  {
    public static CmsAdvertiseDto Find(int cms_files_fk)
    {
      string sql = "SELECT * FROM `cms_advertise` WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cms_files_fk = cms_files_fk
          });
          return readConnection.QueryFirstOrDefault<CmsAdvertiseDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][Find]" + ex.Message);
        return (CmsAdvertiseDto) null;
      }
    }

    public static List<CmsAdvertiseDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_advertise`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsAdvertiseDto>(sql).AsList<CmsAdvertiseDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][FindAll]" + ex.Message);
        return (List<CmsAdvertiseDto>) null;
      }
    }

    public static int Insert(CmsAdvertiseDto model)
    {
      string sql = "INSERT INTO `cms_advertise` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `hyperlink`, `size`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @hyperlink, @size, @lang);";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int FindPkAfterInsert(CmsAdvertiseDto model)
    {
      string sql = "INSERT INTO `cms_advertise` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `hyperlink`, `size`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @hyperlink, @size, @lang);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsFilesService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsAdvertiseDto model)
    {
      string sql = "UPDATE `cms_advertise` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`url` = @url,\n\t\t\t\t`hyperlink` = @hyperlink,\n\t\t\t\t`size` = @size,\n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int cms_files_fk)
    {
      string sql = "DELETE `cms_files`, `cms_advertise` FROM `cms_advertise`\n                           INNER JOIN cms_files ON cms_files.pk = cms_advertise.cms_files_fk\n                           WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cms_files_fk = cms_files_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdvertiseList> FindAdvertiseList(string whereSql = "")
    {
      string sql = "SELECT * \n                FROM (\n                    SELECT cms_advertise.cms_files_fk, cms_advertise.size, IF(cms_advertise.enable = 1, 'o', 'x') AS enable, cms_advertise.lang, CONCAT(admin_config.value, cms_files.url) AS url,\n                    cms_advertise.hyperlink, ROW_NUMBER() OVER (PARTITION BY cms_advertise.lang ORDER BY cms_advertise.cms_files_fk DESC) AS n\n                    FROM `cms_advertise`\n                    LEFT JOIN admin_config on admin_config.name = 'filesite'\n                    LEFT JOIN cms_files on cms_files.pk = cms_advertise.cms_files_fk " + whereSql + "\n                ) AS x\n                WHERE n <= 1";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdvertiseList>(sql).AsList<AdvertiseList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsAdvertiseService][FindAdvertiseList]" + ex.Message);
        return (List<AdvertiseList>) null;
      }
    }
  }
}
