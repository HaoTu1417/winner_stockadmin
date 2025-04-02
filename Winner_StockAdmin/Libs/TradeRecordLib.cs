// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.TradeRecordLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Libs
{
  public class TradeRecordLib
  {
    public static void Save(TradeMoneyRecoreRequest request)
    {
      string lang = ConfigLib.Get("admin_language");
      TradeTemplateDto byTempId = TradeTemplateService.GetByTempId(request.temp_id, lang);
      if (byTempId == null)
        throw new AppException(2405, "missing_wallet_template");
      string str1 = byTempId?.template ?? "";
      for (int index = 0; index < request.list.Length; ++index)
      {
        string str2 = str1;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
        interpolatedStringHandler.AppendLiteral("#");
        interpolatedStringHandler.AppendFormatted<int>(index);
        interpolatedStringHandler.AppendLiteral("#");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        string newValue = Convert.ToString(request.list[index]);
        str1 = str2.Replace(stringAndClear, newValue);
      }
      TradeMoneyRecordService.Insert(new TradeMoneyRecordDto()
      {
        member_fk = request.member_fk,
        sub_account = request.sub_account,
        sn = request.sn,
        temp_id = request.temp_id,
        currency = request.currency,
        affect = request.affect,
        op = request.op,
        exchange = request.exchange,
        balance = request.balance,
        wallet_amount = request.wallet_amount,
        info = str1,
        reviewer = request.reviewer,
        create_datetime = request.create_datetime
      });
    }
  }
}
