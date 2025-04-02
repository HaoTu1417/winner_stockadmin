// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.HisBorrow.HisBorrowFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.HisBorrow
{
  public class HisBorrowFilter
  {
    [Where("=", "market")]
    public string? market { get; set; }

    [Where("=", "t.account")]
    public string? account { get; set; }

    [Where("LIKE", "t.member_name")]
    public string? member_name { get; set; }

    [Where("=", "t.sub_account")]
    public string? sub_account { get; set; }

    [Where("=", "t.borrow_type")]
    public string? borrow_type { get; set; }

    [Where("=", "t.order_id")]
    public string? order_id { get; set; }

    public bool filter_out_test_account { get; set; }
  }
}
