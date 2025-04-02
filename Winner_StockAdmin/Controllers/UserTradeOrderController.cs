// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.UserTradeOrderController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.UserTradeOrder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("UserTradeOrder")]
  public class UserTradeOrderController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(393, 2)]
    public IActionResult IndexVN(string subaccount, UserTradeOrderFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount) && filter.sub_account == null)
        throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeOrderVm userTradeOrderVm = new UserTradeOrderVm()
      {
        filter = filter ?? new UserTradeOrderFilter()
      };
      try
      {
        string subAccount = string.IsNullOrEmpty(subaccount) ? filter.sub_account : subaccount;
        userTradeOrderVm.list = UserTradeOrderBiz.GetUserTradeOrderList(subAccount, userTradeOrderVm.filter);
        // ISSUE: reference to a compiler-generated field
        if (UserTradeOrderController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UserTradeOrderController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "account", typeof (UserTradeOrderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = UserTradeOrderController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) UserTradeOrderController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, subAccount);
        return (IActionResult) this.View((object) userTradeOrderVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradeOrderVm);
      }
    }

    [UseFilter(383, 2)]
    public IActionResult IndexUS(string subaccount, UserTradeOrderFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount) && filter.sub_account == null)
        throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeOrderVm userTradeOrderVm = new UserTradeOrderVm()
      {
        filter = filter ?? new UserTradeOrderFilter()
      };
      try
      {
        string subAccount = string.IsNullOrEmpty(subaccount) ? filter.sub_account : subaccount;
        userTradeOrderVm.list = UserTradeOrderBiz.GetUserTradeOrderList(subAccount, userTradeOrderVm.filter, -5);
        // ISSUE: reference to a compiler-generated field
        if (UserTradeOrderController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UserTradeOrderController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "account", typeof (UserTradeOrderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = UserTradeOrderController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) UserTradeOrderController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, subAccount);
        return (IActionResult) this.View((object) userTradeOrderVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradeOrderVm);
      }
    }
  }
}
