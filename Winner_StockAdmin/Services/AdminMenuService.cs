// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminMenuService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

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
  public class AdminMenuService
  {
    public static AdminMenuDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_menu` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminMenuDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminMenuService][Find]" + ex.Message);
        return (AdminMenuDto) null;
      }
    }

    public static List<AdminMenuDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_menu` order by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminMenuDto>(sql).AsList<AdminMenuDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminMenuService][FindAll]" + ex.Message);
        return (List<AdminMenuDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminMenuDto source)
    {
      string sql = "INSERT INTO `admin_menu` (\n\t\t\t\t`admin_module_fk`, `parent`, `module`, `title`, `title_key`, `icon`, `url_type`, `url_value`, `url_target`, `online_hide`, `sort`, `system_menu`, `status`, `parameter`)\n\t\t\t\tVALUES (@admin_module_fk, @parent, @module, @title, @title_key, @icon, @url_type, @url_value, @url_target, @online_hide, @sort, @system_menu, @status, @parameter);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminMenuService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminMenuDto model)
    {
      string sql = "UPDATE `admin_menu` SET \n\t\t\t\t`admin_module_fk` = @admin_module_fk,\n\t\t\t\t`parent` = @parent,\n\t\t\t\t`module` = @module,\n\t\t\t\t`title` = @title,\n\t\t\t\t`title_key` = @title_key,\n\t\t\t\t`icon` = @icon,\n\t\t\t\t`url_type` = @url_type,\n\t\t\t\t`url_value` = @url_value,\n\t\t\t\t`url_target` = @url_target,\n\t\t\t\t`online_hide` = @online_hide,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`system_menu` = @system_menu,\n\t\t\t\t`status` = @status,\n\t\t\t\t`parameter` = @parameter\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminMenuService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_menu` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminMenuService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminMenuDto> FindAllByFirstMenu(string lang = "CN")
    {
      string sql = "SELECT *, admin_menu.pk AS pk, mt.value AS title\n                            FROM `admin_menu`\n                            LEFT JOIN mutilang_table mt ON mt.dbtable = 'admin_menu' AND mt.lang = '" + lang.ToUpper() + "' AND mt.key = admin_menu.url_value\n                            WHERE admin_menu.pk = admin_menu.parent AND admin_menu.status = 1";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminMenuDto>(sql).AsList<AdminMenuDto>();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log(ex.Message);
        return (List<AdminMenuDto>) null;
      }
    }

    public static List<AdminMenuDto> FindAllByFirstMenu()
    {
      string sql = string.Format("SELECT * FROM `admin_menu` WHERE pk = parent AND status = 1");
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminMenuDto>(sql).AsList<AdminMenuDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log(ex.Message);
        return (List<AdminMenuDto>) null;
      }
    }
  }
}
