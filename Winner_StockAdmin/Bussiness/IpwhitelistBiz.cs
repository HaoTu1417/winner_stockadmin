// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.IpwhitelistBiz
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
using stockadmin.ViewModels.Ipwhitelist;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class IpwhitelistBiz
  {
    public static List<IpwhitelistList> GetIpwhitelistList(IpwhitelistFilter? filter)
    {
      return AdminIpwhitelistService.FindIpwhitelistList(SqlTool.Build<IpwhitelistFilter>(filter)).Select<IpwhitelistList, IpwhitelistList>((Func<IpwhitelistList, IpwhitelistList>) (l => PublicTool.convertUtcToLocalTime<IpwhitelistList>(l))).ToList<IpwhitelistList>();
    }

    public static AdminIpwhitelistDto Get(string ip) => AdminIpwhitelistService.Find(ip);

    public static void PostCreate(AdminIpwhitelistDto req, AdminSession adminUser)
    {
      req.account = adminUser.account;
      if (AdminIpwhitelistService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.ip
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 49,
        list = objArray
      });
    }

    public static void PostEdit(AdminIpwhitelistDto req, AdminSession adminUser)
    {
      req.account = adminUser.account;
      if (AdminIpwhitelistService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      if (AdminIpwhitelistService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.ip
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 48,
        list = objArray
      });
    }

    public static void Delete(string ip, AdminSession adminUser)
    {
      AdminIpwhitelistService.Remove(ip);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) ip
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 50,
        list = objArray
      });
    }
  }
}
