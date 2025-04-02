// Decompiled with JetBrains decompiler
// Type: Models.Dto.WalletTransferDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class WalletTransferDto
  {
    public int admin_user_fk { get; set; }

    public int member_fk { get; set; }

    public int pk { get; set; }

    public string order_no { get; set; }

    public Decimal money { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }

    public string info { get; set; }

    public string currency { get; set; }
  }
}
