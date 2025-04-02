// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ReviewMember.ReviewMemberFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;
using System;

#nullable enable
namespace stockadmin.ViewModels.ReviewMember
{
  public class ReviewMemberFilter
  {
    [Where(">=", "member.auth_time")]
    public DateTime? begin_auth_time { get; set; }

    [Where("<", "member.auth_time")]
    public DateTime? end_auth_time { get; set; }

    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.real_name")]
    public string? real_name { get; set; }

    [Where("LIKE", "member.email")]
    public string? email { get; set; }

    [Where("=", "member.create_ip")]
    public string? create_ip { get; set; }

    public bool has_recommend { get; set; }

    public string id_auth_string { get; set; }
  }
}
