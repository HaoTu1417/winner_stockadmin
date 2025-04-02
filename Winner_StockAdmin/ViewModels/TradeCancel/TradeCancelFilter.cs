// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeCancel.TradeCancelFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.TradeCancel
{
  public class TradeCancelFilter
  {
    [Where("LIKE", "trade_cancel.trade_order_sn")]
    public string? trade_order_sn { get; set; }

    [Where("=", "trade_cancel.stock_code")]
    public string? stock_code { get; set; }

    [Where("LIKE", "trade_cancel.stock_name")]
    public string? stock_name { get; set; }

    public string? sub_account { get; set; }
  }
}
