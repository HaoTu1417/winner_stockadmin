// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxDailyReport.RichboxDailyReportFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.RichboxDailyReport
{
  public class RichboxDailyReportFilter
  {
    [Where(">=", "richbox_daily_report.report_date")]
    public string? begin_report_date { get; set; }

    [Where("<", "richbox_daily_report.report_date")]
    public string? end_report_date { get; set; }
  }
}
