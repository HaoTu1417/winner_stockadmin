// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.SysCountryController
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
using stockadmin.ViewModels.SysCountry;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("SysCountry")]
  public class SysCountryController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (SysCountryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (SysCountryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) SysCountryController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
    }

    [MenuFilter(424, 9)]
    public IActionResult Index(SysCountryFilter filter, int page = 1)
    {
      this.SetSelect();
      SysCountryVm sysCountryVm = new SysCountryVm()
      {
        filter = filter ?? new SysCountryFilter()
      };
      try
      {
        sysCountryVm.list = SysCountryBiz.GetSysCountryList(sysCountryVm.filter).ToPagedList<SysCountryList>(page, this.pageSize);
        return (IActionResult) this.View((object) sysCountryVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) sysCountryVm);
      }
    }

    [UseFilter(424, 9)]
    public IActionResult Edit(string pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) SysCountryBiz.Get(pk));
    }

    public IActionResult PostEdit(SysCountryDto req)
    {
      this.SetSelect();
      try
      {
        SysCountryBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(424, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new SysCountryDto());
    }

    public IActionResult PostCreate(SysCountryDto req)
    {
      this.SetSelect();
      try
      {
        SysCountryBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(424, 9)]
    public IActionResult Delete(string pk)
    {
      try
      {
        SysCountryBiz.Delete(pk, this.GetUser());
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
