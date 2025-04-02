// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletRecordController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletRecord")]
  public class WalletRecordController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(266, 5)]
    public IActionResult Index(int id, int page = 1)
    {
      this.SetFilterSelect();
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (WalletRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WalletRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "User", typeof (WalletRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WalletRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WalletRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, id);
        return (IActionResult) this.View((object) WalletRecordBiz.GetWalletRecordList(id, page, this.pageSize).ToPagedList<WalletRecordList>(page, this.pageSize));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new WalletRecordList());
      }
    }

    [UseFilter(266, 5)]
    public IActionResult IndexCN(int id, int page = 1)
    {
      this.SetFilterSelect();
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (WalletRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WalletRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "User", typeof (WalletRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WalletRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) WalletRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, id);
        return (IActionResult) this.View((object) WalletRecordBiz.GetWalletRecordListByAdminDefaultLang(id, page, this.pageSize).ToPagedList<WalletRecordList>(page, this.pageSize));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new WalletRecordList());
      }
    }
  }
}
