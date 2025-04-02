// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StockOptionRecordController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.StockOptionRecord;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StockOption")]
  public class StockOptionRecordController : BaseController
  {
    public void SetSelect()
    {
    }

    [MenuFilter(372, 2)]
    public IActionResult Index(StockOptionRecordFilter filter, int page = 1)
    {
      this.SetSelect();
      StockOptionRecordVm stockOptionRecordVm = new StockOptionRecordVm()
      {
        filter = filter ?? new StockOptionRecordFilter()
      };
      try
      {
        stockOptionRecordVm.list = StockOptionRecordBiz.GetStockOptionRecordList(stockOptionRecordVm.filter).ToPagedList<StockOptionRecordList>(page, this.pageSize);
        return (IActionResult) this.View((object) stockOptionRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) stockOptionRecordVm);
      }
    }
  }
}
