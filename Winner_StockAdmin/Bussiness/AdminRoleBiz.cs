// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminRoleBiz
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
using stockadmin.Models.Tree;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

#nullable enable
namespace stockadmin.Business
{
  public class AdminRoleBiz
  {
    public static List<SelectListItem> FindSelectList(bool is_super)
    {
      List<AdminRoleDto> all = AdminRoleService.FindAll();
      List<SelectListItem> selectList = new List<SelectListItem>();
      foreach (AdminRoleDto adminRoleDto in all)
      {
        if (is_super || !adminRoleDto.is_super)
        {
          List<SelectListItem> selectListItemList = selectList;
          SelectListItem selectListItem = new SelectListItem();
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
          interpolatedStringHandler.AppendFormatted<int>(adminRoleDto.pk);
          selectListItem.Value = interpolatedStringHandler.ToStringAndClear();
          selectListItem.Text = adminRoleDto.name;
          selectListItemList.Add(selectListItem);
        }
      }
      return selectList;
    }

    public static List<AdminRoleList> GetAdminRoleList(bool is_super)
    {
      List<AdminRoleList> adminRoleList = AdminRoleService.FindAdminRoleList();
      List<AdminRoleList> list = adminRoleList != null ? adminRoleList.Select<AdminRoleList, AdminRoleList>((Func<AdminRoleList, AdminRoleList>) (adminRole => PublicTool.convertUtcToLocalTime<AdminRoleList>(adminRole))).ToList<AdminRoleList>() : (List<AdminRoleList>) null;
      if (!is_super)
        list = list.Where<AdminRoleList>((Func<AdminRoleList, bool>) (adminRole => !adminRole.is_super)).ToList<AdminRoleList>();
      return list;
    }

    public static AdminRoleDto Get(int pk) => AdminRoleService.Find(pk);

    public static AdminRoleList GetAdminRole(int pk) => AdminRoleService.FindAdminRole(pk);

