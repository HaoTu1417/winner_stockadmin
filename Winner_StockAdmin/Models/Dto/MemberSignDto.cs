// Decompiled with JetBrains decompiler
// Type: Models.Dto.MemberSignDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class MemberSignDto
  {
    public int member_fk { get; set; }

    public int pk { get; set; }

    public DateTime sign_time { get; set; }

    public int continuity_day { get; set; }

    public int total_day { get; set; }

    public Decimal coupon { get; set; }

    public string currency { get; set; }
  }
}
