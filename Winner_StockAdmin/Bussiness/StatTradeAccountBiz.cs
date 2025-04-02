// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.StatTradeAccountBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using stockadmin.ViewModels.StatTradeAccount;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Business
{
  public class StatTradeAccountBiz
  {
    public static List<StatTradeAccountList> GetStatTradeAccountList(StatTradeAccountFilter? filter)
    {
      string str1 = SqlTool.Build<StatTradeAccountFilter>(filter);
      string str2 = string.Empty;
      int? nullable;
      DefaultInterpolatedStringHandler interpolatedStringHandler;
      if (filter.start_year.HasValue)
      {
        nullable = filter.start_month;
        if (nullable.HasValue)
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
          interpolatedStringHandler.AppendFormatted<int?>(filter.start_year);
          interpolatedStringHandler.AppendLiteral("/");
          interpolatedStringHandler.AppendFormatted<int?>(filter.start_month);
          interpolatedStringHandler.AppendLiteral("/01 00:00:00");
          str2 = interpolatedStringHandler.ToStringAndClear();
          goto label_7;
        }
      }
      nullable = filter.start_year;
      if (nullable.HasValue)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
        interpolatedStringHandler.AppendFormatted<int?>(filter.start_year);
        interpolatedStringHandler.AppendLiteral("/01/01 00:00:00");
        str2 = interpolatedStringHandler.ToStringAndClear();
      }
      else
      {
        nullable = filter.start_month;
        if (nullable.HasValue)
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
          interpolatedStringHandler.AppendFormatted<int>(DateTime.Now.Year);
          interpolatedStringHandler.AppendLiteral("/");
          interpolatedStringHandler.AppendFormatted<int?>(filter.start_month);
          interpolatedStringHandler.AppendLiteral("/01 00:00:00");
          str2 = interpolatedStringHandler.ToStringAndClear();
        }
      }
label_7:
      if (!string.IsNullOrWhiteSpace(str2))
        str1 = str1.Must("date('" + str2 + "') <= vw_trade_account.begin_time");
      string str3 = string.Empty;
      nullable = filter.end_year;
      if (nullable.HasValue)
      {
        nullable = filter.end_month;
        if (nullable.HasValue)
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
          interpolatedStringHandler.AppendFormatted<int?>(filter.end_year);
          interpolatedStringHandler.AppendLiteral("/");
          interpolatedStringHandler.AppendFormatted<int?>(filter.end_month);
          interpolatedStringHandler.AppendLiteral("/01");
          DateTime dateTime = Convert.ToDateTime(interpolatedStringHandler.ToStringAndClear());
          dateTime = dateTime.AddMonths(1);
          str3 = dateTime.ToString("yyyy/MM/dd 00:00:00");
          goto label_16;
        }
      }
      nullable = filter.end_year;
      if (nullable.HasValue)
      {
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
        interpolatedStringHandler.AppendFormatted<int?>(filter.end_year);
        interpolatedStringHandler.AppendLiteral("/12/31 23:59:59");
        str3 = interpolatedStringHandler.ToStringAndClear();
      }
      else
      {
        nullable = filter.end_month;
        if (nullable.HasValue)
        {
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
          interpolatedStringHandler.AppendFormatted<int>(DateTime.Now.Year);
          interpolatedStringHandler.AppendLiteral("/");
          interpolatedStringHandler.AppendFormatted<int?>(filter.end_month);
          interpolatedStringHandler.AppendLiteral("/01");
          str3 = Convert.ToDateTime(interpolatedStringHandler.ToStringAndClear()).AddMonths(1).ToString("yyyy/MM/dd 00:00:00");
        }
      }
label_16:
      if (!string.IsNullOrWhiteSpace(str3))
        str1 = str1.Must(" vw_trade_account.end_time < date('" + str3 + "')");
      return VwTradeAccountService.FindStatTradeAccountList(str1);
    }
  }
}
