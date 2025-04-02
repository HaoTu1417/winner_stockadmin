// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisAddfinancing.HisAddfinancingFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.HisAddfinancing
{
  public class HisAddfinancingFilter
  {
    [Where("=", "market")]
    public string? market { get; set; }

    [Where(">=", "borrow_addfinancing.add_time")]
    public DateTime? begin_time { get; set; }

    [Where("<", "borrow_addfinancing.add_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "vw_trade_account.account")]
    public string? account { get; set; }

    [Where("LIKE", "vw_trade_account.member_name")]
    public string? member_name { get; set; }

    [Where("=", "borrow_addfinancing.sub_account")]
    public string? sub_account { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
