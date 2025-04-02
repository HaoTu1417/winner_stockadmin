// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.QuestionCategoryController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.QuestionCategory;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("QuestionCategory")]
  public class QuestionCategoryController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(139, 7)]
    public IActionResult Index(QuestionCategoryFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      QuestionCategoryVm questionCategoryVm = new QuestionCategoryVm()
      {
        filter = filter ?? new QuestionCategoryFilter()
      };
      try
      {
        questionCategoryVm.list = QuestionCategoryBiz.GetQuestionCategoryList(questionCategoryVm.filter).ToPagedList<QuestionCategoryList>(page, this.pageSize);
        return (IActionResult) this.View((object) questionCategoryVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) questionCategoryVm);
      }
    }

    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (QuestionCategoryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (QuestionCategoryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) QuestionCategoryController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
    }

    [UseFilter(139, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) QuestionCategoryBiz.Get(pk));
    }

    public IActionResult PostEdit(CmsQuestionCategoryDto req)
    {
      this.SetSelect();
      try
      {
        QuestionCategoryBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(139, 7)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsQuestionCategoryDto());
    }

    public IActionResult PostCreate(CmsQuestionCategoryDto req)
    {
      this.SetSelect();
      try
      {
        QuestionCategoryBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(139, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        QuestionCategoryBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
