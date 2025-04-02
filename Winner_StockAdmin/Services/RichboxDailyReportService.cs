// Decompiled with JetBrains decompiler
// Type: DB.Services.RichboxDailyReportService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.RichboxDailyReport;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class RichboxDailyReportService
  {
    public static RichboxDailyReportDto Find(string report_date)
    {
      string sql = "SELECT * FROM `richbox_daily_report` WHERE `report_date` = @report_date";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            report_date = report_date
          });
          return readConnection.QueryFirstOrDefault<RichboxDailyReportDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][Find]" + ex.Message);
        return (RichboxDailyReportDto) null;
      }
    }

    public static List<RichboxDailyReportDto> FindAll()
    {
      string sql = "SELECT * FROM `richbox_daily_report`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxDailyReportDto>(sql).AsList<RichboxDailyReportDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][FindAll]" + ex.Message);
        return (List<RichboxDailyReportDto>) null;
      }
    }

    public static int Insert(RichboxDailyReportDto model)
    {
      string sql = "INSERT INTO `richbox_daily_report` (\n\t\t\t\t`report_date`, `total_invest`, `total_profit`, `total_input`, `total_output`, `total_interest`)\n\t\t\t\tVALUES (@report_date, @total_invest, @total_profit, @total_input, @total_output, @total_interest); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RichboxDailyReportDto model)
    {
      string sql = "UPDATE `richbox_daily_report` SET \n\t\t\t\t`total_invest` = @total_invest,\n\t\t\t\t`total_profit` = @total_profit,\n\t\t\t\t`total_input` = @total_input,\n\t\t\t\t`total_output` = @total_output,\n\t\t\t\t`total_interest` = @total_interest\n\t\t\t\t WHERE `report_date` = @report_date";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(string report_date)
    {
      string sql = "DELETE FROM `richbox_daily_report` WHERE `report_date` = @report_date";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            report_date = report_date
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<RichboxDailyReportList> FindRichboxDailyReportList(string whereSql = "")
    {
      string sql = "SELECT richbox_daily_report.report_date, richbox_daily_report.total_invest, richbox_daily_report.total_profit, richbox_daily_report.total_input, richbox_daily_report.total_output, richbox_daily_report.total_interest FROM `richbox_daily_report`" + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RichboxDailyReportList>(sql).AsList<RichboxDailyReportList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RichboxDailyReportService][FindRichboxDailyReportList]" + ex.Message);
        return (List<RichboxDailyReportList>) null;
      }
    }
  }
}
