// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ReviewBorrow.ReviewBorrowFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.ReviewBorrow
{
  public class ReviewBorrowFilter
  {
    [Where("=", "member.account")]
    public string? account { get; set; }

    [Where("LIKE", "member.nickname")]
    public string? nickname { get; set; }

    [Where("=", "pk")]
    public int? pk { get; set; }

    [Where("=", "order_id")]
    public string? order_id { get; set; }

    [Where("=", "borrow_type")]
    public string? borrow_type { get; set; }
  }
}
