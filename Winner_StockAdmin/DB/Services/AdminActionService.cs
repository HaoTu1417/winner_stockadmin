// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminActionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/www/service/stockadmin/stockadmin.dll

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
  public class AdminActionService
  {
    public static AdminActionDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_action` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminActionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminActionService][Find]" + ex.Message);
        return (AdminActionDto) null;
      }
    }

    public static AdminActionDto FindByAdminMenu(int admin_menu_fk, string lang)
    {
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          string sql = "SELECT * FROM admin_action WHERE admin_menu_fk = @Admin_menu_fk and lang = @Lang;";
          var data = new
          {
            Admin_menu_fk = admin_menu_fk,
            Lang = lang
          };
          return readConnection.QuerySingleOrDefault<AdminActionDto>(sql, (object) data);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminActionService][FindByAdminMenu]" + ex.Message);
        return (AdminActionDto) null;
      }
    }

    public static List<AdminActionDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_action`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminActionDto>(sql).AsList<AdminActionDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminActionService][FindAll]" + ex.Message);
        return (List<AdminActionDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminActionDto source)
    {
      string sql = "INSERT INTO `admin_action` (\n\t\t\t\t`admin_menu_fk`, `lang`, `title`, `module`, `method`, `remark`, `param`, `log`, `status`)\n\t\t\t\tVALUES (@admin_menu_fk, @lang, @title, @module, @method, @remark, @param, @log, @status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminActionService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminActionDto model)
    {
      string sql = "UPDATE `admin_action` SET \n\t\t\t\t`admin_menu_fk` = @admin_menu_fk,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`title` = @title,\n\t\t\t\t`module` = @module,\n\t\t\t\t`method` = @method,\n\t\t\t\t`remark` = @remark,\n\t\t\t\t`param` = @param,\n\t\t\t\t`log` = @log,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminActionService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_action` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminActionService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
