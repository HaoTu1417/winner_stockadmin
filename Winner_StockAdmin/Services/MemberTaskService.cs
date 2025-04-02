// Decompiled with JetBrains decompiler
// Type: DB.Services.MemberTaskService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.MemberTask;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class MemberTaskService
  {
    public static MemberTaskDto Find(int pk)
    {
      string sql = "SELECT * FROM `member_task` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MemberTaskDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberTaskService][Find]" + ex.Message);
        return (MemberTaskDto) null;
      }
    }

    public static List<MemberTaskDto> FindAll()
    {
      string sql = "SELECT * FROM `member_task`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberTaskDto>(sql).AsList<MemberTaskDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberTaskService][FindAll]" + ex.Message);
        return (List<MemberTaskDto>) null;
      }
    }

    public static int FindPkAfterInsert(MemberTaskDto source)
    {
      string sql = "INSERT INTO `member_task` (\n\t\t\t\t`sub_type`, `currency`, `lang`, `coin`, `title`, `content`)\n\t\t\t\tVALUES (@sub_type, @currency, @lang, @coin, @title, @content);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberTaskService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MemberTaskDto model)
    {
      string sql = "UPDATE `member_task` SET \n\t\t\t\t`sub_type` = @sub_type,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`coin` = @coin,\n\t\t\t\t`title` = @title,\n\t\t\t\t`content` = @content\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberTaskService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `member_task` WHERE `pk` = @pk";
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
        LogLib.Log("[MemberTaskService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<MemberTaskList> FindMemberTaskList(string whereSql = "")
    {
      string sql = "SELECT member_task.pk, member_task.sub_type, member_task.currency, member_task.coin, member_task.lang, member_task.title, member_task.content FROM `member_task`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MemberTaskList>(sql).AsList<MemberTaskList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MemberTaskService][FindMemberTaskList]" + ex.Message);
        return (List<MemberTaskList>) null;
      }
    }

    public static MemberTaskDto FindBySubType_Currency_Lang(
      int sub_type,
      string lang,
      string currency)
    {
      string sql = "SELECT * FROM `member_task` \nWHERE `sub_type` = @sub_type AND `lang` = @lang AND `currency` = @currency";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            sub_type = sub_type,
            lang = lang,
            currency = currency
          });
          return readConnection.QueryFirstOrDefault<MemberTaskDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }
  }
}
