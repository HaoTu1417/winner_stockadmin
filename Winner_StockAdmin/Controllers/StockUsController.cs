// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StockUsController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.StockUs;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StockUs")]
  public class StockUsController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(102, 8)]
    public IActionResult Index(StockUsFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      StockUsVm stockUsVm = new StockUsVm()
      {
        filter = filter ?? new StockUsFilter()
      };
      try
      {
        List<StockUsList> stockUsList = StockUsBiz.GetStockUsList(stockUsVm.filter);
        stockUsVm.list = stockUsList.ToPagedList<StockUsList>(page, this.pageSize);
        return (IActionResult) this.View((object) stockUsVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) stockUsVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(102, 8)]
    public IActionResult Edit(string stock_code)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<StockUsDto>(StockUsBiz.Get(stock_code)));
    }

    public IActionResult PostEdit(StockUsDto req)
    {
      this.SetSelect();
      try
      {
        StockUsBiz.PostEdit(req, this.GetUser());
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
