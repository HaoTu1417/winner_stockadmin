// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.BorrowPlanBiz
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
using stockadmin.ViewModels.BorrowPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class BorrowPlanBiz
  {
    public static List<SelectListItem> GetSelectListItems()
    {
      List<BorrowPlanDto> all = BorrowPlanService.FindAll();
      List<SelectListItem> selectListItems = new List<SelectListItem>();
      foreach (BorrowPlanDto borrowPlanDto in all)
      {
        List<SelectListItem> selectListItemList = selectListItems;
        SelectListItem selectListItem = new SelectListItem();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(borrowPlanDto.pk);
        selectListItem.Value = interpolatedStringHandler.ToStringAndClear();
        selectListItem.Text = borrowPlanDto.name + "(" + borrowPlanDto.market + ")";
        selectListItemList.Add(selectListItem);
      }
      return selectListItems;
    }

    public static List<SelectListItem> GetBorrowTypes()
    {
      List<string> borrowTypes1 = BorrowPlanService.GetBorrowTypes();
      List<SelectListItem> borrowTypes2 = new List<SelectListItem>();
      foreach (string str in borrowTypes1)
        borrowTypes2.Add(new SelectListItem()
        {
          Value = str ?? "",
          Text = str ?? ""
        });
      return borrowTypes2;
    }

    public static List<BorrowPlanList> GetBorrowPlanList(BorrowPlanFilter? filter)
    {
      List<BorrowPlanList> borrowPlanList = BorrowPlanService.FindBorrowPlanList(SqlTool.Build<BorrowPlanFilter>(filter));
      return (borrowPlanList != null ? borrowPlanList.Select<BorrowPlanList, BorrowPlanList>((Func<BorrowPlanList, BorrowPlanList>) (banner => PublicTool.convertUtcToLocalTime<BorrowPlanList>(banner))).ToList<BorrowPlanList>() : (List<BorrowPlanList>) null) ?? new List<BorrowPlanList>();
    }

    public static BorrowPlanDto Get(int pk)
    {
      BorrowPlanDto borrowPlanDto = BorrowPlanService.Find(pk);
      borrowPlanDto.use_time = borrowPlanDto.use_time.Replace("|", "\r\n");
      return borrowPlanDto;
    }

    public static void PostCreate(BorrowPlanDto req)
    {
      if (BorrowPlanService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(BorrowPlanDto req, AdminSession adminUser)
    {
      req.use_time = req.use_time.Replace("\r\n", "|");
      if (BorrowPlanService.UpdateFull(req) == 0)
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
        admin_menu_fk = 1,
        list = objArray
      });
    }

    public static void Delete(int pk) => BorrowPlanService.Remove(pk);
  }
}
