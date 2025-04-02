// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.CacheController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Libs;

#nullable enable
namespace stockadmin.Controllers
{
  [MenuFilter(241, 10)]
  [TranslatorUIFilter("Cache")]
  public class CacheController : BaseController
  {
    public IActionResult Index() => (IActionResult) this.View();

    public IActionResult ReflashWarnning()
    {
      LanguageLib.InitErrorMsgCache();
      this.ShowMessage("重置警告訊息成功");
      return (IActionResult) this.View("Index");
    }

    public IActionResult UpdateMenu()
    {
      AdminMenuBiz.BuildMenu();
      this.ShowMessage("重置選單成功");
      return (IActionResult) this.View("Index");
    }

    public IActionResult UpdateConfig()
    {
      ConfigLib.Reset();
      this.ShowMessage("更新配置設置成功");
      return (IActionResult) this.View("Index");
    }
  }
}
