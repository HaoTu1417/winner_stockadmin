// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HomeBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Cache;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.Home;
using System;

#nullable enable
namespace stockadmin.Business
{
  public class HomeBiz
  {
    public static HomeVm GetHomeVm()
    {
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm homeVm = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (homeVm == null)
        return new HomeVm();
      string currency = ConfigLib.Get("wallet_currency");
      homeVm.RechargeNeedVerifyString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.RechargeNeedVerify), currency);
      homeVm.WithdrawNeedVerifyString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.WithdrawNeedVerify), currency);
      homeVm.RechargeTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.RechargeToday), currency);
      homeVm.WithdrawTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.WithdrawToday), currency);
      homeVm.FirstRechargeAmountTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.FirstRechargeAmountToday), currency);
      homeVm.DealVnEarnTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.DealVnEarnToday), currency);
      homeVm.DealUsEarnTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.DealUsEarnToday), currency);
      homeVm.HandlingVnFeeTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.HandlingVnFeeToday), currency);
      homeVm.HandlingUsFeeTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.HandlingUsFeeToday), currency);
      homeVm.ManagementFeeVnTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.ManagementFeeVnToday), currency);
      homeVm.ManagementFeeUsTodayString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.ManagementFeeUsToday), currency);
      homeVm.RichBoxString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.RichBox), currency);
      homeVm.TotalRechargeString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.TotalRecharge), currency);
      homeVm.TotalWithdrawString = PublicTool.AddNumberSeparation(new Decimal?(homeVm.TotalWithdraw), currency);
      return homeVm;
    }
  }
}
