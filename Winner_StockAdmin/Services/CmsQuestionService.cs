// Decompiled with JetBrains decompiler
// Type: DB.Services.CmsQuestionService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Question;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class CmsQuestionService
  {
    public static CmsQuestionDto Find(int pk)
    {
      string sql = "SELECT * FROM `cms_question` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<CmsQuestionDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][Find]" + ex.Message);
        return (CmsQuestionDto) null;
      }
    }

    public static List<CmsQuestionDto> FindAll()
    {
      string sql = "SELECT * FROM `cms_question`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<CmsQuestionDto>(sql).AsList<CmsQuestionDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][FindAll]" + ex.Message);
        return (List<CmsQuestionDto>) null;
      }
    }

    public static int FindPkAfterInsert(CmsQuestionDto source)
    {
      string sql = "INSERT INTO `cms_question` (\n\t\t\t\t`question_category_fk`, `lang`, `question`, `answer`, `enable`, `commonly_used`, `sort`)\n\t\t\t\tVALUES (@question_category_fk, @lang, @question, @answer, @enable, @commonly_used, @sort);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(CmsQuestionDto model)
    {
      string sql = "UPDATE `cms_question` SET \n\t\t\t\t`question_category_fk` = @question_category_fk,\n                `lang` = @lang,\n\t\t\t\t`question` = @question,\n\t\t\t\t`answer` = @answer,\n\t\t\t\t`enable` = @enable,\n\t\t\t\t`commonly_used` = @commonly_used,\n\t\t\t\t`sort` = @sort\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `cms_question` WHERE `pk` = @pk";
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
        LogLib.Log("[CmsQuestionService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<QuestionList> FindQuestionList(string whereSql = "")
    {
      string sql = "SELECT cq.question_category_fk, cq.pk, cq.lang, cq.question, cq.enable, cq.commonly_used, cq.sort, cqc.label AS question_category_text FROM `cms_question` AS cq LEFT JOIN cms_question_category AS cqc ON cqc.pk=cq.question_category_fk " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<QuestionList>(sql).AsList<QuestionList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[CmsQuestionService][FindQuestionList]" + ex.Message);
        return (List<QuestionList>) null;
      }
    }
  }
}
