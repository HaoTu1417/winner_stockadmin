// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletTemplateController
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
using stockadmin.Models.Dto;
using stockadmin.ViewModels.WalletTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletTemplate")]
  public class WalletTemplateController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (WalletTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (WalletTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WalletTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WalletTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(30, 14)]
    public IActionResult Index(
      WalletTemplateFilter filter,
      int? temp_id,
      string? lang,
      int page = 1,
      int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WalletTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WalletTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WalletTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      WalletTemplateVm walletTemplateVm = new WalletTemplateVm()
      {
        filter = filter ?? new WalletTemplateFilter()
      };
      filter.temp_id = filter.temp_id ?? temp_id;
      filter.lang = filter.lang ?? lang;
      try
      {
        DataCountBase<WalletTemplateList> walletTemplateList = WalletTemplateBiz.GetWalletTemplateList(walletTemplateVm.filter, page, pageSize);
        StaticPagedList<WalletTemplateList> staticPagedList = new StaticPagedList<WalletTemplateList>(walletTemplateList.data, page, pageSize, walletTemplateList.count);
        walletTemplateVm.list = (IPagedList<WalletTemplateList>) staticPagedList;
        return (IActionResult) this.View((object) walletTemplateVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletTemplateVm);
      }
    }

    [UseFilter(30, 14)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) WalletTemplateBiz.Get(pk));
    }

    public IActionResult PostEdit(WalletTemplateDto req)
    {
      this.SetSelect();
      try
      {
        WalletTemplateBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(30, 14)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new WalletTemplateDto());
    }

    public IActionResult PostCreate(WalletTemplateDto req)
    {
      this.SetSelect();
      try
      {
        WalletTemplateBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }
  }
}
