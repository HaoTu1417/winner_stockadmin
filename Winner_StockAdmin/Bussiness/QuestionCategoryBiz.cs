// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.QuestionCategoryBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.QuestionCategory;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class QuestionCategoryBiz
  {
    public static List<QuestionCategoryList> GetQuestionCategoryList(QuestionCategoryFilter? filter)
    {
      return CmsQuestionCategoryService.FindQuestionCategoryList(SqlTool.Build<QuestionCategoryFilter>(filter));
    }

    public static CmsQuestionCategoryDto Get(int pk) => CmsQuestionCategoryService.Find(pk);

    public static async void PostCreate(CmsQuestionCategoryDto req, AdminSession adminUser)
    {
      if (req.image != null)
        req.icon = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.image);
      if (CmsQuestionCategoryService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.label
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 140,
        list = objArray
      });
    }

    public static async void PostEdit(CmsQuestionCategoryDto req, AdminSession adminUser)
    {
      if (req.image != null)
        req.icon = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.image);
      if (CmsQuestionCategoryService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.label
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 139,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      CmsQuestionCategoryService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 141,
        list = objArray
      });
    }

    public static List<SelectListItem> GetDropDownList(string lang)
    {
      List<SelectListItem> dropDownList = new List<SelectListItem>();
      foreach (CmsQuestionCategoryDto questionCategoryDto in CmsQuestionCategoryService.FindDropDown(lang))
      {
        List<SelectListItem> selectListItemList = dropDownList;
        SelectListItem selectListItem = new SelectListItem();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(questionCategoryDto.pk);
        selectListItem.Value = interpolatedStringHandler.ToStringAndClear();
        selectListItem.Text = questionCategoryDto.label;
        selectListItemList.Add(selectListItem);
      }
      return dropDownList;
    }
  }
}
