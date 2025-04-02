// Decompiled with JetBrains decompiler
// Type: Models.Dto.WalletDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class WalletDto
  {
    public int member_fk { get; set; }

    public string currency { get; set; }

    public Decimal balance { get; set; }

    public Decimal freeze { get; set; }

    public Decimal richbox_balance { get; set; }

    public bool status { get; set; }

    public Decimal coupon { get; set; }

    public Decimal total_recharge { get; set; }

    public Decimal total_withdraw { get; set; }

    public DateTime last_update_time { get; set; }
  }
}
