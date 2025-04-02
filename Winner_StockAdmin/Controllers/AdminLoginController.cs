// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminLoginController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.AdminLogin;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminLogin")]
  public class AdminLoginController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(239, 13)]
    public IActionResult Index(AdminLoginFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      AdminLoginVm adminLoginVm = new AdminLoginVm()
      {
        filter = filter ?? new AdminLoginFilter()
      };
      try
      {
        List<AdminLoginList> adminLoginList = AdminLoginBiz.GetAdminLoginList(adminLoginVm.filter);
        adminLoginVm.list = adminLoginList.ToPagedList<AdminLoginList>(page, this.pageSize);
        return (IActionResult) this.View((object) adminLoginVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) adminLoginVm);
      }
    }

    [UseFilter(239, 13)]
    public IActionResult Delete(int pk)
    {
      try
      {
        AdminLoginBiz.Delete(pk);
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
