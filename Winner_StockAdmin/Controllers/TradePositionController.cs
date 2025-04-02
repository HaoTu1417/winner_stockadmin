// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradePositionController
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
using stockadmin.ViewModels.TradePosition;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradePosition")]
  public class TradePositionController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (TradePositionController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradePositionController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (TradePositionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = TradePositionController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) TradePositionController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
    }

    [MenuFilter(394, 2)]
    public IActionResult Index(TradePositionFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (TradePositionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (TradePositionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) TradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      TradePositionVm tradePositionVm = new TradePositionVm()
      {
        filter = filter ?? new TradePositionFilter()
      };
      try
      {
        DataCountBase<TradePositionList> tradePositionList = TradePositionBiz.GetTradePositionList(tradePositionVm.filter, page, pageSize);
        StaticPagedList<TradePositionList> staticPagedList = new StaticPagedList<TradePositionList>(tradePositionList.data, page, pageSize, tradePositionList.count);
        tradePositionVm.list = (IPagedList<TradePositionList>) staticPagedList;
        return (IActionResult) this.View((object) tradePositionVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradePositionVm);
      }
    }
  }
}
