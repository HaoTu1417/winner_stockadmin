// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletWithdrawBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Cache;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Home;
using stockadmin.ViewModels.WalletWithdraw;
using System;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class WalletWithdrawBiz
  {
    public static DataCountBase<WalletWithdrawList> GetWalletWithdrawList(
      WalletWithdrawFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<WalletWithdrawFilter>(filter).Must("wallet_withdraw.status = 0");
      DataCountBase<WalletWithdrawList> walletWithdrawList = WalletWithdrawService.FindWalletWithdrawList(page, pageSize, whereSql);
      return new DataCountBase<WalletWithdrawList>(walletWithdrawList.count, walletWithdrawList.data.Select<WalletWithdrawList, WalletWithdrawList>((Func<WalletWithdrawList, WalletWithdrawList>) (walletWithdraw => PublicTool.convertUtcToLocalTime<WalletWithdrawList>(walletWithdraw))));
    }

    public static WalletWithdrawDto Get(int pk) => WalletWithdrawService.Find(pk);

    public static void PostCreate(WalletWithdrawDto req)
    {
      if (WalletWithdrawService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(WalletWithdrawDto req)
    {
      if (WalletWithdrawService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => WalletWithdrawService.Remove(pk);

    public static WalletWithdrawReview GetReview(int pk)
    {
      return WalletWithdrawService.FindWalletWithdrawReview(pk);
    }

    public static void VerifyWalletWithdraw(
      WalletWithdrawDto req,
      bool result,
      AdminSession adminUser,
      string reject_result)
    {
      int pk = adminUser.pk;
      WalletWithdrawReview walletWithdrawReview = WalletWithdrawService.FindWalletWithdrawReview(req.pk);
      if (walletWithdrawReview.status != 0)
        throw new AppException(3010, "verify_status_incorrect");
      object[] objArray1;
      if (result)
      {
        if (!WalletLib.WithdrawPass(walletWithdrawReview.member_fk, walletWithdrawReview.money, walletWithdrawReview.order_no, walletWithdrawReview.wallet_amount, walletWithdrawReview.currency))
          throw new AppException(3061, "wallet_balance_error");
        WalletDto walletDto = WalletService.Find(walletWithdrawReview.member_fk);
        WalletWithdrawService.VerifyWithdraw(req.pk, walletDto.balance, pk, 1, (string) null);
        objArray1 = new object[5]
        {
          (object) walletWithdrawReview.order_no,
          (object) PublicTool.AddNumberSeparation(new Decimal?(walletWithdrawReview.money), walletWithdrawReview.currency),
          (object) walletWithdrawReview.currency,
          (object) PublicTool.AddNumberSeparation(new Decimal?(walletWithdrawReview.wallet_amount), walletDto.currency),
          (object) walletDto.currency
        };
      }
      else
      {
        WalletLib.WithdrawFail(walletWithdrawReview.member_fk, walletWithdrawReview.money, walletWithdrawReview.order_no);
        WalletDto walletDto = WalletService.Find(walletWithdrawReview.member_fk);
        WalletWithdrawService.VerifyWithdraw(req.pk, walletDto.balance, pk, 2, reject_result);
        objArray1 = new object[2]
        {
          (object) walletWithdrawReview.order_no,
          (object) reject_result
        };
      }
      string account = MemberService.Find(walletWithdrawReview.member_fk).account;
      object[] objArray2 = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 295,
        list = objArray2,
        member_account = account
      });
      int temp_id = result ? 12 : 13;
      SendMessageLib.Send(walletWithdrawReview.member_fk, temp_id, objArray1);
      WalletWithdrawBiz.UpdateWithdrawApplyCount();
      WalletWithdrawBiz.UpdateWithdrawNeedVerify();
    }

    public static void UpdateWithdrawApplyCount()
    {
      int withdrawApplyCount = WalletWithdrawService.GetWithdrawApplyCount();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.WithdrawApplyCount = withdrawApplyCount.ToString();
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }

    public static void UpdateWithdrawNeedVerify()
    {
      Decimal withdrawNeedVerify = WalletWithdrawService.GetWithdrawNeedVerify();
      CacheQuery.SelectDB(CacheEnum.admin);
      HomeVm redisValue = CacheQuery.StringGet<HomeVm>("HomeVm");
      if (redisValue == null)
        return;
      redisValue.WithdrawNeedVerify = withdrawNeedVerify;
      CacheQuery.StringSet<HomeVm>("HomeVm", redisValue);
    }
  }
}
