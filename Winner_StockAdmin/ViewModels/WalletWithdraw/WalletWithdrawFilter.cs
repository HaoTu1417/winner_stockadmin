// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletWithdraw.WalletWithdrawFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.WalletWithdraw
{
  public class WalletWithdrawFilter
  {
    [Where("LIKE", "wallet_withdraw.order_no")]
    public string? order_no { get; set; }

    [Where("LIKE", "member_bank.card")]
    public string? card { get; set; }

    [Where("", "member_bank.bank_account")]
    public string? bank_account { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }
  }
}
