// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MutilangSubjectBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class MutilangSubjectBiz
  {
    public static List<MutilangSubjectDto> GetMutilangSubjectList()
    {
      return MutilangSubjectService.FindAll();
    }

    public static MutilangSubjectDto Get(string lang) => MutilangSubjectService.Find(lang);

    public static async void PostCreate(MutilangSubjectDto req, AdminSession adminUser)
    {
      req.icon = await UploadImageLib.UploadImage(FileManagementLib.Folder.flag, req.icon_file);
      if (MutilangSubjectService.Insert(req) == 0)
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
        admin_menu_fk = 230,
        list = objArray
      });
    }

    public static async void PostEdit(MutilangSubjectDto req, AdminSession adminUser)
    {
      if (req.icon_file != null)
        req.icon = await UploadImageLib.UploadImage(FileManagementLib.Folder.flag, req.icon_file);
      if (MutilangSubjectService.UpdateFull(req) == 0)
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
        admin_menu_fk = 228,
        list = objArray
      });
    }

    public static void Delete(string lang, AdminSession adminUser)
    {
      MutilangSubjectService.Remove(lang);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) lang
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 231,
        list = objArray
      });
    }

    public static MutilangSubjectDto GetAdminDefault() => MutilangSubjectService.FindAdminDefault();
  }
}
