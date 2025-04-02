// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.ClosedTradeAccountController
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
using stockadmin.ViewModels.ClosedTradeAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("ClosedTradeAccount")]
  public class ClosedTradeAccountController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (ClosedTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
      // ISSUE: reference to a compiler-generated field
      if (ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrowType", typeof (ClosedTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BorrowPlanBiz.GetSelectListItems());
      // ISSUE: reference to a compiler-generated field
      if (ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, IEnumerable<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "status", typeof (ClosedTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) ClosedTradeAccountController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, Enum.GetValues(typeof (FilterAccountStatusType)).Cast<FilterAccountStatusType>().Select<FilterAccountStatusType, SelectListItem>((Func<FilterAccountStatusType, SelectListItem>) (status => new SelectListItem()
      {
        Text = ConvertEnum.ConvertAccountStatus((int) status, this.GetUser().lang),
        Value = ((int) status).ToString()
      })));
    }

    [MenuFilter(389, 2)]
    public IActionResult Index(ClosedTradeAccountFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (ClosedTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (ClosedTradeAccountController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) ClosedTradeAccountController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        ClosedTradeAccountVm closedTradeAccountVm = new ClosedTradeAccountVm()
        {
          filter = filter ?? new ClosedTradeAccountFilter()
        };
        DataCountBase<ClosedTradeAccountList> tradeAccountLists = ClosedTradeAccountBiz.GetClosedTradeAccountLists(closedTradeAccountVm.filter, page, pageSize);
        StaticPagedList<ClosedTradeAccountList> staticPagedList = new StaticPagedList<ClosedTradeAccountList>(tradeAccountLists.data, page, pageSize, tradeAccountLists.count);
        closedTradeAccountVm.list = (IPagedList<ClosedTradeAccountList>) staticPagedList;
        return (IActionResult) this.View((object) closedTradeAccountVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new ClosedTradeAccountVm());
      }
    }
  }
}
