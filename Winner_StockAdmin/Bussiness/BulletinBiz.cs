// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BulletinBiz
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
using stockadmin.ViewModels.Bulletin;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class BulletinBiz
  {
    public static List<BulletinList> GetBulletinList(BulletinFilter? filter)
    {
      List<BulletinList> bulletinList = CmsBulletinService.FindBulletinList(SqlTool.Build<BulletinFilter>(filter));
      return bulletinList == null ? (List<BulletinList>) null : bulletinList.Select<BulletinList, BulletinList>((Func<BulletinList, BulletinList>) (bulletin => PublicTool.convertUtcToLocalTime<BulletinList>(bulletin))).ToList<BulletinList>();
    }

    public static CmsBulletinDto Get(int pk) => CmsBulletinService.Find(pk);

    public static async void PostCreate(CmsBulletinDto req, AdminSession adminUser)
    {
      if (req.img_file != null)
        req.img_url = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.img_file);
      if (CmsBulletinService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<CmsBulletinDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 144,
        list = objArray
      });
    }

    public static async void PostEdit(CmsBulletinDto req, AdminSession adminUser)
    {
      if (req.img_file != null)
        req.img_url = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.img_file);
      if (CmsBulletinService.UpdateFull(PublicTool.convertLocalToUtcTime<CmsBulletinDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 143,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string title = CmsBulletinService.Find(pk).title;
      CmsBulletinService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 145,
        list = objArray
      });
    }
  }
}
