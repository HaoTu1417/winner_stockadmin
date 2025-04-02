// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxTaskLogService
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
  public class RichboxTaskLogService
  {
    public static RichboxTaskLogDto Find(int pk)
    {
      string sql = "SELECT * FROM `richbox_task_log` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RichboxTaskLogDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxTaskLogService][Find]" + ex.Message);
        return (RichboxTaskLogDto) null;
      }
    }

    public static List<RichboxTaskLogDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_task_log`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxTaskLogDto>(sql).AsList<RichboxTaskLogDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxTaskLogService][FindAll]" + ex.Message);
        return (List<RichboxTaskLogDto>) null;
      }
    }

    public static int FindPkAfterInsert(RichboxTaskLogDto source)
    {
      string sql = "INSERT INTO `richbox_task_log` (\n\t\t\t\t`member_fk`, `code`, `info`, `create_time`, `result`)\n\t\t\t\tVALUES (@member_fk, @code, @info, @create_time, @result);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxTaskLogService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxTaskLogDto model)
    {
      string sql = "UPDATE `richbox_task_log` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`code` = @code,\n\t\t\t\t`info` = @info,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`result` = @result\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxTaskLogService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `richbox_task_log` WHERE `pk` = @pk";
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
        LogLib.Log("[RichboxTaskLogService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
