// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowAddfinancing.BorrowAddfinancingSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels.BorrowAddfinancing
{
  public class BorrowAddfinancingSearchList
  {
    public uint pk { get; set; }

    public uint member_fk { get; set; }

    public string? member_real_name { get; set; }

    public string? sub_account { get; set; }

    public string borrow_plan { get; set; }

    public Decimal? multiple { get; set; }

    public DateTime? end_time { get; set; }

    public Decimal last_deposit_money { get; set; }

    public Decimal last_borrow_money { get; set; }

    public Decimal money { get; set; }

    public string? currency { get; set; }

    public Decimal? exchange { get; set; }

    public Decimal? freeze { get; set; }

    public DateTime? add_time { get; set; }

    public Decimal borrow_interest { get; set; }

    public DateTime? verify_time { get; set; }

    public string? target_name { get; set; }

    public sbyte status { get; set; }
  }
}
