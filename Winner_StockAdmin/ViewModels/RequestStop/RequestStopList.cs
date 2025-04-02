// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RequestStop.RequestStopList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.RequestStop
{
  public class RequestStopList
  {
    public int pk { get; set; }

    public DateTime add_time { get; set; }

    public string sub_account { get; set; }

    public string loan_type { get; set; }

    public Decimal init_money { get; set; }

    public Decimal balance { get; set; }

    public DateTime end_time { get; set; }

    public int member_fk { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public Decimal warningline { get; set; }

    public Decimal breakline { get; set; }
  }
}
