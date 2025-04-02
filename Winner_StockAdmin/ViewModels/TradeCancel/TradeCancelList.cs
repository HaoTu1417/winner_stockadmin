// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeCancel.TradeCancelList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeCancel
{
  public class TradeCancelList
  {
    public DateTime cancel_datetime { get; set; }

    public string sub_account { get; set; }

    public string sn { get; set; }

    public string trade_order_sn { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public int cancel_volume { get; set; }

    public int cancel_type { get; set; }
  }
}
