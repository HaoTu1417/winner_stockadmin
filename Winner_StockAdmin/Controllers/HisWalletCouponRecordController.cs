// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.HisWalletCouponRecordController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.WalletCouponRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("HisWalletCouponRecord")]
  public class HisWalletCouponRecordController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(265, 5)]
    public IActionResult Index(int member_fk, int page = 1)
    {
      this.SetFilterSelect();
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (HisWalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          HisWalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (member_fk), typeof (HisWalletCouponRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = HisWalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) HisWalletCouponRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, member_fk);
        return (IActionResult) this.View((object) WalletCouponRecordBiz.GetHisWalletCouponRecordList(new int?(member_fk)).ToPagedList<WalletCouponRecordList>(page, this.pageSize));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((string) null);
      }
    }

    [UseFilter(265, 5)]
    public IActionResult IndexCN(int member_fk, int page = 1)
    {
      this.SetFilterSelect();
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (HisWalletCouponRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          HisWalletCouponRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (member_fk), typeof (HisWalletCouponRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = HisWalletCouponRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) HisWalletCouponRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, member_fk);
        return (IActionResult) this.View((object) WalletCouponRecordBiz.GetHisWalletCouponRecordByAdminDefaultLang(member_fk).ToPagedList<WalletCouponRecordList>(page, this.pageSize));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((string) null);
      }
    }
  }
}
