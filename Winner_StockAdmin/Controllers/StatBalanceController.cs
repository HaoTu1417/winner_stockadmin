// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StatBalanceController
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
using stockadmin.ViewModels.StatBalance;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StatBalance")]
  public class StatBalanceController : BaseController
  {
    private void SetFilterSelect()
    {
      List<SelectListItem> selectListItemList1 = new List<SelectListItem>()
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
      if (StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "months", typeof (StatBalanceController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, selectListItemList1);
      List<SelectListItem> selectListItemList2 = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "充值", Value = "1" },
        new SelectListItem() { Text = "提现", Value = "12" }
      };
      // ISSUE: reference to a compiler-generated field
      if (StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "type", typeof (StatBalanceController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) StatBalanceController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, selectListItemList2);
    }

    [MenuFilter(72, 11)]
    public IActionResult Index(
      StatBalanceFilter filter,
      DateTime? start_time,
      DateTime? end_time,
      int? type,
      string? account,
      string? nickname,
      int page = 1,
      int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (StatBalanceController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (StatBalanceController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) StatBalanceController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      StatBalanceVm statBalanceVm = new StatBalanceVm()
      {
        filter = filter ?? new StatBalanceFilter(),
        summary = new StatBalanceSummary()
      };
      StatBalanceFilter statBalanceFilter1 = filter;
      DateTime? nullable1 = filter.start_time;
      DateTime? nullable2 = nullable1 ?? start_time;
      statBalanceFilter1.start_time = nullable2;
      StatBalanceFilter statBalanceFilter2 = filter;
      nullable1 = filter.end_time;
      DateTime? nullable3 = nullable1 ?? end_time;
      statBalanceFilter2.end_time = nullable3;
      filter.type = filter.type ?? type;
      filter.account = filter.account ?? account;
      filter.nickname = filter.nickname ?? nickname;
      try
      {
        (CountAndTotalAmount countAndTotalAmount, DataCountBase<StatBalanceList> dataCountBase) = StatBalanceBiz.GetStatBalanceList(statBalanceVm.filter, page, pageSize);
        StaticPagedList<StatBalanceList> staticPagedList = new StaticPagedList<StatBalanceList>(dataCountBase.data, page, pageSize, dataCountBase.count);
        statBalanceVm.list = (IPagedList<StatBalanceList>) staticPagedList;
        statBalanceVm.summary.withdraw_total = countAndTotalAmount.total_withdraw;
        statBalanceVm.summary.withdraw_count = countAndTotalAmount.withdraw_count;
        statBalanceVm.summary.recharge_total = countAndTotalAmount.total_recharge;
        statBalanceVm.summary.recharge_count = countAndTotalAmount.recharge_count;
        return (IActionResult) this.View((object) statBalanceVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) statBalanceVm);
      }
    }
  }
}
