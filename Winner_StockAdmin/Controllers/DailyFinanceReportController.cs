// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.DailyFinanceReportController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.DailyFinanceReport;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("DailyFinanceReport")]
  public class DailyFinanceReportController : BaseController
  {
    private void SetFilterSelect()
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "一月", Value = "1" },
        new SelectListItem() { Text = "二月", Value = "2" },
        new SelectListItem() { Text = "三月", Value = "3" },
        new SelectListItem() { Text = "四月", Value = "4" },
        new SelectListItem() { Text = "五月", Value = "5" },
        new SelectListItem() { Text = "六月", Value = "6" },
        new SelectListItem() { Text = "七月", Value = "7" },
        new SelectListItem() { Text = "八月", Value = "8" },
        new SelectListItem() { Text = "九月", Value = "9" },
        new SelectListItem() { Text = "十月", Value = "10" },
        new SelectListItem() { Text = "十一月", Value = "11" },
        new SelectListItem() { Text = "十二月", Value = "12" }
      };
      // ISSUE: reference to a compiler-generated field
      if (DailyFinanceReportController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DailyFinanceReportController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "months", typeof (DailyFinanceReportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DailyFinanceReportController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) DailyFinanceReportController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, selectListItemList);
    }

    [MenuFilter(436, 11)]
    public IActionResult Index(DailyFinanceReportFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (DailyFinanceReportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (DailyFinanceReportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) DailyFinanceReportController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      DailyFinanceReportVm dailyFinanceReportVm = new DailyFinanceReportVm()
      {
        filter = filter ?? new DailyFinanceReportFilter(),
        summary = new Summary()
      };
      try
      {
        (Summary summary, DataCountBase<DailyFinanceReportList> dataCountBase) = DailyFinanceReportBiz.GetDailyFinanceReportList(dailyFinanceReportVm.filter, page, pageSize);
        StaticPagedList<DailyFinanceReportList> staticPagedList = new StaticPagedList<DailyFinanceReportList>(dataCountBase.data, page, pageSize, dataCountBase.count);
        dailyFinanceReportVm.list = (IPagedList<DailyFinanceReportList>) staticPagedList;
        dailyFinanceReportVm.summary = summary;
        return (IActionResult) this.View((object) dailyFinanceReportVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) dailyFinanceReportVm);
      }
    }

    [MenuFilter(436, 11)]
    public IActionResult Download(DailyFinanceReportFilter filter, int page = 1)
    {
      DailyFinanceReportVm dailyFinanceReportVm = new DailyFinanceReportVm()
      {
        filter = filter ?? new DailyFinanceReportFilter()
      };
      try
      {
        return (IActionResult) ((ControllerBase) this).File(DailyFinanceReportBiz.DownloadDailyFinanceReportList(dailyFinanceReportVm.filter), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DailyFinanceReport.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) dailyFinanceReportVm);
      }
    }
  }
}
