// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeMoneyCheck.TradeMoneyCheckList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.TradeMoneyCheck
{
  public class TradeMoneyCheckList
  {
    public int pk { get; set; }

    public string account { get; set; }

    public string member_name { get; set; }

    public string sn { get; set; }

    public string sub_account { get; set; }

    public string currency { get; set; }

    public Decimal frozen { get; set; }

    public Decimal balance { get; set; }

    public string loan_type { get; set; }
  }
}
