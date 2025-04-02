// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxCoreService
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
  public class RichboxCoreService
  {
    public static RichboxCoreDto Find(int pk)
    {
      string sql = "SELECT * FROM `richbox_core` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RichboxCoreDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxCoreService][Find]" + ex.Message);
        return (RichboxCoreDto) null;
      }
    }

    public static List<RichboxCoreDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_core`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxCoreDto>(sql).AsList<RichboxCoreDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxCoreService][FindAll]" + ex.Message);
        return (List<RichboxCoreDto>) null;
      }
    }

    public static int FindPkAfterInsert(RichboxCoreDto source)
    {
      string sql = "INSERT INTO `richbox_core` (\n\t\t\t\t`member_fk`, `create_time`, `invest`, `money`, `days`, `pay`)\n\t\t\t\tVALUES (@member_fk, @create_time, @invest, @money, @days, @pay);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxCoreService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxCoreDto model)
    {
      string sql = "UPDATE `richbox_core` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`invest` = @invest,\n\t\t\t\t`money` = @money,\n\t\t\t\t`days` = @days,\n\t\t\t\t`pay` = @pay\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxCoreService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `richbox_core` WHERE `pk` = @pk";
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
        LogLib.Log("[RichboxCoreService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
