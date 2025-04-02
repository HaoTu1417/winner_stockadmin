// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.EndWalletWithdrawController
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
using stockadmin.ViewModels.EndWalletWithdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("EndWalletWithdraw")]
  public class EndWalletWithdrawController : BaseController
  {
    private void SetFilterSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "recharge_types", typeof (EndWalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, EndWalletWithdrawBiz.GetRechargeTypeList(lang));
      // ISSUE: reference to a compiler-generated field
      if (EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "status_list", typeof (EndWalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) EndWalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, EndWalletWithdrawBiz.GetStatusList());
    }

    [MenuFilter(295, 5)]
    public IActionResult Index(EndWalletWithdrawFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (EndWalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (EndWalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) EndWalletWithdrawController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      EndWalletWithdrawVm walletWithdrawVm = new EndWalletWithdrawVm()
      {
        filter = filter ?? new EndWalletWithdrawFilter(),
        summary = new Summary()
      };
      try
      {
        DataCountBase<EndWalletWithdrawList> walletWithdrawList = EndWalletWithdrawBiz.GetEndWalletWithdrawList(walletWithdrawVm.filter, page, pageSize, this.GetUser().lang);
        StaticPagedList<EndWalletWithdrawList> source = new StaticPagedList<EndWalletWithdrawList>(walletWithdrawList.data, page, pageSize, walletWithdrawList.count);
        walletWithdrawVm.list = (IPagedList<EndWalletWithdrawList>) source;
        walletWithdrawVm.summary.page_total_profit = source.Sum<EndWalletWithdrawList>((Func<EndWalletWithdrawList, Decimal>) (o => o.money));
        return (IActionResult) this.View((object) walletWithdrawVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletWithdrawVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(295, 5)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<EndWalletWithdrawEditVm>(EndWalletWithdrawBiz.GetEditVm(pk, this.GetUser().lang)));
    }

    public IActionResult PostEdit(WalletWithdrawDto req)
    {
      this.SetSelect();
      try
      {
        EndWalletWithdrawBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(296, 5)]
    public IActionResult Download(EndWalletWithdrawFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(EndWalletWithdrawBiz.DownloadEndWalletWithdrawList(filter, this.GetUser().lang), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EndWalletWithdraw.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }
  }
}
