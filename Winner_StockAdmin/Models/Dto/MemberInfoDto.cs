// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberInfoDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace Models.Dto
{
  public class MemberInfoDto
  {
    public int member_fk { get; set; }

    public DateTime fristtime_save_money { get; set; }

    public DateTime lasttime_save_money { get; set; }
  }
}
