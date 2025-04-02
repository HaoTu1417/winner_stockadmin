// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.DealSearchFilter
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Internal;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class DealSearchFilter
  {
    [Where("like", "sub_account")]
    public string? sub_account { get; set; }
  }
}
