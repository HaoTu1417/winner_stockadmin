// Decompiled with JetBrains decompiler
// Type: DB.Services.TradeTemplateService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.TradeTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class TradeTemplateService
  {
    public static TradeTemplateDto Find(int pk)
    {
      string sql = "SELECT * FROM `trade_template` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<TradeTemplateDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][Find]" + ex.Message);
        return (TradeTemplateDto) null;
      }
    }

    public static List<TradeTemplateDto> FindAll()
    {
      string sql = "SELECT * FROM `trade_template`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeTemplateDto>(sql).AsList<TradeTemplateDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][FindAll]" + ex.Message);
        return (List<TradeTemplateDto>) null;
      }
    }

    public static List<TradeTemplateDto> FindDropDown(string lang)
    {
      string sql = "SELECT `temp_id`, `name` FROM trade_template\n                WHERE `lang` = @lang ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<TradeTemplateDto>(sql, (object) new
          {
            lang = lang.ToUpper()
          }).AsList<TradeTemplateDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][FindDropDown]" + ex.Message);
        return (List<TradeTemplateDto>) null;
      }
    }

    public static int FindPkAfterInsert(TradeTemplateDto source)
    {
      string sql = "INSERT INTO `trade_template` (\n\t\t\t\t`temp_id`, `lang`, `name`, `template`, `param`, `demo`)\n\t\t\t\tVALUES (@temp_id, @lang, @name, @template, @param, @demo);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(TradeTemplateDto model)
    {
      string sql = "UPDATE `trade_template` SET \n\t\t\t\t`temp_id` = @temp_id,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`name` = @name,\n\t\t\t\t`template` = @template,\n\t\t\t\t`param` = @param,\n\t\t\t\t`demo` = @demo\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `trade_template` WHERE `pk` = @pk";
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
        LogLib.Log("[TradeTemplateService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<TradeTemplateList> FindTradeTemplateList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                            SELECT \n                                COUNT(*) AS count\n                            FROM `trade_template`\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(367, 3);
      interpolatedStringHandler.AppendLiteral("SELECT \n                            trade_template.pk, trade_template.temp_id, trade_template.lang, trade_template.name,\n                            trade_template.template, trade_template.param, trade_template.demo \n                            FROM `trade_template`\n                            ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                            LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                            OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<TradeTemplateList>(readConnection.QuerySingle<int>(sql), (IEnumerable<TradeTemplateList>) readConnection.Query<TradeTemplateList>(stringAndClear).AsList<TradeTemplateList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][FindTradeTemplateList]" + ex.Message);
        return new DataCountBase<TradeTemplateList>();
      }
    }

    public static TradeTemplateDto GetByTempId(int tempId, string lang)
    {
      string sql = "SELECT * FROM `trade_template` WHERE `temp_id` = @tempId AND `lang` = @lang;";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            tempId = tempId,
            lang = lang
          });
          return readConnection.QueryFirstOrDefault<TradeTemplateDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[TradeTemplateService][GetByTempId]" + ex.Message);
        return (TradeTemplateDto) null;
      }
    }
  }
}
