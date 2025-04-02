// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ExchangeRate.ExchangeRateFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.ExchangeRate
{
  public class ExchangeRateFilter
  {
    [Where(">=", "create_time")]
    public DateTime? begin_time { get; set; }

    [Where("<", "create_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "currency_symbol")]
    public string? currency_symbol { get; set; }

    [Where("=", "base_symbol")]
    public string? base_symbol { get; set; }
  }
}
