// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.DemoController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models;
using stockadmin.ViewModels.Demo;
using System;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  public class DemoController : BaseController
  {
    private void SetPermissions()
    {
      AdminSession user = this.GetUser();
      this.ViewData["btn1"] = (object) AdminRoleBiz.VerifyPower(131, 14, user.role);
      this.ViewData["btn2"] = (object) AdminRoleBiz.VerifyPower(132, 14, user.role);
    }

    [MenuFilter(130, 14)]
    public IActionResult Index(int page = 1)
    {
      try
      {
        List<DemoMemberListVm> superset = new List<DemoMemberListVm>();
        for (int index = 1; index <= 10000; ++index)
        {
          DemoMemberListVm demoMemberListVm = new DemoMemberListVm()
          {
            id = index,
            account = "Jack" + (index + 1).ToString(),
            realName = "Kaba" + (index + 1).ToString()
          };
          superset.Add(demoMemberListVm);
        }
        this.SetPermissions();
        return (IActionResult) this.View((object) superset.ToPagedList<DemoMemberListVm>(page, this.pageSize));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View();
      }
    }

    [UseFilter(131, 14)]
    public IActionResult Edit(int id)
    {
      DemoMemberVm demoMemberVm = new DemoMemberVm()
      {
        id = id,
        account = "Jack" + id.ToString(),
        realName = "Kaba" + id.ToString(),
        isSucceed = true
      };
      demoMemberVm.email = demoMemberVm.account + "@gamil.com";
      demoMemberVm.birthday = new DateTime(1989, 9, 8);
      return (IActionResult) this.View((object) demoMemberVm);
    }

    public IActionResult PostEdit(DemoMemberVm req)
    {
      try
      {
        if (req.isSucceed)
          return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
        this.ShowWarning("某某內容錯誤, 請修正");
        return (IActionResult) this.View("Edit", (object) req);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(132, 14)]
    public IActionResult Details(int id)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Edit", (object) id);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [MenuFilter(133, 14)]
    public IActionResult SearchIndex()
    {
      DemoSearchVm demoSearchVm = new DemoSearchVm();
      try
      {
        demoSearchVm.list = DemoBiz.GetSearchList(demoSearchVm.filter).ToPagedList<DemoSearchList>(1, this.pageSize);
        return (IActionResult) this.View(nameof (SearchIndex), (object) demoSearchVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View(nameof (SearchIndex), (object) demoSearchVm);
      }
    }

    [MenuFilter(133, 14)]
    public IActionResult PostSearch(DemoSearchFilter filter, int page = 1)
    {
      DemoSearchVm demoSearchVm = new DemoSearchVm()
      {
        filter = filter
      };
      try
      {
        demoSearchVm.list = DemoBiz.GetSearchList(demoSearchVm.filter).ToPagedList<DemoSearchList>(page, this.pageSize);
        return (IActionResult) this.View("SearchIndex", (object) demoSearchVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("SearchIndex", (object) demoSearchVm);
      }
    }
  }
}
