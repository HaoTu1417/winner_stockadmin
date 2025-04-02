// Decompiled with JetBrains decompiler
// Type: DB.Services.AppLogoService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AppLogo;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class AppLogoService
  {
    public static AppLogoDto Find(int cms_files_fk)
    {
      string sql = "SELECT * FROM `app_logo` WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cms_files_fk = cms_files_fk
          });
          return readConnection.QueryFirstOrDefault<AppLogoDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        return (AppLogoDto) null;
      }
    }

    public static List<AppLogoDto> FindAll()
    {
      string sql = "SELECT * FROM `app_logo`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AppLogoDto>(sql).AsList<AppLogoDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CarouselService][FindAll]" + ex.Message);
        return (List<AppLogoDto>) null;
      }
    }

    public static int Insert(AppLogoDto model)
    {
      string sql = "INSERT INTO `app_logo` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `type`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @type, @lang);";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CarouselService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int FindPkAfterInsert(AppLogoDto model)
    {
      string sql = "INSERT INTO `app_logo` (\n\t\t\t\t`cms_files_fk`, `enable`, `sort`, `url`, `type`, `lang`)\n\t\t\t\tVALUES (@cms_files_fk, @enable, @sort, @url, @type, @lang);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) model);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[FilesService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AppLogoDto model)
    {
      string sql = "UPDATE `app_logo` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`url` = @url,\n\t\t\t\t`type` = @type,\n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `cms_files_fk` = @cms_files_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CarouselService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int cms_files_fk)
    {
      string sql = "DELETE `cms_files`, `app_logo` FROM `app_logo`\n                           INNER JOIN cms_files ON cms_files.pk = app_logo.cms_files_fk\n                           WHERE `cms_files_fk` = @cms_files_fk";
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
        LogLib.Log("[CarouselService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AppLogoList> FindAppLogoList(string whereSql = "", string lang = "VN")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(579, 2);
      interpolatedStringHandler.AppendLiteral("SELECT * \n                FROM (\n                    SELECT app_logo.cms_files_fk, app_logo.type, IF(app_logo.enable = 1, 'o', 'x') AS enable, app_logo.lang, CONCAT(admin_config.value, cms_files.url) AS url,\n                    ROW_NUMBER() OVER (PARTITION BY app_logo.type ORDER BY app_logo.cms_files_fk DESC) AS n, '");
      interpolatedStringHandler.AppendFormatted(lang);
      interpolatedStringHandler.AppendLiteral("' AS admin_lang\n                    FROM `app_logo`\n                    LEFT JOIN admin_config on admin_config.name = 'filesite'\n                    LEFT JOIN cms_files on cms_files.pk = app_logo.cms_files_fk ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ) AS x\n                WHERE n <= 1");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AppLogoList>(stringAndClear).AsList<AppLogoList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AppLogoService][FindAppLogoList]" + ex.Message);
        return (List<AppLogoList>) null;
      }
    }
  }
}
