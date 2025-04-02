// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.AdminLogLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Models.Admin;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Libs
{
    public class AdminLogLib
    {
        public static void Save(AdminLogRequest req)
        {
            AdminUserDto adminUserDto = AdminUserService.Find(req.admin_user_pk);
            AdminActionDto byAdminMenu = AdminActionService.FindByAdminMenu(req.admin_menu_fk, adminUserDto.lang);
            if (byAdminMenu == null)
                return;
            string str1 = byAdminMenu?.log;
            string str2 = string.Empty;
            if (req.list != null)
            {
                for (int index = 0; index < req.list.Length; ++index)
                {
                    string str3 = str1;
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
                    interpolatedStringHandler.AppendLiteral("#");
                    interpolatedStringHandler.AppendFormatted<int>(index);
                    interpolatedStringHandler.AppendLiteral("#");
                    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                    string newValue = req.list[index].ToString();
                    str1 = str3.Replace(stringAndClear, newValue);
                    str2 = str2 + req.list[index].ToString() + "|";
                }
            }
            AdminLogService.FindPkAfterInsert(new AdminLogDto()
            {
                admin_action = byAdminMenu.pk,
                admin_user = adminUserDto.pk,
                param = str2,
                remark = str1,
                create_time = DateTime.UtcNow,
                member_account = req.member_account
            });
        }
    }
}