// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradePositionSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradePositionSearchList
  {
    public string stock_code { get; set; }

    public string? stock_name { get; set; }

    public int? holding_volume { get; set; }

    public Decimal? lastprice { get; set; }

    public Decimal? cost_price_avg { get; set; }

    public Decimal total { get; set; }

    public Decimal? cost_price { get; set; }

    public Decimal? profit { get; set; }

    public int? frozen_volume { get; set; }

    public int? sell_volume { get; set; }
  }
}
