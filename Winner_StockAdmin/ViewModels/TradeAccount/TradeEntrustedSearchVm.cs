// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradeEntrustedSearchVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradeEntrustedSearchVm
  {
    public TradeEntrustedSearchFilter filter { get; set; }

    public IPagedList<TradeEntrustedSearchList> list { get; set; }

    public string sort { get; set; }

    public SortEnum dir { get; set; }
  }
}
