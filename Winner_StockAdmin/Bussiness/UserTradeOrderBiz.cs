// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.UserTradeOrderBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.UserTradeOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class UserTradeOrderBiz
  {
    public static List<UserTradeOrderList> GetUserTradeOrderList(
      string subAccount,
      UserTradeOrderFilter? filter,
      int hour = 7)
    {
      string sourceStr = SqlTool.Build<UserTradeOrderFilter>(filter).Must("trade_order.sub_account = '" + subAccount + "'");
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
      interpolatedStringHandler.AppendLiteral("DATE_ADD(`order_time`, INTERVAL ");
      interpolatedStringHandler.AppendFormatted<int>(hour);
      interpolatedStringHandler.AppendLiteral(" HOUR) >= UTC_DATE");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      List<UserTradeOrderList> userTradeOrderList = TradeOrderService.FindUserTradeOrderList(sourceStr.Must(stringAndClear));
      return userTradeOrderList == null ? (List<UserTradeOrderList>) null : userTradeOrderList.Select<UserTradeOrderList, UserTradeOrderList>((Func<UserTradeOrderList, UserTradeOrderList>) (tradeOrder => PublicTool.convertUtcToLocalTime<UserTradeOrderList>(tradeOrder))).ToList<UserTradeOrderList>();
    }

    public static TradeOrderDto Get(int pk) => TradeOrderService.Find(pk);

    public static void PostCreate(TradeOrderDto req)
    {
      if (TradeOrderService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeOrderDto req)
    {
      if (TradeOrderService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => TradeOrderService.Remove(pk);
  }
}
