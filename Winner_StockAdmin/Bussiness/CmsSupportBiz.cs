// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.CmsSupportBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.CmsSupport;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class CmsSupportBiz
  {
    public static List<CmsSupportList> GetCmsSupportList(CmsSupportFilter? filter)
    {
      List<CmsSupportList> cmsSupportList = CmsSupportService.FindCmsSupportList(SqlTool.Build<CmsSupportFilter>(filter));
      return cmsSupportList == null ? (List<CmsSupportList>) null : cmsSupportList.Select<CmsSupportList, CmsSupportList>((Func<CmsSupportList, CmsSupportList>) (cmsSupport => PublicTool.convertUtcToLocalTime<CmsSupportList>(cmsSupport))).ToList<CmsSupportList>();
    }

    public static CmsSupportDto Get(int pk) => CmsSupportService.Find(pk);

    public static void PostCreate(CmsSupportDto req, AdminSession adminUser)
    {
      if (CmsSupportService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<CmsSupportDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 24,
        list = objArray
      });
    }

    public static void PostEdit(CmsSupportDto req, AdminSession adminUser)
    {
      if (CmsSupportService.UpdateFull(PublicTool.convertLocalToUtcTime<CmsSupportDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 23,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      CmsSupportService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 25,
        list = objArray
      });
    }
  }
}
