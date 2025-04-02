// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOptionPosition.StockOptionPositionList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.StockOptionPosition
{
  public class StockOptionPositionList
  {
    public int member_fk { get; set; }

    public string account { get; set; }

    public string market { get; set; }

    public string stock_code { get; set; }

    public string stock_name { get; set; }

    public int quantity { get; set; }

    public int freeze { get; set; }

    public Decimal last_price { get; set; }

    public Decimal total_cost { get; set; }

    public string real_name { get; set; }

    public bool is_test_account { get; set; }
  }
}
