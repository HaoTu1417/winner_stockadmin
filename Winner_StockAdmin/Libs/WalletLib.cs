// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.WalletLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models;
using stockadmin.Models.Admin;
using stockadmin.Models.Wallet;
using System;

#nullable enable
namespace stockadmin.Libs
{
  public class WalletLib
  {
    public static (WalletDto, bool) TestWallet(int member)
    {
      WalletDto walletDto = WalletService.Find(member);
      if (walletDto == null)
        throw new AppException(3061, "wallet_balance_error");
      if (walletDto.balance < 0M)
      {
        Console.WriteLine("c9");
        throw new AppException(3061, "wallet_balance_error");
      }
      if (!walletDto.status)
        return (walletDto, false);
      if (!WalletService.DebugBalance(member))
        throw new AppException(3061, "wallet_balance_error");
      return (walletDto, true);
    }

    public static bool RechargePass(
      int member,
      Decimal change,
      string id,
      Decimal org_money,
      string org_currency,
      Decimal exchange)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto walletDto1 = tuple.Item1;
      if (!tuple.Item2)
        return false;
      DateTime utcNow = DateTime.UtcNow;
      WalletService.Recharge(member, change, utcNow);
      WalletDto walletDto2 = WalletService.Find(member);
      object[] objArray = new object[5]
      {
        (object) id,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 1,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 1,
        affect = change,
        balance = walletDto2.balance,
        coupon = 0M,
        createtime = utcNow,
        list = objArray
      });
      return true;
    }

    public static bool WithdrawTradePass(
      int member,
      string sn,
      Decimal change,
      string id,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.BalanceMoneyChange(member, change);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[6]
      {
        (object) id,
        (object) sn,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 1,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 49,
        affect = change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool WithdrawPass(
      int member,
      Decimal change,
      string id,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto walletDto1 = tuple.Item1;
      if (!tuple.Item2)
        return false;
      DateTime utcNow = DateTime.UtcNow;
      WalletService.WithdrawChange(member, change, utcNow);
      WalletFreezeService.DeleteBySN(member, id);
      WalletDto walletDto2 = WalletService.Find(member);
      object[] objArray = new object[5]
      {
        (object) id,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 12,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 12,
        affect = -change,
        balance = walletDto2.balance,
        coupon = 0M,
        createtime = utcNow,
        list = objArray
      });
      return true;
    }

    public static bool WithdrawFail(int member, Decimal change, string id)
    {
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, id);
      return true;
    }

    public static bool WithdrawCanel(int member, Decimal change, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, id);
      return true;
    }

    public static bool WithdrawBack(int member, Decimal change, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, id);
      return true;
    }

    public static bool RewardNoviceQuests(int member, Decimal change)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.GmoneyMoneyChange(member, change);
      return true;
    }

    public static bool PromotRewardRealMoney(
      int cms_promotion_fk,
      string promotion_name,
      int member_fk,
      Decimal wallet_amount,
      string currency)
    {
      if (!WalletLib.CheckFreeMoney(WalletService.Find(member_fk), 0M))
        return false;
      WalletService.BalanceMoneyChange(member_fk, wallet_amount);
      WalletDto walletDto = WalletService.Find(member_fk);
      object[] objArray = new object[3]
      {
        (object) promotion_name,
        (object) wallet_amount,
        (object) currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member_fk,
        type = 22,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 22,
        affect = wallet_amount,
        balance = walletDto.balance,
        coupon = walletDto.coupon,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool PromotRewardCoupon(int member_fk, Decimal wallet_amount)
    {
      if (!WalletLib.CheckFreeMoney(WalletService.Find(member_fk), 0M))
        return false;
      WalletService.couponMoneyChange(member_fk, wallet_amount);
      return true;
    }

    public static bool NewBorrowPass(
      int member,
      Decimal change,
      string id,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "b_" + id);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[6]
      {
        (object) id,
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 32,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 32,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool NewBorrowFail(int member, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      string sn = "b_" + id;
      WalletFreezeDto walletFreezeBySn = WalletFreezeService.FindWalletFreezeBySn(sn);
      WalletService.FreezeMoneyChange(member, -walletFreezeBySn.freeze, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, sn);
      return true;
    }

    public static bool BorrowManagementFee(
      int member,
      Decimal change,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[5]
      {
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 34,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 34,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool RenewalManagementFee(int member, Decimal change, string account)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[3]
      {
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency")
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 35,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 35,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool DeferredFee(
      int member,
      Decimal change,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[5]
      {
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 36,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 36,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool MaginCallPass(
      int member,
      Decimal change,
      string id,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "bam_" + id);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[6]
      {
        (object) id,
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 38,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 38,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool MaginCallFail(int member, Decimal change, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "bam_" + id);
      return true;
    }

    public static bool BorrowSettle(
      int member,
      Decimal change,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.BalanceMoneyChange(member, change);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[5]
      {
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 40,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 40,
        affect = change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool BorrowRenewalPass(int member, Decimal change, string id, string account)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "br_" + id);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[3]
      {
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency")
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 35,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 35,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool BorrowRenewalFail(int member, Decimal change, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "br_" + id);
      return true;
    }

    public static bool ExpandBorrowPass(
      int member,
      Decimal change,
      string id,
      string account,
      Decimal org_money,
      string org_currency)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, change))
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "baf_" + id);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[6]
      {
        (object) id,
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency"),
        (object) org_money,
        (object) org_currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 45,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 45,
        affect = -change,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool ExpandBorrowManagementFee(
      int member,
      Decimal change,
      string id,
      string account)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto walletDto1 = tuple.Item1;
      if (!tuple.Item2)
        return false;
      WalletService.BalanceMoneyChange(member, -change);
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletDto walletDto2 = WalletService.Find(member);
      object[] objArray = new object[4]
      {
        (object) id,
        (object) account,
        (object) change,
        (object) ConfigLib.Get("wallet_currency")
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 105,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 105,
        affect = -change,
        balance = walletDto2.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool ExpandBorrowFail(int member, Decimal change, string id)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2 || !WalletLib.CheckFreeMoney(wallet, 0M))
        return false;
      WalletService.FreezeMoneyChange(member, -change, DateTime.UtcNow);
      WalletFreezeService.DeleteBySN(member, "baf_" + id);
      return true;
    }

    public static bool AdminOperate(
      int member,
      Decimal balance,
      Decimal coupon,
      string reason,
      AdminSession adminUser)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2)
        return false;
      if (balance > 0M)
      {
        if (!WalletLib.CheckFreeMoney(wallet, 0M))
          return false;
      }
      else if (!WalletLib.CheckFreeMoney(wallet, -balance))
        return false;
      WalletService.BalanceMoneyChange(member, balance);
      WalletService.couponMoneyChange(member, coupon);
      WalletDto walletDto = WalletService.Find(member);
      int num1 = 0;
      Decimal num2 = 0M;
      if (balance != 0M)
      {
        object[] objArray = new object[2]
        {
          (object) balance,
          (object) reason
        };
        WalletRecordLib.Save(new WalletRecordRequest()
        {
          member_pk = member,
          type = 98,
          currency = ConfigLib.Get("wallet_currency"),
          temp_id = 98,
          affect = balance,
          balance = walletDto.balance,
          coupon = coupon,
          createtime = DateTime.UtcNow,
          list = objArray
        });
        SendMessageLib.Send(member, 98, objArray);
        num1 = 265;
        num2 = balance;
      }
      if (coupon != 0M)
      {
        object[] objArray = new object[2]
        {
          (object) coupon,
          (object) reason
        };
        WalletRecordLib.SaveCouponRecord(new WalletCouponRecordRequest()
        {
          member_pk = member,
          type = 98,
          subtype = 1,
          currency = ConfigLib.Get("wallet_currency"),
          affect = coupon,
          wallet_amount = coupon,
          wallet_coupon_balance = walletDto.coupon,
          createtime = DateTime.UtcNow,
          list = objArray
        });
        SendMessageLib.Send(member, 98, objArray);
        num1 = 266;
        num2 = coupon;
      }
      object[] objArray1 = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) num2
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = num1,
        list = objArray1
      });
      return true;
    }

    public static bool ErrorCorrection(int member, Decimal balance, Decimal coupon, string reason)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto wallet = tuple.Item1;
      if (!tuple.Item2)
        return false;
      if (balance > 0M)
      {
        if (!WalletLib.CheckFreeMoney(wallet, 0M))
          return false;
      }
      else if (!WalletLib.CheckFreeMoney(wallet, -balance))
        return false;
      WalletService.BalanceMoneyChange(member, balance);
      WalletService.couponMoneyChange(member, coupon);
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[2]
      {
        (object) balance,
        (object) reason
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 99,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 99,
        affect = balance,
        balance = walletDto.balance,
        coupon = coupon,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool IsRequestrMoneyOk(int member, Decimal change)
    {
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto walletDto = tuple.Item1;
      return tuple.Item2 && walletDto.balance - walletDto.freeze >= change;
    }

    private static bool CheckFreeMoney(WalletDto wallet, Decimal change)
    {
      return wallet.balance - wallet.freeze >= change;
    }

    private static void FreezeMoney(int member, Decimal change, string id, int subtype)
    {
      WalletFreezeService.Insert(new WalletFreezeDto()
      {
        member_fk = member,
        sn = id,
        freeze = change,
        subtype = subtype,
        create_time = DateTime.UtcNow
      });
    }

    public static bool UseCoupon(int member_id, Decimal amount, string reason)
    {
      if (!WalletLib.CheckFreeCoupon(WalletService.Find(member_id), amount))
        return false;
      WalletService.couponMoneyChange(member_id, -amount);
      return true;
    }

    public static bool IsRequestCouponOk(int member, Decimal amount)
    {
      WalletDto wallet = WalletService.Find(member);
      return wallet != null && WalletLib.CheckFreeCoupon(wallet, amount);
    }

    private static bool CheckFreeCoupon(WalletDto wallet, Decimal amount)
    {
      return wallet.status && wallet.coupon >= amount;
    }

    public static bool SaveFreezeWalletRecord(
      int member,
      string freezeRequestId,
      Decimal change,
      int tempId)
    {
      WalletDto walletDto = WalletService.Find(member);
      object[] objArray = new object[3]
      {
        (object) freezeRequestId,
        (object) change,
        (object) walletDto.currency
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = tempId,
        currency = walletDto.currency,
        temp_id = tempId,
        affect = 0M,
        balance = walletDto.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }

    public static bool SellStockOption(int member, Decimal change, string stock_code)
    {
      Console.WriteLine(member);
      (WalletDto, bool) tuple = WalletLib.TestWallet(member);
      WalletDto walletDto1 = tuple.Item1;
      if (!tuple.Item2)
        return false;
      WalletService.BalanceMoneyChange(member, change);
      WalletDto walletDto2 = WalletService.Find(member);
      object[] objArray = new object[3]
      {
        (object) stock_code,
        (object) change,
        (object) ConfigLib.Get("wallet_currency")
      };
      WalletRecordLib.Save(new WalletRecordRequest()
      {
        member_pk = member,
        type = 81,
        currency = ConfigLib.Get("wallet_currency"),
        temp_id = 81,
        affect = change,
        balance = walletDto2.balance,
        coupon = 0M,
        createtime = DateTime.UtcNow,
        list = objArray
      });
      return true;
    }
  }
}
