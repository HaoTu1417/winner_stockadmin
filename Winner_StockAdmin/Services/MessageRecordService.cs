// Decompiled with JetBrains decompiler
// Type: DB.Services.MessageRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.MessageRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class MessageRecordService
  {
    public static MessageRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `message_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MessageRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][Find]" + ex.Message);
        return (MessageRecordDto) null;
      }
    }

    public static List<MessageRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `message_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MessageRecordDto>(sql).AsList<MessageRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][FindAll]" + ex.Message);
        return (List<MessageRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(MessageRecordDto source)
    {
      string sql = "INSERT INTO `message_record` (\n\t\t\t\t`isbatch`, `receiver_table`, `receiver_fk`, `sender_table`, `sender_fk`, `title`, `info`, `read_status`, `type`, `send_status`, `send_type`, `create_time`, `read_time`, `sent_time`, `classify`)\n\t\t\t\tVALUES (@isbatch, @receiver_table, @receiver_fk, @sender_table, @sender_fk, @title, @info, @read_status, @type, @send_status, @send_type, @create_time, @read_time, @sent_time, @classify);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MessageRecordDto model)
    {
      string sql = "UPDATE `message_record` SET \n\t\t\t\t`isbatch` = @isbatch,\n\t\t\t\t`receiver_table` = @receiver_table,\n\t\t\t\t`receiver_fk` = @receiver_fk,\n\t\t\t\t`sender_table` = @sender_table,\n\t\t\t\t`sender_fk` = @sender_fk,\n\t\t\t\t`title` = @title,\n\t\t\t\t`info` = @info,\n\t\t\t\t`read_status` = @read_status,\n\t\t\t\t`type` = @type,\n\t\t\t\t`send_status` = @send_status,\n\t\t\t\t`send_type` = @send_type,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`read_time` = @read_time,\n\t\t\t\t`sent_time` = @sent_time,\n\t\t\t\t`classify` = @classify\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `message_record` WHERE `pk` = @pk";
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
        LogLib.Log("[MessageRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<MessageRecordList> FindMessageRecordList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                            SELECT \n                                COUNT(*) AS count\n                            FROM `message_record`\n                            INNER JOIN member ON member.pk = message_record.sender_fk\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(572, 3);
      interpolatedStringHandler.AppendLiteral("SELECT message_record.pk, member.nickname, message_record.title, member.account, member.mobile_country, member.mobile, message_record.create_time sent_time, message_record.read_time, member.is_test_account\n                            FROM `message_record`\n                            INNER JOIN member ON member.pk = message_record.sender_fk\n                            ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                            ORDER BY ISNULL(message_record.read_time) DESC, message_record.read_time DESC, message_record.pk DESC\n                            LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                            OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<MessageRecordList>(readConnection.QuerySingle<int>(sql), (IEnumerable<MessageRecordList>) readConnection.Query<MessageRecordList>(stringAndClear).AsList<MessageRecordList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][FindMessageRecordList]" + ex.Message);
        return new DataCountBase<MessageRecordList>();
      }
    }

    public static MessageRecordEditVm FindMessageRecordEditVm(int pk)
    {
      string sql1 = "SELECT message_record.sender_fk as receiver_fk, message_record.title, member.account, member.nickname, message_record.info, message_record.read_time as read_time FROM `message_record`\n                            INNER JOIN member ON member.pk = message_record.sender_fk\n                            WHERE message_record.pk = @pk";
      string sql2 = "UPDATE `message_record` SET \n                                `read_status` = 1,\n                                `read_time` = @read_time\n                                WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters1 = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          MessageRecordEditVm messageRecordEditVm = readConnection.QueryFirstOrDefault<MessageRecordEditVm>(sql1, (object) parameters1);
          if (!messageRecordEditVm.read_time.HasValue)
          {
            DateTime utcNow = DateTime.UtcNow;
            DynamicParameters parameters2 = DapperMysql.GetParameters((object) new
            {
              pk = pk,
              read_time = utcNow
            });
            readConnection.Execute(sql2, (object) parameters2);
            messageRecordEditVm.read_time = new DateTime?(utcNow);
          }
          return messageRecordEditVm;
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][FindMessageRecordEditVm]" + ex.Message);
        return (MessageRecordEditVm) null;
      }
    }

    public static long GetUnreadMessages()
    {
      try
      {
        string sql = "\n                    SELECT COUNT(*) FROM `message_record`\n                    INNER JOIN member ON member.pk = message_record.sender_fk\n                    WHERE classify = 2 AND receiver_table = 2 AND read_status = 0";
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<long>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageRecordService][GetUnreadMessages]" + ex.Message);
        return 0;
      }
    }
  }
}
