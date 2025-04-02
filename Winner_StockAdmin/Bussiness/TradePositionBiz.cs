// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradePositionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.TradePosition;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class TradePositionBiz
  {
    public static DataCountBase<TradePositionList> GetTradePositionList(
      TradePositionFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<TradePositionFilter>(filter).Must("m.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("m.is_test_account = 0");
      DataCountBase<TradePositionList> tradePositionList = TradePositionService.FindTradePositionList(page, pageSize, str);
      return new DataCountBase<TradePositionList>(tradePositionList.count, tradePositionList.data.Select<TradePositionList, TradePositionList>((Func<TradePositionList, TradePositionList>) (tradePosition => PublicTool.convertUtcToLocalTime<TradePositionList>(tradePosition))));
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
