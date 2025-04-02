// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOptionPosition.StockOptionPositionFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.StockOptionPosition
{
  public class StockOptionPositionFilter
  {
    [Where("=", "t.market")]
    public string? market { get; set; }

    [Where("=", "t.stock_code")]
    public string? stock_code { get; set; }

    [Where("LIKE", "t.stock_name")]
    public string? stock_name { get; set; }

    [Where("=", "vwt.member_fk")]
    public int? member_fk { get; set; }

    [Where("=", "vwt.account")]
    public string? account { get; set; }

    [Where("LIKE", "vwt.member_name")]
    public string? member_name { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
