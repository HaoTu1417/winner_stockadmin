// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MarqueeBiz
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
using stockadmin.ViewModels.Marquee;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class MarqueeBiz
  {
    public static List<MarqueeList> GetMarqueeList(MarqueeFilter? filter)
    {
      return CmsMarqService.FindMarqueeList(SqlTool.Build<MarqueeFilter>(filter));
    }

    public static CmsMarqDto Get(int pk) => CmsMarqService.Find(pk);

    public static void PostCreate(CmsMarqDto req, AdminSession adminUser)
    {
      if (CmsMarqService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.msg
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 175,
        list = objArray
      });
    }

    public static void PostEdit(CmsMarqDto req, AdminSession adminUser)
    {
      if (CmsMarqService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.msg
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 174,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string msg = CmsMarqService.Find(pk).msg;
      CmsMarqService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) msg
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 176,
        list = objArray
      });
    }
  }
}
