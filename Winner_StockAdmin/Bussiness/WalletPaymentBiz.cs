// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletPaymentBiz
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
using stockadmin.ViewModels.WalletPayment;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class WalletPaymentBiz
  {
    public static List<WalletPaymentList> GetWalletPaymentList(WalletPaymentFilter? filter)
    {
      List<WalletPaymentList> walletPaymentList1 = WalletPaymentService.FindWalletPaymentList(SqlTool.Build<WalletPaymentFilter>(filter));
      List<WalletPaymentList> list = walletPaymentList1 != null ? walletPaymentList1.Select<WalletPaymentList, WalletPaymentList>((Func<WalletPaymentList, WalletPaymentList>) (walletPayment => PublicTool.convertUtcToLocalTime<WalletPaymentList>(walletPayment))).ToList<WalletPaymentList>() : (List<WalletPaymentList>) null;
      foreach (WalletPaymentList walletPaymentList2 in list)
        walletPaymentList2.total_amount = WalletRechargeService.GetTotalAmount(walletPaymentList2.pay_name);
      return list;
    }

    public static WalletPaymentDto Get(int pk) => WalletPaymentService.Find(pk);

    public static void PostCreate(WalletPaymentDto req, AdminSession adminUser)
    {
      req.create_time = DateTime.UtcNow;
      if (WalletPaymentService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.pay_account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 291,
        list = objArray
      });
    }

    public static void PostEdit(WalletPaymentDto req, AdminSession adminUser)
    {
      if (WalletPaymentService.UpdateFull(PublicTool.convertLocalToUtcTime<WalletPaymentDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.pay_account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 290,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      WalletPaymentService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 292,
        list = objArray
      });
    }
  }
}
