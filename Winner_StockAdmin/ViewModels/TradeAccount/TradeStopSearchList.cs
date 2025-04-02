// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradeStopSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradeStopSearchList
  {
    public string? sn { get; set; }

    public byte dir { get; set; }

    public string? stock_code { get; set; }

    public string? stock_name { get; set; }

    public Decimal? price { get; set; }

    public DateTime? cancel_datetime { get; set; }

    public long? cancel_datetime_time_zone { get; set; }

    public string? cancel_by { get; set; }

    public int volume { get; set; }

    public int? succeed_volume { get; set; }

    public int? free_volume { get; set; }

    public int? cancel_volume { get; set; }
  }
}
