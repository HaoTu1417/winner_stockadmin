// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeCancelBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeCancel;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class TradeCancelBiz
  {
    public static List<TradeCancelList> GetTradeCancelList(
      string subAccount,
      TradeCancelFilter? filter)
    {
      List<TradeCancelList> tradeCancelList = TradeCancelService.FindTradeCancelList(SqlTool.Build<TradeCancelFilter>(filter).Must("sub_account = '" + subAccount + "'").Must("DATE(`cancel_datetime`) >= UTC_DATE"));
      return tradeCancelList == null ? (List<TradeCancelList>) null : tradeCancelList.Select<TradeCancelList, TradeCancelList>((Func<TradeCancelList, TradeCancelList>) (tradeCancel => PublicTool.convertUtcToLocalTime<TradeCancelList>(tradeCancel))).ToList<TradeCancelList>();
    }

    public static TradeCancelDto Get(int pk) => TradeCancelService.Find(pk);

    public static void PostCreate(TradeCancelDto req)
    {
      if (TradeCancelService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeCancelDto req)
    {
      if (TradeCancelService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => TradeCancelService.Remove(pk);
  }
}
