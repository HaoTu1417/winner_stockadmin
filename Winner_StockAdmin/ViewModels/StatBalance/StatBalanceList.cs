// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatBalance.StatBalanceList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.StatBalance
{
  public class StatBalanceList
  {
    public string account { get; set; }

    public string nickname { get; set; }

    public DateTime create_time { get; set; }

    public int type { get; set; }

    public string name { get; set; }

    public Decimal recharge { get; set; }

    public Decimal withdraw { get; set; }
  }
}
