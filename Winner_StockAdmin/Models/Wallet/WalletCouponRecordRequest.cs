// Decompiled with JetBrains decompiler
// Type: stockadmin.Models.Wallet.WalletCouponRecordRequest
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.Models.Wallet
{
  public class WalletCouponRecordRequest
  {
    public int member_pk { get; set; }

    public int type { get; set; }

    public int subtype { get; set; }

    public string currency { get; set; }

    public Decimal wallet_coupon_balance { get; set; }

    public Decimal affect { get; set; }

    public Decimal wallet_amount { get; set; }

    public bool sended { get; set; }

    public int money_type { get; set; }

    public DateTime createtime { get; set; }

    public object[]? list { get; set; }

    public string param { get; set; }
  }
}
