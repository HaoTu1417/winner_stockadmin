// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.Wallet.WalletList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.Wallet
{
  public class WalletList
  {
    public int member_fk { get; set; }

    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("昵称")]
    public string nickname { get; set; }

    [DisplayName("币别")]
    public string currency { get; set; }

    [DisplayName("账户金额")]
    public Decimal balance { get; set; }

    [DisplayName("冻结金额")]
    public Decimal freeze { get; set; }

    [DisplayName("资金余额")]
    public Decimal available_balance { get; set; }

    public bool status { get; set; }

    [DisplayName("钱包可用")]
    public string status_string => !this.status ? "不可用" : "可用";

    [DisplayName("折抵券")]
    public Decimal coupon { get; set; }

    [DisplayName("累计充值")]
    public Decimal total_recharge { get; set; }

    [DisplayName("累计提现")]
    public Decimal total_withdraw { get; set; }

    [DisplayName("最后更动时间")]
    public DateTime last_update_time { get; set; }

    [DisplayName("最后一次登录时间")]
    public DateTime last_login_time { get; set; }

    [DisplayName("最后一次登录ip")]
    public string last_login_ip { get; set; }

    public int admin_user_fk { get; set; }

    public string admin_user { get; set; }

    public int id_auth { get; set; }

    public bool is_test_account { get; set; }
  }
}
