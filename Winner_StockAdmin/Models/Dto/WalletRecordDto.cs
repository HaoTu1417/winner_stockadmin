// Decompiled with JetBrains decompiler
// Type: Models.Dto.WalletRecordDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class WalletRecordDto
  {
    public int member_fk { get; set; }

    public int pk { get; set; }

    public int type { get; set; }

    public string currency { get; set; }

    public Decimal affect { get; set; }

    public Decimal freeze { get; set; }

    public Decimal balance { get; set; }

    public Decimal coupon { get; set; }

    public string param { get; set; }

    public int templat_id { get; set; }

    public string info { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }
  }
}
