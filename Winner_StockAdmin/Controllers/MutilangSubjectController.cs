// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MutilangSubjectController
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
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("MutilangSubject")]
  public class MutilangSubjectController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (MutilangSubjectController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MutilangSubjectController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (MutilangSubjectController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = MutilangSubjectController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) MutilangSubjectController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(228, 9)]
    public IActionResult Index()
    {
      this.SetSelect();
      try
      {
        return (IActionResult) this.View((object) MutilangSubjectBiz.GetMutilangSubjectList());
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new List<MutilangSubjectDto>());
      }
    }

    [UseFilter(228, 9)]
    public IActionResult Edit(string lang)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) MutilangSubjectBiz.Get(lang));
    }

    public IActionResult PostEdit(MutilangSubjectDto req)
    {
      this.SetSelect();
      try
      {
        MutilangSubjectBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(228, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new MutilangSubjectDto());
    }

    public IActionResult PostCreate(MutilangSubjectDto req)
    {
      this.SetSelect();
      try
      {
        MutilangSubjectBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(228, 9)]
    public IActionResult Delete(string lang)
    {
      try
      {
        MutilangSubjectBiz.Delete(lang, this.GetUser());
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
