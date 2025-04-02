// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowAddMoney.AddMoneySearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.BorrowAddMoney
{
  public class AddMoneySearchList
  {
    public uint pk { get; set; }

    public int member_fk { get; set; }

    public string? member_real_name { get; set; }

    public string sub_account { get; set; }

    public sbyte status { get; set; }

    public string currency { get; set; }

    public Decimal money { get; set; }

    public Decimal balance { get; set; }

    public Decimal warningline { get; set; }

    public Decimal breakline { get; set; }

    public Decimal? exchange { get; set; }

    public Decimal freeze { get; set; }

    public DateTime add_time { get; set; }

    public DateTime? verify_time { get; set; }

    public string? target_name { get; set; }
  }
}
