// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsBannerService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Banner;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsBannerService
  {
    public static CmsBannerDto Find(int cms_files_fk)
    {
      string sql = "SELECT * FROM `cms_banner` WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cms_files_fk = cms_files_fk
          });
          return readConnection.QueryFirstOrDefault<CmsBannerDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][Find]" + ex.Message);
        return (CmsBannerDto) null;
      }
    }

    public static List<CmsBannerDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_banner`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsBannerDto>(sql).AsList<CmsBannerDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsCarouselService][FindAll]" + ex.Message);
        return (List<CmsBannerDto>) null;
      }
    }

    public static int Insert(CmsBannerDto model)
    {
      string sql = "INSERT INTO `cms_banner` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `size`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @size, @lang);";
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

    public static int FindPkAfterInsert(CmsBannerDto model)
    {
      string sql = "INSERT INTO `cms_banner` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `size`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @size, @lang);\n\n                select @@IDENTITY;";
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

    public static int UpdateFull(CmsBannerDto model)
    {
      string sql = "UPDATE `cms_banner` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`url` = @url,\n\t\t\t\t`size` = @size,\n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `cms_files_fk` = @cms_files_fk";
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
      string sql = "DELETE `cms_files`, `cms_banner` FROM `cms_banner`\n                           INNER JOIN cms_files ON cms_files.pk = cms_banner.cms_files_fk\n                           WHERE `cms_files_fk` = @cms_files_fk";
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

    public static List<BannerList> FindBannerList(string whereSql = "", string lang = "VN")
    {
      string sql = "SELECT cms_banner.cms_files_fk, cms_banner.size, IF(cms_banner.enable = 1, 'o', 'x') AS enable, cms_banner.lang,\n                cms_banner.sort, CONCAT(admin_config.value, cms_files.url) AS url, IF(cms_banner.size = 0, '桌機', '手機') AS size_str\n                FROM `cms_banner`\n                inner join admin_config on admin_config.name = 'filesite'\n                inner join cms_files on cms_files.pk = cms_banner.cms_files_fk " + whereSql;
      if (lang.ToUpper() == "EN")
        sql = "SELECT cms_banner.cms_files_fk, cms_banner.size, IF(cms_banner.enable = 1, 'o', 'x') AS enable, cms_banner.lang,\n                    cms_banner.sort, CONCAT(admin_config.value, cms_files.url) AS url, IF(cms_banner.size = 0, 'PC', 'Phone') AS size_str\n                    FROM `cms_banner`\n                    inner join admin_config on admin_config.name = 'filesite'\n                    inner join cms_files on cms_files.pk = cms_banner.cms_files_fk " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BannerList>(sql).AsList<BannerList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsBannerService][FindBannerList]" + ex.Message);
        return (List<BannerList>) null;
      }
    }
  }
}
