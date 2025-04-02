// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ReviewMember.ReviewMemberList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.ReviewMember
{
  public class ReviewMemberList
  {
    public int pk { get; set; }

    public DateTime? auth_time { get; set; }

    public string account { get; set; }

    public string real_name { get; set; }

    public string email { get; set; }

    public string recommend_code { get; set; }

    public string? recommend_id { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }

    public string auth_result { get; set; }

    public int id_auth { get; set; }

    public string admin_lang { get; set; }

    public string id_auth_string
    {
      get => IdAuthStatusConvertEnum.ConvertIdAuthStatus(this.id_auth, this.admin_lang);
    }

    public string auth_time_string
    {
      get
      {
        if (this.auth_time.HasValue)
        {
          DateTime? authTime = this.auth_time;
          DateTime minValue = DateTime.MinValue;
          if ((authTime.HasValue ? (authTime.GetValueOrDefault() == minValue ? 1 : 0) : 0) == 0)
          {
            authTime = this.auth_time;
            ref DateTime? local = ref authTime;
            return !local.HasValue ? (string) null : local.GetValueOrDefault().ToString();
          }
        }
        return "";
      }
    }
  }
}
