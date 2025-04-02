// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.ExchangeRateBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using stockadmin.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class ExchangeRateBiz
  {
    public static List<ExchangeRateList> GetExchangeRateList(ExchangeRateFilter? filter)
    {
      List<ExchangeRateList> exchangeRateList = ViewExchangeRateService.FindExchangeRateList(SqlTool.Build<ExchangeRateFilter>(filter));
      return exchangeRateList == null ? (List<ExchangeRateList>) null : exchangeRateList.Select<ExchangeRateList, ExchangeRateList>((Func<ExchangeRateList, ExchangeRateList>) (exchangeRate => PublicTool.convertUtcToLocalTime<ExchangeRateList>(exchangeRate))).ToList<ExchangeRateList>();
    }
  }
}
