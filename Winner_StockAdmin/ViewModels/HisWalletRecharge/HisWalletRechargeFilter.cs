// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisWalletRecharge.HisWalletRechargeFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.HisWalletRecharge
{
  public class HisWalletRechargeFilter
  {
    [Where("=", "wallet_recharge.status")]
    public int? status { get; set; }

    [Where("=", "wallet_recharge.verify_admin_pk")]
    public int? verify_admin_pk { get; set; }

    [Where(">=", "wallet_recharge.verify_time")]
    public DateTime? begin_verify_time { get; set; }

    [Where("<", "wallet_recharge.verify_time")]
    public DateTime? end_verify_time { get; set; }

    [Where("=", "wallet_recharge.order_no")]
    public string? order_no { get; set; }

    [Where(">=", "wallet_recharge.create_time")]
    public DateTime? begin_create_time { get; set; }

    [Where("<", "wallet_recharge.create_time")]
    public DateTime? end_create_time { get; set; }

    public string? card { get; set; }

    [Where("LIKE", "wallet_recharge.line_bank")]
    public string? line_bank { get; set; }

    [Where("=", "wallet_recharge.type")]
    public string? type { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
