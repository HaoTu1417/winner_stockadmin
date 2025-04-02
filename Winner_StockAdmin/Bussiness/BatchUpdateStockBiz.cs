// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BatchUpdateStockBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.ViewModels.BatchUpdateStock;

#nullable enable
namespace stockadmin.Business
{
  public class BatchUpdateStockBiz
  {
    public static BatchUpdateStockVm GetStockSetting()
    {
      SysMarketDto sysMarketDto1 = SysMarketService.Find("US");
      SysMarketDto sysMarketDto2 = SysMarketService.Find("VN");
      return new BatchUpdateStockVm()
      {
        us_min_stock_price = sysMarketDto1.min_stock_price,
        us_min_stock_month_volume = sysMarketDto1.min_stock_month_volume,
        us_capital_filter_enable = sysMarketDto1.capital_filter_enable,
        us_capital_filter_number = sysMarketDto1.capital_filter_number,
        vn_min_stock_price = sysMarketDto2.min_stock_price,
        vn_min_stock_month_volume = sysMarketDto2.min_stock_month_volume,
        vn_capital_filter_enable = sysMarketDto2.capital_filter_enable,
        vn_capital_filter_number = sysMarketDto2.capital_filter_number
      };
    }

    public static void BatchUpdateStock(BatchUpdateStockRequest req, AdminSession adminUser)
    {
      SysMarketService.UpdateSysByMarket("US", req.us_min_stock_price, req.us_min_stock_month_volume, req.us_capital_filter_enable, req.us_capital_filter_number);
      SysMarketService.UpdateSysByMarket("VN", req.vn_min_stock_price, req.vn_min_stock_month_volume, req.vn_capital_filter_enable, req.vn_capital_filter_number);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) "批次设置不可交易股票"
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 431,
        list = objArray
      });
    }

    public static void UpdateUsTradingSwitch(StockUsDto stock, bool program_enable, string info)
    {
      StockUsService.UpdateStockUsSetting(stock.stock_code, program_enable, info);
      StockUsDto stockUsDto = StockUsService.Find(stock.stock_code);
      StockUsService.UpdateTradingSwitch(stockUsDto.program_enable && stockUsDto.enable && !stockUsDto.disable_alwayse, stockUsDto.stock_code);
    }

    public static void UpdateVnTradingSwitch(StockVnDto stock, bool program_enable, string info)
    {
      StockVnService.UpdateStockVnSetting(stock.stock_code, program_enable, info);
      StockVnDto stockVnDto = StockVnService.Find(stock.stock_code);
      StockVnService.UpdateTradingSwitch(stockVnDto.program_enable && stockVnDto.enable && !stockVnDto.disable_alwayse, stockVnDto.stock_code);
    }
  }
}
