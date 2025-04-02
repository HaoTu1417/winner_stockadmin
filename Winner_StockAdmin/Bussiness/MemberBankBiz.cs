// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.MemberBankBiz
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
using stockadmin.ViewModels.MemberBank;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class MemberBankBiz
  {
    public static List<MemberBankList> GetMemberBankList(int member)
    {
      string whereSql = "";
      if (member != 0)
      {
        string sourceStr = SqlTool.Build<object>((object) null);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
        interpolatedStringHandler.AppendLiteral("member_bank.member_fk = ");
        interpolatedStringHandler.AppendFormatted<int>(member);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        whereSql = sourceStr.Must(stringAndClear);
      }
      return MemberBankService.FindMemberBankList(whereSql);
    }

    public static MemberBankDto Get(string card_pk) => MemberBankService.Find(card_pk);

    public static void PostCreate(MemberBankDto req)
    {
      if (MemberBankService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(MemberBankDto req)
    {
      if (MemberBankService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void PostEditIsConfirm(
      MemberBankDto req,
      bool is_confirm,
      AdminSession adminUser)
    {
      if (MemberBankService.UpdateIsConfirm(req.card_pk, is_confirm) == 0)
        throw new AppException("更新提款卡是否核实失败");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.card
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 272,
        list = objArray,
        member_account = req.account
      });
    }

    public static void PostEditIsDelete(MemberBankDto req, bool is_confirm, AdminSession adminUser)
    {
      if (MemberBankService.UpdateIsDelete(req.card_pk, is_confirm) == 0)
        throw new AppException("更新提款卡是否删除失败");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.card
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 272,
        list = objArray,
        member_account = req.account
      });
    }

    public static void Delete(string card_pk) => MemberBankService.Remove(card_pk);

    public static MemberBankReview GetReview(string card_pk)
    {
      return MemberBankService.FindMemberBankReview(card_pk);
    }
  }
}
