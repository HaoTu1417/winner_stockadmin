// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberBankDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class MemberBankDto
  {
    public int member_fk { get; set; }

    public string card_pk { get; set; }

    public int card_type { get; set; }

    public string currency { get; set; }

    public string country { get; set; }

    public string bank { get; set; }

    public string branch { get; set; }

    public string card { get; set; }

    public string account { get; set; }

    public int cms_files_fk { get; set; }

    public bool is_confirm { get; set; }

    public bool is_delete { get; set; }

    public string create_ip { get; set; }

    public DateTime create_time { get; set; }
  }
}
