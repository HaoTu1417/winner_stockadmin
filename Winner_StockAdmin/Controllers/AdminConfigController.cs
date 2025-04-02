// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminConfigController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminConfig;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminConfig")]
  public class AdminConfigController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(89, 9)]
    public IActionResult Index(AdminConfigFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (AdminConfigController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (AdminConfigController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AdminConfigController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      AdminConfigVm adminConfigVm = new AdminConfigVm()
      {
        filter = filter ?? new AdminConfigFilter()
      };
      try
      {
        List<AdminConfigList> commonAdminConfigList = AdminConfigBiz.GetCommonAdminConfigList(adminConfigVm.filter, this.GetUser());
        adminConfigVm.list = commonAdminConfigList.ToPagedList<AdminConfigList>(page, pageSize);
        return (IActionResult) this.View((object) adminConfigVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) adminConfigVm);
      }
    }

    public void SetSelect()
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      selectListItemList.Add(new SelectListItem()
      {
        Text = "藍色",
        Value = "blue",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "紅色",
        Value = "red",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "灰色",
        Value = "gray",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "棕色",
        Value = "brown",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "紫色",
        Value = "purple",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "綠色",
        Value = "green",
        Selected = false
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "黑色",
        Value = "black",
        Selected = false
      });
      // ISSUE: reference to a compiler-generated field
      if (AdminConfigController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminConfigController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "themes", typeof (AdminConfigController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = AdminConfigController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) AdminConfigController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, selectListItemList);
    }

    [UseFilter(89, 9)]
    public IActionResult Edit(string name)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AdminConfigDto>(AdminConfigBiz.Get(name)));
    }

    public IActionResult PostEdit(AdminConfigDto req)
    {
      this.SetSelect();
      try
      {
        AdminConfigBiz.PostEdit(req, this.GetUser());
        ConfigLib.Reset();
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(89, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new AdminConfigDto());
    }

    public IActionResult PostCreate(AdminConfigDto req)
    {
      this.SetSelect();
      try
      {
        AdminConfigBiz.PostCreate(req, this.GetUser());
        ConfigLib.Reset();
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    public IActionResult UpdateCache()
    {
      try
      {
        ConfigLib.Reset();
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
      }
      return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
    }
  }
}
