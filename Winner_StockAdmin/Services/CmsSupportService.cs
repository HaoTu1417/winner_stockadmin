// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsSupportService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.CmsSupport;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsSupportService
  {
    public static CmsSupportDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_support` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsSupportDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsSupportService][Find]" + ex.Message);
        return (CmsSupportDto) null;
      }
    }

    public static List<CmsSupportDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_support`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsSupportDto>(sql).AsList<CmsSupportDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsSupportService][FindAll]" + ex.Message);
        return (List<CmsSupportDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsSupportDto source)
    {
      string sql = "INSERT INTO `cms_support` (\n\t\t\t\t`lang`, `svc_phone`, `svc_workday`, `svc_nonworkday`, `svc_email`, `svc_link`)\n\t\t\t\tVALUES (@lang, @svc_phone, @svc_workday, @svc_nonworkday, @svc_email, @svc_link);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsSupportService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsSupportDto model)
    {
      string sql = "UPDATE `cms_support` SET \n\t\t\t\t`lang` = @lang,\n\t\t\t\t`svc_phone` = @svc_phone,\n\t\t\t\t`svc_workday` = @svc_workday,\n\t\t\t\t`svc_nonworkday` = @svc_nonworkday,\n\t\t\t\t`svc_email` = @svc_email,\n\t\t\t\t`svc_link` = @svc_link\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsSupportService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_support` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsSupportService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<CmsSupportList> FindCmsSupportList(string whereSql = "")
    {
      string sql = "SELECT cms_support.pk, cms_support.lang, cms_support.svc_phone, cms_support.svc_workday, cms_support.svc_nonworkday, cms_support.svc_email, cms_support.svc_link FROM `cms_support`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsSupportList>(sql).AsList<CmsSupportList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsSupportService][FindCmsSupportList]" + ex.Message);
        return (List<CmsSupportList>) null;
      }
    }
  }
}
