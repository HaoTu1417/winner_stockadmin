// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.RichboxBook.RichboxBookDetailVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using tradeapi.Models.RichBox;
using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.RichboxBook
{
  public class RichboxBookDetailVm
  {
    public string account { get; set; }

    public RichboxBookDetailFilter filter { get; set; }

    public IPagedList<RichHistoryResponse> list { get; set; }
  }
}
