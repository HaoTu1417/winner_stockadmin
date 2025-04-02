// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.HisTradeMoneyCheckBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisTradeMoneyCheck;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class HisTradeMoneyCheckBiz
  {
    public static DataCountBase<HisTradeMoneyCheckList> GetHisTradeMoneyCheckList(
      HisTradeMoneyCheckFilter? filter,
      int page,
      int pageSize)
    {
      string str = SqlTool.Build<HisTradeMoneyCheckFilter>(filter).Must("t.type = 0").Must("t.state > 0").Must("m.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("m.is_test_account = 0");
      DataCountBase<HisTradeMoneyCheckList> tradeMoneyCheckList = TradeMoneyCheckService.FindHisTradeMoneyCheckList(page, pageSize, str);
      return new DataCountBase<HisTradeMoneyCheckList>(tradeMoneyCheckList.count, tradeMoneyCheckList.data.Select<HisTradeMoneyCheckList, HisTradeMoneyCheckList>((Func<HisTradeMoneyCheckList, HisTradeMoneyCheckList>) (tradeRecordCheck => PublicTool.convertUtcToLocalTime<HisTradeMoneyCheckList>(tradeRecordCheck))));
    }

    public static HisTradeMoneyCheckReview GetReview(int pk)
    {
      return TradeMoneyCheckService.FindHisTradeMoneyCheckReview(pk);
    }
  }
}
