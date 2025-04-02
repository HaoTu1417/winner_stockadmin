// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.DailyFinanceReportBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using OfficeOpenXml;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.DailyFinanceReport;
using System;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Business
{
  public class DailyFinanceReportBiz
  {
    public static (Summary, DataCountBase<DailyFinanceReportList>) GetDailyFinanceReportList(
      DailyFinanceReportFilter? filter,
      int page,
      int pageSize)
    {
      (CountAndSummary countAndSummary, DataCountBase<DailyFinanceReportList> dataCountBase) = StatisticsService.GetDailyFinanceReport(SqlTool.Build<DailyFinanceReportFilter>(filter), page: page, pageSize: pageSize);
      return (new Summary()
      {
        total_recharge = countAndSummary.total_recharge,
        total_withdraw = countAndSummary.total_withdraw,
        total_profit_loss = countAndSummary.total_profit_loss,
        total_member = countAndSummary.total_member,
        total_management_fee = countAndSummary.total_management_fee
      }, new DataCountBase<DailyFinanceReportList>(dataCountBase.count, dataCountBase.data));
    }

    public static byte[]? DownloadDailyFinanceReportList(DailyFinanceReportFilter? filter)
    {
      string whereSql = SqlTool.Build<DailyFinanceReportFilter>(filter);
      ExcelPackage.LicenseContext = new LicenseContext?(LicenseContext.NonCommercial);
      using (ExcelPackage excelPackage = new ExcelPackage())
      {
        ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
        (CountAndSummary countAndSummary, DataCountBase<DailyFinanceReportList> dataCountBase) = StatisticsService.GetDailyFinanceReport(whereSql, true);
        Summary summary = new Summary()
        {
          total_recharge = countAndSummary.total_recharge,
          total_withdraw = countAndSummary.total_withdraw,
          total_profit_loss = countAndSummary.total_profit_loss,
          total_member = countAndSummary.total_member,
          total_management_fee = countAndSummary.total_management_fee
        };
        excelWorksheet.Cells.Style.Numberformat.Format = "0";
        excelWorksheet.Cells["A2:A" + (dataCountBase.count + 1).ToString()].Style.Numberformat.Format = "yyyy/MM/dd";
        excelWorksheet.Cells["A1"].LoadFromCollection<DailyFinanceReportList>(dataCountBase.data, true);
        int column = excelWorksheet.Dimension.End.Column;
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 1) + "1"].Value = (object) "合計充值";
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 1) + "2"].Value = (object) summary.total_recharge;
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 2) + "1"].Value = (object) "合計提盈";
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 2) + "2"].Value = (object) summary.total_withdraw;
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 3) + "1"].Value = (object) "合計盈虧";
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 3) + "2"].Value = (object) summary.total_profit_loss;
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 4) + "1"].Value = (object) "总会员数";
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 4) + "2"].Value = (object) summary.total_member;
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 5) + "1"].Value = (object) "总管理费收入";
        excelWorksheet.Cells[DailyFinanceReportBiz.GetExcelColumnName(column + 5) + "2"].Value = (object) summary.total_management_fee;
        return excelPackage.GetAsByteArray();
      }
    }

    public static string GetExcelColumnName(int columnIndex)
    {
      string excelColumnName = "";
      for (; columnIndex > 0; columnIndex = (columnIndex - 1) / 26)
      {
        char ch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(columnIndex - 1) % 26];
        //excelColumnName = new ReadOnlySpan<char>(ref ch).ToString() + string.op_Implicit(excelColumnName);
        excelColumnName = ch.ToString() + excelColumnName;
      }
      return excelColumnName;
    }

    public static Summary GetSummary(
      List<DailyFinanceReportList> dailyFinanceReportList)
    {
      Decimal num1 = 0M;
      Decimal num2 = 0M;
      Decimal num3 = 0M;
      int num4 = 0;
      Decimal num5 = 0M;
      foreach (DailyFinanceReportList dailyFinanceReport in dailyFinanceReportList)
      {
        num1 += dailyFinanceReport.today_profit_loss;
        num2 += dailyFinanceReport.today_recharge;
        num3 += dailyFinanceReport.today_withdraw;
        num4 += dailyFinanceReport.today_member;
        num5 += dailyFinanceReport.today_management_fee;
      }
      return new Summary()
      {
        total_profit_loss = num1,
        total_recharge = num2,
        total_withdraw = num3,
        total_member = num4,
        total_management_fee = num5
      };
    }
  }
}
