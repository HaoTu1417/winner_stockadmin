// Decompiled with JetBrains decompiler
// Type: stockadmin.Filter.MenuFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using stockadmin.Business;
using stockadmin.Controllers;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.ViewModels.Menu;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Filter
{
  public class MenuFilter : ActionFilterAttribute
  {
    private BaseController? controller;

    public int id { get; set; }

    public int mid { get; set; }

    public MenuFilter(int menuId, int moduleId)
    {
      this.id = menuId;
      this.mid = moduleId;
    }

    public virtual void OnActionExecuting(ActionExecutingContext filterContext)
    {
      try
      {
        this.controller = filterContext.Controller as BaseController;
        AdminSession user = this.controller.GetUser();
        if (user != null && this.SetMenu(user.role, this.id, this.mid))
          return;
        filterContext.Result = (IActionResult) this.RedirectToLogin();
      }
      catch (Exception ex)
      {
        LogLib.Error(ex);
        filterContext.Result = (IActionResult) this.RedirectToLogin();
      }
    }

    protected RedirectToRouteResult RedirectToLogin()
    {
      RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
      routeValueDictionary.Add("controller", (object) "Login");
      routeValueDictionary.Add("action", (object) "Index");
      return new RedirectToRouteResult((object) routeValueDictionary);
    }

    public bool SetMenu(int roleId, int id, int model)
    {
      AdminSession user = this.controller.GetUser();
      List<MainMenuVm> menuByRole = AdminMenuBiz.GetMenuByRole(roleId, user.lang);
      if (user.lang.ToLower() == "vn")
        this.controller.ViewData["menu_lang"] = (object) "họ ngôn ngữ";
      else if (user.lang.ToLower() == "cn")
        this.controller.ViewData["menu_lang"] = (object) "語系";
      else
        this.controller.ViewData["menu_lang"] = (object) "Language";
      if (user.lang.ToLower() == "vn")
        this.controller.ViewData["logout"] = (object) "Đăng xuất";
      else if (user.lang.ToLower() == "cn")
        this.controller.ViewData["logout"] = (object) "登出";
      else
        this.controller.ViewData["logout"] = (object) "Logout";
      if (user.lang.ToLower() == "vn")
        this.controller.ViewData["changepwd"] = (object) "đổi mật khẩu";
      else if (user.lang.ToLower() == "cn")
        this.controller.ViewData["changepwd"] = (object) "更改密碼";
      else
        this.controller.ViewData["changepwd"] = (object) "Change password";
      if (user.lang.ToLower() == "vn")
        this.controller.ViewData["invitation_code"] = (object) "Mã khuyến mãi";
      else if (user.lang.ToLower() == "cn")
        this.controller.ViewData["invitation_code"] = (object) "推廣碼";
      else
        this.controller.ViewData["invitation_code"] = (object) "Invitation code";
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
                this.controller.ViewData["Menu"] = (object) menuByRole;
                this.controller.ViewData["workCtrl"] = (object) mainMenuVm1.Title;
                this.controller.ViewData["workAction"] = (object) mainMenuVm2.Title;
                this.controller.ViewData["Title"] = (object) mainMenuVm2.Title;
                this.controller.ViewData["UserName"] = (object) user.nickName;
                this.controller.ViewData["InvitationCode"] = (object) user.invitation_code;
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
