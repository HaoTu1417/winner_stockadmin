// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Home.HomeVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.Home
{
  public class HomeVm
  {
    public long TotalMember { get; set; }

    public long TodayRegister { get; set; }

    public long TodayVerify { get; set; }

    public long MemberIsTrading { get; set; }

    public long MemberHasPosition { get; set; }

    public long MemberHasVNPosition { get; set; }

    public long MemberHasUSPosition { get; set; }

    public Decimal RechargeNeedVerify { get; set; }

    public Decimal WithdrawNeedVerify { get; set; }

    public Decimal RechargeToday { get; set; }

    public Decimal WithdrawToday { get; set; }

    public long FirstRechargeMemberToday { get; set; }

    public Decimal FirstRechargeAmountToday { get; set; }

    public long NewVnSubAccountToday { get; set; }

    public long NewUsSubAccountToday { get; set; }

    public Decimal DealVnEarnToday { get; set; }

    public Decimal DealUsEarnToday { get; set; }

    public Decimal HandlingVnFeeToday { get; set; }

    public Decimal HandlingUsFeeToday { get; set; }

    public Decimal ManagementFeeVnToday { get; set; }

    public Decimal ManagementFeeUsToday { get; set; }

    public Decimal RichBox { get; set; }

    public Decimal TotalRecharge { get; set; }

    public Decimal TotalWithdraw { get; set; }

    public string RechargeApplyCount { get; set; }

    public string WithdrawApplyCount { get; set; }

    public string MemberVerifying { get; set; }

    public string MessageRecordUnread { get; set; }

    public string RechargeNeedVerifyString { get; set; }

    public string WithdrawNeedVerifyString { get; set; }

    public string RechargeTodayString { get; set; }

    public string WithdrawTodayString { get; set; }

    public string FirstRechargeAmountTodayString { get; set; }

    public string DealVnEarnTodayString { get; set; }

    public string DealUsEarnTodayString { get; set; }

    public string HandlingVnFeeTodayString { get; set; }

    public string HandlingUsFeeTodayString { get; set; }

    public string ManagementFeeVnTodayString { get; set; }

    public string ManagementFeeUsTodayString { get; set; }

    public string RichBoxString { get; set; }

    public string TotalRechargeString { get; set; }

    public string TotalWithdrawString { get; set; }
  }
}
