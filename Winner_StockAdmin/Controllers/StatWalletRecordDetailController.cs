// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StatWalletRecordDetailController
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
using stockadmin.ViewModels.StatWalletRecordDetail;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StatWalletRecordDetail")]
  public class StatWalletRecordDetailController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(70, 5)]
    public IActionResult Index(StatWalletRecordDetailFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (StatWalletRecordDetailController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (StatWalletRecordDetailController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) StatWalletRecordDetailController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      StatWalletRecordDetailVm walletRecordDetailVm = new StatWalletRecordDetailVm()
      {
        filter = filter ?? new StatWalletRecordDetailFilter()
      };
      try
      {
        DataCountBase<StatWalletRecordDetailList> recordDetailList = StatWalletRecordDetailBiz.GetStatWalletRecordDetailList(walletRecordDetailVm.filter, this.GetLanguage(), page, pageSize);
        StaticPagedList<StatWalletRecordDetailList> staticPagedList = new StaticPagedList<StatWalletRecordDetailList>(recordDetailList.data, page, pageSize, recordDetailList.count);
        walletRecordDetailVm.list = (IPagedList<StatWalletRecordDetailList>) staticPagedList;
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
    }

    [MenuFilter(70, 5)]
    public IActionResult IndexCN(StatWalletRecordDetailFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (StatWalletRecordDetailController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (StatWalletRecordDetailController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) StatWalletRecordDetailController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pageSize);
      StatWalletRecordDetailVm walletRecordDetailVm = new StatWalletRecordDetailVm()
      {
        filter = filter ?? new StatWalletRecordDetailFilter()
      };
      try
      {
        DataCountBase<StatWalletRecordDetailList> adminDefaultLang = StatWalletRecordDetailBiz.GetStatWalletRecordDetailListByAdminDefaultLang(walletRecordDetailVm.filter, page, pageSize);
        StaticPagedList<StatWalletRecordDetailList> staticPagedList = new StaticPagedList<StatWalletRecordDetailList>(adminDefaultLang.data, page, pageSize, adminDefaultLang.count);
        walletRecordDetailVm.list = (IPagedList<StatWalletRecordDetailList>) staticPagedList;
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
    }

    [MenuFilter(71, 11)]
    public IActionResult Undone(StatWalletRecordDetailFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      StatWalletRecordDetailVm walletRecordDetailVm = new StatWalletRecordDetailVm()
      {
        filter = filter ?? new StatWalletRecordDetailFilter()
      };
      try
      {
        DataCountBase<StatWalletRecordDetailList> recordDetailList = StatWalletRecordDetailBiz.GetStatWalletRecordDetailList(walletRecordDetailVm.filter, this.GetLanguage(), page, this.pageSize);
        StaticPagedList<StatWalletRecordDetailList> staticPagedList = new StaticPagedList<StatWalletRecordDetailList>(recordDetailList.data, page, this.pageSize, recordDetailList.count);
        walletRecordDetailVm.list = (IPagedList<StatWalletRecordDetailList>) staticPagedList;
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletRecordDetailVm);
      }
    }

    [UseFilter(69, 5)]
    public IActionResult Download(StatWalletRecordDetailFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(StatWalletRecordDetailBiz.DownloadStatWalletRecordDetailList(filter, this.GetLanguage()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StatWalletRecord.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }

    [UseFilter(69, 5)]
    public IActionResult DownloadCN(StatWalletRecordDetailFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(StatWalletRecordDetailBiz.DownloadStatWalletRecordDetailList(filter, this.GetLanguage(), true), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StatWalletRecordCN.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("IndexCN", (object) filter);
      }
    }
  }
}
