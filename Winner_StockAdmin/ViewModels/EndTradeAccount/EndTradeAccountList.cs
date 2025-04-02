// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.EndTradeAccount.EndTradeAccountList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.EndTradeAccount
{
  public class EndTradeAccountList
  {
    [DisplayName("市场")]
    public string market { get; set; }

    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("会员姓名")]
    public string member_name { get; set; }

    [DisplayName("交易子帐号")]
    public string sub_account { get; set; }

    [DisplayName("合约类型")]
    public string loan_type { get; set; }

    [DisplayName("初始資金")]
    public Decimal init_money { get; set; }

    [DisplayName("初始保证金")]
    public Decimal margin { get; set; }

    [DisplayName("子帐号交割盈亏")]
    public Decimal total_profit { get; set; }

    [DisplayName("返回主账户金额")]
    public Decimal transferrable_amount { get; set; }

    [DisplayName("关闭帐号时间")]
    public DateTime close_time { get; set; }

    [DisplayName("起始时间")]
    public DateTime begin_time { get; set; }

    [DisplayName("应结束时间")]
    public DateTime end_time { get; set; }

    [DisplayName("关闭种类")]
    public string close_type_str => ConvertEnum.ConvertCloseType(this.close_type, this.lang);

    public Decimal balance { get; set; }

    public Decimal margin_float { get; set; }

    public Decimal breakline { get; set; }

    public int member_fk { get; set; }

    public int close_type { get; set; }

    public bool is_test_account { get; set; }

    public string lang { get; set; }
  }
}
