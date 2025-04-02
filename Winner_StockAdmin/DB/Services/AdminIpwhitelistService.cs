// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminIpwhitelistService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Ipwhitelist;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminIpwhitelistService
  {
    public static AdminIpwhitelistDto Find(string ip)
    {
      string sql = "SELECT * FROM `admin_ipwhitelist` WHERE `ip` = @ip";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            ip = ip
          });
          return readConnection.QueryFirstOrDefault<AdminIpwhitelistDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][Find]" + ex.Message);
        return (AdminIpwhitelistDto) null;
      }
    }

    public static AdminIpwhitelistDto FindByIpAndAccount(string ip, string account)
    {
      string sql = "SELECT * FROM `admin_ipwhitelist` WHERE `ip` = @ip AND account = @account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            ip = ip,
            account = account
          });
          return readConnection.QueryFirstOrDefault<AdminIpwhitelistDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][Find]" + ex.Message);
        return (AdminIpwhitelistDto) null;
      }
    }

    public static List<AdminIpwhitelistDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_ipwhitelist`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminIpwhitelistDto>(sql).AsList<AdminIpwhitelistDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][FindAll]" + ex.Message);
        return (List<AdminIpwhitelistDto>) null;
      }
    }

    public static int Insert(AdminIpwhitelistDto model)
    {
      string sql = "INSERT INTO `admin_ipwhitelist` (\n\t\t\t\t`ip`, `remarks`, `account`, `status`, `create_time`, `update_time`)\n\t\t\t\tVALUES (@ip, @remarks, @account, @status, @create_time, @update_time); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminIpwhitelistDto model)
    {
      string sql = "UPDATE `admin_ipwhitelist` SET \n\t\t\t\t`remarks` = @remarks,\n\t\t\t\t`account` = @account,\n\t\t\t\t`status` = @status,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`update_time` = @update_time\n\t\t\t\t WHERE `ip` = @ip";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string ip)
    {
      string sql = "DELETE FROM `admin_ipwhitelist` WHERE `ip` = @ip";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            ip = ip
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<IpwhitelistList> FindIpwhitelistList(string whereSql = "")
    {
      string sql = "SELECT * FROM `admin_ipwhitelist`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<IpwhitelistList>(sql).AsList<IpwhitelistList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminIpwhitelistService][FindIpwhitelistList]" + ex.Message);
        return (List<IpwhitelistList>) null;
      }
    }
  }
}
