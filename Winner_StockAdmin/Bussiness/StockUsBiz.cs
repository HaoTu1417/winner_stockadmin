// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockUsBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using Models.ViewModels;
using stockadmin.Cache;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.StockUs;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class StockUsBiz
  {
    public static List<StockUsList> GetStockUsList(StockUsFilter? filter)
    {
      List<StockUsList> stockUsList = StockUsService.FindStockUsList(SqlTool.Build<StockUsFilter>(filter));
      return stockUsList == null ? (List<StockUsList>) null : stockUsList.Select<StockUsList, StockUsList>((Func<StockUsList, StockUsList>) (stockUs => PublicTool.convertUtcToLocalTime<StockUsList>(stockUs))).ToList<StockUsList>();
    }

    public static StockUsDto Get(string stock_code) => StockUsService.Find(stock_code);

    public static void PostCreate(StockUsDto req)
    {
      if (StockUsService.Insert(PublicTool.convertLocalToUtcTime<StockUsDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(StockUsDto req, AdminSession adminUser)
    {
      if (StockUsService.UpdateFull(PublicTool.convertLocalToUtcTime<StockUsDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      Dictionary<string, StockInfo> dictionary = StockUsService.FindEnableList().ToDictionary<StockUsDto, string, StockInfo>((Func<StockUsDto, string>) (x => x.stock_code), (Func<StockUsDto, StockInfo>) (x => new StockInfo()
      {
        stock_code = x.stock_code,
        stock_name = x.stock_name
      }));
      CacheQuery.SelectDB(CacheEnum.UsStockData);
      CacheQuery.StringSet<Dictionary<string, StockInfo>>("@stock_info", dictionary);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.stock_name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 100,
        list = objArray
      });
    }

    public static void Delete(string stock_code) => StockUsService.Remove(stock_code);
  }
}
