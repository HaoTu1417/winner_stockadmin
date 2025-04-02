// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletWithdrawController
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
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.WalletWithdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletWithdraw")]
  public class WalletWithdrawController : BaseController
  {
    [MenuFilter(294, 5)]
    public IActionResult Index(WalletWithdrawFilter filter, int page = 1, int pageSize = 20)
    {
      WalletWithdrawVm walletWithdrawVm = new WalletWithdrawVm()
      {
        filter = filter ?? new WalletWithdrawFilter(),
        summary = new Summary()
      };
      // ISSUE: reference to a compiler-generated field
      if (WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WalletWithdrawController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) WalletWithdrawController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        DataCountBase<WalletWithdrawList> walletWithdrawList = WalletWithdrawBiz.GetWalletWithdrawList(walletWithdrawVm.filter, page, pageSize);
        StaticPagedList<WalletWithdrawList> source = new StaticPagedList<WalletWithdrawList>(walletWithdrawList.data, page, pageSize, walletWithdrawList.count);
        walletWithdrawVm.list = (IPagedList<WalletWithdrawList>) source;
        walletWithdrawVm.summary.page_total_profit = source.Sum<WalletWithdrawList>((Func<WalletWithdrawList, Decimal>) (o => o.money));
        return (IActionResult) this.View((object) walletWithdrawVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletWithdrawVm);
      }
    }

    [MenuFilter(294, 5)]
    public IActionResult Review(int pk)
    {
      WalletWithdrawReview localTime = PublicTool.convertUtcToLocalTime<WalletWithdrawReview>(WalletWithdrawBiz.GetReview(pk));
      localTime.id_selfie = !string.IsNullOrEmpty(localTime.id_selfie) ? ConfigLib.Get("filesite") + localTime.id_selfie : "";
      return (IActionResult) this.View((object) localTime);
    }

    [MenuFilter(294, 5)]
    public IActionResult PostReview(WalletWithdrawDto req, bool result)
    {
      try
      {
        WalletWithdrawBiz.VerifyWalletWithdraw(req, result, this.GetUser(), req.reject_result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) req.pk);
      }
    }
  }
}
