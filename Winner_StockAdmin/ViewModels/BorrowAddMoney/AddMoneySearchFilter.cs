// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowAddMoney.AddMoneySearchFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.BorrowAddMoney
{
  public class AddMoneySearchFilter
  {
    [Where("=", "member_fk")]
    public int? member_fk { get; set; }

    [Where("like", "member_real_name")]
    public string? member_real_name { get; set; }

    [Where("like", "sub_account")]
    public string? sub_account { get; set; }

    [Where("=", "status")]
    public int? status { get; set; }
  }
}
