// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminLogService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminLog;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminLogService
  {
    public static AdminLogDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_log` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminLogDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLogService][Find]" + ex.Message);
        return (AdminLogDto) null;
      }
    }

    public static List<AdminLogDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_log`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminLogDto>(sql).AsList<AdminLogDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLogService][FindAll]" + ex.Message);
        return (List<AdminLogDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminLogDto source)
    {
      string sql = "INSERT INTO `admin_log` (\n\t\t\t\t`admin_action`, `admin_user`, `param`, `remark`, `create_time`,  `member_account`)\n\t\t\t\tVALUES (@admin_action, @admin_user, @param, @remark, @create_time, @member_account);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLogService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminLogDto model)
    {
      string sql = "UPDATE `admin_log` SET \n\t\t\t\t`admin_action` = @admin_action,\n\t\t\t\t`admin_user` = @admin_user,\n\t\t\t\t`table_name` = @table_name,\n\t\t\t\t`table_index` = @table_index,\n\t\t\t\t`action_ip` = @action_ip,\n\t\t\t\t`param` = @param,\n\t\t\t\t`remark` = @remark,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLogService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_log` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminLogService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminLogList> FindAdminLogList(string whereSql = "")
    {
      string sql = "SELECT admin_log.pk, admin_log.create_time, admin_user.account, admin_user.nickname, admin_log.remark, admin_log.action_ip, admin_log.member_account\n                FROM `admin_log`\n                INNER JOIN admin_user on admin_user.pk = admin_log.admin_user\n                " + whereSql + " ORDER BY admin_log.create_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminLogList>(sql).AsList<AdminLogList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminLogService][FindAdminLogList]" + ex.Message);
        return (List<AdminLogList>) null;
      }
    }
  }
}
