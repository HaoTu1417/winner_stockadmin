// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeTemplateBiz
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
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeTemplate;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class TradeTemplateBiz
  {
    public static DataCountBase<TradeTemplateList> GetTradeTemplateList(
      TradeTemplateFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<TradeTemplateFilter>(filter);
      DataCountBase<TradeTemplateList> tradeTemplateList = TradeTemplateService.FindTradeTemplateList(page, pageSize, whereSql);
      return new DataCountBase<TradeTemplateList>(tradeTemplateList.count, tradeTemplateList.data);
    }

    public static TradeTemplateDto Get(int pk) => TradeTemplateService.Find(pk);

    public static void PostCreate(TradeTemplateDto req, AdminSession adminUser)
    {
      if (TradeTemplateService.FindPkAfterInsert(req) == 0)
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
        admin_menu_fk = 32,
        list = objArray
      });
    }

    public static void PostEdit(TradeTemplateDto req, AdminSession adminUser)
    {
      if (TradeTemplateService.UpdateFull(req) == 0)
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
        admin_menu_fk = 32,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      TradeTemplateService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 32,
        list = objArray
      });
    }

    public static List<SelectListItem> GetDropDownList(string lang)
    {
      List<SelectListItem> dropDownList = new List<SelectListItem>();
      foreach (TradeTemplateDto tradeTemplateDto in TradeTemplateService.FindDropDown(lang))
      {
        List<SelectListItem> selectListItemList = dropDownList;
        SelectListItem selectListItem = new SelectListItem();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
        interpolatedStringHandler.AppendFormatted<int>(tradeTemplateDto.temp_id);
        selectListItem.Value = interpolatedStringHandler.ToStringAndClear();
        selectListItem.Text = tradeTemplateDto.name ?? "";
        selectListItemList.Add(selectListItem);
      }
      return dropDownList;
    }
  }
}
