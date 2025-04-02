// Decompiled with JetBrains decompiler
// Type: Models.Dto.RichboxBookDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace Models.Dto
{
  public class RichboxBookDto
  {
    public int member_fk { get; set; }

    public Decimal total_assets { get; set; }

    public Decimal profit { get; set; }

    public Decimal day_earning { get; set; }

    public Decimal total_earing { get; set; }

    public Decimal max_assets { get; set; }
  }
}