    public static void PostCreate(AdminRoleDto req, AdminSession adminUser)
    {
      using (JsonDocument jsonDocument = JsonDocument.Parse(req.admin_menu, new JsonDocumentOptions()))
      {
        JsonElement rootElement = jsonDocument.RootElement;
        if (!rootElement.EnumerateObject().Any(x => x.Name == req.admin_module_fk.ToString()))
          throw new AppException(3022, "請開啟(勾選)預設登入頁面權限或修改預設登入頁面");
      }
      if (AdminRoleService.FindPkAfterInsert(req) == 0)
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
        admin_menu_fk = 409,
        list = objArray
      });
    }

    public static void PostEdit(AdminRoleDto req, AdminSession adminUser)
    {
      using (JsonDocument jsonDocument = JsonDocument.Parse(req.admin_menu, new JsonDocumentOptions()))
      {
        JsonElement rootElement = jsonDocument.RootElement;
        if (!rootElement.EnumerateObject().Any(x => x.Name == req.admin_module_fk.ToString()))
          throw new AppException(3022, "請開啟(勾選)預設登入頁面權限或修改預設登入頁面");
      }
      if (AdminRoleService.UpdateFull(req) == 0)
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
        admin_menu_fk = 408,
        list = objArray
      });
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      string name = AdminRoleService.Find(pk).name;
      if (AdminUserService.CountByRole(pk) != 0)
        throw new AppException(3200, "illegal_delete_role");
      AdminRoleService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 410,
        list = objArray
      });
    }

    public static bool VerifyPower(string router)
    {
      try
      {
        return false;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static bool VerifyPower(int menuId, int modelId, int roleId)
    {
      try
      {
        Dictionary<int, int[]> dictionary = PublicTool.FromJson<Dictionary<int, int[]>>(AdminRoleService.Find(roleId).admin_menu);
        return dictionary != null && Array.IndexOf<int>(dictionary[modelId], menuId) >= 0;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private static PowerNode CreatePowerNode(int id, bool isSelect, string name, string icon)
    {
      return new PowerNode()
      {
        id = id,
        text = name,
        icon = "fa fa-lg " + icon,
        state = new NodeState(isSelect),
        children = new List<PowerNode>()
      };
    }

    private static void BuildFirstNode(PowerNode parent, List<AdminMenuDto> fullMenu, int[] power)
    {
      List<AdminMenuDto> list = fullMenu.Where<AdminMenuDto>((Func<AdminMenuDto, bool>) (d => d.admin_module_fk == parent.id - 10000 && d.parent == d.pk)).OrderBy<AdminMenuDto, int>((Func<AdminMenuDto, int>) (d => d.sort)).ToList<AdminMenuDto>();
      if (list == null || list.Count <= 0)
        return;
      foreach (AdminMenuDto adminMenuDto in list)
      {
        bool power1 = AdminRoleBiz.GetPower(adminMenuDto.pk, power);
        PowerNode powerNode = AdminRoleBiz.CreatePowerNode(adminMenuDto.pk, power1, adminMenuDto.title, "fa-angle-right");
        AdminRoleBiz.BuildSecondNode(powerNode, fullMenu, power);
        parent.children.Add(powerNode);
      }
    }

    private static void BuildSecondNode(PowerNode parent, List<AdminMenuDto> fullMenu, int[] power)
    {
      List<AdminMenuDto> list = fullMenu.Where<AdminMenuDto>((Func<AdminMenuDto, bool>) (d => d.parent == parent.id && d.pk != d.parent)).OrderBy<AdminMenuDto, int>((Func<AdminMenuDto, int>) (d => d.sort)).ToList<AdminMenuDto>();
      if (list == null || list.Count <= 0)
        return;
      foreach (AdminMenuDto adminMenuDto in list)
      {
        bool power1 = AdminRoleBiz.GetPower(adminMenuDto.pk, power);
        PowerNode powerNode = AdminRoleBiz.CreatePowerNode(adminMenuDto.pk, power1, adminMenuDto.title, "fa-cog");
        parent.children.Add(powerNode);
      }
    }

    private static int[] ToPowerArray(string json)
    {
      int[] array = Array.Empty<int>();
      if (json == null || string.IsNullOrEmpty(json))
        return array;
      foreach (KeyValuePair<int, int[]> keyValuePair in PublicTool.FromJson<Dictionary<int, int[]>>(json))
      {
        int[] sourceArray = keyValuePair.Value;
        if (sourceArray != null && sourceArray.Length != 0)
        {
          int length = array.Length;
          Array.Resize<int>(ref array, array.Length + sourceArray.Length);
          Array.Copy((Array) sourceArray, 0, (Array) array, length, sourceArray.Length);
        }
      }
      return array;
    }

    private static bool GetPower(int id, int[] power)
    {
      if (power != null)
      {
        if (power.Length != 0)
        {
          try
          {
            if (Array.IndexOf<int>(power, id) > -1)
              return true;
          }
          catch (Exception ex)
          {
            return false;
          }
          return false;
        }
      }
      return false;
    }

    public static List<PowerNode> AdminMenuToTree(string admin_menu)
    {
      PowerNode powerNode1 = AdminRoleBiz.CreatePowerNode(0, false, "", "fa-home");
      List<PowerNode> tree = new List<PowerNode>()
      {
        powerNode1
      };
      try
      {
        int[] powerArray = AdminRoleBiz.ToPowerArray(admin_menu);
        PublicTool.FromJson<Dictionary<int, int[]>>(admin_menu);
        List<AdminModuleDto> all1 = AdminModuleService.FindAll();
        List<AdminMenuDto> all2 = AdminMenuService.FindAll();
        foreach (AdminModuleDto adminModuleDto in all1)
        {
          PowerNode powerNode2 = AdminRoleBiz.CreatePowerNode(adminModuleDto.pk + 10000, false, adminModuleDto.title, "fa-folder");
          AdminRoleBiz.BuildFirstNode(powerNode2, all2, powerArray);
          powerNode1.children.Add(powerNode2);
        }
      }
      catch (Exception ex)
      {
        throw new AppException("生成jtree異常");
      }
      return tree;
    }

    public static string TreeToAdminMenu(string tree)
    {
      try
      {
        if (string.IsNullOrEmpty(tree))
          return "{}";
        int[] second = PublicTool.FromJson<int[]>(tree);
        Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
        List<AdminModuleDto> all1 = AdminModuleService.FindAll();
        List<AdminMenuDto> all2 = AdminMenuService.FindAll();
        foreach (AdminModuleDto adminModuleDto in all1)
        {
          int id = adminModuleDto.pk;
          AdminMenuDto[] array1 = all2.Where<AdminMenuDto>((Func<AdminMenuDto, bool>) (p => p.admin_module_fk == id)).ToArray<AdminMenuDto>();
          if (array1.Length != 0)
          {
            int[] array2 = ((IEnumerable<AdminMenuDto>) array1).Select<AdminMenuDto, int>((Func<AdminMenuDto, int>) (p => p.pk)).Intersect<int>((IEnumerable<int>) second).ToArray<int>();
            if (array2.Length != 0)
              dictionary.Add(id, array2);
          }
        }
        return PublicTool.ToJson((object) dictionary);
      }
      catch (Exception ex)
      {
        throw new AppException("[AdminRoleBiz][TreeToAdminMenu]無法解析字串內容");
      }
    }
  }
}
