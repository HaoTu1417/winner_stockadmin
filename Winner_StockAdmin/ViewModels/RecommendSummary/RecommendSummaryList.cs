// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RecommendSummary.RecommendSummaryList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.RecommendSummary
{
  public class RecommendSummaryList
  {
    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("会员姓名")]
    public string real_name { get; set; }

    [DisplayName("合计分润金额")]
    public Decimal total_profit { get; set; }

    [DisplayName("分润月份")]
    public string profit_date { get; set; }

    [DisplayName("会员提现时间")]
    public DateTime? withdraw_date { get; set; }

    [DisplayName("第一层人数")]
    public int layer1_child_count { get; set; }

    [DisplayName("第一层分润金额")]
    public Decimal layer1_profit { get; set; }

    [DisplayName("第二层人数")]
    public int layer2_child_count { get; set; }

    [DisplayName("第二层分润金额")]
    public Decimal layer2_profit { get; set; }

    [DisplayName("第三层人数")]
    public int layer3_child_count { get; set; }

    [DisplayName("第三层分润金额")]
    public Decimal layer3_profit { get; set; }

    public bool is_test_account { get; set; }

    public int member_fk { get; set; }
  }
}
