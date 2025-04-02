// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeOrderBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeAccount;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class TradeOrderBiz
  {
    public static List<TradeStopSearchList> GetTradeStopSearchList(TradeStopSearchFilter filter)
    {
      List<TradeStopSearchList> tradeOrderSearch = TradeOrderService.FindTradeOrderSearch(SqlTool.Build<TradeStopSearchFilter>(filter));
      return tradeOrderSearch == null ? (List<TradeStopSearchList>) null : tradeOrderSearch.Select<TradeStopSearchList, TradeStopSearchList>((Func<TradeStopSearchList, TradeStopSearchList>) (tradeStopSearch => PublicTool.convertUtcToLocalTime<TradeStopSearchList>(tradeStopSearch))).ToList<TradeStopSearchList>();
    }

    public static List<TradeEntrustedSearchList> GetEntrustedSearchList(
      TradeEntrustedSearchFilter filter)
    {
      return TradeOrderService.FindEntrustedOrderSearch(SqlTool.Build<TradeEntrustedSearchFilter>(filter));
    }

    public static void CancelOrder(TradeEntrustedVm vm, string ip, string adminName)
    {
      TradeOrderDto order = TradeOrderService.Find(Convert.ToInt32(vm.sn));
      switch (order.dir)
      {
        case 1:
          TradeOrderService.UpdateCancelOrderVolume(Convert.ToInt32(vm.sn));
          TradeFrozenService.CancelFrozenMoney(order);
          TradeAccountService.UpdateAccountFrozenMoney(order);
          TradeCancelService.AddCancelOrderRecord(order, ip, adminName);
          break;
        case 2:
          TradeOrderService.UpdateCancelOrderVolume(Convert.ToInt32(vm.sn));
          TradeFrozenService.CancelFrozenVolume(order);
          TradePositionService.UpdateSellVolume(order);
          TradeCancelService.AddCancelOrderRecord(order, ip, adminName);
          break;
      }
    }
  }
}
