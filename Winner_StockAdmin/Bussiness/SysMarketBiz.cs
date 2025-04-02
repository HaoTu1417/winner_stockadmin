// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.SysMarketBiz
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
using stockadmin.ViewModels.SysMarket;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class SysMarketBiz
  {
    public static List<SysMarketList> GetSysMarketList() => SysMarketService.FindSysMarketList();

    public static SysMarketDto Get(string code) => SysMarketService.Find(code);

    public static void PostCreate(SysMarketDto req, AdminSession adminUser)
    {
      if (SysMarketService.Insert(req) == 0)
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
        admin_menu_fk = 229,
        list = objArray
      });
    }

    public static void PostEdit(SysMarketDto req, AdminSession adminUser)
    {
      if (SysMarketService.UpdateFull(req) == 0)
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
        admin_menu_fk = 227,
        list = objArray
      });
    }

    public static void Delete(string code) => SysMarketService.Remove(code);

    public static List<SelectListItem> GetDropDownList(string lang)
    {
      List<SelectListItem> dropDownList = new List<SelectListItem>();
      foreach (SysMarketDto sysMarketDto in SysMarketService.FindDropDown(lang))
        dropDownList.Add(new SelectListItem()
        {
          Value = sysMarketDto.code,
          Text = sysMarketDto.name + "(" + sysMarketDto.code + ")"
        });
      return dropDownList;
    }
  }
}
