// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.MemberTaskLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Internal;
using stockadmin.Tool;
using System;

#nullable disable
namespace stockadmin.Libs
{
  public class MemberTaskLib
  {
    public static bool MemberTaskFinish(int member_pk, int sub_type)
    {
      string currency = ConfigLib.Get("wallet_currency");
      if (currency == "")
        throw new AppException(2402, "missing_wallet_currency");
      string lang = MemberService.Find(member_pk).lang;
      MemberTaskDto typeCurrencyLang1 = MemberTaskService.FindBySubType_Currency_Lang(sub_type, lang, currency);
      if (typeCurrencyLang1 == null || typeCurrencyLang1.currency.ToLower() != currency.ToLower())
        throw new AppException(2401, "missing_membertask_config");
      MutilangSubjectDto adminDefault = MutilangSubjectBiz.GetAdminDefault();
      MemberTaskDto typeCurrencyLang2 = MemberTaskService.FindBySubType_Currency_Lang(sub_type, adminDefault.lang, currency);
      if (WalletCouponRecordService.FindByMemberFK_Type_SubType(member_pk, 21, sub_type) != null)
        return false;
      WalletDto walletDto1 = WalletService.Find(member_pk);
      if (walletDto1 == null)
        throw new AppException(2403, "missing_wallet");
      if (walletDto1.currency.ToLower() != currency.ToLower())
        throw new AppException(2404, "wallet_currency_mismatch");
      string str1 = (WalletTemplateService.GetByTempId(21, lang) ?? throw new AppException(2405, "missing_wallet_template")).template.Replace("#0#", typeCurrencyLang1.title).Replace("#1#", typeCurrencyLang1.coin.ToString());
      string str2 = typeCurrencyLang2.title + "|" + typeCurrencyLang1.coin.ToString();
      bool flag = WalletLib.RewardNoviceQuests(member_pk, typeCurrencyLang1.coin);
      WalletDto walletDto2 = WalletService.Find(member_pk);
      WalletCouponRecordService.FindPkAfterInsert(new WalletCouponRecordDto()
      {
        coupon_balance = walletDto2.coupon,
        member_fk = member_pk,
        currency = walletDto2.currency,
        affect = typeCurrencyLang1.coin,
        money_type = 2,
        type = 21,
        sub_type = sub_type,
        info = str1,
        create_time = DateTime.UtcNow,
        sended = true,
        send_time = new DateTime?(DateTime.UtcNow),
        param = str2
      });
      object[] objArray = new object[3]
      {
        (object) PublicTool.AddNumberSeparation(new Decimal?(typeCurrencyLang1.coin), walletDto2.currency),
        (object) walletDto2.currency,
        (object) typeCurrencyLang1.title
      };
      SendMessageLib.Send(member_pk, 112, objArray);
      return flag;
    }
  }
}
