// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberSignService
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
  public class MemberSignService
  {
    public static MemberSignDto Find(int pk)
    {
      string sql = "SELECT * FROM `member_sign` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MemberSignDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberSignService][Find]" + ex.Message);
        return (MemberSignDto) null;
      }
    }

    public static List<MemberSignDto> FindAll()
    {
      string sql = "SELECT * FROM `member_sign`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberSignDto>(sql).AsList<MemberSignDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberSignService][FindAll]" + ex.Message);
        return (List<MemberSignDto>) null;
      }
    }

    public static int FindPkAfterInsert(MemberSignDto source)
    {
      string sql = "INSERT INTO `member_sign` (\n\t\t\t\t`member_fk`, `sign_time`, `continuity_day`, `total_day`, `coupon`, `currency`)\n\t\t\t\tVALUES (@member_fk, @sign_time, @continuity_day, @total_day, @coupon, @currency);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberSignService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberSignDto model)
    {
      string sql = "UPDATE `member_sign` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`sign_time` = @sign_time,\n\t\t\t\t`continuity_day` = @continuity_day,\n\t\t\t\t`total_day` = @total_day,\n\t\t\t\t`coupon` = @coupon,\n\t\t\t\t`currency` = @currency\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberSignService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `member_sign` WHERE `pk` = @pk";
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
        LogLib.Log("[MemberSignService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
