// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradeCancelController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.TradeCancel;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradeCancel")]
  public class TradeCancelController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(367, 2)]
    public IActionResult IndexVN(string subAccount, TradeCancelFilter filter)
    {
      if (string.IsNullOrEmpty(subAccount))
        subAccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      TradeCancelVm tradeCancelVm = new TradeCancelVm()
      {
        sub_account = subAccount,
        filter = filter ?? new TradeCancelFilter()
      };
      try
      {
        tradeCancelVm.list = TradeCancelBiz.GetTradeCancelList(subAccount, tradeCancelVm.filter);
        return (IActionResult) this.View((object) tradeCancelVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeCancelVm);
      }
    }

    [UseFilter(357, 2)]
    public IActionResult IndexUS(string subAccount, TradeCancelFilter filter)
    {
      if (string.IsNullOrEmpty(subAccount))
        subAccount = !string.IsNullOrEmpty(filter.sub_account) ? filter.sub_account : throw new AppException(210, "illegal_operation");
      this.SetFilterSelect();
      TradeCancelVm tradeCancelVm = new TradeCancelVm()
      {
        sub_account = subAccount,
        filter = filter ?? new TradeCancelFilter()
      };
      try
      {
        tradeCancelVm.list = TradeCancelBiz.GetTradeCancelList(subAccount, tradeCancelVm.filter);
        return (IActionResult) this.View((object) tradeCancelVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeCancelVm);
      }
    }
  }
}
