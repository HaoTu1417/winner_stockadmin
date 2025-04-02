// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminRoleController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Tree;
using stockadmin.Tool;
using stockadmin.ViewModels;
using stockadmin.ViewModels.AdminRole;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminRole")]
  public class AdminRoleController : BaseController
  {
    [MenuFilter(408, 10)]
    public IActionResult Index(ErrorVm? err = null)
    {
      try
      {
        if (err != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (AdminRoleController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            AdminRoleController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ErrorVm, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ShowAlter", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = AdminRoleController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AdminRoleController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, err);
        }
        List<AdminRoleList> adminRoleList = AdminRoleBiz.GetAdminRoleList(this.GetUser().is_super);
        TimeTool.ConvertTimeZone<AdminRoleList>(adminRoleList, BaseController.tz);
        return (IActionResult) this.View((object) adminRoleList);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View();
      }
    }

    [UseFilter(411, 10)]
    public IActionResult Edit(int id)
    {
      try
      {
        AdminRoleDto localTime = PublicTool.convertUtcToLocalTime<AdminRoleDto>(AdminRoleService.Find(id));
        List<PowerNode> tree = AdminRoleBiz.AdminMenuToTree(localTime.admin_menu);
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "tree", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, PublicTool.ToJson((object) tree));
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<AdminModuleDto>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "admin_module_list", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AdminRoleController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, AdminModuleBiz.GetEnabledList());
        return (IActionResult) this.View((object) localTime);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View();
      }
    }

    public IActionResult PostEdit(AdminRoleDto req, string tree)
    {
      try
      {
        req.admin_menu = AdminRoleBiz.TreeToAdminMenu(tree);
        AdminRoleBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        ((IDictionary<string, object>) this.TempData)["ErrorMessage"] = (object) ex.Message;
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Edit", (object) new
        {
          id = req.pk
        });
      }
    }

    [UseFilter(411, 10)]
    public IActionResult Create(AdminRoleDto? req)
    {
      try
      {
        AdminRoleDto adminRoleDto = req ?? new AdminRoleDto();
        List<PowerNode> tree = AdminRoleBiz.AdminMenuToTree(string.Empty);
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "tree", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, PublicTool.ToJson((object) tree));
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<AdminModuleDto>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "admin_module_list", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) AdminRoleController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, AdminModuleBiz.GetEnabledList());
        return (IActionResult) this.View((object) adminRoleDto);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Index");
      }
    }

    public IActionResult PostCreate(AdminRoleDto req, string tree)
    {
      try
      {
        req.admin_menu = AdminRoleBiz.TreeToAdminMenu(tree);
        AdminRoleBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        ((IDictionary<string, object>) this.TempData)["ErrorMessage"] = (object) ex.Message;
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Create", (object) req);
      }
    }

    [UseFilter(411, 10)]
    public IActionResult Delete(int id)
    {
      try
      {
        AdminRoleBiz.Delete(id, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowError(ex.Message);
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, IActionResult>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (IActionResult), typeof (AdminRoleController)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, IActionResult> target1 = AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, IActionResult>> p2 = AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, AdminRoleController, string, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, "RedirectToAction", (IEnumerable<Type>) null, typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, AdminRoleController, string, object, object> target2 = AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, AdminRoleController, string, object, object>> p1 = AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "ShowAlter", typeof (AdminRoleController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) AdminRoleController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag);
        object obj2 = target2((CallSite) p1, this, "Index", obj1);
        return target1((CallSite) p2, obj2);
      }
    }
  }
}
