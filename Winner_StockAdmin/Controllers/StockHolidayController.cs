// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StockHolidayController
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
using stockadmin.ViewModels.StockHoliday;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StockHoliday")]
  public class StockHolidayController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (StockHolidayController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StockHolidayController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (StockHolidayController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = StockHolidayController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) StockHolidayController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
    }

    [MenuFilter(100, 8)]
    public IActionResult Index(StockHolidayFilter filter, int page = 1)
    {
      this.SetSelect();
      StockHolidayVm stockHolidayVm = new StockHolidayVm()
      {
        filter = filter ?? new StockHolidayFilter()
      };
      try
      {
        List<StockHolidayList> stockHolidayList = StockHolidayBiz.GetStockHolidayList(stockHolidayVm.filter);
        stockHolidayVm.list = stockHolidayList.ToPagedList<StockHolidayList>(page, this.pageSize);
        return (IActionResult) this.View((object) stockHolidayVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) stockHolidayVm);
      }
    }

    [UseFilter(100, 8)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<StockHolidayDto>(StockHolidayBiz.Get(pk)));
    }

    public IActionResult PostEdit(StockHolidayDto req)
    {
      this.SetSelect();
      try
      {
        StockHolidayBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req.pk);
      }
    }

    [UseFilter(100, 8)]
    public IActionResult Create(StockHolidayDto? data = null)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new StockHolidayDto()
      {
        is_allday = true
      });
    }

    public IActionResult PostCreate(StockHolidayDto req)
    {
      this.SetSelect();
      try
      {
        StockHolidayBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(100, 8)]
    public IActionResult Delete(int pk)
    {
      try
      {
        StockHolidayBiz.Delete(pk, this.GetUser());
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
