// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.EndWalletWithdraw.EndWalletWithdrawList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.EndWalletWithdraw
{
  public class EndWalletWithdrawList
  {
    public int status { get; set; }

    [DisplayName("审核结果")]
    public string status_string
    {
      get => WalletWithdrawConvertEnum.ConvertVerifyStatus(this.status, this.admin_lang);
    }

    [DisplayName("申请编号")]
    public string order_no { get; set; }

    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("昵称")]
    public string nickname { get; set; }

    [DisplayName("提现币别")]
    public string currency { get; set; }

    [DisplayName("提现金额")]
    public Decimal money { get; set; }

    [DisplayName("主钱包金额")]
    public string balance_str => !this.balance.HasValue ? "" : this.balance.ToString();

    [DisplayName("收款卡号")]
    public string card { get; set; }

    [DisplayName("收款银行")]
    public string bank { get; set; }

    [DisplayName("收款分行")]
    public string branch { get; set; }

    [DisplayName("卡号持有人")]
    public string bank_account { get; set; }

    [DisplayName("申请时间")]
    public DateTime create_time { get; set; }

    [DisplayName("审核时间")]
    public DateTime verify_time { get; set; }

    public int verify_admin_pk { get; set; }

    [DisplayName("审核人员")]
    public string admin_account { get; set; }

    [DisplayName("审核备注")]
    public string reject_result { get; set; }

    public Decimal wallet_amount { get; set; }

    public Decimal exchange { get; set; }

    public Decimal? balance { get; set; }

    public int pk { get; set; }

    public bool is_test_account { get; set; }

    public string admin_lang { get; set; }
  }
}
