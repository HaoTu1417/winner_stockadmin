// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RecommendRegister.RecommendRegisterFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.RecommendRegister
{
  public class RecommendRegisterFilter
  {
    [Where(">=", "member.create_time")]
    public DateTime? begin_register_date { get; set; }

    [Where("<", "member.create_time")]
    public DateTime? end_register_date { get; set; }

    [Where("=", "member.admin_user_fk")]
    public int? admin_user_fk { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }

    [Where("LIKE", "member.real_name")]
    public string? real_name { get; set; }

    [Where("=", "inviter.account")]
    public string? Inviteaccount { get; set; }

    [Where("=", "Invitenickname")]
    public string? Invitenickname { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
