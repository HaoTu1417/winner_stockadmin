// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RichboxDailyReportController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.RichboxDailyReport;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RichboxDailyReport")]
  public class RichboxDailyReportController : BaseController
  {
    [MenuFilter(181, 15)]
    public IActionResult Index(
      RichboxDailyReportFilter filter,
      string? begin_report_date,
      string? end_report_date,
      int page = 1,
      int pageSize = 20)
    {
      RichboxDailyReportVm richboxDailyReportVm = new RichboxDailyReportVm()
      {
        filter = filter ?? new RichboxDailyReportFilter()
      };
      filter.begin_report_date = string.IsNullOrEmpty(filter.begin_report_date) ? begin_report_date : filter.begin_report_date;
      filter.end_report_date = string.IsNullOrEmpty(filter.end_report_date) ? end_report_date : filter.end_report_date;
      // ISSUE: reference to a compiler-generated field
      if (RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (RichboxDailyReportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (RichboxDailyReportController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) RichboxDailyReportController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        int int32 = Convert.ToInt32(ConfigLib.Get("time_zone_difference"));
        DateTime dateTime = RichboxRecordService.MinDate();
        richboxDailyReportVm.filter.begin_report_date = !string.IsNullOrEmpty(richboxDailyReportVm.filter.begin_report_date) ? DateTime.Parse(richboxDailyReportVm.filter.begin_report_date).AddHours((double) int32).ToString("yyyy-MM-dd HH:mm:ss") : dateTime.Date.AddHours((double) int32).ToString("yyyy-MM-dd HH:mm:ss");
        richboxDailyReportVm.filter.end_report_date = !string.IsNullOrEmpty(richboxDailyReportVm.filter.end_report_date) ? DateTime.Parse(richboxDailyReportVm.filter.end_report_date).AddHours((double) int32).ToString("yyyy-MM-dd HH:mm:ss") : DateTime.UtcNow.AddHours((double) int32).ToString("yyyy-MM-dd HH:mm:ss");
        richboxDailyReportVm.total_invest = RichboxRecordService.GetDepositAmount();
        richboxDailyReportVm.list = RichboxDailyReportBiz.GetRichboxDailyReportList(richboxDailyReportVm.filter).ToPagedList<RichboxDailyReportList>(page, pageSize);
        return (IActionResult) this.View((object) richboxDailyReportVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) richboxDailyReportVm);
      }
    }
  }
}
