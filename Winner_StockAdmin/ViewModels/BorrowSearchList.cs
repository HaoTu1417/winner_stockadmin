// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowSearchList
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using System;

#nullable enable
namespace stockadmin.ViewModels
{
  public class BorrowSearchList
  {
    public uint pk { get; set; }

    public int? borrow_plan_fk { get; set; }

    public int member_fk { get; set; }

    public string member_username { get; set; }

    public string? member_real_name { get; set; }

    public string order_id { get; set; }

    public sbyte status { get; set; }

    public string? borrow_type { get; set; }

    public string? market { get; set; }

    public int borrow_duration { get; set; }

    public sbyte? auto_renewal { get; set; }

    public DateTime? begin_time { get; set; }

    public DateTime? end_time { get; set; }

    public Decimal deposit_money { get; set; }

    public Decimal borrow_money { get; set; }

    public sbyte multiple { get; set; }

    public Decimal rate { get; set; }

    public Decimal borrow_interest { get; set; }

    public Decimal init_money { get; set; }

    public DateTime create_time { get; set; }

    public DateTime? verify_time { get; set; }
  }
}
