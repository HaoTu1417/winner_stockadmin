// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminLoginBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminLogin;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AdminLoginBiz
  {
    public static List<AdminLoginList> GetAdminLoginList(AdminLoginFilter? filter)
    {
      List<AdminLoginList> adminLoginList = AdminLoginService.FindAdminLoginList(SqlTool.Build<AdminLoginFilter>(filter));
      return adminLoginList == null ? (List<AdminLoginList>) null : adminLoginList.Select<AdminLoginList, AdminLoginList>((Func<AdminLoginList, AdminLoginList>) (adminLogin => PublicTool.convertUtcToLocalTime<AdminLoginList>(adminLogin))).ToList<AdminLoginList>();
    }

    public static AdminLoginDto Get(int pk) => AdminLoginService.Find(pk);

    public static void PostCreate(AdminLoginDto req)
    {
      if (AdminLoginService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(AdminLoginDto req)
    {
      if (AdminLoginService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => AdminLoginService.Remove(pk);
  }
}
