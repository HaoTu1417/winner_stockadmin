// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.DailyFinanceReport.DailyFinanceReportList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable disable
namespace stockadmin.ViewModels.DailyFinanceReport
{
  public class DailyFinanceReportList
  {
    [DisplayName("日期")]
    public DateTime create_time { get; set; }

    [DisplayName("本日新增人数")]
    public int today_member { get; set; }

    [DisplayName("本日首充人數")]
    public int today_first_recharge { get; set; }

    [DisplayName("本日充值")]
    public Decimal today_recharge { get; set; }

    [DisplayName("本日提款")]
    public Decimal today_withdraw { get; set; }

    [DisplayName("本日交割盈亏")]
    public Decimal today_profit_loss { get; set; }

    [DisplayName("本日管理费收入")]
    public Decimal today_management_fee { get; set; }

    [DisplayName("本日实际手续费收入")]
    public Decimal today_handling_fee { get; set; }

    [DisplayName("本日使用優惠卷")]
    public Decimal today_used_coupon { get; set; }
  }
}
