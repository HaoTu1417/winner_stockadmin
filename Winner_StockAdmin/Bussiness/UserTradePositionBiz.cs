// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.UserTradePositionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.UserTradePosition;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class UserTradePositionBiz
  {
    public static List<UserTradePositionList> GetUserTradePositionList(
      string subAccount,
      UserTradePositionFilter? filter)
    {
      List<UserTradePositionList> tradePositionList = TradePositionService.FindUserTradePositionList(SqlTool.Build<UserTradePositionFilter>(filter).Must("trade_position.sub_account = '" + subAccount + "' "));
      return tradePositionList == null ? (List<UserTradePositionList>) null : tradePositionList.Select<UserTradePositionList, UserTradePositionList>((Func<UserTradePositionList, UserTradePositionList>) (userTradePosition => PublicTool.convertUtcToLocalTime<UserTradePositionList>(userTradePosition))).ToList<UserTradePositionList>();
    }

    public static TradePositionDto Get(string sub_account)
    {
      return TradePositionService.Find(sub_account);
    }

    public static void PostCreate(TradePositionDto req)
    {
      if (TradePositionService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradePositionDto req)
    {
      if (TradePositionService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(string sub_account, string stock_code)
    {
      TradePositionService.Remove(sub_account, stock_code);
    }
  }
}
