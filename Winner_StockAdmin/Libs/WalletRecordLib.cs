// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.WalletRecordLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Models.Wallet;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Libs
{
  public class WalletRecordLib
  {
    public static void Save(WalletRecordRequest req)
    {
      string lang = ConfigLib.Get("admin_language");
      WalletTemplateDto byTempId = WalletTemplateService.GetByTempId(req.temp_id, lang);
      if (byTempId == null)
        throw new AppException(2405, "missing_wallet_template");
      string str1 = byTempId?.template;
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
      WalletRecordService.FindPkAfterInsert(new WalletRecordDto()
      {
        member_fk = req.member_pk,
        type = req.type,
        currency = req.currency,
        affect = req.affect,
        balance = req.balance,
        coupon = req.coupon,
        param = str2,
        templat_id = req.temp_id,
        info = str1,
        create_time = req.createtime,
        create_ip = ""
      });
    }

    public static void SaveCouponRecord(WalletCouponRecordRequest req)
    {
      MemberDto memberDto = MemberService.Find(req.member_pk);
      string str1 = WalletTemplateService.GetByTempId(req.type, memberDto.lang)?.template;
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
      WalletCouponRecordService.FindPkAfterInsert(new WalletCouponRecordDto()
      {
        coupon_balance = req.wallet_coupon_balance,
        member_fk = req.member_pk,
        currency = ConfigLib.Get("wallet_currency"),
        wallet_amount = req.wallet_amount,
        affect = req.affect,
        money_type = req.money_type,
        type = req.type,
        sub_type = req.subtype,
        info = str1,
        param = str2,
        sended = req.sended,
        create_user = "match_borrow",
        create_time = req.createtime
      });
    }
  }
}
