// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StockVnController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.StockVn;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StockVn")]
  public class StockVnController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(101, 8)]
    public IActionResult Index(StockVnFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      StockVnVm stockVnVm = new StockVnVm()
      {
        filter = filter ?? new StockVnFilter()
      };
      try
      {
        List<StockVnList> stockVnList = StockVnBiz.GetStockVnList(stockVnVm.filter);
        stockVnVm.list = stockVnList.ToPagedList<StockVnList>(page, this.pageSize);
        return (IActionResult) this.View((object) stockVnVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) stockVnVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(101, 8)]
    public IActionResult Edit(string stock_code)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<StockVnDto>(StockVnBiz.Get(stock_code)));
    }

    public IActionResult PostEdit(StockVnDto req)
    {
      this.SetSelect();
      try
      {
        StockVnBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }
  }
}
