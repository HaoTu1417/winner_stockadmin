// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeDealBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeAccount;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class TradeDealBiz
  {
    public static List<DealSearchList> GetTradeDealSearchList(DealSearchFilter filter)
    {
      List<DealSearchList> tradeDealSearch1 = TradeDealService.FindTradeDealSearch(SqlTool.Build<DealSearchFilter>(filter));
      return tradeDealSearch1 == null ? (List<DealSearchList>) null : tradeDealSearch1.Select<DealSearchList, DealSearchList>((Func<DealSearchList, DealSearchList>) (tradeDealSearch => PublicTool.convertUtcToLocalTime<DealSearchList>(tradeDealSearch))).ToList<DealSearchList>();
    }
  }
}
