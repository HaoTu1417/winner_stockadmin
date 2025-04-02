// Decompiled with JetBrains decompiler
// Type: DB.Services.StockOptionRecordService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.StockOptionRecord;
using System;
using System.Collections.Generic;

#nullable enable
namespace DB.Services
{
  public class StockOptionRecordService
  {
    public static List<StockOptionRecordList> FindStockOptionRecordList(string whereSql = "")
    {
      string sql = "SELECT *, stock_option_record.quantity, stock_option_record.member_fk, IFNULL(stock_us.stock_name, stock_vn.stock_name) AS stock_name, stock_option_record.pk, stock_option_record.status, stock_option_record.create_time as create_time, member.account as account, admin_user.account as admin_user\n                FROM `stock_option_record`\n                INNER JOIN member ON member.pk = stock_option_record.member_fk\n                LEFT JOIN admin_user ON admin_user.pk = stock_option_record.admin_user_fk\n                LEFT JOIN stock_us ON LOWER(stock_option_record.market) = 'us' AND stock_option_record.stock_code = stock_us.stock_code\n                LEFT JOIN stock_vn ON LOWER(stock_option_record.market) = 'vn' AND stock_option_record.stock_code = stock_us.stock_code\n                " + whereSql + "\n                order by stock_option_record.create_time desc";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockOptionRecordList>(sql).AsList<StockOptionRecordList>();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[StockOptionRecordService][FindStockOptionList]" + ex.Message);
        return (List<StockOptionRecordList>) null;
      }
    }

    public static StockOptionRecordList GetReview(int pk)
    {
      string sql = "SELECT *, stock_option_record.pk, stock_option_record.quantity, stock_option_record.pk, stock_option_position.stock_name, stock_option_record.status, stock_option_record.create_time as create_time, member.account as account, admin_user.account as admin_user\n                FROM `stock_option_record`\n                LEFT JOIN member ON member.pk = stock_option_record.member_fk\n                LEFT JOIN admin_user ON admin_user.pk = stock_option_record.admin_user_fk\n                LEFT JOIN stock_option_position ON stock_option_position.stock_code = stock_option_record.stock_code\n                WHERE stock_option_record.`pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<StockOptionRecordList>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[StockOptionRecordService][GetReview]" + ex.Message);
        return (StockOptionRecordList) null;
      }
    }

    public static StockOptionRecordDto Find(int pk)
    {
      string sql = "SELECT * FROM `stock_option_record` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<StockOptionRecordDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][Find]" + ex.Message);
        return (StockOptionRecordDto) null;
      }
    }

    public static List<StockOptionRecordDto> FindAll()
    {
      string sql = "SELECT * FROM `stock_option_record`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockOptionRecordDto>(sql).AsList<StockOptionRecordDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][FindAll]" + ex.Message);
        return (List<StockOptionRecordDto>) null;
      }
    }

    public static int FindPkAfterInsert(StockOptionRecordDto source)
    {
      string sql = "INSERT INTO `stock_option_record` (\n\t\t\t\t`member_fk`, `stock_option_fk`, `stock_code`, `price`, `quantity`, `total`, `status`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @stock_option_fk, @stock_code, @price, @quantity, @total, @status, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(StockOptionRecordDto model)
    {
      string sql = "UPDATE `stock_option_record` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`stock_optoin_fk` = @stock_option_fk,\n\t\t\t\t`stock_code` = @stock_code,\n\t\t\t\t`price` = @price,\n\t\t\t\t`quantity` = @quantity,\n\t\t\t\t`total` = @total,\n\t\t\t\t`status` = @status,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateSuccess(int pk)
    {
      string sql = "UPDATE `stock_option_record` SET \n\t\t\t\t`status` = 2\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          pk = pk
        });
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][UpdateSuccess]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFail(int pk, string reject_result)
    {
      string sql = "UPDATE `stock_option_record` SET \n\t\t\t\t`status` = 3,\n                `reject_result` = @reject_result\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          pk = pk,
          reject_result = reject_result
        });
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[StockOptionRecordService][UpdateFail]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `stock_option_record` WHERE `pk` = @pk";
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
        LogLib.Log("[StockOptionRecordService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
