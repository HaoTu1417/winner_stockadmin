// Decompiled with JetBrains decompiler
// Type: Models.Dto.RichBoxInterestDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class RichBoxInterestDto
  {
    public int member_fk { get; set; }

    public uint pk { get; set; }

    public Decimal amount { get; set; }

    public DateTime date { get; set; }

    public string remarks { get; set; } = "";
  }
}
