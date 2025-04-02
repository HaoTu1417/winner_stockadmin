// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradeMoneyRecordController
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
using stockadmin.ViewModels.TradeMoneyRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradeMoneyRecord")]
  public class TradeMoneyRecordController : BaseController
  {
    private void SetFilterSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (TradeMoneyRecordController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradeMoneyRecordController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TradeTemp", typeof (TradeMoneyRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = TradeMoneyRecordController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) TradeMoneyRecordController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, TradeTemplateBiz.GetDropDownList(this.GetLanguage()));
    }

    [UseFilter(391, 2)]
    public IActionResult IndexVN(string subAccount, TradeMoneyRecordFilter filter, int page = 1)
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> tradeMoneyRecordList = TradeMoneyRecordBiz.GetTradeMoneyRecordList(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = tradeMoneyRecordList.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = false;
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(381, 2)]
    public IActionResult IndexUS(string subAccount, TradeMoneyRecordFilter filter, int page = 1)
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> tradeMoneyRecordList = TradeMoneyRecordBiz.GetTradeMoneyRecordList(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = tradeMoneyRecordList.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = false;
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(388, 2)]
    public IActionResult IndexEndTradeAccount(
      string subAccount,
      TradeMoneyRecordFilter filter,
      int page = 1,
      string market = "VN")
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> tradeMoneyRecordList = TradeMoneyRecordBiz.GetTradeMoneyRecordList(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = tradeMoneyRecordList.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = false;
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexUS", (object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexUS", (object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(378, 2)]
    public IActionResult IndexEndTradeAccountUS(
      string subAccount,
      TradeMoneyRecordFilter filter,
      int page = 1,
      string market = "US")
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> tradeMoneyRecordList = TradeMoneyRecordBiz.GetTradeMoneyRecordList(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = tradeMoneyRecordList.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = false;
        return (IActionResult) this.View("IndexUS", (object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("IndexUS", (object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(388, 2)]
    public IActionResult IndexEndTradeAccountCN(
      string subAccount,
      TradeMoneyRecordFilter filter,
      int page = 1,
      string market = "VN")
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> adminDefaultLang = TradeMoneyRecordBiz.GetTradeMoneyRecordListByAdminDefaultLang(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = adminDefaultLang.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = true;
        return market == "VN" ? (IActionResult) this.View("IndexCN_VN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexCN_US", (object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return market == "VN" ? (IActionResult) this.View("IndexCN_VN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexCN_US", (object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(378, 2)]
    public IActionResult IndexEndTradeAccountUSCN(
      string subAccount,
      TradeMoneyRecordFilter filter,
      int page = 1,
      string market = "US")
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> adminDefaultLang = TradeMoneyRecordBiz.GetTradeMoneyRecordListByAdminDefaultLang(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = adminDefaultLang.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = true;
        return market == "VN" ? (IActionResult) this.View("IndexCN_VN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexCN_US", (object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return market == "VN" ? (IActionResult) this.View("IndexCN_VN", (object) tradeMoneyRecordVm) : (IActionResult) this.View("IndexCN_US", (object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(391, 2)]
    public IActionResult IndexCN_VN(string subAccount, TradeMoneyRecordFilter filter, int page = 1)
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> adminDefaultLang = TradeMoneyRecordBiz.GetTradeMoneyRecordListByAdminDefaultLang(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = adminDefaultLang.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = true;
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("IndexCN", (object) tradeMoneyRecordVm);
      }
    }

    [UseFilter(381, 2)]
    public IActionResult IndexCN_US(string subAccount, TradeMoneyRecordFilter filter, int page = 1)
    {
      TradeMoneyRecordVm tradeMoneyRecordVm = new TradeMoneyRecordVm()
      {
        filter = filter ?? new TradeMoneyRecordFilter()
      };
      try
      {
        if (string.IsNullOrWhiteSpace(subAccount) && string.IsNullOrWhiteSpace(filter.sub_account))
          throw new AppException(210, "illegal_operation");
        this.SetFilterSelect();
        tradeMoneyRecordVm.filter.sub_account = subAccount ?? filter.sub_account;
        List<TradeMoneyRecordList> adminDefaultLang = TradeMoneyRecordBiz.GetTradeMoneyRecordListByAdminDefaultLang(tradeMoneyRecordVm.filter);
        tradeMoneyRecordVm.list = adminDefaultLang.ToPagedList<TradeMoneyRecordList>(page, this.pageSize);
        tradeMoneyRecordVm.subAccount = subAccount ?? filter.sub_account;
        tradeMoneyRecordVm.fromCN = true;
        return (IActionResult) this.View((object) tradeMoneyRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("IndexCN", (object) tradeMoneyRecordVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(391, 2)]
    public IActionResult Edit(int pk, string subAccount, bool fromCN)
    {
      this.SetSelect();
      TradeMoneyRecordDto localTime = PublicTool.convertUtcToLocalTime<TradeMoneyRecordDto>(TradeMoneyRecordBiz.Get(pk));
      this.ViewData[nameof (subAccount)] = (object) subAccount;
      this.ViewData[nameof (fromCN)] = (object) fromCN;
      return (IActionResult) this.View((object) localTime);
    }
  }
}
