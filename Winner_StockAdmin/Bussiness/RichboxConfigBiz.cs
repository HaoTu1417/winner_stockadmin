// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RichboxConfigBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.ViewModels.RichboxConfig;

#nullable enable
namespace stockadmin.Business
{
  public class RichboxConfigBiz
  {
    public static RichboxConfigEditVm Get() => RichboxConfigService.FindRichboxConfigEditVm();

    public static void PostEdit(RichboxConfigEditVm req, AdminSession adminUser)
    {
      if (RichboxConfigService.Update(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.id
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 184,
        list = objArray
      });
    }
  }
}
