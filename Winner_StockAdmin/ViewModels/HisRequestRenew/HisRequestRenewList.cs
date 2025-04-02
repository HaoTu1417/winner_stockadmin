// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisRequestRenew.HisRequestRenewList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.HisRequestRenew
{
  public class HisRequestRenewList
  {
    public DateTime verify_time { get; set; }

    public int status { get; set; }

    public string statusTxt => BorrowRequestConvertEnum.ConvertVerifyStatus(this.status);

    public Decimal borrow_fee { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public DateTime add_time { get; set; }

    public string sub_account { get; set; }

    public string market { get; set; }

    public string loan_type { get; set; }

    public int pk { get; set; }

    public int borrow_duration { get; set; }

    public DateTime end_time { get; set; }

    public DateTime new_end_time { get; set; }
  }
}
