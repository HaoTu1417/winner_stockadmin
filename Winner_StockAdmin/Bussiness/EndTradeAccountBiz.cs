// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.EndTradeAccountBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.EndTradeAccount;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class EndTradeAccountBiz
  {
    public static (Decimal totalProfit, DataCountBase<EndTradeAccountList>) GetEndTradeAccountList(
      EndTradeAccountFilter? filter,
      int page,
      int pageSize,
      string market,
      string lang)
    {
      string str = SqlTool.Build<EndTradeAccountFilter>(filter).Must("t.status = 3").Must("t.market='" + market + "'").Must("m.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("m.is_test_account = 0");
      (Decimal totalProfit, DataCountBase<EndTradeAccountList> dataCountBase) = VwTradeAccountService.FindEndTradeAccountList(page, pageSize, str, lang);
      return (totalProfit, new DataCountBase<EndTradeAccountList>(dataCountBase.count, dataCountBase.data.Select<EndTradeAccountList, EndTradeAccountList>((Func<EndTradeAccountList, EndTradeAccountList>) (endTradeAccount => PublicTool.convertUtcToLocalTime<EndTradeAccountList>(endTradeAccount)))));
    }

    public static byte[]? DownloadEndTradeAccountList(
      EndTradeAccountFilter? filter,
      string market,
      string lang)
    {
      (Decimal totalProfit, DataCountBase<EndTradeAccountList>) tradeAccountList = EndTradeAccountBiz.GetEndTradeAccountList(filter ?? new EndTradeAccountFilter(), 1, int.MaxValue, market, lang);
      Decimal totalProfit = tradeAccountList.totalProfit;
      return Exportlib.ExportExcel<EndTradeAccountList>(tradeAccountList.Item2.data);
    }
  }
}
