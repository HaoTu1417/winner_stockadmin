// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.DealSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class DealSearchList
  {
    public uint pk { get; set; }

    public string? trade_order_sn { get; set; }

    public byte dir { get; set; }

    public string? stock_code { get; set; }

    public string? stock_name { get; set; }

    public Decimal? final_price { get; set; }

    public int? final_volume { get; set; }

    public Decimal? total_amount { get; set; }

    public DateTime? create_datetime { get; set; }

    public DateTime? create_datetime_time_zone { get; set; }

    public Decimal? total_pay_system { get; set; }

    public Decimal? total_pay_user { get; set; }

    public Decimal? handling_fee { get; set; }

    public Decimal? transfer_fee { get; set; }

    public Decimal? other_fee { get; set; }
  }
}
