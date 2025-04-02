// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatBalance.StatBalanceFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.StatBalance
{
  public class StatBalanceFilter
  {
    [Where(">=", "wallet_record.create_time")]
    public DateTime? start_time { get; set; }

    [Where("<=", "wallet_record.create_time")]
    public DateTime? end_time { get; set; }

    public int? start_year { get; set; }

    public int? start_month { get; set; }

    public int? end_year { get; set; }

    public int? end_month { get; set; }

    [Where("=", "wallet_record.type")]
    public int? type { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("=", "member.nickname")]
    public string? nickname { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
