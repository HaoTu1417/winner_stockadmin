// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletPayment.WalletPaymentFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.WalletPayment
{
  public class WalletPaymentFilter
  {
    [Where("LIKE", "wallet_payment.pay_name")]
    public string? pay_name { get; set; }

    [Where("", "wallet_payment.pay_code")]
    public string? pay_code { get; set; }
  }
}
