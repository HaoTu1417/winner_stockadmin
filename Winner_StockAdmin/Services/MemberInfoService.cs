// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberInfoService
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
  public class MemberInfoService
  {
    public static MemberInfoDto Find(int member_fk)
    {
      string sql = "SELECT * FROM `member_info` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<MemberInfoDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberInfoService][Find]" + ex.Message);
        return (MemberInfoDto) null;
      }
    }

    public static List<MemberInfoDto> FindAll()
    {
      string sql = "SELECT * FROM `member_info`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberInfoDto>(sql).AsList<MemberInfoDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberInfoService][FindAll]" + ex.Message);
        return (List<MemberInfoDto>) null;
      }
    }

    public static int Insert(MemberInfoDto model)
    {
      string sql = "INSERT INTO `member_info` (\n\t\t\t\t`member_fk`, `fristtime_save_money`, `lasttime_save_money`)\n\t\t\t\tVALUES (@member_fk, @fristtime_save_money, @lasttime_save_money); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberInfoService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberInfoDto model)
    {
      string sql = "UPDATE `member_info` SET \n\t\t\t\t`fristtime_save_money` = @fristtime_save_money,\n\t\t\t\t`lasttime_save_money` = @lasttime_save_money\n\t\t\t\t WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberInfoService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int member_fk)
    {
      string sql = "DELETE FROM `member_info` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberInfoService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
