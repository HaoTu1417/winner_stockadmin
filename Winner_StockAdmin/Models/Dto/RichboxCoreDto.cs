// Decompiled with JetBrains decompiler
// Type: Models.Dto.RichboxCoreDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace Models.Dto
{
  public class RichboxCoreDto
  {
    public int member_fk { get; set; }

    public int pk { get; set; }

    public DateTime create_time { get; set; }

    public Decimal invest { get; set; }

    public Decimal money { get; set; }

    public int days { get; set; }

    public Decimal pay { get; set; }
  }
}
