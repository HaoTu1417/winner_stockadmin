// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatWalletRecordDetail.StatWalletRecordDetailList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;
using System.ComponentModel;

#nullable enable
namespace stockadmin.ViewModels.StatWalletRecordDetail
{
  public class StatWalletRecordDetailList
  {
    public int admin_user_fk { get; set; }

    [DisplayName("所属客服")]
    public string admin_account { get; set; }

    [DisplayName("会员帐号")]
    public string account { get; set; }

    [DisplayName("昵称")]
    public string nickname { get; set; }

    public int type { get; set; }

    [DisplayName("资金类型")]
    public string template_name { get; set; }

    [DisplayName("金额")]
    public Decimal affect { get; set; }

    [DisplayName("详情")]
    public string info { get; set; }

    [DisplayName("交易时间")]
    public DateTime create_time { get; set; }

    public bool is_test_account { get; set; }

    public string param { get; set; }

    public string template { get; set; }
  }
}
