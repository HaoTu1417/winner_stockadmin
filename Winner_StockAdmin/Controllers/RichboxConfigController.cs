// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RichboxConfigController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.RichboxConfig;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RichboxConfig")]
  public class RichboxConfigController : BaseController
  {
    [UseFilter(184, 15)]
    public IActionResult Edit() => (IActionResult) this.View((object) RichboxConfigBiz.Get());

    [UseFilter(184, 15)]
    public IActionResult PostEdit(RichboxConfigEditVm req)
    {
      try
      {
        RichboxConfigBiz.PostEdit(req, this.GetUser());
        this.ShowMessage("success_executed");
        return (IActionResult) this.View("Edit", (object) req);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }
  }
}
