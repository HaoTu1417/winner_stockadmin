// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StatBalance.CountAndTotalAmount
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable disable
namespace stockadmin.ViewModels.StatBalance
{
  public class CountAndTotalAmount
  {
    public int count { get; set; }

    public int recharge_count { get; set; }

    public int withdraw_count { get; set; }

    public Decimal total_recharge { get; set; }

    public Decimal total_withdraw { get; set; }
  }
}
