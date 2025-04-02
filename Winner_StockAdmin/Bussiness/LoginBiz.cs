// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.LoginBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.ViewModels.Login;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class LoginBiz
  {
    public static bool VerifyPassword(string password, string dbpassword)
    {
      return BCrypt.Net.BCrypt.Verify(password, dbpassword);
    }

    public static void CheckWhiteList(string ip, string account)
    {
      if (Convert.ToInt32(ConfigLib.Get("enable_white_list")) != 1)
        return;
      AdminIpwhitelistDto byIpAndAccount = AdminIpwhitelistService.FindByIpAndAccount(ip, account);
      if (byIpAndAccount == null || byIpAndAccount.status == 0)
        throw new AppException(300, "ip_reject");
    }

    public static AdminSession Authenticate(string account, string password)
    {
      AdminUserDto byAccount = AdminUserBiz.GetByAccount(account);
      if (byAccount == null)
        throw new AppException(1270, "none_account");
      if (!byAccount.status)
        throw new AppException(1230, "account_expired");
      if (string.IsNullOrWhiteSpace(password))
        throw new AppException(1209, "incorrect_password");
      if (!LoginBiz.VerifyPassword(password, byAccount.password))
        throw new AppException(1209, "incorrect_password");
      bool isSuper = AdminRoleBiz.GetAdminRole(byAccount.role).is_super;
      return new AdminSession()
      {
        pk = byAccount.pk,
        role = byAccount.role,
        account = byAccount.account,
        nickName = byAccount.nickname,
        avatar = byAccount.avatar,
        lang = byAccount.lang,
        is_super = isSuper,
        change_password = byAccount.change_password,
        enable_mfa = !string.IsNullOrEmpty(byAccount.mfa_secret),
        invitation_code = byAccount.invitation_code
      };
    }

    public static void VerifyMfa(string account, string code)
    {
      if (string.IsNullOrEmpty(code))
        throw new AppException(1272, "mfa_code_required");
      AdminUserDto adminUserDto = AdminUserBiz.GetByAccount(account) ?? throw new AppException(1270, "none_account");
      if (string.IsNullOrEmpty(adminUserDto.mfa_secret))
        throw new AppException(1271, "mfa_not_enabled");
      if (!MfaLib.VerifyCode(adminUserDto.mfa_secret, code))
        throw new AppException(1273, "mfa_code_incorrect");
    }

    public static void AuthCaptcha(string userCode, string sysCode)
    {
      if (string.IsNullOrEmpty(sysCode))
        throw new AppException(1200, "incorrect_captcha_code");
      if (userCode != sysCode)
        throw new AppException(1200, "incorrect_captcha_code");
    }

    public static List<SelectListItem> GetAdminListVm()
    {
      List<SelectListItem> adminListVm = new List<SelectListItem>();
      foreach (AdminListVm admin in AdminUserService.FindAdminList())
        adminListVm.Add(new SelectListItem()
        {
          Text = admin.nickname,
          Value = admin.account
        });
      return adminListVm;
    }

    internal static void ChangePassword(
      string loginProvider,
      string providerKey,
      string newPassword,
      string confirmPassword)
    {
      if (newPassword != confirmPassword)
        throw new AppException(1320, "new_password_inconsistent");
      if (providerKey == newPassword)
        throw new AppException(1219, "same_new_current_password");
      if (newPassword.Length <= 5)
        throw new AppException(1208, "password_length_6_96_error");
      LoginBiz.Authenticate(loginProvider, providerKey);
      string newpassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
      AdminUserService.UpdatePassword(loginProvider, newpassword, false);
    }
  }
}
