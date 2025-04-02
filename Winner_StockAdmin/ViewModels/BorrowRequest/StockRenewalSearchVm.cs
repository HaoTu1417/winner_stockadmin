// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.BorrowRequest.StockRenewalSearchVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.BorrowRequest
{
  public class StockRenewalSearchVm
  {
    public StockRenewalSearchFilter filter { get; set; }

    public IPagedList<StockRenewalSearchList> list { get; set; }

    public int page { get; set; } = 1;

    public string sort { get; set; }
  }
}
