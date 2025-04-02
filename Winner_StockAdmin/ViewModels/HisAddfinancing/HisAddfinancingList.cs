// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisAddfinancing.HisAddfinancingList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.HisAddfinancing
{
  public class HisAddfinancingList
  {
    public int status { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public string sub_account { get; set; }

    public string market { get; set; }

    public string loan_type { get; set; }

    public int pk { get; set; }

    public Decimal money { get; set; }

    public Decimal borrow_interest { get; set; }

    public Decimal exchange { get; set; }

    public Decimal freeze { get; set; }

    public DateTime add_time { get; set; }

    public DateTime verify_time { get; set; }

    public bool is_test_account { get; set; }
  }
}
