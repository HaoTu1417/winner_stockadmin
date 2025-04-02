// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxDailyReport.RichboxDailyReportList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.RichboxDailyReport
{
  public class RichboxDailyReportList
  {
    public string report_date { get; set; }

    public Decimal total_invest { get; set; }

    public Decimal total_profit { get; set; }

    public Decimal total_input { get; set; }

    public Decimal total_output { get; set; }
  }
}
