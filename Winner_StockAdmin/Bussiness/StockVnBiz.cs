// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockVnBiz
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
using stockadmin.ViewModels.StockVn;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class StockVnBiz
  {
    public static List<StockVnList> GetStockVnList(StockVnFilter? filter)
    {
      List<StockVnList> stockVnList = StockVnService.FindStockVnList(SqlTool.Build<StockVnFilter>(filter));
      return stockVnList == null ? (List<StockVnList>) null : stockVnList.Select<StockVnList, StockVnList>((Func<StockVnList, StockVnList>) (reviewMember => PublicTool.convertUtcToLocalTime<StockVnList>(reviewMember))).ToList<StockVnList>();
    }

    public static StockVnDto Get(string stock_code) => StockVnService.Find(stock_code);

    public static void PostCreate(StockVnDto req)
    {
      if (StockVnService.Insert(PublicTool.convertLocalToUtcTime<StockVnDto>(req)) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(StockVnDto req, AdminSession adminUser)
    {
      if (StockVnService.UpdateFull(PublicTool.convertLocalToUtcTime<StockVnDto>(req)) == 0)
        throw new AppException(3010, "record_update_false");
      Dictionary<string, StockInfo> dictionary = StockVnService.FindEnableList().ToDictionary<StockUsDto, string, StockInfo>((Func<StockUsDto, string>) (x => x.stock_code), (Func<StockUsDto, StockInfo>) (x => new StockInfo()
      {
        stock_code = x.stock_code,
        stock_name = x.stock_name
      }));
      CacheQuery.SelectDB(CacheEnum.VnStockData);
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
        admin_menu_fk = 101,
        list = objArray
      });
    }

    public static void Delete(string stock_code) => StockVnService.Remove(stock_code);
  }
}
