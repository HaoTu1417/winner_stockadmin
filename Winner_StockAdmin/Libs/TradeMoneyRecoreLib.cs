// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.TradeMoneyRecoreLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using DB.Services;
using Models.Dto;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Libs
{
    public class TradeMoneyRecoreLib
    {
        public static void Log(int member_pk, int temp_id, params object[] list)
        {
            MemberDto memberDto = MemberService.Find(member_pk);
            string str1 = TradeTemplateService.GetByTempId(temp_id, memberDto.lang)?.template ?? "";
            for (int index = 0; index < list.Length; ++index)
            {
                string str2 = str1;
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
                interpolatedStringHandler.AppendLiteral("#");
                interpolatedStringHandler.AppendFormatted<int>(index);
                interpolatedStringHandler.AppendLiteral("#");
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                string newValue = Convert.ToString(list[index]);
                str1 = str2.Replace(stringAndClear, newValue);
            }
            TradeMoneyRecordService.Insert(new TradeMoneyRecordDto()
            {
                member_fk = member_pk,
                sub_account = "",
                trade_deal_fk = new int?(1),
                sn = "",
                temp_id = temp_id,
                op = 1,
                currency = "",
                balance = 1M,
                affect = 1M,
                exchange = 1M,
                wallet_amount = 1M,
                info = str1,
                reviewer = "",
                create_datetime = DateTime.UtcNow,
                market = "",
                stock_code = "",
                stock_name = ""
            });
        }
    }
}