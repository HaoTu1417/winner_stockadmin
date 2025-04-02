// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletController
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
using stockadmin.ViewModels.Wallet;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Wallet")]
  public class WalletController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(264, 5)]
    public IActionResult Index(WalletFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (WalletController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WalletController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WalletController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WalletController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WalletController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WalletController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WalletController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WalletController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      WalletVm walletVm = new WalletVm()
      {
        filter = filter ?? new WalletFilter()
      };
      try
      {
        DataCountBase<WalletList> walletList = WalletBiz.GetWalletList(walletVm.filter, page, pageSize);
        StaticPagedList<WalletList> staticPagedList = new StaticPagedList<WalletList>(walletList.data, page, pageSize, walletList.count);
        walletVm.list = (IPagedList<WalletList>) staticPagedList;
        return (IActionResult) this.View((object) walletVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(264, 5)]
    public IActionResult Edit(int member_fk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<WalletEditVm>(WalletBiz.GetEditVm(member_fk)));
    }

    public IActionResult PostEdit(WalletDto req)
    {
      this.SetSelect();
      try
      {
        WalletBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [MenuFilter(264, 5)]
    public IActionResult ChangeException(int member_fk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) WalletBiz.GetChangeException(member_fk));
    }

    public IActionResult PostChangeException(WalletChangeExceptionVm req)
    {
      try
      {
        WalletRechargeBiz.ChangeException(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(263, 5)]
    public IActionResult Download(WalletFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(WalletBiz.DownloadWalletList(filter), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Wallet.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }
  }
}
