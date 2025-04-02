// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletRechargeBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Home;
using stockadmin.ViewModels.WalletRecharge;
using stockadmin.ViewModels.WalletRecord;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class WalletRechargeBiz
  {
    public static DataCountBase<WalletRechargeList> GetWalletRechargeList(
      WalletRechargeFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<WalletRechargeFilter>(filter).Must("wallet_recharge.status = 0");
      DataCountBase<WalletRechargeList> walletRechargeList = WalletRechargeService.FindWalletRechargeList(page, pageSize, whereSql);
      return new DataCountBase<WalletRechargeList>(walletRechargeList.count, walletRechargeList.data.Select<WalletRechargeList, WalletRechargeList>((Func<WalletRechargeList, WalletRechargeList>) (walletRecharge => PublicTool.convertUtcToLocalTime<WalletRechargeList>(walletRecharge))));
    }

    public static List<SelectListItem> GetRechargeTypeList(string lang)
    {
      if (lang == "EN")
        return new List<SelectListItem>()
        {
          new SelectListItem() { Text = "Bank card", Value = "bank" },
          new SelectListItem() { Text = "Crypto", Value = "crypto" },
          new SelectListItem()
          {
            Text = "Third party payment",
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

    public static List<SelectListItem> GetStatusList()
    {
      return new List<SelectListItem>()
      {
        new SelectListItem() { Text = "Success", Value = "1" },
        new SelectListItem() { Text = "Failed", Value = "2" }
      };
    }

    public static WalletRechargeDto Get(int pk) => WalletRechargeService.Find(pk);

    public static void PostCreate(WalletRechargeDto req)
    {
      if (WalletRechargeService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletRechargeDto req)
    {
      if (WalletRechargeService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => WalletRechargeService.Remove(pk);

    public static WalletRechargeReview GetReview(int pk)
    {
      return WalletRechargeService.FindWalletRechargeReview(pk);
    }

    public static void RechargeVerify(
      int pk,
      bool verifyStatus,
      AdminSession adminUser,
      string rejectResult)
    {
      WalletRechargeDto walletRechargeDto = WalletRechargeService.Find(pk);
      if (walletRechargeDto.status != 0)
        throw new AppException(3010, "verify_status_incorrect");
      if (verifyStatus)
      {
        if (!WalletLib.RechargePass(walletRechargeDto.member_fk, walletRechargeDto.wallet_amount, walletRechargeDto.order_no, walletRechargeDto.money, walletRechargeDto.currency, walletRechargeDto.exchange))
          throw new AppException(3060, "wallet_is_frozen");
        WalletDto walletDto = WalletService.Find(walletRechargeDto.member_fk);
        WalletRechargeService.AccecptRecharge(pk, walletDto.balance, adminUser.pk);
        MemberTaskLib.MemberTaskFinish(walletRechargeDto.member_fk, 3);
        object[] objArray = new object[4]
        {
          (object) walletRechargeDto.order_no,
          (object) PublicTool.AddNumberSeparation(new Decimal?(walletRechargeDto.wallet_amount), ConfigLib.Get("wallet_currency")),
          (object) ConfigLib.Get("wallet_currency"),
          (object) walletRechargeDto.exchange
        };
        SendMessageLib.Send(walletRechargeDto.member_fk, 1, objArray);
        WalletRechargeBiz.UpdateRechargeApplyCount();
        WalletRechargeBiz.UpdateRechargeNeedVerify();
      }
      else
      {
        if (string.IsNullOrEmpty(rejectResult))
          throw new AppException("請填寫拒絕原因");
        WalletDto walletDto = WalletService.Find(walletRechargeDto.member_fk);
        WalletRechargeService.RejectRecharge(pk, walletDto.balance, adminUser.pk, rejectResult);
        object[] objArray = new object[5]
        {
          (object) walletRechargeDto.order_no,
          (object) PublicTool.AddNumberSeparation(new Decimal?(walletRechargeDto.wallet_amount), ConfigLib.Get("wallet_currency")),
          (object) ConfigLib.Get("wallet_currency"),
          (object) walletRechargeDto.exchange,
          (object) rejectResult
        };
        SendMessageLib.Send(walletRechargeDto.member_fk, 2, objArray);
        WalletRechargeBiz.UpdateRechargeApplyCount();
        WalletRechargeBiz.UpdateRechargeNeedVerify();
      }
      string account = MemberService.Find(walletRechargeDto.member_fk).account;
      object[] objArray1 = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 274,
        list = objArray1,
        member_account = account
      });
    }

    public static void ChangeException(WalletChangeExceptionVm req, AdminSession adminUser)
    {
      if (!WalletLib.AdminOperate(req.member_fk, req.change_balance, req.change_coupon, req.reason, adminUser))
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.member_fk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 265,
        list = objArray,
        member_account = MemberService.Find(req.member_fk).account
      });
    }

    public static void UpdateRechargeApplyCount()
    {
      int rechargeApplyCount = WalletRechargeService.GetRechargeApplyCount();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.RechargeApplyCount = rechargeApplyCount.ToString();
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }

    public static void UpdateRechargeNeedVerify()
    {
      Decimal rechargeNeedVerify = WalletRechargeService.GetRechargeNeedVerify();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.RechargeNeedVerify = rechargeNeedVerify;
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }
  }
}
