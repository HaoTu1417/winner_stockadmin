// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.AdminConfigBiz
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
using stockadmin.ViewModels.AdminConfig;
using stockadmin.ViewModels.RecommendConfig;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class AdminConfigBiz
  {
    public static List<AdminConfigList> GetCommonAdminConfigList(
      AdminConfigFilter? filter,
      AdminSession adminUser)
    {
      List<AdminConfigList> adminConfigList = AdminConfigService.FindAdminConfigList(!adminUser.is_super ? SqlTool.Build<AdminConfigFilter>(filter).Must("admin_config.group in ('base')") : SqlTool.Build<AdminConfigFilter>(filter).Must("admin_config.group in ('system', 'base')"));
      return adminConfigList == null ? (List<AdminConfigList>) null : adminConfigList.Select<AdminConfigList, AdminConfigList>((Func<AdminConfigList, AdminConfigList>) (adminConfig => PublicTool.convertUtcToLocalTime<AdminConfigList>(adminConfig))).ToList<AdminConfigList>();
    }

    public static RecommendConfigEditVm GetRecommendAdminConfig()
    {
      Dictionary<string, string> dictionary = AdminConfigService.FindRecommendConfig().ToDictionary<AdminConfigList, string, string>((Func<AdminConfigList, string>) (item => item.name), (Func<AdminConfigList, string>) (item => item.value));
      return new RecommendConfigEditVm()
      {
        layer_rate_1 = Decimal.Parse(dictionary["layer_rate_1"]),
        layer_rate_2 = Decimal.Parse(dictionary["layer_rate_2"]),
        layer_rate_3 = Decimal.Parse(dictionary["layer_rate_3"])
      };
    }

    public static AdminConfigDto Get(string name)
    {
      AdminConfigDto adminConfigDto = AdminConfigService.Find(name);
      if (adminConfigDto.type == "switch")
        adminConfigDto.value = PublicTool.ToBool(adminConfigDto.value).ToString();
      return adminConfigDto;
    }

    public static void PostCreate(AdminConfigDto req, AdminSession adminUser)
    {
      if (AdminConfigService.Insert(req) == 0)
      {
        ConfigLib.Reset();
        throw new AppException(3020, "insert_record_false");
      }
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 430,
        list = objArray
      });
    }

    public static void PostEdit(AdminConfigDto req, AdminSession adminUser)
    {
      if (req.type == "switch")
      {
        string str = AdminConfigService.Find(req.name).value;
        if (str == "0" || str == "1")
          req.value = PublicTool.BoolStringToNumberString(req.value);
      }
      if (AdminConfigService.UpdateConfig(req) == 0)
      {
        ConfigLib.Reset();
        throw new AppException(3010, "record_update_false");
      }
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.title
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 431,
        list = objArray
      });
    }

    public static void PostRecommendConfigEdit(RecommendConfigEditVm req, AdminSession adminUser)
    {
      if (AdminConfigService.UpdateRecommendConfig(req) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) "recommend config"
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 184,
        list = objArray
      });
    }

    public static void Delete(string name, AdminSession adminUser)
    {
      AdminConfigService.Remove(name);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) name
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 432,
        list = objArray
      });
    }
  }
}
