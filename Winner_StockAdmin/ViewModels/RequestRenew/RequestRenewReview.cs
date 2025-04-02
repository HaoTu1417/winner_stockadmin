// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RequestRenew.RequestRenewReview
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.RequestRenew
{
  public class RequestRenewReview
  {
    public DateTime add_time { get; set; }

    public string sub_account { get; set; }

    public string loan_type { get; set; }

    public int member_fk { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public int pk { get; set; }

    public int borrow_duration { get; set; }

    public DateTime end_time { get; set; }

    public DateTime new_end_time { get; set; }

    public Decimal borrow_fee { get; set; }

    public string market { get; set; }

    public Decimal margin { get; set; }

    public Decimal balance { get; set; }

    public Decimal warningline { get; set; }

    public Decimal breakline { get; set; }

    public int status { get; set; }

    public DateTime verify_time { get; set; }
  }
}
