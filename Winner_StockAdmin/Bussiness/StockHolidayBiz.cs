// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockHolidayBiz
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
using stockadmin.ViewModels.StockHoliday;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class StockHolidayBiz
  {
    public static List<StockHolidayList> GetStockHolidayList(StockHolidayFilter? filter)
    {
      List<StockHolidayList> stockHolidayList = StockHolidayService.FindStockHolidayList(SqlTool.Build<StockHolidayFilter>(filter));
      return stockHolidayList == null ? (List<StockHolidayList>) null : stockHolidayList.ToList<StockHolidayList>();
    }

    public static StockHolidayDto Get(int pk) => StockHolidayService.Find(pk);

    public static void PostCreate(StockHolidayDto req, AdminSession adminUser)
    {
      if (StockHolidayService.Find(req.market, req.date.Date) != null)
        throw new AppException(3020, "insert_record_false");
      req.year = req.date.Year;
      if (StockHolidayService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 103,
        list = objArray
      });
    }

    public static void PostEdit(StockHolidayDto req, AdminSession adminUser)
    {
      if (StockHolidayService.Find(req.pk).date != req.date)
      {
        string market = req.market;
        DateTime date1 = req.date;
        DateTime date2 = date1.Date;
        if (StockHolidayService.Find(market, date2) != null)
          throw new AppException(3020, "insert_record_false");
        StockHolidayDto stockHolidayDto = req;
        date1 = req.date;
        int year = date1.Year;
        stockHolidayDto.year = year;
      }
      if (StockHolidayService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 100,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      StockHolidayService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 104,
        list = objArray
      });
    }
  }
}
