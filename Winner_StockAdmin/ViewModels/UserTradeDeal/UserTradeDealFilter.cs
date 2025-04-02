// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradeDeal.UserTradeDealFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.UserTradeDeal
{
  public class UserTradeDealFilter
  {
    [Where(">=", "trade_deal.create_datetime")]
    public DateTime? start_time { get; set; }

    [Where("<=", "trade_deal.create_datetime")]
    public DateTime? end_time { get; set; }

    [Where("=", "trade_deal.stock_code")]
    public string? stock_code { get; set; }

    [Where("LIKE", "trade_deal.stock_name")]
    public string? stock_name { get; set; }

    [Where("=", "trade_deal.deal_id")]
    public string? deal_id { get; set; }

    [Where("=", "trade_deal.trade_order_sn")]
    public string? trade_order_sn { get; set; }

    public string? sub_account { get; set; }
  }
}
