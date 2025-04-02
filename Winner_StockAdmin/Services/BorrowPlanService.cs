// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowPlanService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.BorrowPlan;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class BorrowPlanService
  {
    public static BorrowPlanDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_plan` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowPlanDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][Find]" + ex.Message);
        return (BorrowPlanDto) null;
      }
    }

    public static BorrowPlanDto FindByBorrowTypeMarket(string borrow_type, string market)
    {
      string sql = "SELECT * FROM `borrow_plan` WHERE `borrow_type` = @borrow_type and `market` = @market";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            borrow_type = borrow_type,
            market = market
          });
          return readConnection.QueryFirstOrDefault<BorrowPlanDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][FindByBorrowTypeMarket]" + ex.Message);
        return (BorrowPlanDto) null;
      }
    }

    public static BorrowPlanDto FindByBorrowType(string borrow_type)
    {
      string sql = "SELECT * FROM `borrow_plan` WHERE `borrow_type` = @borrow_type";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            borrow_type = borrow_type
          });
          return readConnection.QueryFirstOrDefault<BorrowPlanDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][FindByBorrowType]" + ex.Message);
        return (BorrowPlanDto) null;
      }
    }

    public static List<BorrowPlanDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_plan`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowPlanDto>(sql).AsList<BorrowPlanDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][FindAll]" + ex.Message);
        return (List<BorrowPlanDto>) null;
      }
    }

    public static List<string> GetBorrowTypes()
    {
      string sql = "SELECT DISTINCT(borrow_type) FROM `borrow_plan`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<string>(sql).AsList<string>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][FindAll]" + ex.Message);
        return (List<string>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowPlanDto source)
    {
      string sql = "INSERT INTO `borrow_plan` (\n\t\t\t\t`enable`, `borrow_type`, `market`, `name`, `lang`, `rate`, `warning_line`, `break_line`, `max_proporting`, `renewal`, `use_time`, `money_range_min`, `money_range_max`, `money_range_increase`, `fastbtn`, `slogan`, `note`, `unique_set`)\n\t\t\t\tVALUES (@enable, @borrow_type, @market, @name, @lang, @rate, @warning_line, @break_line, @max_proporting, @renewal, @use_time, @money_range_min, @money_range_max, @money_range_increase, @fastbtn, @slogan, @note, @unique_set);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowPlanDto model)
    {
      string sql = "UPDATE `borrow_plan` SET \n\t\t\t\t`enable` = @enable,\n\t\t\t\t`borrow_type` = @borrow_type,\n\t\t\t\t`market` = @market,\n\t\t\t\t`name` = @name,\n\t\t\t\t`rate` = @rate,\n\t\t\t\t`warning_line` = @warning_line,\n\t\t\t\t`break_line` = @break_line,\n\t\t\t\t`max_proporting` = @max_proporting,\n\t\t\t\t`renewal` = @renewal,\n\t\t\t\t`use_time` = @use_time,\n\t\t\t\t`money_range_min` = @money_range_min,\n\t\t\t\t`money_range_max` = @money_range_max,\n\t\t\t\t`money_range_increase` = @money_range_increase,\n\t\t\t\t`fastbtn` = @fastbtn,\n\t\t\t\t`slogan` = @slogan,\n\t\t\t\t`sort` = @sort,\n\t\t\t\t`note` = @note,\n\t\t\t\t`unique_set` = @unique_set\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_plan` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowPlanService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<BorrowPlanList> FindBorrowPlanList(string whereSql = "")
    {
      string sql = "SELECT borrow_plan.pk, borrow_plan.lang, borrow_plan.market, borrow_plan.enable, borrow_plan.borrow_type, borrow_plan.name, borrow_plan.sort \n                FROM `borrow_plan`" + whereSql + " order by market, borrow_type ";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowPlanList>(sql).AsList<BorrowPlanList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[Service][FindBorrowPlanList]" + ex.Message);
        return (List<BorrowPlanList>) null;
      }
    }
  }
}
