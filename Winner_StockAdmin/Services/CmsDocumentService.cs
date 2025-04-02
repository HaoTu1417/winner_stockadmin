// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsDocumentService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Document;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsDocumentService
  {
    public static CmsDocumentDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_document` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsDocumentDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][Find]" + ex.Message);
        return (CmsDocumentDto) null;
      }
    }

    public static CmsDocumentDto FindByCIDLANG(string cid, string lang)
    {
      string sql = "SELECT * FROM `cms_document` WHERE `cid` = @cid and `lang` = @lang";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            cid = cid,
            lang = lang
          });
          return readConnection.QueryFirstOrDefault<CmsDocumentDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][FindByCIDLANG]" + ex.Message);
        return (CmsDocumentDto) null;
      }
    }

    public static List<CmsDocumentDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_document`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsDocumentDto>(sql).AsList<CmsDocumentDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][FindAll]" + ex.Message);
        return (List<CmsDocumentDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsDocumentDto source)
    {
      string sql = "INSERT INTO `cms_document` (\n\t\t\t\t`cid`, `lang`, `title`, `content`, `flag`, `view`, `comment`, `good`, `bad`, `mark`, `sort`, `status`, `trash`)\n\t\t\t\tVALUES (@cid, @lang, @title, @content, @flag, @view, @comment, @good, @bad, @mark, @sort, @status, @trash);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsDocumentDto model)
    {
      string sql = "UPDATE `cms_document` SET \n\t\t\t\t`cid` = @cid,\n\t\t\t\t`lang` = @lang,\n\t\t\t\t`title` = @title,\n\t\t\t\t`content` = @content,\n\t\t\t\t`flag` = @flag,\n\t\t\t\t`view` = @view,\n\t\t\t\t`comment` = @comment,\n\t\t\t\t`good` = @good,\n\t\t\t\t`bad` = @bad,\n\t\t\t\t`mark` = @mark,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`status` = @status,\n\t\t\t\t`trash` = @trash\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_document` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsDocumentService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<DocumentList> FindDocumentList(string whereSql = "")
    {
      string sql = "SELECT cms_document.pk, cms_document.cid, cms_document.lang, cms_document.title, cms_document.view, cms_document.status FROM `cms_document`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<DocumentList>(sql).AsList<DocumentList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsDocumentService][FindDocumentList]" + ex.Message);
        return (List<DocumentList>) null;
      }
    }
  }
}
