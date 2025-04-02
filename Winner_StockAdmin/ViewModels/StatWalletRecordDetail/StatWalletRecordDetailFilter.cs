// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatWalletRecordDetail.StatWalletRecordDetailFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.StatWalletRecordDetail
{
  public class StatWalletRecordDetailFilter
  {
    [Where("=", "member.admin_user_fk")]
    public int? admin_user_fk { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("=", "member.nickname")]
    public string? nickname { get; set; }

    [Where(">=", "wallet_record.create_time")]
    public DateTime? begin_create_time { get; set; }

    [Where("<", "wallet_record.create_time")]
    public DateTime? end_create_time { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
