// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminModuleService
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
  public class AdminModuleService
  {
    public static AdminModuleDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_module` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminModuleDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][Find]" + ex.Message);
        return (AdminModuleDto) null;
      }
    }

    public static AdminModuleDto? FindByAdminUser(int admin_user_pk)
    {
      string sql = "\nSELECT T1.* \nFROM `admin_module` T1\nINNER JOIN `admin_role` T2 ON (T1.pk = T2.admin_module_fk)\nINNER JOIN `admin_user` T3 ON (T2.pk = T3.role)\nWHERE T3.`pk` = @admin_user_pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            admin_user_pk = admin_user_pk
          });
          return readConnection.QueryFirstOrDefault<AdminModuleDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][Find]" + ex.Message);
        return (AdminModuleDto) null;
      }
    }

    public static List<AdminModuleDto> FindAll(string lang)
    {
      string sql = "SELECT *, admin_module.pk AS pk, mt.value as title FROM `admin_module`\n                           LEFT JOIN mutilang_table mt ON mt.dbtable = 'admin_module' AND mt.lang = '" + lang.ToUpper() + "' AND mt.key = admin_module.name\n                           order by sort\n                           ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminModuleDto>(sql).AsList<AdminModuleDto>();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[AdminModuleService][FindAll]" + ex.Message);
        return (List<AdminModuleDto>) null;
      }
    }

    public static List<AdminModuleDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_module` order by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminModuleDto>(sql).AsList<AdminModuleDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][FindAll]" + ex.Message);
        return (List<AdminModuleDto>) null;
      }
    }

    public static List<AdminModuleDto> FindAll(int status)
    {
      string sql = "\nSELECT * FROM `admin_module` \nWHERE status = @status\norder by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          var data = new{ status = status };
          return readConnection.Query<AdminModuleDto>(sql, (object) data).AsList<AdminModuleDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][FindAll]" + ex.Message);
        return (List<AdminModuleDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminModuleDto source)
    {
      string sql = "INSERT INTO `admin_module` (\n\t\t\t\t`name`, `title`, `icon`, `description`, `identifier`, `system_module`, `sort`, `status`)\n\t\t\t\tVALUES (@name, @title, @icon, @description, @identifier, @system_module, @sort, @status);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminModuleDto model)
    {
      string sql = "UPDATE `admin_module` SET \n\t\t\t\t`name` = @name,\n\t\t\t\t`title` = @title,\n\t\t\t\t`icon` = @icon,\n\t\t\t\t`description` = @description,\n\t\t\t\t`identifier` = @identifier,\n\t\t\t\t`system_module` = @system_module,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminModuleService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_module` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminModuleService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
