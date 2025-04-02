// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.SysCountryBiz
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
using stockadmin.ViewModels.SysCountry;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class SysCountryBiz
  {
    public static List<SysCountryList> GetSysCountryList(SysCountryFilter? filter)
    {
      return SysCountryService.FindSysCountryList(SqlTool.Build<SysCountryFilter>(filter));
    }

    public static SysCountryDto Get(string pk) => SysCountryService.Find(pk);

    public static async void PostCreate(SysCountryDto req, AdminSession adminUser)
    {
      if (req.flag_file != null)
        req.flag = await UploadImageLib.UploadImage(FileManagementLib.Folder.flag, req.flag_file);
      if (SysCountryService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.label
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 425,
        list = objArray
      });
    }

    public static async void PostEdit(SysCountryDto req, AdminSession adminUser)
    {
      if (req.flag_file != null)
        req.flag = await UploadImageLib.UploadImage(FileManagementLib.Folder.flag, req.flag_file);
      if (SysCountryService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.label
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 424,
        list = objArray
      });
    }

    public static void Delete(string pk, AdminSession adminUser)
    {
      SysCountryService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 426,
        list = objArray
      });
    }
  }
}
