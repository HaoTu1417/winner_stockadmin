// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOption.StockOptionFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.StockOption
{
  public class StockOptionFilter
  {
    [Where("LIKE", "stock_option.stock_name")]
    public string? stock_name { get; set; }
  }
}
