// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeAccountBiz
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
  public class TradeAccountBiz
  {
    public static List<TradeAccountSearchList> GetSearchList(TradeAccountSearchFilter filter)
    {
      List<TradeAccountSearchList> tradeAccountSearch1 = TradeAccountService.FindTradeAccountSearch(SqlTool.Build<TradeAccountSearchFilter>(filter));
      return tradeAccountSearch1 == null ? (List<TradeAccountSearchList>) null : tradeAccountSearch1.Select<TradeAccountSearchList, TradeAccountSearchList>((Func<TradeAccountSearchList, TradeAccountSearchList>) (tradeAccountSearch => PublicTool.convertUtcToLocalTime<TradeAccountSearchList>(tradeAccountSearch))).ToList<TradeAccountSearchList>();
    }
  }
}
