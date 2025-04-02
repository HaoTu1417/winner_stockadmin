// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.MemberBank.MemberBankReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.MemberBank
{
  public class MemberBankReview
  {
    public int member_fk { get; set; }

    public string card_pk { get; set; }

    public int card_type { get; set; }

    public string currency { get; set; }

    public string bank { get; set; }

    public string branch { get; set; }

    public string card { get; set; }

    public string bank_account { get; set; }

    public bool is_confirm { get; set; }

    public string create_ip { get; set; }

    public DateTime create_time { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string real_name { get; set; }

    public int id_auth { get; set; }

    public string card_front { get; set; }
  }
}
