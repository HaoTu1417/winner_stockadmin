// Decompiled with JetBrains decompiler
// Type: stockadmin.Filter.UseFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using stockadmin.Business;
using stockadmin.Controllers;
using stockadmin.Models;
using stockadmin.ViewModels.Menu;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Filter
{
  public class UseFilter : ActionFilterAttribute
  {
    public int id { get; set; }

    public int mid { get; set; }

    public UseFilter(int menuId, int moduleId)
    {
      this.id = menuId;
      this.mid = moduleId;
    }

    public virtual void OnActionExecuting(ActionExecutingContext filterContext)
    {
      try
      {
        ((ActionContext) filterContext).HttpContext.Request.RouteValues["action"].ToString();
        ((ActionContext) filterContext).HttpContext.Request.RouteValues["controller"].ToString();
        BaseController controller = filterContext.Controller as BaseController;
        AdminSession user = controller.GetUser();
        if (!this.CheckRolePower(user.role))
          filterContext.Result = (IActionResult) this.RedirectToUnAuthorized();
        int parentId = this.GetParentId(this.id);
        this.SetMenu(controller, user.role, parentId, this.mid);
      }
      catch (Exception ex)
      {
        filterContext.Result = (IActionResult) this.RedirectToUnAuthorized();
      }
    }

    public bool CheckRolePower(int role) => AdminRoleBiz.VerifyPower(this.id, this.mid, role);

    public int GetParentId(int id) => AdminMenuBiz.GetMenuByPK(id).parent;

    protected RedirectToRouteResult RedirectToUnAuthorized()
    {
      RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
      routeValueDictionary.Add("controller", (object) "Login");
      routeValueDictionary.Add("action", (object) "UnAuthorized");
      return new RedirectToRouteResult((object) routeValueDictionary);
    }

    public bool SetMenu(BaseController controller, int roleId, int id, int model)
    {
      AdminSession user = controller.GetUser();
      List<MainMenuVm> menuByRole = AdminMenuBiz.GetMenuByRole(roleId, user.lang);
      foreach (MainMenuVm mainMenuVm1 in menuByRole)
      {
        if (mainMenuVm1.Id == model)
        {
          mainMenuVm1.Active = "active";
          if (mainMenuVm1.Child != null)
          {
            foreach (MainMenuVm mainMenuVm2 in mainMenuVm1.Child)
            {
              if (mainMenuVm2.Id == id)
              {
                mainMenuVm2.Css += " active ";
                controller.ViewData["Menu"] = (object) menuByRole;
                controller.ViewData["workCtrl"] = (object) mainMenuVm1.Title;
                controller.ViewData["workAction"] = (object) mainMenuVm2.Title;
                controller.ViewData["Title"] = (object) mainMenuVm2.Title;
                return true;
              }
            }
          }
        }
      }
      return false;
    }
  }
}
