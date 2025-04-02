// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WithdrawCurrencyController
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
using stockadmin.ViewModels.WithdrawCurrency;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WithdrawCurrency")]
  public class WithdrawCurrencyController : BaseController
  {
    [MenuFilter(438, 5)]
    public IActionResult Index(WithdrawCurrencyFilter filter, int page = 1, int pageSize = 20)
    {
      WithdrawCurrencyVm withdrawCurrencyVm = new WithdrawCurrencyVm()
      {
        filter = filter ?? new WithdrawCurrencyFilter()
      };
      // ISSUE: reference to a compiler-generated field
      if (WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WithdrawCurrencyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WithdrawCurrencyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) WithdrawCurrencyController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        withdrawCurrencyVm.list = WithdrawCurrencyBiz.GetWithdrawCurrencyList(withdrawCurrencyVm.filter, this.GetUser().lang).ToPagedList<WithdrawCurrencyList>(page, pageSize);
        return (IActionResult) this.View((object) withdrawCurrencyVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) withdrawCurrencyVm);
      }
    }

    [MenuFilter(438, 5)]
    public IActionResult Edit(int pk)
    {
      return (IActionResult) this.View((object) WithdrawCurrencyBiz.Get(pk));
    }

    [MenuFilter(438, 5)]
    public IActionResult PostEdit(WithdrawSupportCurrencyDto req)
    {
      try
      {
        WithdrawCurrencyBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [MenuFilter(438, 5)]
    public IActionResult Create()
    {
      return (IActionResult) this.View((object) new WithdrawSupportCurrencyDto());
    }

    [MenuFilter(438, 5)]
    public IActionResult PostCreate(WithdrawSupportCurrencyDto req)
    {
      try
      {
        WithdrawCurrencyBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }
  }
}
