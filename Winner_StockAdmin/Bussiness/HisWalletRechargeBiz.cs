// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisWalletRechargeBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisWalletRecharge;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisWalletRechargeBiz
  {
    public static DataCountBase<HisWalletRechargeList> GetHisWalletRechargeList(
      HisWalletRechargeFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string str1 = SqlTool.Build<HisWalletRechargeFilter>(filter).Must("wallet_recharge.status > 0 and member.is_del = 0");
      string str2 = SqlTool.Build<HisWalletRechargeFilter>(filter).Must("wallet_recharge.status > 0 and member.is_del = 0");
      if (filter.card != null)
      {
        str2 = str1.Must("wallet_payment.pay_code = '" + filter.card + "'");
        str1 = str1.Must("admin_bank.card = '" + filter.card + "'");
      }
      if (filter.filter_out_test_account)
      {
        str1 = str1.Must("member.is_test_account = 0");
        str2 = str2.Must("member.is_test_account = 0");
      }
      DataCountBase<HisWalletRechargeList> walletRechargeList = WalletRechargeService.FindHisWalletRechargeList(page, pageSize, str1, str2, lang);
      return new DataCountBase<HisWalletRechargeList>(walletRechargeList.count, walletRechargeList.data.Select<HisWalletRechargeList, HisWalletRechargeList>((Func<HisWalletRechargeList, HisWalletRechargeList>) (hisWalletRecharge => PublicTool.convertUtcToLocalTime<HisWalletRechargeList>(hisWalletRecharge))));
    }

    public static WalletRechargeDto Get(int pk) => WalletRechargeService.Find(pk);

    public static void PostCreate(WalletRechargeDto req)
    {
      if (WalletRechargeService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletRechargeDto req)
    {
      if (WalletRechargeService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => WalletRechargeService.Remove(pk);

    public static byte[]? DownloadHisWalletRechargeList(HisWalletRechargeFilter? filter, string lang)
    {
      return Exportlib.ExportExcel<HisWalletRechargeList>(HisWalletRechargeBiz.GetHisWalletRechargeList(filter, 1, int.MaxValue, lang).data);
    }
  }
}
