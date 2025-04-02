// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.WalletCouponRecordBiz
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
using stockadmin.ViewModels.WalletCouponRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class WalletCouponRecordBiz
  {
    public static List<WalletCouponRecordList> GetWalletCouponRecordList(int id)
    {
      string whereSql = "";
      if (id != 0)
      {
        string sourceStr = SqlTool.Build<object>((object) null);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
        interpolatedStringHandler.AppendLiteral("cms_promotion_fk = ");
        interpolatedStringHandler.AppendFormatted<int>(id);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        whereSql = sourceStr.Must(stringAndClear);
      }
      List<WalletCouponRecordList> couponRecordList = WalletCouponRecordService.FindWalletCouponRecordList(whereSql);
      return couponRecordList == null ? (List<WalletCouponRecordList>) null : couponRecordList.Select<WalletCouponRecordList, WalletCouponRecordList>((Func<WalletCouponRecordList, WalletCouponRecordList>) (walletCoupon => PublicTool.convertUtcToLocalTime<WalletCouponRecordList>(walletCoupon))).ToList<WalletCouponRecordList>();
    }

    public static List<WalletCouponRecordList> GetHisWalletCouponRecordList(int? member_fk)
    {
      string whereSql = "";
      if (member_fk.HasValue)
      {
        string sourceStr = SqlTool.Build<object>((object) null);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
        interpolatedStringHandler.AppendLiteral("member_fk = ");
        interpolatedStringHandler.AppendFormatted<int?>(member_fk);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        whereSql = sourceStr.Must(stringAndClear);
      }
      List<WalletCouponRecordList> couponRecordList = WalletCouponRecordService.FindWalletCouponRecordList(whereSql);
      return couponRecordList == null ? (List<WalletCouponRecordList>) null : couponRecordList.Select<WalletCouponRecordList, WalletCouponRecordList>((Func<WalletCouponRecordList, WalletCouponRecordList>) (walletCoupon => PublicTool.convertUtcToLocalTime<WalletCouponRecordList>(walletCoupon))).ToList<WalletCouponRecordList>();
    }

    public static List<WalletCouponRecordList> GetHisWalletCouponRecordByAdminDefaultLang(
      int member_fk)
    {
      MutilangSubjectDto adminDefault = MutilangSubjectBiz.GetAdminDefault();
      List<WalletCouponRecordList> couponRecordList1 = WalletCouponRecordService.FindWalletCouponRecordList(member_fk, adminDefault.lang);
      return couponRecordList1 != null ? couponRecordList1.Select<WalletCouponRecordList, WalletCouponRecordList>((Func<WalletCouponRecordList, WalletCouponRecordList>) (walletCouponRecord =>
      {
        PublicTool.convertUtcToLocalTime<WalletCouponRecordList>(walletCouponRecord);
        if (walletCouponRecord.param != null && walletCouponRecord.param != "")
        {
          string[] strArray = walletCouponRecord.param?.Split('|', StringSplitOptions.None);
          if (strArray != null)
          {
            for (int index = 0; index < strArray.Length; ++index)
            {
              WalletCouponRecordList couponRecordList2 = walletCouponRecord;
              string template = walletCouponRecord.template;
              DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
              interpolatedStringHandler.AppendLiteral("#");
              interpolatedStringHandler.AppendFormatted<int>(index);
              interpolatedStringHandler.AppendLiteral("#");
              string stringAndClear = interpolatedStringHandler.ToStringAndClear();
              string newValue = strArray[index]?.ToString();
              string str = template.Replace(stringAndClear, newValue);
              couponRecordList2.template = str;
            }
            walletCouponRecord.info = walletCouponRecord.template;
          }
        }
        return walletCouponRecord;
      })).ToList<WalletCouponRecordList>() : (List<WalletCouponRecordList>) null;
    }

    public static WalletCouponRecordEditVm Get(int pk)
    {
      return WalletCouponRecordService.FindWalletCouponRecordEditVm(pk);
    }

    public static void PostCreate(WalletCouponRecordEditVm req, AdminSession adminUser)
    {
      MemberDto byAccount = MemberService.FindByAccount(req.account);
      if (byAccount == null)
        throw new AppException(1270, "none_account");
      if (WalletCouponRecordService.Find(req.cms_promotion_fk, byAccount.pk) != null)
        throw new AppException(3050, "duplicate_coupon_record");
      if (byAccount.id_auth != 1)
        throw new AppException(1303, "no_id_auth_yet");
      if (WalletCouponRecordService.FindPkAfterInsert(new WalletCouponRecordDto()
      {
        member_fk = byAccount.pk,
        cms_promotion_fk = req.cms_promotion_fk,
        currency = req.currency,
        affect = req.affect,
        exchange = ExchangeLib.GetRate(req.currency, ConfigLib.Get("wallet_currency")),
        wallet_amount = ExchangeLib.Convert(req.affect, req.currency, ConfigLib.Get("wallet_currency")),
        money_type = req.money_type,
        type = req.money_type == 1 ? 22 : 23,
        sub_type = req.cms_promotion_fk,
        info = req.info,
        create_time = DateTime.UtcNow,
        create_user = req.create_user,
        sended = false,
        param = ""
      }) == 0)
        throw new AppException(3020, "insert_record_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 146,
        list = objArray,
        member_account = req.account
      });
    }

    public static void PostEdit(WalletCouponRecordEditVm req, AdminSession adminUser)
    {
      if (WalletCouponRecordService.UpdateWalletCoupon(new WalletCouponRecordDto()
      {
        pk = req.pk,
        currency = req.currency,
        affect = req.affect,
        exchange = ExchangeLib.GetRate(req.currency, ConfigLib.Get("wallet_currency")),
        wallet_amount = ExchangeLib.Convert(req.affect, req.currency, ConfigLib.Get("wallet_currency")),
        money_type = req.money_type,
        info = req.info
      }) == 0)
        throw new AppException(3010, "record_update_false");
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) req.account
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 146,
        list = objArray,
        member_account = req.account
      });
    }

    public static void GiveOut(string give_out_user, int promotion_id)
    {
      string sourceStr = SqlTool.Build<object>((object) null);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
      interpolatedStringHandler.AppendLiteral("cms_promotion_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(promotion_id);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      foreach (WalletCouponRecordDto walletCouponRecordDto in WalletCouponRecordService.FindAll(sourceStr.Must(stringAndClear).Must("sended = 0")))
      {
        string title = CmsPromotionService.Find(walletCouponRecordDto.cms_promotion_fk)?.title;
        object[] objArray = new object[3]
        {
          (object) title,
          (object) PublicTool.AddNumberSeparation(new Decimal?(walletCouponRecordDto.wallet_amount), ConfigLib.Get("wallet_currency")),
          (object) ConfigLib.Get("wallet_currency")
        };
        if (walletCouponRecordDto.money_type == 1)
        {
          WalletLib.PromotRewardRealMoney(walletCouponRecordDto.cms_promotion_fk, title, walletCouponRecordDto.member_fk, walletCouponRecordDto.wallet_amount, ConfigLib.Get("wallet_currency"));
          SendMessageLib.Send(walletCouponRecordDto.member_fk, 22, objArray);
        }
        else
        {
          WalletLib.PromotRewardCoupon(walletCouponRecordDto.member_fk, walletCouponRecordDto.wallet_amount);
          SendMessageLib.Send(walletCouponRecordDto.member_fk, 23, objArray);
        }
      }
      WalletCouponRecordService.UpdateStatusAndSendTimeAndSendUser(promotion_id, DateTime.UtcNow, give_out_user);
    }

    public static void Delete(int pk, AdminSession adminUser)
    {
      WalletCouponRecordService.Remove(pk);
      object[] objArray = new object[3]
      {
        (object) adminUser.account,
        (object) adminUser.nickName,
        (object) pk
      };
      AdminLogLib.Save(new AdminLogRequest()
      {
        admin_user_pk = adminUser.pk,
        admin_menu_fk = 146,
        list = objArray
      });
    }
  }
}
