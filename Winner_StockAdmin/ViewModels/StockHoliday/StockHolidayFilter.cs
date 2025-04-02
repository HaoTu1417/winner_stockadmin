// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockHoliday.StockHolidayFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.StockHoliday
{
  public class StockHolidayFilter
  {
    [Where("=", "stock_holiday.market")]
    public string? market { get; set; }

    [Where("LIKE", "stock_holiday.name")]
    public string? name { get; set; }

    [Where("=", "stock_holiday.year")]
    public int? year { get; set; }

    [Where(">=", "stock_holiday.date")]
    public string? begin_date { get; set; }

    [Where("<=", "stock_holiday.date")]
    public string? end_date { get; set; }
  }
}
