// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.TradeMoneyRecordBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.TradeMoneyRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class TradeMoneyRecordBiz
  {
    public static List<TradeMoneyRecordList> GetTradeMoneyRecordList(TradeMoneyRecordFilter? filter)
    {
      List<TradeMoneyRecordList> tradeMoneyRecordList = TradeMoneyRecordService.FindTradeMoneyRecordList(SqlTool.Build<TradeMoneyRecordFilter>(filter).Must("trade_money_record.sub_account = '" + filter.sub_account + "'"));
      return tradeMoneyRecordList == null ? (List<TradeMoneyRecordList>) null : tradeMoneyRecordList.Select<TradeMoneyRecordList, TradeMoneyRecordList>((Func<TradeMoneyRecordList, TradeMoneyRecordList>) (tradeMoneyRecord => PublicTool.convertUtcToLocalTime<TradeMoneyRecordList>(tradeMoneyRecord))).ToList<TradeMoneyRecordList>();
    }

    public static List<TradeMoneyRecordList> GetTradeMoneyRecordListByAdminDefaultLang(
      TradeMoneyRecordFilter? filter)
    {
      MutilangSubjectDto adminDefault = MutilangSubjectBiz.GetAdminDefault();
      List<TradeMoneyRecordList> tradeMoneyRecordList1 = TradeMoneyRecordService.FindTradeMoneyRecordList(SqlTool.Build<TradeMoneyRecordFilter>(filter).Must("trade_money_record.sub_account = '" + filter.sub_account + "'"), adminDefault.lang);
      return tradeMoneyRecordList1 != null ? tradeMoneyRecordList1.Select<TradeMoneyRecordList, TradeMoneyRecordList>((Func<TradeMoneyRecordList, TradeMoneyRecordList>) (tradeMoneyRecord =>
      {
        PublicTool.convertUtcToLocalTime<TradeMoneyRecordList>(tradeMoneyRecord);
        string[] strArray = tradeMoneyRecord.param?.Split('|', StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index = 0; index < strArray.Length; ++index)
          {
            TradeMoneyRecordList tradeMoneyRecordList2 = tradeMoneyRecord;
            string template = tradeMoneyRecord.template;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
            interpolatedStringHandler.AppendLiteral("#");
            interpolatedStringHandler.AppendFormatted<int>(index);
            interpolatedStringHandler.AppendLiteral("#");
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            string newValue = strArray[index]?.ToString();
            string str = template.Replace(stringAndClear, newValue);
            tradeMoneyRecordList2.template = str;
          }
          tradeMoneyRecord.info = tradeMoneyRecord.template;
        }
        return tradeMoneyRecord;
      })).ToList<TradeMoneyRecordList>() : (List<TradeMoneyRecordList>) null;
    }

    public static TradeMoneyRecordDto Get(int pk) => TradeMoneyRecordService.Find(pk);

    public static void PostCreate(TradeMoneyRecordDto req)
    {
      if (TradeMoneyRecordService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(TradeMoneyRecordDto req)
    {
      if (TradeMoneyRecordService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => TradeMoneyRecordService.Remove(pk);
  }
}
