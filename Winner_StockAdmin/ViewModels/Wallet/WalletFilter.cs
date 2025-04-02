// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Wallet.WalletFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.Wallet
{
  public class WalletFilter
  {
    [Where("=", "member_fk")]
    public int? member_fk { get; set; }

    [Where("=", "account")]
    public string? account { get; set; }

    [Where("LIKE", "nickname")]
    public string? nickname { get; set; }

    [Where(">=", "last_update_time")]
    public DateTime? begin_last_update_time { get; set; }

    [Where("<", "last_update_time")]
    public DateTime? end_last_update_time { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
