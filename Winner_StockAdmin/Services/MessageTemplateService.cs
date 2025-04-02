// Decompiled with JetBrains decompiler
// Type: DB.Services.MessageTemplateService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.MessageTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class MessageTemplateService
  {
    public static MessageTemplateDto Find(int pk)
    {
      string sql = "SELECT * FROM `message_template` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<MessageTemplateDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageTemplateService][Find]" + ex.Message);
        return (MessageTemplateDto) null;
      }
    }

    public static List<MessageTemplateDto> FindAll()
    {
      string sql = "SELECT * FROM `message_template`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<MessageTemplateDto>(sql).AsList<MessageTemplateDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageTemplateService][FindAll]" + ex.Message);
        return (List<MessageTemplateDto>) null;
      }
    }

    public static int FindPkAfterInsert(MessageTemplateDto source)
    {
      string sql = "INSERT INTO `message_template` (\r\n\t\t\t\t`temp_id`, `lang`, `status`, `name`, `type`, `receiver`, `title`, `title_param`, `param`, `template`, `remark`)\r\n\t\t\t\tVALUES (@temp_id, @lang, @status, @name, @type, @receiver, @title, @title_param, @param, @template, @remark);\r\n\r\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageTemplateService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(MessageTemplateDto model)
    {
      string sql = "UPDATE `message_template` SET \r\n\t\t\t\t`temp_id` = @temp_id,\r\n\t\t\t\t`lang` = @lang,\r\n\t\t\t\t`status` = @status,\r\n\t\t\t\t`name` = @name,\r\n\t\t\t\t`type` = @type,\r\n\t\t\t\t`receiver` = @receiver,\r\n\t\t\t\t`title` = @title,\r\n\t\t\t\t`title_param` = @title_param,\r\n\t\t\t\t`param` = @param,\r\n\t\t\t\t`template` = @template,\r\n\t\t\t\t`remark` = @remark\r\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageTemplateService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `message_template` WHERE `pk` = @pk";
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
        LogLib.Log("[MessageTemplateService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static MessageTemplateDto FindByTemplateId(int temp_id, string lang)
    {
      string sql = "SELECT * FROM message_template WHERE temp_id = @temp_id AND lang = @lang ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QuerySingleOrDefault<MessageTemplateDto>(sql, (object) new
          {
            temp_id = temp_id,
            lang = lang
          });
      }
      catch (Exception ex)
      {
        LogLib.Log(ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static DataCountBase<MessageTemplateList> FindMessageTemplateList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\r\n                        SELECT \r\n                            COUNT(*) AS count\r\n                        FROM \r\n                            `message_template` \r\n                        " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(538, 3);
      interpolatedStringHandler.AppendLiteral("\r\n                        SELECT \r\n                            pk,\r\n                            message_template.temp_id,message_template.lang,message_template.status,message_template.name,message_template.type,\r\n                            message_template.title,message_template.title_param,message_template.param,message_template.template,message_template.remark \r\n                        FROM \r\n                            `message_template` \r\n                        ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\r\n                        LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\r\n                        OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<MessageTemplateList>(readConnection.QuerySingle<int>(sql), (IEnumerable<MessageTemplateList>) readConnection.Query<MessageTemplateList>(stringAndClear).AsList<MessageTemplateList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[MessageTemplateService][FindMessageTemplateList]" + ex.Message);
        return new DataCountBase<MessageTemplateList>();
      }
    }
  }
}
