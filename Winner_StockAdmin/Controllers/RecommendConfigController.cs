// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RecommendConfigController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.RecommendConfig;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RecommendConfig")]
  public class RecommendConfigController : BaseController
  {
    [MenuFilter(14, 12)]
    public IActionResult Index()
    {
      return (IActionResult) this.View((object) AdminConfigBiz.GetRecommendAdminConfig());
    }

    [UseFilter(14, 12)]
    public IActionResult PostEdit(RecommendConfigEditVm req)
    {
      try
      {
        AdminConfigBiz.PostRecommendConfigEdit(req, this.GetUser());
        this.ShowMessage("success_executed");
        return (IActionResult) this.View("Index", (object) req);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Index", (object) req);
      }
    }
  }
}
