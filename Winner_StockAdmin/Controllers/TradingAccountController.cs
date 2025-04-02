// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradingAccountController
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
using stockadmin.Tool;
using stockadmin.ViewModels.TradingAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradingAccount")]
  public class TradingAccountController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrowType", typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BorrowPlanBiz.GetSelectListItems());
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, IEnumerable<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "status", typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) TradingAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, Enum.GetValues(typeof (FilterAccountStatusType)).Cast<FilterAccountStatusType>().Select<FilterAccountStatusType, SelectListItem>((Func<FilterAccountStatusType, SelectListItem>) (status => new SelectListItem()
      {
        Text = ConvertEnum.ConvertAccountStatus((int) status, this.GetUser().lang),
        Value = ((int) status).ToString()
      })));
    }

    [MenuFilter(390, 2)]
    public IActionResult IndexVN(TradingAccountFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) TradingAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        (Decimal totalProfit, DataCountBase<TradingAccountList> list) = TradingAccountBiz.GetTradingAccountList(filter ?? new TradingAccountFilter(), page, pageSize, "VN", this.GetUser().lang);
        StaticPagedList<TradingAccountList> staticPagedList = new StaticPagedList<TradingAccountList>(list.data, page, pageSize, list.count);
        return (IActionResult) this.View((object) new TradingAccountVm()
        {
          filter = (filter ?? new TradingAccountFilter()),
          summary = new Summary()
          {
            total_profit = totalProfit
          },
          list = (IPagedList<TradingAccountList>) staticPagedList
        });
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new TradingAccountVm());
      }
    }

    [MenuFilter(380, 2)]
    public IActionResult IndexUS(TradingAccountFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (TradingAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) TradingAccountController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        (Decimal totalProfit, DataCountBase<TradingAccountList> list) = TradingAccountBiz.GetTradingAccountList(filter ?? new TradingAccountFilter(), page, pageSize, "US", this.GetUser().lang);
        StaticPagedList<TradingAccountList> staticPagedList = new StaticPagedList<TradingAccountList>(list.data, page, pageSize, list.count);
        return (IActionResult) this.View((object) new TradingAccountVm()
        {
          filter = (filter ?? new TradingAccountFilter()),
          summary = new Summary()
          {
            total_profit = totalProfit
          },
          list = (IPagedList<TradingAccountList>) staticPagedList
        });
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new TradingAccountVm());
      }
    }

    [UseFilter(390, 2)]
    public IActionResult Edit(string sub_account)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<VwTradeAccountDto>(TradingAccountBiz.GetFromView(sub_account)));
    }

    public IActionResult PostEdit(TradeAccountDto req)
    {
      this.SetSelect();
      try
      {
        TradingAccountBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(397, 2)]
    public IActionResult DownloadVN(TradingAccountFilter filter)
    {
      TradingAccountVm tradingAccountVm = new TradingAccountVm()
      {
        filter = filter ?? new TradingAccountFilter()
      };
      try
      {
        return (IActionResult) ((ControllerBase) this).File(TradingAccountBiz.DownloadTradingAccountList(tradingAccountVm.filter, "VN", this.GetUser().lang), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TradingAccount.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("IndexVN", (object) filter);
      }
    }

    [UseFilter(397, 2)]
    public IActionResult DownloadUS(TradingAccountFilter filter)
    {
      TradingAccountVm tradingAccountVm = new TradingAccountVm()
      {
        filter = filter ?? new TradingAccountFilter()
      };
      try
      {
        return (IActionResult) ((ControllerBase) this).File(TradingAccountBiz.DownloadTradingAccountList(tradingAccountVm.filter, "US", this.GetUser().lang), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TradingAccount.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("IndexUS", (object) filter);
      }
    }
  }
}
