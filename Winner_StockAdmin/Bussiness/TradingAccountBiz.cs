// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradingAccountBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.TradingAccount;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class TradingAccountBiz
  {
    public static (Decimal totalProfit, DataCountBase<TradingAccountList> list) GetTradingAccountList(
      TradingAccountFilter? filter,
      int page,
      int pageSize,
      string market,
      string lang)
    {
      string str1 = SqlTool.Build<TradingAccountFilter>(filter).Must("t.status < 3").Must("t.market ='" + market.ToUpper() + "'");
      if (filter.filter_out_test_account)
        str1 = str1.Must("m.is_test_account = 0");
      string str2 = ConfigLib.Get("time_zone_difference");
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      if (filter.begin_time.HasValue && str2 != null)
      {
        string str3 = filter.begin_time.Value.AddHours((double) -Convert.ToInt32(str2)).ToString("yyyy/MM/dd HH:mm:ss");
        str1 = str1.Must("'" + str3 + "' <= t.begin_time");
      }
      if (filter.end_time.HasValue && str2 != null)
      {
        string str4 = filter.end_time.Value.AddHours((double) -Convert.ToInt32(str2)).ToString("yyyy/MM/dd HH:mm:ss");
        str1 = str1.Must("t.end_time < '" + str4 + "'");
      }
      (Decimal totalProfit, DataCountBase<TradingAccountList> list) = TradeAccountService.FindTradingAccountList(page, pageSize, str1, lang);
      return (totalProfit, new DataCountBase<TradingAccountList>(list.count, list.data.Select<TradingAccountList, TradingAccountList>((Func<TradingAccountList, TradingAccountList>) (d => PublicTool.convertUtcToLocalTime<TradingAccountList>(d)))));
    }

    public static TradeAccountDto Get(string sub_account) => TradeAccountService.Find(sub_account);

    public static VwTradeAccountDto GetFromView(string sub_account)
    {
      return VwTradeAccountService.Find(sub_account);
    }

    public static void PostCreate(TradeAccountDto req)
    {
      if (TradeAccountService.Insert(PublicTool.convertLocalToUtcTime<TradeAccountDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeAccountDto req, AdminSession adminUser)
    {
      if (TradeAccountService.UpdateFull(PublicTool.convertLocalToUtcTime<TradeAccountDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.sub_account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 390,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static byte[]? DownloadTradingAccountList(
      TradingAccountFilter? filter,
      string market,
      string lang)
    {
      (Decimal totalProfit, DataCountBase<TradingAccountList> list) tradingAccountList = TradingAccountBiz.GetTradingAccountList(filter ?? new TradingAccountFilter(), 1, int.MaxValue, market, lang);
      Decimal totalProfit = tradingAccountList.totalProfit;
      return Exportlib.ExportExcel<TradingAccountList>(tradingAccountList.list.data);
    }
  }
}
