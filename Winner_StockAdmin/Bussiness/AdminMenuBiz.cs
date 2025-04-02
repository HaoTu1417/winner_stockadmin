// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminMenuBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AdminMenuBiz
  {
    public static List<MainMenuVm> GetMenuByRole(int role, string lang = "CN")
    {
      CacheQuery.SelectDB(CacheEnum.admin);
      return CacheQuery.HashGet<List<MainMenuVm>>("AdminMenu" + lang.ToUpper(), role.ToString());
    }

    public static void UpdateMenu(int role)
    {
      AdminRoleDto adminRoleDto = AdminRoleService.Find(role);
      if (adminRoleDto == null)
        return;
      List<AdminMenuDto> allByFirstMenu = AdminMenuService.FindAllByFirstMenu();
      List<MainMenuVm> menuFromDb = AdminMenuBiz.GetMenuFromDb(PublicTool.FromJson<Dictionary<int, int[]>>(adminRoleDto.admin_menu), allByFirstMenu);
      CacheQuery.SelectDB(CacheEnum.admin);
      CacheQuery.HashSet<List<MainMenuVm>>("AdminMenu", role.ToString(), menuFromDb);
    }

    public static void BuildMenu()
    {
      LogLib.Debug("建立選單緩存");
      CacheQuery.SelectDB(CacheEnum.admin);
      List<AdminRoleDto> all = AdminRoleService.FindAll();
      if (all == null || all.Count <= 0)
        return;
      foreach (string lang in new List<string>()
      {
        "VN",
        "CN",
        "EN"
      })
      {
        LogLib.Debug("建立" + lang + "語系選單緩存");
        List<AdminMenuDto> allByFirstMenu = AdminMenuService.FindAllByFirstMenu(lang);
        foreach (AdminRoleDto adminRoleDto in all)
        {
          int pk = adminRoleDto.pk;
          Dictionary<int, int[]> dic = PublicTool.FromJson<Dictionary<int, int[]>>(adminRoleDto.admin_menu);
          if (dic != null)
          {
            List<MainMenuVm> menuFromDb = AdminMenuBiz.GetMenuFromDb(dic, allByFirstMenu, lang);
            CacheQuery.HashSet<List<MainMenuVm>>("AdminMenu" + lang, pk.ToString(), menuFromDb);
          }
        }
      }
    }

    public static List<MainMenuVm> GetMenuFromDb(
      Dictionary<int, int[]> dic,
      List<AdminMenuDto> fullMenu,
      string lang = "CN")
    {
      List<MainMenuVm> menuFromDb = new List<MainMenuVm>();
      List<AdminModuleDto> source = !(lang.ToLower() == "en") ? AdminModuleService.FindAll() : AdminModuleService.FindAll("EN");
      foreach (int key in dic.Keys)
      {
        int item = key;
        AdminModuleDto adminModuleDto = source.Where<AdminModuleDto>((Func<AdminModuleDto, bool>) (x => x.pk == item)).FirstOrDefault<AdminModuleDto>();
        if (adminModuleDto != null)
        {
          MainMenuVm mainMenuVm = new MainMenuVm()
          {
            Id = item,
            Parent = 0,
            Url = "",
            Active = "",
            IconClass = adminModuleDto.icon,
            Title = adminModuleDto.title,
            Child = AdminMenuBiz.GetMenuByModel(item, dic[item], fullMenu)
          };
          menuFromDb.Add(mainMenuVm);
        }
      }
      string str1;
      switch (lang.ToLower())
      {
        case "vn":
          str1 = "Đăng xuất";
          break;
        case "cn":
          str1 = "登出";
          break;
        default:
          str1 = "Logout";
          break;
      }
      string str2 = str1;
      menuFromDb.Add(new MainMenuVm()
      {
        Id = 9999,
        Parent = 0,
        Url = "/Login/index",
        Active = "",
        IconClass = "fa fa-fw fa-sign-out",
        Title = str2
      });
      return menuFromDb;
    }

    public static List<MainMenuVm> GetMenuByModel(
      int modelid,
      int[] numbers,
      List<AdminMenuDto> fullMenu)
    {
      List<MainMenuVm> menuByModel = new List<MainMenuVm>();
      if (numbers == null || numbers.Length == 0)
        return menuByModel;
      List<AdminMenuDto> list = fullMenu.Where<AdminMenuDto>((Func<AdminMenuDto, bool>) (d => d.admin_module_fk == modelid)).OrderBy<AdminMenuDto, int>((Func<AdminMenuDto, int>) (d => d.sort)).ToList<AdminMenuDto>();
      if (list != null)
      {
        foreach (AdminMenuDto adminMenuDto in list)
        {
          if (Array.IndexOf<int>(numbers, adminMenuDto.pk) > -1)
          {
            MainMenuVm mainMenuVm = new MainMenuVm()
            {
              Id = adminMenuDto.pk,
              Parent = adminMenuDto.parent,
              Url = adminMenuDto.url_value,
              Active = "",
              IconClass = "fa fa-circle nav-icon",
              Title = adminMenuDto.title
            };
            menuByModel.Add(mainMenuVm);
          }
        }
      }
      return menuByModel;
    }

    public static AdminMenuDto GetMenuByPK(int id) => AdminMenuService.Find(id);
  }
}
