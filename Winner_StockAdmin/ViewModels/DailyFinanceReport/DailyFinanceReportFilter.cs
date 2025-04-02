// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.DailyFinanceReport.DailyFinanceReportFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable disable
namespace stockadmin.ViewModels.DailyFinanceReport
{
  public class DailyFinanceReportFilter
  {
    [Where("<=", "date(all_date.create_time)")]
    public DateTime? end_time { get; set; }

    [Where(">=", "date(all_date.create_time)")]
    public DateTime? start_time { get; set; }
  }
}
