// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisBorrow.HisBorrowEditVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.HisBorrow
{
  public class HisBorrowEditVm
  {
    public string account { get; set; }

    public string member_name { get; set; }

    public string sub_account { get; set; }

    public int status { get; set; }

    public string status_string { get; set; }

    public string market { get; set; }

    public string borrow_type { get; set; }

    public Decimal init_money { get; set; }

    public Decimal balance { get; set; }

    public Decimal deposit_money { get; set; }

    public int multiple { get; set; }

    public bool auto_renewal { get; set; }

    public int pk { get; set; }

    public string order_id { get; set; }

    public Decimal borrow_interest { get; set; }

    public DateTime begin_time { get; set; }

    public DateTime end_time { get; set; }

    public DateTime create_time { get; set; }

    public DateTime verify_time { get; set; }
  }
}
