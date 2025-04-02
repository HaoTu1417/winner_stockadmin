// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOption.StockOptionList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.StockOption
{
  public class StockOptionList
  {
    public int pk { get; set; }

    public string stock_name { get; set; }

    public string stock_code { get; set; }

    public int spot { get; set; }

    public int remain_spot { get; set; }

    public Decimal price { get; set; }

    public int quantity { get; set; }

    public bool enable { get; set; }

    public DateTime create_time { get; set; }
  }
}
