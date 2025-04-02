// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradePosition.UserTradePositionList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.UserTradePosition
{
  public class UserTradePositionList
  {
    public string sub_account { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public int stock_type { get; set; }

    public string stock_type_display => this.stock_type != 1 ? "Short" : "Long";

    public Decimal profit { get; set; }

    public int holding_volume { get; set; }

    public Decimal lastprice { get; set; }

    public Decimal cost_price { get; set; }

    public int new_pos { get; set; }

    public int close_pos { get; set; }

    public int stop_lose_pos { get; set; }

    public Decimal total { get; set; }
  }
}
