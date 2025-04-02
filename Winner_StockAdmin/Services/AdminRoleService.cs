// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminRoleService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminRole;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class AdminRoleService
  {
    public static AdminRoleDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_role` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminRoleDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][Find]" + ex.Message);
        return (AdminRoleDto) null;
      }
    }

    public static List<AdminRoleDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_role`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminRoleDto>(sql).AsList<AdminRoleDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][FindAll]" + ex.Message);
        return (List<AdminRoleDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminRoleDto source)
    {
      string sql = "INSERT INTO `admin_role` (\n\t\t\t\t`admin_module_fk`, `name`, `description`, `model`, `admin_menu`, `sort`, `status`, `lock_delete`, `is_super`)\n\t\t\t\tVALUES (@admin_module_fk, @name, @description, @model, @admin_menu, @sort, @status, @lock_delete, @is_super);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminRoleDto model)
    {
      string sql = "UPDATE `admin_role` SET \n                `admin_module_fk` = @admin_module_fk,\n\t\t\t\t`name` = @name,\n\t\t\t\t`description` = @description,\n\t\t\t\t`model` = @model,\n\t\t\t\t`admin_menu` = @admin_menu,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status,\n\t\t\t\t`lock_delete` = @lock_delete,\n                `is_super` = @is_super\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `admin_role` WHERE `pk` = @pk";
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
        LogLib.Log("[AdminRoleService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminRoleList> FindAdminRoleList()
    {
      string sql = "SELECT admin_module_fk, pk, name, description, status, is_super  FROM `admin_role` ORDER BY sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminRoleList>(sql).AsList<AdminRoleList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][FindAdminRoleList]" + ex.Message);
        return (List<AdminRoleList>) null;
      }
    }

    internal static AdminRoleList FindAdminRole(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(94, 1);
      interpolatedStringHandler.AppendLiteral("SELECT admin_module_fk, pk, name, description, status, is_super  FROM `admin_role` where pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<AdminRoleList>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminRoleService][FindAdminRoleList]" + ex.Message);
        return (AdminRoleList) null;
      }
    }
  }
}
