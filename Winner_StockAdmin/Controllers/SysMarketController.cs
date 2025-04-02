// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.SysMarketController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("SysMarket")]
  public class SysMarketController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(227, 9)]
    public IActionResult Index()
    {
      this.SetFilterSelect();
      try
      {
        return (IActionResult) this.View((object) SysMarketBiz.GetSysMarketList());
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((string) null);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(227, 9)]
    public IActionResult Edit(string code)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) SysMarketBiz.Get(code));
    }

    public IActionResult PostEdit(SysMarketDto req)
    {
      this.SetSelect();
      try
      {
        SysMarketBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(227, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new SysMarketDto());
    }

    public IActionResult PostCreate(SysMarketDto req)
    {
      this.SetSelect();
      try
      {
        SysMarketBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }
  }
}
