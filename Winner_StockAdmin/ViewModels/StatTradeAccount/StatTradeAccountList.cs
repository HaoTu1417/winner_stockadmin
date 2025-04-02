// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatTradeAccount.StatTradeAccountList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.StatTradeAccount
{
  public class StatTradeAccountList
  {
    public string market { get; set; }

    public string loan_type { get; set; }

    public Decimal margin { get; set; }

    public Decimal loan_money { get; set; }

    public int dcount { get; set; }
  }
}
