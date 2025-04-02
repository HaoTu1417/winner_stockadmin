// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ReviewMember.ReviewMemberReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.ReviewMember
{
  public class ReviewMemberReview
  {
    public int pk { get; set; }

    public int admin_user_fk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string real_name { get; set; }

    public string email { get; set; }

    public string id_card { get; set; }

    public int id_card_type { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }

    public string auth_result { get; set; }

    public string card_pic_front { get; set; }

    public string remark { get; set; }

    public bool is_test_account { get; set; }
  }
}
