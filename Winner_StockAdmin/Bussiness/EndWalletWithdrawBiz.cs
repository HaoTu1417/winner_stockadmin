// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.EndWalletWithdrawBiz
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
using stockadmin.ViewModels.EndWalletWithdraw;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class EndWalletWithdrawBiz
  {
    public static DataCountBase<EndWalletWithdrawList> GetEndWalletWithdrawList(
      EndWalletWithdrawFilter? filter,
      int page,
      int pageSize,
      string lang)
    {
      string str = SqlTool.Build<EndWalletWithdrawFilter>(filter).Must("wallet_withdraw.status != 0 and member.is_del = 0");
      if (filter.filter_out_test_account)
        str = str.Must("member.is_test_account = 0");
      DataCountBase<EndWalletWithdrawList> walletWithdrawList = WalletWithdrawService.FindEndWalletWithdrawList(page, pageSize, str, lang);
      return new DataCountBase<EndWalletWithdrawList>(walletWithdrawList.count, walletWithdrawList.data.Select<EndWalletWithdrawList, EndWalletWithdrawList>((Func<EndWalletWithdrawList, EndWalletWithdrawList>) (endWalletWithdraw => PublicTool.convertUtcToLocalTime<EndWalletWithdrawList>(endWalletWithdraw))));
    }

    public static WalletWithdrawDto Get(int pk) => WalletWithdrawService.Find(pk);

    public static void PostCreate(WalletWithdrawDto req, AdminSession adminUser)
    {
      if (WalletWithdrawService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
      MemberDto memberDto = MemberBiz.Get(req.member_fk, adminUser);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) memberDto.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 295,
        list = objArray,
        member_account = memberDto.account
      });
    }

    public static void PostEdit(WalletWithdrawDto req, AdminSession adminUser)
    {
      if (WalletWithdrawService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
      MemberDto memberDto = MemberBiz.Get(req.member_fk, adminUser);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) memberDto.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 295,
        list = objArray,
        member_account = memberDto.account
      });
    }

    public static void Delete(int pk) => WalletWithdrawService.Remove(pk);

    public static EndWalletWithdrawEditVm GetEditVm(int pk, string lang)
    {
      return WalletWithdrawService.FindEndWalletWithdrawEditVm(pk, lang);
    }

    public static List<SelectListItem> GetStatusList()
    {
      return new List<SelectListItem>()
      {
        new SelectListItem() { Text = "成功", Value = "1" },
        new SelectListItem() { Text = "失敗", Value = "2" }
      };
    }

    public static List<SelectListItem> GetRechargeTypeList(string lang)
    {
      if (lang == "VN")
        return new List<SelectListItem>()
        {
          new SelectListItem()
          {
            Text = "Thẻ ngân hàng",
            Value = "bank"
          },
          new SelectListItem() { Text = "Tiền ảo", Value = "crypto" },
          new SelectListItem()
          {
            Text = "Thanh toán của bên thứ ba",
            Value = "third_party"
          }
        };
      return new List<SelectListItem>()
      {
        new SelectListItem() { Text = "銀行卡", Value = "bank" },
        new SelectListItem() { Text = "虛擬貨幣", Value = "crypto" },
        new SelectListItem()
        {
          Text = "第三方支付",
          Value = "third_party"
        }
      };
    }

    public static byte[]? DownloadEndWalletWithdrawList(EndWalletWithdrawFilter? filter, string lang)
    {
      return Exportlib.ExportExcel<EndWalletWithdrawList>(EndWalletWithdrawBiz.GetEndWalletWithdrawList(filter, 1, int.MaxValue, lang).data);
    }
  }
}
