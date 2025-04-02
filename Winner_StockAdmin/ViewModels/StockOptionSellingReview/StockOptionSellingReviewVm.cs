// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.StockOptionSellingReview.StockOptionSellingReviewVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.ViewModels.StockOptionRecord;
using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.StockOptionSellingReview
{
  public class StockOptionSellingReviewVm
  {
    public StockOptionSellingReviewFilter filter { get; set; }

    public IPagedList<StockOptionRecordList> list { get; set; }
  }
}
