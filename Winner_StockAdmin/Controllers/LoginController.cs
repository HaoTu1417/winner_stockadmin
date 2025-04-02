// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.LoginController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels.Login;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Login")]
  public class LoginController : BaseController
  {
    public IActionResult Index()
    {
      this.DeleteSession("token");
      ((ControllerBase) this).HttpContext.Session.Clear();
      this.ViewData["login_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(1);
      this.ViewData["operator_name"] = (object) ConfigLib.Get("operator_name");
      return (IActionResult) this.View((object) new LoginVm()
      {
        LoginProvider = "",
        ProviderKey = ""
      });
    }

    public IActionResult SignIn(LoginVm model)
    {
      string ip = PublicTool.Text((object) ((ControllerBase) this).HttpContext.Connection.RemoteIpAddress);
      // string platForm = this.GetPlatForm(StringValues.op_Implicit(((ControllerBase) this).Request.Headers["User-Agent"]));
      //
      string platForm = this.GetPlatForm(((ControllerBase) this).Request.Headers["User-Agent"].ToString());
      try
      {
        LoginBiz.CheckWhiteList(ip, model.LoginProvider);
        this.GetSession("Captcha.Code");
        AdminSession adminSession = LoginBiz.Authenticate(model.LoginProvider.ToString(), model.ProviderKey);
        AdminLoginBiz.PostCreate(new AdminLoginDto()
        {
          login_account = adminSession.account,
          ip = ip,
          ip_country = PublicTool.GetCountryByIp(ip),
          create_time = DateTime.UtcNow,
          status = true,
          device = platForm,
          remark = "Login successful"
        });
        AdminUserBiz.UpdateLoginInfo(adminSession.pk, ip);
        if (adminSession.change_password)
          return (IActionResult) ((ControllerBase) this).RedirectToAction("ChangePasswd", (object) new ChangePasswdVm()
          {
            LoginProvider = model.LoginProvider
          });
        if (adminSession.enable_mfa)
        {
          ((IDictionary<string, object>) this.TempData)["account"] = (object) adminSession.account;
          return (IActionResult) this.View("Mfa");
        }
        this.SetSession("token", (object) adminSession);
        AdminRoleDto adminRoleDto = AdminRoleBiz.Get(adminSession.role);
        Dictionary<int, int[]> dictionary = adminRoleDto.status ? PublicTool.FromJson<Dictionary<int, int[]>>(adminRoleDto.admin_menu) : throw new AppException(1238, "group_permission_closed");
        return dictionary != null && dictionary.ContainsKey(adminRoleDto.admin_module_fk) && dictionary[adminRoleDto.admin_module_fk].Length != 0 ? (IActionResult) ((ControllerBase) this).Redirect(AdminMenuBiz.GetMenuByPK(dictionary[adminRoleDto.admin_module_fk][0]).url_value) : (IActionResult) ((ControllerBase) this).RedirectToAction("Index", "home");
      }
      catch (AppException ex)
      {
        if (ex.GetStatus() != 1200)
          AdminLoginBiz.PostCreate(new AdminLoginDto()
          {
            login_account = model.LoginProvider,
            ip = ip,
            ip_country = PublicTool.GetCountryByIp(ip),
            create_time = DateTime.UtcNow,
            status = false,
            device = platForm,
            remark = "Login failed"
          });
        if (ex.GetStatus() == 300)
          return (IActionResult) ((ControllerBase) this).Forbid();
        this.ShowError(ex.Message);
        return (IActionResult) this.View("Index", (object) model);
      }
    }

    public IActionResult MfaVerification(MfaVm req)
    {
      string account = ((IDictionary<string, object>) this.TempData)["account"].ToString();
      this.ViewData["login_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(1);
      this.ViewData["operator_name"] = (object) ConfigLib.Get("operator_name");
      try
      {
        LoginBiz.VerifyMfa(account, req.MfaCode);
      }
      catch (AppException ex)
      {
        ((IDictionary<string, object>) this.TempData)["account"] = (object) account;
        this.ShowError(ex.Message);
        return (IActionResult) this.View("Mfa");
      }
      AdminUserDto byAccount = AdminUserBiz.GetByAccount(account);
      AdminSession adminSession = new AdminSession()
      {
        pk = byAccount.pk,
        role = byAccount.role,
        account = byAccount.account,
        nickName = byAccount.nickname,
        avatar = byAccount.avatar,
        lang = byAccount.lang
      };
      adminSession.is_super = AdminRoleBiz.GetAdminRole(adminSession.role).is_super;
      this.SetSession("token", (object) adminSession);
      AdminRoleDto adminRoleDto = AdminRoleBiz.Get(byAccount.role);
      Dictionary<int, int[]> dictionary = PublicTool.FromJson<Dictionary<int, int[]>>(adminRoleDto.admin_menu);
      return dictionary != null && dictionary.ContainsKey(adminRoleDto.admin_module_fk) && dictionary[adminRoleDto.admin_module_fk].Length != 0 ? (IActionResult) ((ControllerBase) this).Redirect(AdminMenuBiz.GetMenuByPK(dictionary[adminRoleDto.admin_module_fk][0]).url_value) : (IActionResult) ((ControllerBase) this).RedirectToAction("Index", "home");
    }

    public IActionResult ChangePasswd(ChangePasswdVm req)
    {
      this.ViewData["login_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(1);
      this.ViewData["operator_name"] = (object) ConfigLib.Get("operator_name");
      return (IActionResult) this.View((object) req);
    }

    public IActionResult ChangeAdminPasswd()
    {
      this.ViewData["login_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(1);
      this.ViewData["operator_name"] = (object) ConfigLib.Get("operator_name");
      AdminSession user = this.GetUser();
      return (IActionResult) ((ControllerBase) this).RedirectToAction("ChangePasswd", (object) new ChangePasswdVm()
      {
        LoginProvider = user.account
      });
    }

    public IActionResult PostChangePasswd(ChangePasswdVm req)
    {
      try
      {
        LoginBiz.ChangePassword(req.LoginProvider, req.ProviderKey, req.NewPassword, req.confirmPassword);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowError(ex.GetMessage(ConfigLib.Get("admin_language")));
        return (IActionResult) this.View("ChangePasswd", (object) req);
      }
    }

    public IActionResult UnAuthorized()
    {
      this.ViewData["login_logo_url"] = (object) AppLogoBiz.GetAppLogoUrl(1);
      this.ViewData["operator_name"] = (object) ConfigLib.Get("operator_name");
      return (IActionResult) this.View();
    }

    public string GetPlatForm(string userAgent)
    {
      string platForm = "Unknown";
      if (userAgent.Contains("Windows NT"))
        platForm = "Windows";
      else if (userAgent.Contains("Macintosh"))
        platForm = "macOS";
      else if (userAgent.Contains("iPhone") || userAgent.Contains("iPad"))
        platForm = "iOS";
      else if (userAgent.Contains("Android"))
        platForm = "Android";
      else if (userAgent.Contains("Linux"))
        platForm = "Linux";
      return platForm;
    }
  }
}
