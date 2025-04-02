// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisAddmoney.HisAddmoneyList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.HisAddmoney
{
  public class HisAddmoneyList
  {
    public string account { get; set; }

    public string member_name { get; set; }

    public string sub_account { get; set; }

    public string loan_type { get; set; }

    public string market { get; set; }

    public DateTime add_time { get; set; }

    public Decimal money { get; set; }

    public int pk { get; set; }

    public int status { get; set; }

    public DateTime verify_time { get; set; }

    public string target_name { get; set; }

    public bool is_test_account { get; set; }
  }
}
