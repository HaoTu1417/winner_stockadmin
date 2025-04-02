// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.WalletCouponRecord.WalletCouponRecordEditVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.WalletCouponRecord
{
  public class WalletCouponRecordEditVm
  {
    public int cms_promotion_fk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public int money_type { get; set; }

    public string currency { get; set; }

    public Decimal affect { get; set; }

    public int pk { get; set; }

    public string info { get; set; }

    public DateTime send_time { get; set; }

    public string create_user { get; set; }
  }
}
