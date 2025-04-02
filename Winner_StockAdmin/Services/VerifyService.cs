// Decompiled with JetBrains decompiler
// Type: DB.Services.VerifyService
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
  public class VerifyService
  {
    public static VerifyDto Find(int pk)
    {
      string sql = "SELECT * FROM `verify` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<VerifyDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[VerifyService][Find]" + ex.Message);
        return (VerifyDto) null;
      }
    }

    public static List<VerifyDto> FindAll()
    {
      string sql = "SELECT * FROM `verify`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<VerifyDto>(sql).AsList<VerifyDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[VerifyService][FindAll]" + ex.Message);
        return (List<VerifyDto>) null;
      }
    }

    public static int FindPkAfterInsert(VerifyDto source)
    {
      string sql = "INSERT INTO `verify` (\n\t\t\t\t`code`, `send_time`, `type`, `email`)\n\t\t\t\tVALUES (@code, @send_time, @type, @email);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[VerifyService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(VerifyDto model)
    {
      string sql = "UPDATE `verify` SET \n\t\t\t\t`code` = @code,\n\t\t\t\t`send_time` = @send_time,\n\t\t\t\t`type` = @type,\n\t\t\t\t`email` = @email\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[VerifyService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `verify` WHERE `pk` = @pk";
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
        LogLib.Log("[VerifyService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
