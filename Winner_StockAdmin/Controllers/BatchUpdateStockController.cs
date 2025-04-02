// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BatchUpdateStockController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("BatchUpdateStock")]
  public class BatchUpdateStockController : BaseController
  {
    [MenuFilter(437, 8)]
    public IActionResult Index()
    {
      try
      {
        return (IActionResult) this.View((object) BatchUpdateStockBiz.GetStockSetting());
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View();
      }
    }

    [MenuFilter(437, 8)]
    public IActionResult PostEdit(BatchUpdateStockRequest req)
    {
      try
      {
        BatchUpdateStockBiz.BatchUpdateStock(req, this.GetUser());
        BatchUpdateStockBiz.GetStockSetting();
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        BatchUpdateStockBiz.GetStockSetting();
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
