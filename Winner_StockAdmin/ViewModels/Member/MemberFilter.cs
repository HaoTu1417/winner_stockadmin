// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Member.MemberFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.Member
{
  public class MemberFilter
  {
    [Where("=", "member.admin_user_fk")]
    public int? admin_user_fk { get; set; }

    [Where("=", "member.pk")]
    public int? pk { get; set; }

    [Where("LIKE", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }

    [Where("LIKE", "member.real_name")]
    public string? real_name { get; set; }

    [Where(">=", "member.create_time")]
    public DateTime? begin_create_time { get; set; }

    [Where("<", "member.create_time")]
    public DateTime? end_create_time { get; set; }

    public bool only_no_recommend { get; set; }

    public bool only_id_auth { get; set; }

    [Where("=", "member.recommend")]
    public string recommend { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
