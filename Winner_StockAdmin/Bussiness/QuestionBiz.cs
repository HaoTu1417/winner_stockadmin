// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.QuestionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.Question;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class QuestionBiz
  {
    public static List<QuestionList> GetQuestionList(QuestionFilter? filter)
    {
      return CmsQuestionService.FindQuestionList(SqlTool.Build<QuestionFilter>(filter));
    }

    public static CmsQuestionDto Get(int pk) => CmsQuestionService.Find(pk);

    public static void PostCreate(CmsQuestionDto req, AdminSession adminUser)
    {
      if (req.question_category_fk == 0)
        throw new AppException(3010, "record_update_false");
      if (CmsQuestionService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.question
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 126,
        list = objArray
      });
    }

    public static void PostEdit(CmsQuestionDto req, AdminSession adminUser)
    {
      if (req.question_category_fk == 0)
        throw new AppException(3010, "record_update_false");
      if (CmsQuestionService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.question
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 125,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string question = CmsQuestionService.Find(pk).question;
      CmsQuestionService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) question
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = (int) sbyte.MaxValue,
        list = objArray
      });
    }
  }
}
