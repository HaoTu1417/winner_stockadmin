// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisRequestRenew.HisRequestRenewFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.HisRequestRenew
{
  public class HisRequestRenewFilter
  {
    [Where(">=", "add_time")]
    public DateTime? begin_time { get; set; }

    [Where("<", "add_time")]
    public DateTime? end_time { get; set; }

    [Where("=", "vw_trade_account.account")]
    public string? account { get; set; }

    [Where("LIKE", "vw_trade_account.member_name")]
    public string? member_name { get; set; }

    [Where("LIKE", "borrow_request.sub_account")]
    public string? sub_account { get; set; }
  }
}
