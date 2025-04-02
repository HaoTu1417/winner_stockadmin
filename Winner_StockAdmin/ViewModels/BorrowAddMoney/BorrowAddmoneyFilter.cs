// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowAddmoney.BorrowAddmoneyFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.BorrowAddmoney
{
  public class BorrowAddmoneyFilter
  {
    [Where("=", "borrow_addmoney.sub_account")]
    public string? sub_account { get; set; }

    [Where("=", "vw_trade_account.market")]
    public string? market { get; set; }

    [Where("=", "borrow_addmoney.member_fk")]
    public int? member_fk { get; set; }

    [Where("=", "vw_trade_account.account")]
    public string? account { get; set; }

    [Where("LIKE", "vw_trade_account.member_name")]
    public string? member_name { get; set; }
  }
}
