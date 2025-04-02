// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.TradeMoneyCheckController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.TradeMoneyCheck;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("TradeMoneyCheck")]
  public class TradeMoneyCheckController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(260, 2)]
    public IActionResult Index(TradeMoneyCheckFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      TradeMoneyCheckVm tradeMoneyCheckVm = new TradeMoneyCheckVm()
      {
        filter = filter ?? new TradeMoneyCheckFilter()
      };
      try
      {
        tradeMoneyCheckVm.list = TradeMoneyCheckBiz.GetTradeMoneyCheckList(tradeMoneyCheckVm.filter).ToPagedList<TradeMoneyCheckList>(page, this.pageSize);
        return (IActionResult) this.View((object) tradeMoneyCheckVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) tradeMoneyCheckVm);
      }
    }

    [MenuFilter(260, 2)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) TradeMoneyCheckBiz.GetReview(pk));
    }

    public IActionResult PostReview(TradeMoneyCheckDto req, bool result)
    {
      try
      {
        TradeMoneyCheckBiz.WithdrawVerify(req.pk, result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) req);
      }
    }
  }
}
