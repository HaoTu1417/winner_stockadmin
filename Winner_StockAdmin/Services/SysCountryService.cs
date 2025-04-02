// Decompiled with JetBrains decompiler
// Type: DB.Services.SysCountryService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.SysCountry;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class SysCountryService
  {
    public static SysCountryDto Find(string pk)
    {
      string sql = "SELECT * FROM `sys_country` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<SysCountryDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysCountryService][Find]" + ex.Message);
        return (SysCountryDto) null;
      }
    }

    public static List<SysCountryDto> FindAll()
    {
      string sql = "SELECT * FROM `sys_country`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<SysCountryDto>(sql).AsList<SysCountryDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysCountryService][FindAll]" + ex.Message);
        return (List<SysCountryDto>) null;
      }
    }

    public static int Insert(SysCountryDto model)
    {
      string sql = "INSERT INTO `sys_country` (\n\t\t\t\t`pk`, `label`, `enable`, `lang`, `currency`, `flag`, `code`)\n\t\t\t\tVALUES (@pk, @label, @enable, @lang, @currency, @flag, @code); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysCountryService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(SysCountryDto model)
    {
      string sql = "UPDATE `sys_country` SET \n\t\t\t\t`label` = @label,\n\t\t\t\t`enable` = @enable,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`flag` = @flag,\n\t\t\t\t`code` = @code\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysCountryService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string pk)
    {
      string sql = "DELETE FROM `sys_country` WHERE `pk` = @pk";
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
        LogLib.Log("[SysCountryService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<SysCountryList> FindSysCountryList(string whereSql = "")
    {
      string sql = "SELECT sys_country.pk, sys_country.label, sys_country.enable, sys_country.lang, sys_country.currency, sys_country.flag, sys_country.code FROM `sys_country`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<SysCountryList>(sql).AsList<SysCountryList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[SysCountryService][FindSysCountryList]" + ex.Message);
        return (List<SysCountryList>) null;
      }
    }
  }
}
