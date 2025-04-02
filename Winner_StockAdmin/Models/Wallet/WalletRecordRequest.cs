// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Wallet.WalletRecordRequest
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.Models.Wallet
{
  public class WalletRecordRequest
  {
    public int member_pk { get; set; }

    public int type { get; set; }

    public string currency { get; set; }

    public int temp_id { get; set; }

    public Decimal affect { get; set; }

    public Decimal coupon { get; set; }

    public Decimal balance { get; set; }

    public DateTime createtime { get; set; }

    public object[]? list { get; set; }

    public string param { get; set; }
  }
}
