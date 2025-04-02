// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Wallet.WalletEditVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.Wallet
{
  public class WalletEditVm
  {
    public int member_fk { get; set; }

    public string account { get; set; }

    public string nickname { get; set; }

    public string real_name { get; set; }

    public string currency { get; set; }

    public Decimal balance { get; set; }

    public Decimal freeze { get; set; }

    public Decimal available_balance { get; set; }

    public Decimal richbox_balance { get; set; }

    public bool status { get; set; }

    public Decimal coupon { get; set; }

    public Decimal total_recharge { get; set; }

    public Decimal total_withdraw { get; set; }

    public DateTime last_update_time { get; set; }

    public int admin_user_fk { get; set; }

    public string admin_user { get; set; }

    public string email { get; set; }

    public int id_auth { get; set; }

    public DateTime create_time { get; set; }

    public string create_ip { get; set; }

    public DateTime last_login_time { get; set; }

    public string last_login_ip { get; set; }

    public DateTime auth_time { get; set; }
  }
}
