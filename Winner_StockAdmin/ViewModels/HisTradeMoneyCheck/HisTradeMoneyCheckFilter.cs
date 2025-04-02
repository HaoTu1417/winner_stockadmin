// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisTradeMoneyCheck.HisTradeMoneyCheckFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.HisTradeMoneyCheck
{
  public class HisTradeMoneyCheckFilter
  {
    [Where(">=", "trade_money_check.request_time")]
    public DateTime? start_time { get; set; }

    [Where("<", "trade_money_check.request_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "vwt.account")]
    public string? account { get; set; }

    [Where("=", "vwt.member_name")]
    public string? member_name { get; set; }

    [Where("like", "trade_money_check.sub_account")]
    public string? sub_account { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
