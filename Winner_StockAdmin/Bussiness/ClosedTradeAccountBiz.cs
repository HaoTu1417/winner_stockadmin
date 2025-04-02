// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.ClosedTradeAccountBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.ClosedTradeAccount;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class ClosedTradeAccountBiz
  {
    public static DataCountBase<ClosedTradeAccountList> GetClosedTradeAccountLists(
      ClosedTradeAccountFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<ClosedTradeAccountFilter>(filter).Must("close_time IS NOT NULL");
      DataCountBase<ClosedTradeAccountList> tradeAccountList = StatisticsService.GetClosedTradeAccountList(page, pageSize, whereSql);
      return new DataCountBase<ClosedTradeAccountList>(tradeAccountList.count, tradeAccountList.data.Select<ClosedTradeAccountList, ClosedTradeAccountList>((Func<ClosedTradeAccountList, ClosedTradeAccountList>) (closedTradeAccount => PublicTool.convertUtcToLocalTime<ClosedTradeAccountList>(closedTradeAccount))));
    }
  }
}
