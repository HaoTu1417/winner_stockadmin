// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.UserTradeDealController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.UserTradeDeal;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("UserTradeDeal")]
  public class UserTradeDealController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(396, 2)]
    public IActionResult IndexVN(string subaccount, UserTradeDealFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount))
        subaccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeDealVm userTradeDealVm = new UserTradeDealVm()
      {
        sub_account = subaccount,
        filter = filter ?? new UserTradeDealFilter()
      };
      try
      {
        userTradeDealVm.list = UserTradeDealBiz.GetUserTradeDealList(subaccount, userTradeDealVm.filter);
        return (IActionResult) this.View((object) userTradeDealVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradeDealVm);
      }
    }

    [UseFilter(386, 2)]
    public IActionResult IndexUS(string subaccount, UserTradeDealFilter filter)
    {
      if (string.IsNullOrEmpty(subaccount))
        subaccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeDealVm userTradeDealVm = new UserTradeDealVm()
      {
        sub_account = subaccount,
        filter = filter ?? new UserTradeDealFilter()
      };
      try
      {
        userTradeDealVm.list = UserTradeDealBiz.GetUserTradeDealList(subaccount, userTradeDealVm.filter);
        return (IActionResult) this.View((object) userTradeDealVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) userTradeDealVm);
      }
    }

    [UseFilter(388, 2)]
    public IActionResult IndexEndTradeAccount(
      string subaccount,
      UserTradeDealFilter filter,
      string market)
    {
      if (string.IsNullOrEmpty(subaccount))
        subaccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeDealVm userTradeDealVm = new UserTradeDealVm()
      {
        sub_account = subaccount,
        filter = filter ?? new UserTradeDealFilter()
      };
      try
      {
        userTradeDealVm.list = UserTradeDealBiz.GetUserTradeDealList(subaccount, userTradeDealVm.filter);
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) userTradeDealVm) : (IActionResult) this.View("IndexUS", (object) userTradeDealVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) userTradeDealVm) : (IActionResult) this.View("IndexUS", (object) userTradeDealVm);
      }
    }

    [UseFilter(378, 2)]
    public IActionResult IndexEndTradeAccountUS(
      string subaccount,
      UserTradeDealFilter filter,
      string market)
    {
      if (string.IsNullOrEmpty(subaccount))
        subaccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      UserTradeDealVm userTradeDealVm = new UserTradeDealVm()
      {
        sub_account = subaccount,
        filter = filter ?? new UserTradeDealFilter()
      };
      try
      {
        userTradeDealVm.list = UserTradeDealBiz.GetUserTradeDealList(subaccount, userTradeDealVm.filter);
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) userTradeDealVm) : (IActionResult) this.View("IndexUS", (object) userTradeDealVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return market == "VN" ? (IActionResult) this.View("IndexVN", (object) userTradeDealVm) : (IActionResult) this.View("IndexUS", (object) userTradeDealVm);
      }
    }
  }
}
