// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminConfigService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminConfig;
using stockadmin.ViewModels.RecommendConfig;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminConfigService
  {
    public static AdminConfigDto Find(string name)
    {
      string sql = "SELECT * FROM `admin_config` WHERE `name` = @name";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            name = name
          });
          return readConnection.QueryFirstOrDefault<AdminConfigDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][Find]" + ex.Message);
        return (AdminConfigDto) null;
      }
    }

    public static List<AdminConfigDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_config`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminConfigDto>(sql).AsList<AdminConfigDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][FindAll]" + ex.Message);
        return (List<AdminConfigDto>) null;
      }
    }

    public static int Insert(AdminConfigDto model)
    {
      string sql = "INSERT INTO `admin_config` (\n\t\t\t\t`name`, `title`, `group`, `type`, `value`, `options`, `tips`, `ajax_url`, `next_items`, `param`, `format`, `table`, `level`, `key`, `option`, `pid`, `ak`, `sort`, `status`)\n\t\t\t\tVALUES (@name, @title, @group, @type, @value, @options, @tips, @ajax_url, @next_items, @param, @format, @table, @level, @key, @option, @pid, @ak, @sort, @status); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int InsertConfig(AdminConfigVm model)
    {
      string sql = "INSERT INTO `admin_config` (\n\t\t\t\t`name`, `title`, `group`, `type`, `value`, `options`, `tips`, `level`, `sort`, `status`)\n\t\t\t\tVALUES (@name, @title, @group, @type, @value, @options, @tips, @level, @sort, @status); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminConfigDto model)
    {
      string sql = "UPDATE `admin_config` SET \n\t\t\t\t`title` = @title,\n\t\t\t\t`group` = @group,\n\t\t\t\t`type` = @type,\n\t\t\t\t`value` = @value,\n\t\t\t\t`options` = @options,\n\t\t\t\t`tips` = @tips,\n\t\t\t\t`ajax_url` = @ajax_url,\n\t\t\t\t`next_items` = @next_items,\n\t\t\t\t`param` = @param,\n\t\t\t\t`format` = @format,\n\t\t\t\t`table` = @table,\n\t\t\t\t`level` = @level,\n\t\t\t\t`key` = @key,\n\t\t\t\t`option` = @option,\n\t\t\t\t`pid` = @pid,\n\t\t\t\t`ak` = @ak,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `name` = @name";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateConfig(AdminConfigDto model)
    {
      string sql = "UPDATE `admin_config` SET \n\t\t\t\t`title` = @title,\n\t\t\t\t`group` = @group,\n\t\t\t\t`value` = @value,\n\t\t\t\t`tips` = @tips,\n\t\t\t\t`format` = @format,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `name` = @name";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateRecommendConfig(RecommendConfigEditVm model)
    {
      string sql = "UPDATE `admin_config`\n                            SET `value` = CASE\n                                WHEN `name` = 'layer_rate_1' THEN @layer_rate_1\n                                WHEN `name` = 'layer_rate_2' THEN @layer_rate_2\n                                WHEN `name` = 'layer_rate_3' THEN @layer_rate_3\n                                ELSE `value`\n                            END\n                            WHERE `name` IN ('layer_rate_1', 'layer_rate_2', 'layer_rate_3');";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][UpdateRecommendConfig]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string name)
    {
      string sql = "DELETE FROM `admin_config` WHERE `name` = @name";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            name = name
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminConfigList> FindAdminConfigList(string whereSql = "")
    {
      string sql = "SELECT admin_config.name, admin_config.title, admin_config.group, admin_config.value, admin_config.status, admin_config.common,  admin_config.sort FROM `admin_config`" + whereSql + " order by  admin_config.sort ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminConfigList>(sql).AsList<AdminConfigList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminConfigService][FindAdminConfigList]" + ex.Message);
        return (List<AdminConfigList>) null;
      }
    }

    public static List<AdminConfigList> FindRecommendConfig()
    {
      string sql = "SELECT * FROM `admin_config` Where admin_config.name in ('layer_rate_1', 'layer_rate_2', 'layer_rate_3')";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminConfigList>(sql).AsList<AdminConfigList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendConfigEditVm][FindRecommendConfig]" + ex.Message);
        return (List<AdminConfigList>) null;
      }
    }
  }
}
