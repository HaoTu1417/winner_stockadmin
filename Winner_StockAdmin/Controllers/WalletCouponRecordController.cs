// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletCouponRecordController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.WalletCouponRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletCouponRecord")]
  public class WalletCouponRecordController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(146, 7)]
    public IActionResult Index(int promotion_id, int page = 1)
    {
      this.SetFilterSelect();
      try
      {
        IPagedList<WalletCouponRecordList> pagedList = WalletCouponRecordBiz.GetWalletCouponRecordList(promotion_id).ToPagedList<WalletCouponRecordList>(page, this.pageSize);
        // ISSUE: reference to a compiler-generated field
        if (WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Id", typeof (WalletCouponRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, promotion_id);
        if (pagedList != null && pagedList.Count > 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Sended", typeof (WalletCouponRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pagedList[0].sended);
        }
        return (IActionResult) this.View((object) pagedList);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((string) null);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(146, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<WalletCouponRecordEditVm>(WalletCouponRecordBiz.Get(pk)));
    }

    public IActionResult PostEdit(WalletCouponRecordEditVm req)
    {
      this.SetSelect();
      try
      {
        WalletCouponRecordBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(146, 7)]
    public IActionResult GiveOut(int promotion_id)
    {
      this.SetSelect();
      WalletCouponRecordBiz.GiveOut(this.GetUser().account, promotion_id);
      return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
    }

    [UseFilter(146, 7)]
    public IActionResult Create(int promotion_id)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new WalletCouponRecordEditVm()
      {
        cms_promotion_fk = promotion_id
      });
    }

    public IActionResult PostCreate(WalletCouponRecordEditVm req)
    {
      this.SetSelect();
      try
      {
        WalletCouponRecordBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [MenuFilter(146, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        WalletCouponRecordBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
