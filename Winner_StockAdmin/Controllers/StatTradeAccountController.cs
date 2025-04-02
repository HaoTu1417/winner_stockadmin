// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StatTradeAccountController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.StatTradeAccount;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StatTradeAccount")]
  public class StatTradeAccountController : BaseController
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
      if (StatTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "months", typeof (StatTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = StatTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) StatTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, selectListItemList);
    }

    [MenuFilter(316, 11)]
    public IActionResult Index(StatTradeAccountFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      StatTradeAccountVm statTradeAccountVm = new StatTradeAccountVm()
      {
        filter = filter ?? new StatTradeAccountFilter()
      };
      try
      {
        statTradeAccountVm.list = StatTradeAccountBiz.GetStatTradeAccountList(statTradeAccountVm.filter).ToPagedList<StatTradeAccountList>(page, this.pageSize);
        return (IActionResult) this.View((object) statTradeAccountVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) statTradeAccountVm);
      }
    }
  }
}
