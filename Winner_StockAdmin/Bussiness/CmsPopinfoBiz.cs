// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.CmsPopinfoBiz
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
using stockadmin.ViewModels.CmsPopinfo;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class CmsPopinfoBiz
  {
    public static List<CmsPopinfoList> GetCmsPopinfoList(CmsPopinfoFilter? filter)
    {
      List<CmsPopinfoList> cmsPopinfoList = CmsPopinfoService.FindCmsPopinfoList(SqlTool.Build<CmsPopinfoFilter>(filter));
      return cmsPopinfoList == null ? (List<CmsPopinfoList>) null : cmsPopinfoList.Select<CmsPopinfoList, CmsPopinfoList>((Func<CmsPopinfoList, CmsPopinfoList>) (cmsPopinfo => PublicTool.convertUtcToLocalTime<CmsPopinfoList>(cmsPopinfo))).ToList<CmsPopinfoList>();
    }

    public static CmsPopinfoDto Get(int pk) => CmsPopinfoService.Find(pk);

    public static void PostCreate(CmsPopinfoDto req, AdminSession adminUser)
    {
      if (CmsPopinfoService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<CmsPopinfoDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.info
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 210,
        list = objArray
      });
    }

    public static void PostEdit(CmsPopinfoDto req, AdminSession adminUser)
    {
      if (CmsPopinfoService.UpdateFull(PublicTool.convertLocalToUtcTime<CmsPopinfoDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.info
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 209,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string info = CmsPopinfoService.Find(pk).info;
      CmsPopinfoService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) info
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 211,
        list = objArray
      });
    }
  }
}
