// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.ExchangeRateController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.ExchangeRate;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("ExchangeRate")]
  public class ExchangeRateController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(423, 5)]
    public IActionResult Index(ExchangeRateFilter Filter, int page = 1)
    {
      this.SetFilterSelect();
      ExchangeRateVm exchangeRateVm = new ExchangeRateVm()
      {
        filter = Filter ?? new ExchangeRateFilter()
      };
      try
      {
        exchangeRateVm.list = ExchangeRateBiz.GetExchangeRateList(exchangeRateVm.filter).ToPagedList<ExchangeRateList>(page, this.pageSize);
        return (IActionResult) this.View((object) exchangeRateVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) exchangeRateVm);
      }
    }
  }
}
