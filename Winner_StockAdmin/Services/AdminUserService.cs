// Decompiled with JetBrains decompiler
// Type: DB.Services.AdminUserService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.AdminUser;
using stockadmin.ViewModels.Login;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class AdminUserService
  {
    public static AdminUserDto FindByAccount(string account)
    {
      string sql = "SELECT * FROM `admin_user` where account = @account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<AdminUserDto>(sql, (object) new
          {
            account = account
          });
      }
      catch (Exception ex)
      {
        LogLib.Log(ex.Message);
        return (AdminUserDto) null;
      }
    }

    public static AdminUserDto Find(int pk)
    {
      string sql = "SELECT * FROM `admin_user` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AdminUserDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][Find]" + ex.Message);
        return (AdminUserDto) null;
      }
    }

    public static bool FindIsSuper(int pk)
    {
      string sql = "SELECT admin_role.is_super FROM `admin_user`\n                        INNER JOIN admin_role on admin_user.role = admin_role.pk\n                        WHERE admin_user.pk = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<bool>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][FindIsSuper]" + ex.Message);
        return false;
      }
    }

    public static List<AdminUserDto> FindByRole(int role)
    {
      string sql = "SELECT * FROM `admin_user` WHERE `role` = @role";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DapperMysql.GetParameters((object) new
          {
            role = role
          });
          return readConnection.Query<AdminUserDto>(sql, (object) new
          {
            role = role
          }).AsList<AdminUserDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][Find]" + ex.Message);
        return (List<AdminUserDto>) null;
      }
    }

    public static List<AdminUserDto> FindAll()
    {
      string sql = "SELECT * FROM `admin_user` where is_delete = false order by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminUserDto>(sql).AsList<AdminUserDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][FindAll]" + ex.Message);
        return (List<AdminUserDto>) null;
      }
    }

    public static int FindPkAfterInsert(AdminUserDto source)
    {
      string sql = "INSERT INTO `admin_user` (\n\t\t\t\t`account`, `role`, `password`, `status`, `nickname`, `is_admin`, `mobile`, `email`, `avatar`, `sort`, `lang`, `change_password`)\n\t\t\t\tVALUES (@account, @role, @password, @status, @nickname, @is_admin, @mobile, @email, @avatar, @sort, @lang, @change_password);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(AdminUserDto model)
    {
      string sql = "UPDATE `admin_user` SET \n\t\t\t\t`account` = @account,\n\t\t\t\t`role` = @role,\n\t\t\t\t`status` = @status,\n\t\t\t\t`nickname` = @nickname,\n\t\t\t\t`is_admin` = @is_admin,\n\t\t\t\t`mobile` = @mobile,\n\t\t\t\t`email` = @email,\n\t\t\t\t`avatar` = @avatar,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`last_login_time` = @last_login_time,\n\t\t\t\t`last_login_ip` = @last_login_ip,\n\t\t\t\t`change_password` = @change_password\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int SetLang(int pk, string lang)
    {
      string sql = "UPDATE `admin_user` SET \n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk,
            lang = lang
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][SetLang]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateLoginInfo(int pk, string ip)
    {
      string sql = "UPDATE `admin_user` SET\n\t\t\t\t`last_login_time` = @login_time,\n                `last_login_ip` = @ip\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DateTime utcNow = DateTime.UtcNow;
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            login_time = utcNow,
            ip = ip,
            pk = pk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][UpdateLoginTime]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    internal static void UpdateIInvitationCode(int adminUserId, string invitationCode)
    {
      string sql = "UPDATE `admin_user` SET \n                `invitation_code` = @invitationCode\n                 WHERE `pk` = @adminUserId";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            invitationCode = invitationCode,
            adminUserId = adminUserId
          });
          writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][UpdateIInvitationCode]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "UPDATE `admin_user` SET is_delete = 1 WHERE `pk` = @pk";
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
        LogLib.Log("[AdminUserService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static string GetMfaSecret(int pk)
    {
      string sql = "\nSELECT `mfa_secret`\nFROM `admin_user`\nWHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QuerySingleOrDefault<string>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][GetMfaSecret]" + ex.Message);
        return (string) null;
      }
    }

    public static int UpdateMfaSecret(int pk, string? secret)
    {
      string sql = "\nUPDATE `admin_user`\nSET mfa_secret=@secret\nWHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk,
            secret = secret
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][UpdateMfaSecret]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AdminUserList> FindAdminUserList(string whereSql = "")
    {
      string sql = "SELECT admin_user.pk, admin_user.account, admin_user.nickname, admin_role.name, \n                admin_user.status, admin_user.is_admin, admin_user.is_delete, admin_user.sort, admin_user.lang, admin_role.is_super, admin_user.last_login_time \n                FROM `admin_user`\n                INNER JOIN admin_role ON admin_role.pk = admin_user.role \n                " + whereSql + " order by admin_user.role, admin_user.account";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminUserList>(sql).AsList<AdminUserList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][FindAdminUserList]" + ex.Message);
        return (List<AdminUserList>) null;
      }
    }

    public static List<AdminListVm> FindAdminList()
    {
      string sql = "SELECT account, nickname FROM `admin_user` where status = 1 order by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AdminListVm>(sql).AsList<AdminListVm>();
      }
      catch (Exception ex)
      {
        LogLib.Log(ex.Message);
        return (List<AdminListVm>) null;
      }
    }

    public static int UpdatePassword(string account, string newpassword, bool needChangePassword)
    {
      string sql = "UPDATE `admin_user` SET\n\t\t\t\t`password` = @newpassword,\n\t\t\t\t`change_password` = @needChangePassword\n\t\t\t\t WHERE `account` = @account ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            newpassword = newpassword,
            needChangePassword = needChangePassword,
            account = account
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[AdminUserService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int CountByRole(int role_pk)
    {
      string sql = "SELECT COUNT(*) FROM admin_user WHERE role = @role_pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          role_pk = role_pk
        });
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[AdminUserService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
