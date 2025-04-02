// Decompiled with JetBrains decompiler
// Type: Models.Dto.VwRichboxPrincipalDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace Models.Dto
{
  public class VwRichboxPrincipalDto
  {
    public Decimal daily_interest { get; set; }

    public Decimal richbox_balance { get; set; }

    public Decimal total_deposit { get; set; }

    public Decimal total_amount { get; set; }

    public DateTime create_time { get; set; }
  }
}
