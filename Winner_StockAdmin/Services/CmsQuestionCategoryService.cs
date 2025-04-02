// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsQuestionCategoryService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.QuestionCategory;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsQuestionCategoryService
  {
    public static List<CmsQuestionCategoryDto> FindDropDown(string lang)
    {
      string sql = "SELECT * FROM `cms_question_category` ";
      if (!string.IsNullOrWhiteSpace(lang))
        sql += " WHERE `lang` = @lang";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsQuestionCategoryDto>(sql, (object) new
          {
            lang = lang.ToUpper()
          }).AsList<CmsQuestionCategoryDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][FindDropDown]" + ex.Message);
        return (List<CmsQuestionCategoryDto>) null;
      }
    }

    public static CmsQuestionCategoryDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_question_category` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsQuestionCategoryDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionCategoryService][Find]" + ex.Message);
        return (CmsQuestionCategoryDto) null;
      }
    }

    public static List<CmsQuestionCategoryDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_question_category`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsQuestionCategoryDto>(sql).AsList<CmsQuestionCategoryDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionCategoryService][FindAll]" + ex.Message);
        return (List<CmsQuestionCategoryDto>) null;
      }
    }

    public static int Insert(CmsQuestionCategoryDto model)
    {
      string sql = "INSERT INTO `cms_question_category` (\n\t\t\t\t`enable`, `label`, `icon`, `sort`, `lang`)\n\t\t\t\tVALUES (@enable, @label, @icon, @sort, @lang); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionCategoryService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsQuestionCategoryDto model)
    {
      string sql = "UPDATE `cms_question_category` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`label` = @label,\n\t\t\t\t`icon` = @icon,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`lang` = @lang\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionCategoryService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_question_category` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsQuestionCategoryService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<QuestionCategoryList> FindQuestionCategoryList(string whereSql = "")
    {
      string sql = "SELECT cms_question_category.pk, cms_question_category.enable, cms_question_category.label, \n                cms_question_category.icon, cms_question_category.sort, cms_question_category.lang\n                FROM `cms_question_category`\n                " + whereSql + " order by sort";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<QuestionCategoryList>(sql).AsList<QuestionCategoryList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionCategoryService][FindQuestionCategoryList]" + ex.Message);
        return (List<QuestionCategoryList>) null;
      }
    }
  }
}
