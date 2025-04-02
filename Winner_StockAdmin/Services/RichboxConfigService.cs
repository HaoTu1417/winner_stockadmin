// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxConfigService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.RichboxConfig;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace DB.Services
{
  public class RichboxConfigService
  {
    public static RichboxConfigDto? Find()
    {
      string sql = "\nSELECT `id`, `enable`, `active_date`, `diactive_date`, `currency`, `min_investment`, `max_investment`, `interest_rate`, `begin_profit`, `closing_time`, `give_interest_time`, `feature`, `description`, `trade_info`\nFROM `richbox_config`\nWHERE 1\n";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection != null ? readConnection.Query<RichboxConfigDto>(sql).AsList<RichboxConfigDto>().LastOrDefault<RichboxConfigDto>() : (RichboxConfigDto) null;
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static RichboxConfigDto Find(int id)
    {
      string sql = "SELECT * FROM `richbox_config` WHERE `id` = @id";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            id = id
          });
          return readConnection.QueryFirstOrDefault<RichboxConfigDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][Find]" + ex.Message);
        return (RichboxConfigDto) null;
      }
    }

    public static List<RichboxConfigDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_config`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxConfigDto>(sql).AsList<RichboxConfigDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][FindAll]" + ex.Message);
        return (List<RichboxConfigDto>) null;
      }
    }

    public static int FindPkAfterInsert(RichboxConfigDto source)
    {
      string sql = "INSERT INTO `richbox_config` (\n\t\t\t\t`enable`, `active_date`, `diactive_date`, `currency`, `min_investment`, `max_investment`, `interest_rate`, `begin_profit`, `closing_time`, `give_interest_time`, `feature`, `description`, `trade_info`)\n\t\t\t\tVALUES (@enable, @active_date, @diactive_date, @currency, @min_investment, @max_investment, @interest_rate, @begin_profit, @closing_time, @give_interest_time, @feature, @description, @trade_info);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxConfigDto model)
    {
      string sql = "UPDATE `richbox_config` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`active_date` = @active_date,\n\t\t\t\t`diactive_date` = @diactive_date,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`min_investment` = @min_investment,\n\t\t\t\t`max_investment` = @max_investment,\n\t\t\t\t`interest_rate` = @interest_rate,\n\t\t\t\t`begin_profit` = @begin_profit,\n\t\t\t\t`closing_time` = @closing_time,\n\t\t\t\t`give_interest_time` = @give_interest_time,\n\t\t\t\t`feature` = @feature,\n\t\t\t\t`description` = @description,\n\t\t\t\t`trade_info` = @trade_info\n\t\t\t\t WHERE `id` = @id";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int id)
    {
      string sql = "DELETE FROM `richbox_config` WHERE `id` = @id";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            id = id
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Update(RichboxConfigEditVm model)
    {
      string sql = "UPDATE `richbox_config` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`min_investment` = @min_investment,\n\t\t\t\t`max_investment` = @max_investment,\n\t\t\t\t`interest_rate` = @interest_rate,\n\t\t\t\t`begin_profit` = @begin_profit\t\t\n\t\t\t\t WHERE `id` = @id";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static RichboxConfigEditVm FindRichboxConfigEditVm()
    {
      string sql = "SELECT richbox_config.id, richbox_config.enable, richbox_config.min_investment, richbox_config.max_investment, richbox_config.interest_rate, richbox_config.begin_profit \n                FROM `richbox_config` where id = 1";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RichboxConfigEditVm>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxConfigService][FindRichboxConfigEditVm]" + ex.Message);
        return (RichboxConfigEditVm) null;
      }
    }
  }
}
