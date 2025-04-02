// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradingAccount.TradingAccountList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.TradingAccount
{
  public class TradingAccountList
  {
    [DisplayName("市场")]
    public string market { get; set; }

    [DisplayName("帐号")]
    public string account { get; set; }

    [DisplayName("姓名")]
    public string member_name { get; set; }

    [DisplayName("交易子帐号")]
    public string sub_account { get; set; }

    [DisplayName("合约类型")]
    public string loan_type { get; set; }

    [DisplayName("状态")]
    public string statusText => ConvertEnum.ConvertAccountStatus(this.status, this.lang);

    [DisplayName("总市值")]
    public Decimal balance { get; set; }

    [DisplayName("预警线")]
    public Decimal warningline { get; set; }

    [DisplayName("平仓线")]
    public Decimal breakline { get; set; }

    [DisplayName("子账户盈亏")]
    public Decimal total_profit { get; set; }

    public Decimal profit_percent { get; set; }

    [DisplayName("盈亏百分比")]
    public string profit_percent_string => this.profit_percent.ToString("#0.00") + "%";

    [DisplayName("持仓市值")]
    public Decimal position_value { get; set; }

    [DisplayName("起始时间")]
    public DateTime begin_time { get; set; }

    [DisplayName("结束时间")]
    public DateTime end_time { get; set; }

    public int status { get; set; }

    public float warningline_percent { get; set; }

    public int member_fk { get; set; }

    public bool is_test_account { get; set; }

    public string lang { get; set; }
  }
}
