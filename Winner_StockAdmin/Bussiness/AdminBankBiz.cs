// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminBankBiz
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
using stockadmin.ViewModels.AdminBank;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AdminBankBiz
  {
    public static List<AdminBankList> GetAdminBankList(AdminBankFilter? filter, string lang)
    {
      List<AdminBankList> adminBankList = AdminBankService.FindAdminBankList(SqlTool.Build<AdminBankFilter>(filter), lang);
      return adminBankList == null ? (List<AdminBankList>) null : adminBankList.Select<AdminBankList, AdminBankList>((Func<AdminBankList, AdminBankList>) (adminBank => PublicTool.convertUtcToLocalTime<AdminBankList>(adminBank))).ToList<AdminBankList>();
    }

    public static AdminBankDto Get(int pk) => AdminBankService.Find(pk);

    public static async void PostCreate(AdminBankDto req, AdminSession adminUser)
    {
      if (req.image_file != null)
        req.image = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.image_file);
      if (AdminBankService.FindPkAfterInsert(PublicTool.convertLocalToUtcTime<AdminBankDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.card
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 435,
        list = objArray
      });
    }

    public static async void PostEdit(AdminBankDto req, AdminSession adminUser)
    {
      if (req.image_file != null)
        req.image = await UploadImageLib.UploadImage(FileManagementLib.Folder.article, req.image_file);
      if (AdminBankService.UpdateFull(PublicTool.convertLocalToUtcTime<AdminBankDto>(req)) == 0)
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
        admin_menu_fk = 302,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string card = AdminBankService.Find(pk).card;
      AdminBankService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) card
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 304,
        list = objArray
      });
    }
  }
}
