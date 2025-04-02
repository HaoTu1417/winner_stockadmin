// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.CmsSupportController
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
using stockadmin.Tool;
using stockadmin.ViewModels.CmsSupport;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("CmsSupport")]
  public class CmsSupportController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (CmsSupportController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CmsSupportController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (CmsSupportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = CmsSupportController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) CmsSupportController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(23, 9)]
    public IActionResult Index(CmsSupportFilter filter, int page = 1)
    {
      this.SetSelect();
      CmsSupportVm cmsSupportVm = new CmsSupportVm()
      {
        filter = filter ?? new CmsSupportFilter()
      };
      try
      {
        List<CmsSupportList> cmsSupportList = CmsSupportBiz.GetCmsSupportList(cmsSupportVm.filter);
        cmsSupportVm.list = cmsSupportList.ToPagedList<CmsSupportList>(page, this.pageSize);
        return (IActionResult) this.View((object) cmsSupportVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) cmsSupportVm);
      }
    }

    [UseFilter(23, 9)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<CmsSupportDto>(CmsSupportBiz.Get(pk)));
    }

    public IActionResult PostEdit(CmsSupportDto req)
    {
      this.SetSelect();
      try
      {
        CmsSupportBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(23, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsSupportDto());
    }

    public IActionResult PostCreate(CmsSupportDto req)
    {
      this.SetSelect();
      try
      {
        CmsSupportBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(23, 9)]
    public IActionResult Delete(int pk)
    {
      try
      {
        CmsSupportBiz.Delete(pk, this.GetUser());
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
