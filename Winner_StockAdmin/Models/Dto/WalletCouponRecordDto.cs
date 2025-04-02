// Decompiled with JetBrains decompiler
// Type: Models.Dto.WalletCouponRecordDto
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace Models.Dto
{
  public class WalletCouponRecordDto
  {
    public int member_fk { get; set; }

    public int cms_promotion_fk { get; set; }

    public int pk { get; set; }

    public string currency { get; set; }

    public Decimal affect { get; set; }

    public Decimal exchange { get; set; }

    public Decimal wallet_amount { get; set; }

    public Decimal coupon_balance { get; set; }

    public int money_type { get; set; }

    public int type { get; set; }

    public int sub_type { get; set; }

    public string info { get; set; }

    public DateTime create_time { get; set; }

    public string create_user { get; set; }

    public bool sended { get; set; }

    public DateTime? send_time { get; set; }

    public string param { get; set; }
  }
}
