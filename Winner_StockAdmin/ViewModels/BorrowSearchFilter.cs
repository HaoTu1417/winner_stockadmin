// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowSearchFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels
{
  public class BorrowSearchFilter
  {
    [Where("=", "member_fk")]
    public int? member_fk { get; set; }

    [Where("=", "status")]
    public int? status { get; set; }

    [Where("like", "member_username")]
    public string? member_username { get; set; }

    [Where("like", "member_real_name")]
    public string? member_real_name { get; set; }

    [Where("like", "order_id")]
    public string? order_id { get; set; }
  }
}
