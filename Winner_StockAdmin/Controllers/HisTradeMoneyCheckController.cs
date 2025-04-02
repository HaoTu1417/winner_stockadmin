// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.HisTradeMoneyCheckController
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
using stockadmin.Tool;
using stockadmin.ViewModels.HisTradeMoneyCheck;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("HisTradeMoneyCheck")]
  public class HisTradeMoneyCheckController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(261, 2)]
    public IActionResult Index(HisTradeMoneyCheckFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (HisTradeMoneyCheckController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (HisTradeMoneyCheckController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) HisTradeMoneyCheckController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      HisTradeMoneyCheckVm tradeMoneyCheckVm = new HisTradeMoneyCheckVm()
      {
        filter = filter ?? new HisTradeMoneyCheckFilter()
      };
      try
      {
        DataCountBase<HisTradeMoneyCheckList> tradeMoneyCheckList = HisTradeMoneyCheckBiz.GetHisTradeMoneyCheckList(tradeMoneyCheckVm.filter, page, pageSize);
        StaticPagedList<HisTradeMoneyCheckList> staticPagedList = new StaticPagedList<HisTradeMoneyCheckList>(tradeMoneyCheckList.data, page, pageSize, tradeMoneyCheckList.count);
        tradeMoneyCheckVm.list = (IPagedList<HisTradeMoneyCheckList>) staticPagedList;
        return (IActionResult) this.View((object) tradeMoneyCheckVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeMoneyCheckVm);
      }
    }

    [MenuFilter(261, 2)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<HisTradeMoneyCheckReview>(HisTradeMoneyCheckBiz.GetReview(pk)));
    }
  }
}
