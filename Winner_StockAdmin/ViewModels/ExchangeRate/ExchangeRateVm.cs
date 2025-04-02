// Decompiled with JetBrains decompiler
// Type: stockadmin.ViewModels.ExchangeRate.ExchangeRateVm
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using X.PagedList;

#nullable enable
namespace stockadmin.ViewModels.ExchangeRate
{
  public class ExchangeRateVm
  {
    public ExchangeRateFilter filter { get; set; }

    public IPagedList<ExchangeRateList> list { get; set; }
  }
}
