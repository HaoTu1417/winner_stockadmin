// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradeTemplateController
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
using stockadmin.ViewModels.TradeTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradeTemplate")]
  public class TradeTemplateController : BaseController
  {
    private void SetFilterSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (TradeTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradeTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (TradeTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = TradeTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) TradeTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(32, 14)]
    public IActionResult Index(
      TradeTemplateFilter filter,
      int? temp_id,
      string? lang,
      int page = 1,
      int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (TradeTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (TradeTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) TradeTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      TradeTemplateVm tradeTemplateVm = new TradeTemplateVm()
      {
        filter = filter ?? new TradeTemplateFilter()
      };
      filter.temp_id = filter.temp_id ?? temp_id;
      filter.lang = filter.lang ?? lang;
      try
      {
        DataCountBase<TradeTemplateList> tradeTemplateList = TradeTemplateBiz.GetTradeTemplateList(tradeTemplateVm.filter, page, pageSize);
        StaticPagedList<TradeTemplateList> staticPagedList = new StaticPagedList<TradeTemplateList>(tradeTemplateList.data, page, pageSize, tradeTemplateList.count);
        tradeTemplateVm.list = (IPagedList<TradeTemplateList>) staticPagedList;
        return (IActionResult) this.View((object) tradeTemplateVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeTemplateVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(32, 14)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) TradeTemplateBiz.Get(pk));
    }

    public IActionResult PostEdit(TradeTemplateDto req)
    {
      this.SetSelect();
      try
      {
        TradeTemplateBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(32, 14)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new TradeTemplateDto());
    }

    public IActionResult PostCreate(TradeTemplateDto req)
    {
      this.SetSelect();
      try
      {
        TradeTemplateBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [MenuFilter(32, 14)]
    public IActionResult Delete(int pk)
    {
      try
      {
        TradeTemplateBiz.Delete(pk, this.GetUser());
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
