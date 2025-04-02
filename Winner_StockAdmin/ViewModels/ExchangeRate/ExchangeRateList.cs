// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ExchangeRate.ExchangeRateList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.ExchangeRate
{
  public class ExchangeRateList
  {
    public string date { get; set; }

    public string currency_symbol { get; set; }

    public string base_symbol { get; set; }

    public Decimal inward_rate { get; set; }

    public Decimal outward_rate { get; set; }

    public DateTime create_time { get; set; }
  }
}
