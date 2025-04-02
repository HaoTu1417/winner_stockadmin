// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RewardDetail.RewardDetailList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.RewardDetail
{
  public class RewardDetailList
  {
    [DisplayName("下线会员帐号")]
    public string account { get; set; }

    [DisplayName("下线会员姓名")]
    public string real_name { get; set; }

    [DisplayName("推荐人帐号")]
    public string recommend_account { get; set; }

    [DisplayName("层级")]
    public int generation { get; set; }

    [DisplayName("管理費")]
    public Decimal management_fee { get; set; }

    [DisplayName("分润百分比")]
    public Decimal rate { get; set; }

    public Decimal rate_percent => this.rate * 100M;

    [DisplayName("分润金额")]
    public Decimal reward { get; set; }

    [DisplayName("交易日期")]
    public DateTime borrow_date { get; set; }

    public string sub_account { get; set; }

    public int type { get; set; }

    public string type_string
    {
      get
      {
        int type = this.type;
        return BorrowRequestConvertEnum.ConvertBorrowType(this.type).ToString();
      }
    }
  }
}
