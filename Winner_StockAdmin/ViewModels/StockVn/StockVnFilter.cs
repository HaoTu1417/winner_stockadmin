// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockVn.StockVnFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.StockVn
{
  public class StockVnFilter
  {
    [Where("LIKE", "stock_vn.stock_code")]
    public string? stock_code { get; set; }

    [Where("LIKE", "stock_vn.stock_name")]
    public string? stock_name { get; set; }
  }
}
