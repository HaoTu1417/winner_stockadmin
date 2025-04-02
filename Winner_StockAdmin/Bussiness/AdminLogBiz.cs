// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminLogBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminLog;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AdminLogBiz
  {
    public static List<AdminLogList> GetAdminLogList(AdminLogFilter? filter)
    {
      List<AdminLogList> adminLogList = AdminLogService.FindAdminLogList(SqlTool.Build<AdminLogFilter>(filter));
      return adminLogList == null ? (List<AdminLogList>) null : adminLogList.Select<AdminLogList, AdminLogList>((Func<AdminLogList, AdminLogList>) (adminlog => PublicTool.convertUtcToLocalTime<AdminLogList>(adminlog))).ToList<AdminLogList>();
    }

    public static AdminLogDto Get(int pk) => AdminLogService.Find(pk);

    public static void PostCreate(AdminLogDto req)
    {
      if (AdminLogService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(AdminLogDto req)
    {
      if (AdminLogService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => AdminLogService.Remove(pk);
  }
}
