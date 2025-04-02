// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.EndTradeAccountController
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
using stockadmin.ViewModels.EndTradeAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("EndTradeAccount")]
  public class EndTradeAccountController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrowType", typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BorrowPlanBiz.GetSelectListItems());
    }

    [MenuFilter(388, 2)]
    public IActionResult IndexVN(EndTradeAccountFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      EndTradeAccountVm endTradeAccountVm = new EndTradeAccountVm()
      {
        filter = filter ?? new EndTradeAccountFilter(),
        summary = new Summary()
      };
      try
      {
        (Decimal totalProfit, DataCountBase<EndTradeAccountList> dataCountBase) = EndTradeAccountBiz.GetEndTradeAccountList(endTradeAccountVm.filter, page, pageSize, "VN", this.GetUser().lang);
        StaticPagedList<EndTradeAccountList> source = new StaticPagedList<EndTradeAccountList>(dataCountBase.data, page, pageSize, dataCountBase.count);
        endTradeAccountVm.list = (IPagedList<EndTradeAccountList>) source;
        endTradeAccountVm.summary.total_profit = totalProfit;
        endTradeAccountVm.summary.page_total_profit = source.Sum<EndTradeAccountList>((Func<EndTradeAccountList, Decimal>) (o => o.total_profit));
        return (IActionResult) this.View((object) endTradeAccountVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) endTradeAccountVm);
      }
    }

    [MenuFilter(378, 2)]
    public IActionResult IndexUS(EndTradeAccountFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (EndTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) EndTradeAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pageSize);
      EndTradeAccountVm endTradeAccountVm = new EndTradeAccountVm()
      {
        filter = filter ?? new EndTradeAccountFilter(),
        summary = new Summary()
      };
      try
      {
        (Decimal totalProfit, DataCountBase<EndTradeAccountList> dataCountBase) = EndTradeAccountBiz.GetEndTradeAccountList(endTradeAccountVm.filter, page, pageSize, "US", this.GetUser().lang);
        StaticPagedList<EndTradeAccountList> source = new StaticPagedList<EndTradeAccountList>(dataCountBase.data, page, pageSize, dataCountBase.count);
        endTradeAccountVm.list = (IPagedList<EndTradeAccountList>) source;
        endTradeAccountVm.summary.total_profit = totalProfit;
        endTradeAccountVm.summary.page_total_profit = source.Sum<EndTradeAccountList>((Func<EndTradeAccountList, Decimal>) (o => o.total_profit));
        return (IActionResult) this.View((object) endTradeAccountVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) endTradeAccountVm);
      }
    }

    [UseFilter(387, 2)]
    public IActionResult DownloadVN(EndTradeAccountFilter filter)
    {
      EndTradeAccountVm endTradeAccountVm = new EndTradeAccountVm()
      {
        filter = filter ?? new EndTradeAccountFilter()
      };
      try
      {
        return (IActionResult) ((ControllerBase) this).File(EndTradeAccountBiz.DownloadEndTradeAccountList(endTradeAccountVm.filter, "VN", this.GetUser().lang), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EndTradeAccount.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }

    [UseFilter(387, 2)]
    public IActionResult DownloadUS(EndTradeAccountFilter filter)
    {
      EndTradeAccountVm endTradeAccountVm = new EndTradeAccountVm()
      {
        filter = filter ?? new EndTradeAccountFilter()
      };
      try
      {
        return (IActionResult) ((ControllerBase) this).File(EndTradeAccountBiz.DownloadEndTradeAccountList(endTradeAccountVm.filter, "US", this.GetUser().lang), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EndTradeAccount.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }
  }
}
