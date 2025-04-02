// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.QuestionController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Question")]
  public class QuestionController : BaseController
  {
    public void SetSelect(string? lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (QuestionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "questionCategory", typeof (QuestionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) QuestionController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, QuestionCategoryBiz.GetDropDownList(lang == null ? "" : lang));
    }

    [MenuFilter(125, 7)]
    public IActionResult Index(QuestionFilter filter, int page = 1)
    {
      this.SetSelect("");
      QuestionVm questionVm = new QuestionVm()
      {
        filter = filter ?? new QuestionFilter()
      };
      try
      {
        questionVm.list = QuestionBiz.GetQuestionList(questionVm.filter).ToPagedList<QuestionList>(page, this.pageSize);
        return (IActionResult) this.View((object) questionVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) questionVm);
      }
    }

    [UseFilter(125, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect("");
      CmsQuestionDto cmsQuestionDto = QuestionBiz.Get(pk);
      if (cmsQuestionDto.answer != null)
        cmsQuestionDto.answer = UploadImageLib.AddHostName(cmsQuestionDto.answer);
      return (IActionResult) this.View((object) cmsQuestionDto);
    }

    [MenuFilter(125, 7)]
    public IActionResult PostEdit(CmsQuestionDto req)
    {
      this.SetSelect("");
      try
      {
        req.answer = UploadImageLib.RemoveHostName(req.answer);
        QuestionBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(125, 7)]
    public IActionResult Create(string? lang)
    {
      this.SetSelect(lang);
      return (IActionResult) this.View((object) new CmsQuestionDto());
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile upload)
    {
      QuestionController questionController = this;
      try
      {
        string str = await UploadBiz.UploadImage(upload, FileManagementLib.Folder.article);
        return (IActionResult) new JsonResult((object) new UploadSuccess()
        {
          uploaded = 1,
          url = str
        });
      }
      catch (AppException ex)
      {
        questionController.ShowError(ex.Message);
        return (IActionResult) questionController.View();
      }
    }

    [MenuFilter(125, 7)]
    public IActionResult PostCreate(CmsQuestionDto req)
    {
      this.SetSelect("");
      try
      {
        req.answer = UploadImageLib.RemoveHostName(req.answer);
        QuestionBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(125, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        QuestionBiz.Delete(pk, this.GetUser());
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
