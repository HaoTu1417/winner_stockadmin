// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminUserController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using QRCoder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminUser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminUser")]
  public class AdminUserController : BaseController
  {
    public void SetSelect()
    {
      AdminSession user = this.GetUser();
      // ISSUE: reference to a compiler-generated field
      if (AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "roleDropdown", typeof (AdminUserController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, AdminRoleBiz.FindSelectList(user.is_super));
      // ISSUE: reference to a compiler-generated field
      if (AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (AdminUserController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) AdminUserController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(402, 10)]
    public IActionResult Index(AdminUserFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      AdminUserVm adminUserVm = new AdminUserVm()
      {
        filter = filter ?? new AdminUserFilter()
      };
      // ISSUE: reference to a compiler-generated field
      if (AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (AdminUserController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (AdminUserController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AdminUserController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      AdminSession user = this.GetUser();
      try
      {
        List<AdminUserList> adminUserList = AdminUserBiz.GetAdminUserList(adminUserVm.filter, user.is_super);
        adminUserVm.list = adminUserList.ToPagedList<AdminUserList>(page, pageSize);
        adminUserVm.roleDropdown = AdminRoleBiz.FindSelectList(this.GetUser().is_super);
        return (IActionResult) this.View((object) adminUserVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) adminUserVm);
      }
    }

    [UseFilter(402, 10)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AdminUserDto>(AdminUserBiz.Get(pk)));
    }

    public IActionResult PostEdit(AdminUserDto req)
    {
      this.SetSelect();
      try
      {
        AdminUserBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req.pk);
      }
    }

    [UseFilter(402, 10)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new AdminUserDto());
    }

    public IActionResult PostCreate(AdminUserDto req)
    {
      this.SetSelect();
      try
      {
        AdminUserBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    public IActionResult ResetPassword(string account)
    {
      this.SetSelect();
      try
      {
        AdminUserBiz.ResetPassword(account);
        this.ShowMessage(ConfigLib.Get("new_admin_password"));
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [UseFilter(402, 10)]
    public IActionResult Delete(int pk)
    {
      this.SetSelect();
      try
      {
        if (!AdminUserBiz.Delete(pk, this.GetUser()))
          this.ShowWarning("super user can't be deleted");
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [HttpGet]
    public IActionResult GenerateMfaSecret()
    {
      using (new MemoryStream())
      {
        string secretKey = MfaLib.GenerateSecretKey();
        string str = "data:image/png;base64," + Convert.ToBase64String(((IEnumerable<byte>) new PngByteQRCode(new QRCodeGenerator().CreateQrCode(MfaLib.GenerateUri("stockadmin", "Flyer", secretKey), QRCodeGenerator.ECCLevel.Q)).GetGraphic(5)).ToArray<byte>());
        return (IActionResult) ((ControllerBase) this).Ok((object) new
        {
          secret = secretKey,
          image = str
        });
      }
    }

    [HttpPost]
    public IActionResult VerifyMfaCode([FromBody] MfaVerifyDto data)
    {
      bool flag = MfaLib.VerifyCode(data.Secret, data.Code);
      if (flag)
        AdminUserService.UpdateMfaSecret(data.Pk, data.Secret);
      return (IActionResult) ((ControllerBase) this).Ok((object) flag);
    }

    [HttpPost]
    public IActionResult RemoveMfaCode([FromBody] MfaVerifyDto data)
    {
      string mfaSecret = AdminUserService.GetMfaSecret(data.Pk);
      if (string.IsNullOrEmpty(mfaSecret))
        return (IActionResult) ((ControllerBase) this).Ok((object) false);
      if (data.Code == null)
      {
        AdminUserService.UpdateMfaSecret(data.Pk, (string) null);
        return (IActionResult) ((ControllerBase) this).Ok((object) true);
      }
      bool flag = MfaLib.VerifyCode(mfaSecret, data.Code);
      if (flag)
        AdminUserService.UpdateMfaSecret(data.Pk, (string) null);
      return (IActionResult) ((ControllerBase) this).Ok((object) flag);
    }

    [HttpPost]
    public IActionResult SetLang([FromBody] ChangeLangRequest data)
    {
      AdminSession user = this.GetUser();
      user.lang = data.lang;
      AdminUserService.SetLang(user.pk, data.lang);
      this.SetSession("token", (object) user);
      return (IActionResult) ((ControllerBase) this).Ok((object) 200);
    }
  }
}
