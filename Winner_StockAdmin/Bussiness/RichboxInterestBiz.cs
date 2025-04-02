// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RichboxInterestBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Tool;
using System;
using System.Linq;

#nullable disable
namespace stockadmin.Business
{
  public class RichboxInterestBiz
  {
    public static Decimal GetWithdrawnAmount(DateTime begin_report_date, DateTime end_begin_date)
    {
      begin_report_date = TimeTool.ConvertLocalToUtc(begin_report_date);
      end_begin_date = TimeTool.ConvertLocalToUtc(end_begin_date);
      return RichboxInterestService.GetWithdrawnAmount(begin_report_date, end_begin_date).Sum<(DateTime?, Decimal)>((Func<(DateTime?, Decimal), Decimal>) (item => item.amount));
    }

    public static Decimal GetTotalRecordedAmount()
    {
      return RichboxInterestService.GetTotalRecordedAmount();
    }
  }
}
