// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WithdrawCurrency.WithdrawCurrencyFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable disable
namespace stockadmin.ViewModels.WithdrawCurrency
{
  public class WithdrawCurrencyFilter
  {
    [Where("=", "withdraw_support_currency.type")]
    public int? type { get; set; }
  }
}
