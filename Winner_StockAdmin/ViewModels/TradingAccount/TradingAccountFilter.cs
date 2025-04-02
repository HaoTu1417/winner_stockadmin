// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradingAccount.TradingAccountFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.TradingAccount
{
  public class TradingAccountFilter
  {
    [Where("=", "t.market")]
    public string? market { get; set; }

    [Where("=", "t.sub_account")]
    public string? sub_account { get; set; }

    [Where("=", "t.status")]
    public int? status { get; set; }

    [Where("=", "borrow_plan.pk")]
    public string? loan_type { get; set; }

    public DateTime? begin_time { get; set; }

    public DateTime? end_time { get; set; }

    [Where("=", "t.account")]
    public string? account { get; set; }

    [Where("LIKE", "member_name")]
    public string? member_name { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
