// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.TradeMoneyRecord.TradeMoneyRecordVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.TradeMoneyRecord
{
  public class TradeMoneyRecordVm
  {
    public TradeMoneyRecordFilter filter { get; set; }

    public string subAccount { get; set; }

    public bool fromCN { get; set; }

    public IPagedList<TradeMoneyRecordList> list { get; set; }
  }
}
