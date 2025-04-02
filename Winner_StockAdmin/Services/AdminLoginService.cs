// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminLoginService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminLogin;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminLoginService
  {
    public static AdminLoginDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_login` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminLoginDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLoginService][Find]" + ex.Message);
        return (AdminLoginDto) null;
      }
    }

    public static List<AdminLoginDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_login`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminLoginDto>(sql).AsList<AdminLoginDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLoginService][FindAll]" + ex.Message);
        return (List<AdminLoginDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminLoginDto source)
    {
      string sql = "INSERT INTO `admin_login` (\n\t\t\t\t`ip`, `ip_country`, `login_account`, `device`, `create_time`, `status`, `remark`)\n\t\t\t\tVALUES (@ip, @ip_country, @login_account, @device, @create_time, @status, @remark);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLoginService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminLoginDto model)
    {
      string sql = "UPDATE `admin_login` SET \n\t\t\t\t`ip` = @ip,\n\t\t\t\t`ip_country` = @ip_country,\n\t\t\t\t`login_account` = @login_account,\n\t\t\t\t`device` = @device,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`status` = @status,\n\t\t\t\t`remark` = @remark\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLoginService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_login` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminLoginService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminLoginList> FindAdminLoginList(string whereSql = "")
    {
      string sql = "SELECT admin_login.pk, admin_login.login_account, admin_login.create_time, admin_login.status, admin_login.ip, admin_login.ip_country, admin_login.remark, admin_login.device \n                FROM `admin_login`" + whereSql + " order by create_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminLoginList>(sql).AsList<AdminLoginList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLoginService][FindAdminLoginList]" + ex.Message);
        return (List<AdminLoginList>) null;
      }
    }
  }
}
