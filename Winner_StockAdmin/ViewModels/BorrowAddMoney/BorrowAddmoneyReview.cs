// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowAddmoney.BorrowAddmoneyReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.BorrowAddmoney
{
  public class BorrowAddmoneyReview
  {
    public DateTime add_time { get; set; }

    public string sub_account { get; set; }

    public Decimal money { get; set; }

    public string currency { get; set; }

    public int trade_status { get; set; }

    public DateTime end_time { get; set; }

    public string market { get; set; }

    public Decimal init_money { get; set; }

    public Decimal balance { get; set; }

    public Decimal warningline { get; set; }

    public Decimal breakline { get; set; }

    public string loan_type { get; set; }

    public int member_fk { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public int pk { get; set; }

    public Decimal exchange { get; set; }

    public Decimal freeze { get; set; }

    public int status { get; set; }

    public DateTime verify_time { get; set; }

    public int target_uid { get; set; }

    public string target_name { get; set; }
  }
}
