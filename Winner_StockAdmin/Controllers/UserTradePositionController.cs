// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.UserTradePositionController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.UserTradePosition;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("UserTradePosition")]
  public class UserTradePositionController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(395, 2)]
    public IActionResult IndexVN(string subaccount, UserTradePositionFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount) && filter.sub_account == null)
        throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradePositionVm userTradePositionVm = new UserTradePositionVm()
      {
        filter = filter ?? new UserTradePositionFilter()
      };
      try
      {
        string subAccount = string.IsNullOrEmpty(subaccount) ? filter.sub_account : subaccount;
        userTradePositionVm.list = UserTradePositionBiz.GetUserTradePositionList(subAccount, userTradePositionVm.filter);
        // ISSUE: reference to a compiler-generated field
        if (UserTradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UserTradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "account", typeof (UserTradePositionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = UserTradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) UserTradePositionController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, subAccount);
        return (IActionResult) this.View((object) userTradePositionVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradePositionVm);
      }
    }

    [UseFilter(385, 2)]
    public IActionResult IndexUS(string subaccount, UserTradePositionFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount) && filter.sub_account == null)
        throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradePositionVm userTradePositionVm = new UserTradePositionVm()
      {
        filter = filter ?? new UserTradePositionFilter()
      };
      try
      {
        string subAccount = string.IsNullOrEmpty(subaccount) ? filter.sub_account : subaccount;
        userTradePositionVm.list = UserTradePositionBiz.GetUserTradePositionList(subAccount, userTradePositionVm.filter);
        // ISSUE: reference to a compiler-generated field
        if (UserTradePositionController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UserTradePositionController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "account", typeof (UserTradePositionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = UserTradePositionController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) UserTradePositionController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, subAccount);
        return (IActionResult) this.View((object) userTradePositionVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradePositionVm);
      }
    }
  }
}
