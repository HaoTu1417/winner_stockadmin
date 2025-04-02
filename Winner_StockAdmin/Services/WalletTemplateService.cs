// Decompiled with JetBrains decompiler
// Type: DB.Services.WalletTemplateService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.WalletTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class WalletTemplateService
  {
    public static WalletTemplateDto Find(int pk)
    {
      string sql = "SELECT * FROM `wallet_template` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<WalletTemplateDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][Find]" + ex.Message);
        return (WalletTemplateDto) null;
      }
    }

    public static List<WalletTemplateDto> FindAll()
    {
      string sql = "SELECT * FROM `wallet_template`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<WalletTemplateDto>(sql).AsList<WalletTemplateDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][FindAll]" + ex.Message);
        return (List<WalletTemplateDto>) null;
      }
    }

    public static int FindPkAfterInsert(WalletTemplateDto source)
    {
      string sql = "INSERT INTO `wallet_template` (\n\t\t\t\t`temp_id`, `lang`, `name`, `template`, `param`, `demo`)\n\t\t\t\tVALUES (@temp_id, @lang, @name, @template, @param, @demo);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(WalletTemplateDto model)
    {
      string sql = "UPDATE `wallet_template` SET \n\t\t\t\t`temp_id` = @temp_id,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`name` = @name,\n\t\t\t\t`template` = @template,\n\t\t\t\t`param` = @param,\n\t\t\t\t`demo` = @demo\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `wallet_template` WHERE `pk` = @pk";
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
        LogLib.Log("[WalletTemplateService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static WalletTemplateDto GetByTempId(int temp_id, string lang)
    {
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          string sql = "SELECT * FROM wallet_template WHERE temp_Id = @temp_Id and Lang = @Lang;";
          var data = new{ temp_Id = temp_id, Lang = lang };
          return readConnection.QuerySingleOrDefault<WalletTemplateDto>(sql, (object) data);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static DataCountBase<WalletTemplateList> FindWalletTemplateList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                            SELECT \n                                COUNT(*) AS count\n                            FROM `wallet_template`\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(374, 3);
      interpolatedStringHandler.AppendLiteral("SELECT \n                            wallet_template.pk, wallet_template.temp_id, wallet_template.lang, wallet_template.name,\n                            wallet_template.template,wallet_template.param, wallet_template.demo \n                            FROM `wallet_template`\n                            ");
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
          return new DataCountBase<WalletTemplateList>(readConnection.QuerySingle<int>(sql), (IEnumerable<WalletTemplateList>) readConnection.Query<WalletTemplateList>(stringAndClear).AsList<WalletTemplateList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][FindWalletTemplateList]" + ex.Message);
        return new DataCountBase<WalletTemplateList>();
      }
    }

    public static WalletTemplateEditVm FindWalletTemplateEditVm(int pk)
    {
      string sql = "SELECT wallet_template.pk, wallet_template.temp_id, wallet_template.lang, wallet_template.name, wallet_template.template, wallet_template.param, wallet_template.demo FROM `wallet_template`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<WalletTemplateEditVm>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[WalletTemplateService][FindWalletTemplateEditVm]" + ex.Message);
        return (WalletTemplateEditVm) null;
      }
    }
  }
}
