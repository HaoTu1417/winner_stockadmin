// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletTemplateBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.WalletTemplate;

#nullable enable
namespace stockadmin.Business
{
  public class WalletTemplateBiz
  {
    public static DataCountBase<WalletTemplateList> GetWalletTemplateList(
      WalletTemplateFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<WalletTemplateFilter>(filter);
      DataCountBase<WalletTemplateList> walletTemplateList = WalletTemplateService.FindWalletTemplateList(page, pageSize, whereSql);
      return new DataCountBase<WalletTemplateList>(walletTemplateList.count, walletTemplateList.data);
    }

    public static WalletTemplateDto Get(int pk) => WalletTemplateService.Find(pk);

    public static void PostCreate(WalletTemplateDto req, AdminSession adminUser)
    {
      if (WalletTemplateService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 32,
        list = objArray
      });
    }

    public static void PostEdit(WalletTemplateDto req, AdminSession adminUser)
    {
      if (WalletTemplateService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 30,
        list = objArray
      });
    }

    public static void Delete(int pk) => WalletTemplateService.Remove(pk);

    public static WalletTemplateEditVm GetEditVm(int pk)
    {
      return WalletTemplateService.FindWalletTemplateEditVm(pk);
    }
  }
}
