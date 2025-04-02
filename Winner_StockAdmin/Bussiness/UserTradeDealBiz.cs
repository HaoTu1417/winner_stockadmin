// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.UserTradeDealBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.UserTradeDeal;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class UserTradeDealBiz
  {
    public static List<UserTradeDealList> GetUserTradeDealList(
      string subAccount,
      UserTradeDealFilter? filter)
    {
      List<UserTradeDealList> userTradeDealList = TradeDealService.FindUserTradeDealList(SqlTool.Build<UserTradeDealFilter>(filter).Must("trade_deal.sub_account = '" + subAccount + "' "));
      return userTradeDealList == null ? (List<UserTradeDealList>) null : userTradeDealList.Select<UserTradeDealList, UserTradeDealList>((Func<UserTradeDealList, UserTradeDealList>) (userTradeDeal => PublicTool.convertUtcToLocalTime<UserTradeDealList>(userTradeDeal))).ToList<UserTradeDealList>();
    }

    public static TradeDealDto Get(int pk) => TradeDealService.Find(pk);

    public static void PostCreate(TradeDealDto req)
    {
      if (TradeDealService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeDealDto req)
    {
      if (TradeDealService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => TradeDealService.Remove(pk);
  }
}
