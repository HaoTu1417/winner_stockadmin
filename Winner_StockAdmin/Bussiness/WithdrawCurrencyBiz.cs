// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WithdrawCurrencyBiz
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
using stockadmin.ViewModels.WithdrawCurrency;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class WithdrawCurrencyBiz
  {
    public static List<WithdrawCurrencyList> GetWithdrawCurrencyList(
      WithdrawCurrencyFilter? filter,
      string lang)
    {
      return WithdrawSupportCurrencyService.FindWithdrawSupportCurrency(SqlTool.Build<WithdrawCurrencyFilter>(filter), lang);
    }

    public static WithdrawSupportCurrencyDto Get(int pk) => WithdrawSupportCurrencyService.Find(pk);

    public static void PostCreate(WithdrawSupportCurrencyDto req, AdminSession adminUser)
    {
      if (WithdrawSupportCurrencyService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.currency
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 32,
        list = objArray
      });
    }

    public static void PostEdit(WithdrawSupportCurrencyDto req, AdminSession adminUser)
    {
      if (WithdrawSupportCurrencyService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.currency
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 30,
        list = objArray
      });
    }
  }
}
