// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradeOrder.UserTradeOrderFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.UserTradeOrder
{
  public class UserTradeOrderFilter
  {
    [Where("LIKE", "trade_order.sn")]
    public string? sn { get; set; }

    [Where("=", "trade_order.stock_code")]
    public string? stock_code { get; set; }

    [Where("LIKE", "trade_order.stock_name")]
    public string? stock_name { get; set; }

    public string? sub_account { get; set; }
  }
}
