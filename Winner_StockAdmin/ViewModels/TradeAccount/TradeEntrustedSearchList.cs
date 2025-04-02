// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradeEntrustedSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradeEntrustedSearchList
  {
    public string? sn { get; set; }

    public byte dir { get; set; }

    public byte? status { get; set; }

    public byte? order_source { get; set; }

    public string? stock_code { get; set; }

    public string? stock_name { get; set; }

    public Decimal? price { get; set; }

    public int volume { get; set; }

    public int? free_volume { get; set; }

    public int succeed_volume { get; set; }

    public DateTime? order_time { get; set; }

    public DateTime? order_time_time_zone { get; set; }

    public string? order_ip { get; set; }

    public string? cancel_by { get; set; }

    public string? market { get; set; }

    public string? sub_account { get; set; }
  }
}
