// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowFee.BorrowFeeList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.BorrowFee
{
  public class BorrowFeeList
  {
    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("会员姓名")]
    public string member_name { get; set; }

    [DisplayName("收费时间")]
    public DateTime create_time { get; set; }

    [DisplayName("管理费")]
    public Decimal borrow_fee { get; set; }

    [DisplayName("交易子帐号")]
    public string sub_account { get; set; }

    [DisplayName("合约类型")]
    public string loan_type { get; set; }

    public string borrow_type { get; set; }

    [DisplayName("市场币种")]
    public string currency { get; set; }

    [DisplayName("合约时长")]
    public string borrow_duration_string { get; set; }

    public int type { get; set; }

    public int borrow_duration { get; set; }

    public bool is_test_account { get; set; }
  }
}
