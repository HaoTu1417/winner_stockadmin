// Decompiled with JetBrains decompiler
// Type: DB.Services.MutilangTableService
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
  public class MutilangTableService
  {
    public static MutilangTableDto Find(int pk)
    {
      string sql = "SELECT * FROM `mutilang_table` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MutilangTableDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangTableService][Find]" + ex.Message);
        return (MutilangTableDto) null;
      }
    }

    public static List<MutilangTableDto> FindAll()
    {
      string sql = "SELECT * FROM `mutilang_table`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MutilangTableDto>(sql).AsList<MutilangTableDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangTableService][FindAll]" + ex.Message);
        return (List<MutilangTableDto>) null;
      }
    }

    public static int FindPkAfterInsert(MutilangTableDto source)
    {
      string sql = "INSERT INTO `mutilang_table` (\n\t\t\t\t`dbtable`, `field`, `key`, `lang`, `value`)\n\t\t\t\tVALUES (@dbtable, @field, @key, @lang, @value);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangTableService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MutilangTableDto model)
    {
      string sql = "UPDATE `mutilang_table` SET \n\t\t\t\t`dbtable` = @dbtable,\n\t\t\t\t`field` = @field,\n\t\t\t\t`key` = @key,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`value` = @value\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MutilangTableService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `mutilang_table` WHERE `pk` = @pk";
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
        LogLib.Log("[MutilangTableService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
