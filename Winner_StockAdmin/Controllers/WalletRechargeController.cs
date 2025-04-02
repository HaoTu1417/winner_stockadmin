// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletRechargeController
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
using stockadmin.ViewModels.WalletRecharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletRecharge")]
  public class WalletRechargeController : BaseController
  {
    private void SetFilterSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (WalletRechargeController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletRechargeController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "recharge_types", typeof (WalletRechargeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WalletRechargeController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WalletRechargeController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, WalletRechargeBiz.GetRechargeTypeList(lang));
    }

    [MenuFilter(274, 5)]
    public IActionResult Index(WalletRechargeFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WalletRechargeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WalletRechargeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WalletRechargeController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      WalletRechargeVm walletRechargeVm = new WalletRechargeVm()
      {
        filter = filter ?? new WalletRechargeFilter(),
        summary = new Summary()
      };
      try
      {
        DataCountBase<WalletRechargeList> walletRechargeList = WalletRechargeBiz.GetWalletRechargeList(walletRechargeVm.filter, page, pageSize);
        StaticPagedList<WalletRechargeList> source = new StaticPagedList<WalletRechargeList>(walletRechargeList.data, page, pageSize, walletRechargeList.count);
        walletRechargeVm.list = (IPagedList<WalletRechargeList>) source;
        walletRechargeVm.summary.page_total_profit = source.Sum<WalletRechargeList>((Func<WalletRechargeList, Decimal>) (o => o.wallet_amount));
        return (IActionResult) this.View((object) walletRechargeVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletRechargeVm);
      }
    }

    [MenuFilter(274, 5)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<WalletRechargeReview>(WalletRechargeBiz.GetReview(pk)));
    }

    [MenuFilter(274, 5)]
    public IActionResult PostReview(WalletRechargeDto req, bool result)
    {
      try
      {
        WalletRechargeBiz.RechargeVerify(req.pk, result, this.GetUser(), req.reject_result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) PublicTool.convertUtcToLocalTime<WalletRechargeReview>(WalletRechargeBiz.GetReview(req.pk)));
      }
    }
  }
}
