// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockOptionBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.StockOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Business
{
  public class StockOptionBiz
  {
    public static List<StockOptionList> GetStockOptionList(StockOptionFilter? filter)
    {
      List<StockOptionList> stockOptionList = StockOptionService.FindStockOptionList(SqlTool.Build<StockOptionFilter>(filter));
      return stockOptionList == null ? (List<StockOptionList>) null : stockOptionList.Select<StockOptionList, StockOptionList>((Func<StockOptionList, StockOptionList>) (so => PublicTool.convertUtcToLocalTime<StockOptionList>(so))).ToList<StockOptionList>();
    }

    public static StockOptionDto Get(int pk) => StockOptionService.Find(pk);

    public static async Task PostCreate(StockOptionDto req, AdminSession adminUser)
    {
      try
      {
        req.stock_name = StockOptionService.FindStockName(req.market, req.stock_code) ?? throw new AppException("找不到股票代號");
        if (StockOptionService.FindPkAfterInsert(req) == 0)
          throw new AppException("資料建立失敗");
        object[] objArray = new object[6]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) req.stock_name,
          (object) req.spot,
          (object) req.price,
          (object) req.quantity
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 371,
          list = objArray
        });
      }
      catch (AppException ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public static async void PostEdit(StockOptionDto req, AdminSession adminUser)
    {
      try
      {
        Console.WriteLine(req.pk);
        if (StockOptionService.UpdateFull(req) == 0)
          throw new AppException("資料建立失敗");
        object[] objArray = new object[6]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) req.stock_name,
          (object) req.spot,
          (object) req.price,
          (object) req.quantity
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 369,
          list = objArray
        });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw new AppException("資料建立失敗");
      }
    }
  }
}
