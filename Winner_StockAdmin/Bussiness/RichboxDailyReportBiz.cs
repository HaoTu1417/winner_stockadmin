// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RichboxDailyReportBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.RichboxDailyReport;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class RichboxDailyReportBiz
  {
    public static List<RichboxDailyReportList> GetRichboxDailyReportList(
      RichboxDailyReportFilter? filter)
    {
      DateTime result1;
      DateTime.TryParse(filter.begin_report_date, out result1);
      DateTime utc1 = TimeTool.ConvertLocalToUtc(result1);
      DateTime result2;
      DateTime.TryParse(filter.end_report_date, out result2);
      DateTime utc2 = TimeTool.ConvertLocalToUtc(result2.AddDays(1.0));
      List<(DateTime, DateTime, DateTime)> valueTupleList = new List<(DateTime, DateTime, DateTime)>();
      if ((result2 - result1).Days == 0)
      {
        valueTupleList.Add((result1.Date, TimeTool.ConvertLocalToUtc(result1), TimeTool.ConvertLocalToUtc(result1.AddDays(1.0))));
      }
      else
      {
        for (DateTime localTime = result1; localTime <= result2; localTime = localTime.AddDays(1.0))
          valueTupleList.Add((localTime, TimeTool.ConvertLocalToUtc(localTime), TimeTool.ConvertLocalToUtc(localTime.AddDays(1.0))));
      }
      List<(DateTime?, Decimal)> depositAmount = RichboxRecordService.GetDepositAmount(utc1, utc2);
      List<(DateTime?, Decimal)> withdrawnAmount = RichboxRecordService.GetWithdrawnAmount(utc1, utc2);
      List<(DateTime?, Decimal)> interest = RichboxRecordService.GetInterest(utc1, utc2);
      List<RichboxDailyReportList> source = new List<RichboxDailyReportList>();
      foreach ((_, _, _) in valueTupleList)
      {
        (DateTime, DateTime, DateTime) date;
        Decimal num1 = depositAmount.Where<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), bool>) (item =>
        {
          DateTime? datetime1 = item.datetime;
          DateTime dateTime1 = date.Item2;
          
          if ((datetime1.HasValue ? (datetime1.GetValueOrDefault() >= dateTime1 ? 1 : 0) : 0) == 0)
            return false;
          DateTime? datetime2 = item.datetime;
          DateTime dateTime2 = date.Item3;
          return datetime2.HasValue && datetime2.GetValueOrDefault() < dateTime2;
        })).Sum<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), Decimal>) (item2 => item2.amount));
        Decimal num2 = withdrawnAmount.Where<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), bool>) (item =>
        {
          DateTime? datetime3 = item.datetime;
          DateTime dateTime3 = date.Item2;
          if ((datetime3.HasValue ? (datetime3.GetValueOrDefault() >= dateTime3 ? 1 : 0) : 0) == 0)
            return false;
          DateTime? datetime4 = item.datetime;
          DateTime dateTime4 = date.Item3;
          return datetime4.HasValue && datetime4.GetValueOrDefault() < dateTime4;
        })).Sum<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), Decimal>) (item2 => item2.amount));
        Decimal num3 = interest.Where<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), bool>) (item =>
        {
          DateTime? datetime5 = item.datetime;
          DateTime dateTime5 = date.Item2;
          if ((datetime5.HasValue ? (datetime5.GetValueOrDefault() >= dateTime5 ? 1 : 0) : 0) == 0)
            return false;
          DateTime? datetime6 = item.datetime;
          DateTime dateTime6 = date.Item3;
          return datetime6.HasValue && datetime6.GetValueOrDefault() < dateTime6;
        })).Sum<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), Decimal>) (item2 => item2.amount));
        RichboxDailyReportList richboxDailyReportList = new RichboxDailyReportList()
        {
          report_date = date.Item1.ToString("yyyy-MM-dd"),
          total_profit = num3,
          total_input = num1,
          total_output = num2
        };
        source.Add(richboxDailyReportList);
      }
      return source.OrderByDescending<RichboxDailyReportList, string>((Func<RichboxDailyReportList, string>) (item => item.report_date)).ToList<RichboxDailyReportList>();
    }

    public static RichboxDailyReportDto Get(string report_date)
    {
      return RichboxDailyReportService.Find(report_date);
    }

    public static void PostCreate(RichboxDailyReportDto req)
    {
      if (RichboxDailyReportService.Insert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(RichboxDailyReportDto req)
    {
      if (RichboxDailyReportService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(string report_date) => RichboxDailyReportService.Remove(report_date);

    public static Decimal GetWithdrawnAmount(DateTime begin_report_date, DateTime end_begin_date)
    {
      begin_report_date = TimeTool.ConvertLocalToUtc(begin_report_date);
      end_begin_date = TimeTool.ConvertLocalToUtc(end_begin_date);
      return RichboxInterestService.GetWithdrawnAmount(begin_report_date, end_begin_date).Sum<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), Decimal>) (item => item.amount));
    }
  }
}
