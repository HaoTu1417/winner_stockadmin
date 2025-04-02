// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.IpwhitelistController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.Ipwhitelist;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Ipwhitelist")]
  public class IpwhitelistController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(48, 10)]
    public IActionResult Index(IpwhitelistFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      IpwhitelistVm ipwhitelistVm = new IpwhitelistVm()
      {
        filter = filter ?? new IpwhitelistFilter()
      };
      try
      {
        ipwhitelistVm.list = IpwhitelistBiz.GetIpwhitelistList(ipwhitelistVm.filter).ToPagedList<IpwhitelistList>(page, this.pageSize);
        return (IActionResult) this.View((object) ipwhitelistVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) ipwhitelistVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(48, 10)]
    public IActionResult Edit(string ip)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AdminIpwhitelistDto>(IpwhitelistBiz.Get(ip)));
    }

    public IActionResult PostEdit(AdminIpwhitelistDto req)
    {
      this.SetSelect();
      try
      {
        IpwhitelistBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Edit", (object) req);
      }
    }

    [UseFilter(48, 10)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new AdminIpwhitelistDto());
    }

    public IActionResult PostCreate(AdminIpwhitelistDto req)
    {
      this.SetSelect();
      try
      {
        IpwhitelistBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(48, 10)]
    public IActionResult Delete(string ip)
    {
      try
      {
        IpwhitelistBiz.Delete(ip, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
