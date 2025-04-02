// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StockOptionSellingReviewBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Tool;
using stockadmin.ViewModels.StockOptionRecord;
using stockadmin.ViewModels.StockOptionSellingReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

#nullable enable
namespace stockadmin.Business
{
  public class StockOptionSellingReviewBiz
  {
    public static List<StockOptionRecordList> GetStockOptionSellingReviewList(
      StockOptionSellingReviewFilter? filter)
    {
      return StockOptionRecordService.FindStockOptionRecordList(SqlTool.Build<StockOptionSellingReviewFilter>(filter).Must("stock_option_record.type = 2 AND stock_option_record.status = 1")).Select<StockOptionRecordList, StockOptionRecordList>((Func<StockOptionRecordList, StockOptionRecordList>) (review => PublicTool.convertUtcToLocalTime<StockOptionRecordList>(review))).ToList<StockOptionRecordList>();
    }

    public static List<SelectListItem> GetStatusList()
    {
      return new List<SelectListItem>()
      {
        new SelectListItem() { Text = "成功", Value = "1" },
        new SelectListItem() { Text = "失敗", Value = "2" }
      };
    }

    public static StockOptionRecordList GetReview(int pk) => StockOptionRecordService.GetReview(pk);

    public static void Review(
      StockOptionRecordList req,
      bool review_status,
      AdminSession adminUser,
      string? reject_result)
    {
      using (TransactionScope transactionScope = new TransactionScope())
      {
        if (!WalletLib.SellStockOption(req.member_fk, req.total, req.stock_code))
          throw new AppException(1626, "sell_stock_option_money_handle_failed");
        StockOptionPositionDto model = StockOptionPositionService.Find(MemberService.Find(req.member_fk).pk, req.stock_code, req.market.ToUpper());
        model.freeze -= req.quantity;
        if (review_status)
          model.quantity -= req.quantity;
        if (StockOptionPositionService.SellUpdate(model) == 0)
          throw new AppException(1627, "sell_stock_option_position_handle_failed");
        if (review_status)
          StockOptionRecordService.UpdateSuccess(req.pk);
        else
          StockOptionRecordService.UpdateFail(req.pk, reject_result);
        string account = MemberService.Find(req.member_fk).account;
        object[] objArray = new object[6]
        {
          (object) adminUser.account,
          (object) adminUser.nickName,
          (object) account,
          (object) req.stock_code,
          (object) req.quantity,
          (object) req.total
        };
        AdminLogLib.Save(new AdminLogRequest()
        {
          admin_user_pk = adminUser.pk,
          admin_menu_fk = 374,
          list = objArray,
          member_account = account
        });
        transactionScope.Complete();
      }
    }
  }
}
