// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.UserTradeOrder.UserTradeOrderList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.UserTradeOrder
{
  public class UserTradeOrderList
  {
    public int pk { get; set; }

    public string sub_account { get; set; }

    public DateTime order_time { get; set; }

    public string sn { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public string market { get; set; }

    public int dir { get; set; }

    public int order_type { get; set; }

    public int price_type { get; set; }

    public Decimal price { get; set; }

    public int status { get; set; }

    public int volume { get; set; }

    public int free_volume { get; set; }

    public int succeed_volume { get; set; }

    public int cancel_volume { get; set; }
  }
}
