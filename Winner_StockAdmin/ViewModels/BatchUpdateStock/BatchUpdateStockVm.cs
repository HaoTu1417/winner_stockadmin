// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BatchUpdateStock.BatchUpdateStockVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace stockadmin.ViewModels.BatchUpdateStock
{
  public class BatchUpdateStockVm
  {
    public Decimal us_min_stock_price { get; set; }

    public int us_min_stock_month_volume { get; set; }

    public Decimal vn_min_stock_price { get; set; }

    public bool us_capital_filter_enable { get; set; }

    public int us_capital_filter_number { get; set; }

    public bool vn_capital_filter_enable { get; set; }

    public int vn_capital_filter_number { get; set; }

    public int vn_min_stock_month_volume { get; set; }
  }
}
