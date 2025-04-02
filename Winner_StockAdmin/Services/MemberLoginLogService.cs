// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberLoginLogService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class MemberLoginLogService
  {
    public static MemberLoginLogDto Find(int pk)
    {
      string sql = "SELECT * FROM `member_login_log` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MemberLoginLogDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberLoginLogService][Find]" + ex.Message);
        return (MemberLoginLogDto) null;
      }
    }

    public static List<MemberLoginLogDto> FindAll()
    {
      string sql = "SELECT * FROM `member_login_log`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberLoginLogDto>(sql).AsList<MemberLoginLogDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberLoginLogService][FindAll]" + ex.Message);
        return (List<MemberLoginLogDto>) null;
      }
    }

    public static int FindPkAfterInsert(MemberLoginLogDto source)
    {
      string sql = "INSERT INTO `member_login_log` (\n\t\t\t\t`member_fk`, `ip`, `ip_country`, `login_account`, `device`, `create_time`, `status`, `remark`)\n\t\t\t\tVALUES (@member_fk, @ip, @ip_country, @login_account, @device, @create_time, @status, @remark);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberLoginLogService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberLoginLogDto model)
    {
      string sql = "UPDATE `member_login_log` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`ip` = @ip,\n\t\t\t\t`ip_country` = @ip_country,\n\t\t\t\t`login_account` = @login_account,\n\t\t\t\t`device` = @device,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`status` = @status,\n\t\t\t\t`remark` = @remark\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberLoginLogService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `member_login_log` WHERE `pk` = @pk";
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
        LogLib.Log("[MemberLoginLogService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
