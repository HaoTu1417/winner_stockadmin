// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MenuController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;

#nullable enable
namespace stockadmin.Controllers
{
  public class MenuController : Controller
  {
    public IActionResult MainMenu()
    {
      return (IActionResult) this.View((object) AdminMenuBiz.GetMenuByRole(1));
    }
  }
}
