// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeAccount.TradeStopSearchVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.TradeAccount
{
  public class TradeStopSearchVm
  {
    public TradeStopSearchFilter filter { get; set; }

    public IPagedList<TradeStopSearchList> list { get; set; }

    public string sort { get; set; }

    public SortEnum dir { get; set; }
  }
}
