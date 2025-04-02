// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletRecharge.WalletRechargeFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.WalletRecharge
{
  public class WalletRechargeFilter
  {
    [Where("=", "admin_bank.card")]
    public string? card { get; set; }

    [Where("LIKE", "admin_bank.bank_name")]
    public string? bank_name { get; set; }

    [Where("=", "wallet_recharge.order_no")]
    public string? order_no { get; set; }

    [Where("LIKE", "wallet_recharge.line_bank")]
    public string? line_bank { get; set; }

    [Where("=", "wallet_recharge.type")]
    public string? type { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }
  }
}
