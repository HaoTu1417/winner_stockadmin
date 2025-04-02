// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxDailyReport.RichboxDailyReportVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.RichboxDailyReport
{
  public class RichboxDailyReportVm
  {
    public RichboxDailyReportFilter filter { get; set; }

    public IPagedList<RichboxDailyReportList> list { get; set; }

    public Decimal day_withdrawn_interest { get; set; }

    public Decimal not_paid_interest { get; set; }

    public Decimal total_invest { get; set; }
  }
}
