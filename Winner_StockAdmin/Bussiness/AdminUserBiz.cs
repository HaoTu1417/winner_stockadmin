// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminUserBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class AdminUserBiz
  {
    public static List<AdminUserList> GetAdminUserList(AdminUserFilter? filter, bool is_super)
    {
      List<AdminUserList> adminUserList1 = AdminUserService.FindAdminUserList(SqlTool.Build<AdminUserFilter>(filter));
      List<AdminUserList> list = adminUserList1 != null ? adminUserList1.Select<AdminUserList, AdminUserList>((Func<AdminUserList, AdminUserList>) (adminUser => PublicTool.convertUtcToLocalTime<AdminUserList>(adminUser))).ToList<AdminUserList>() : (List<AdminUserList>) null;
      if (!is_super)
        list = list != null ? list.Where<AdminUserList>((Func<AdminUserList, bool>) (adminUserList => !adminUserList.is_super)).ToList<AdminUserList>() : (List<AdminUserList>) null;
      return list;
    }

    public static AdminUserDto Get(int pk) => AdminUserService.Find(pk);

    private static string CreatePassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public static void PostCreate(AdminUserDto req, AdminSession adminUser)
    {
      string password = AdminConfigService.Find("new_admin_password").value;
      req.password = AdminUserBiz.CreatePassword(password);
      int pkAfterInsert = AdminUserService.FindPkAfterInsert(req);
      if (pkAfterInsert == 0)
        throw new AppException(3020, "insert_record_false");
      string invitationCode = (pkAfterInsert + 2000).ToString();
      AdminUserService.UpdateIInvitationCode(pkAfterInsert, invitationCode);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 403,
        list = objArray
      });
    }

    public static void UpdateLoginInfo(int pk, string ip)
    {
      AdminUserService.UpdateLoginInfo(pk, ip);
    }

    public static void PostEdit(AdminUserDto req, AdminSession adminUser)
    {
      if (AdminUserService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 402,
        list = objArray
      });
    }

    public static void ResetPassword(string account)
    {
      string inputKey = ConfigLib.Get("new_admin_password");
      string newpassword = !string.IsNullOrWhiteSpace(inputKey) ? BCrypt.Net.BCrypt.HashPassword(inputKey) : throw new AppException(3020, "record_update_false");
      AdminUserService.UpdatePassword(account, newpassword, true);
    }

    public static bool Delete(int pk, AdminSession adminUser)
    {
      string account = AdminUserService.Find(pk).account;
      if (AdminUserService.FindIsSuper(pk))
        return false;
      AdminUserService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 404,
        list = objArray
      });
      return true;
    }

    public static AdminUserDto GetByAccount(string account)
    {
      return AdminUserService.FindByAccount(account);
    }

    public static List<SelectListItem> GetSelectList()
    {
      List<AdminUserDto> all = AdminUserService.FindAll();
      List<SelectListItem> selectList = new List<SelectListItem>();
      foreach (AdminUserDto adminUserDto in all)
      {
        List<SelectListItem> selectListItemList = selectList;
        SelectListItem selectListItem = new SelectListItem();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(adminUserDto.pk);
        selectListItem.Value = interpolatedStringHandler.ToStringAndClear();
        selectListItem.Text = adminUserDto.account;
        selectListItemList.Add(selectListItem);
      }
      return selectList;
    }
  }
}
