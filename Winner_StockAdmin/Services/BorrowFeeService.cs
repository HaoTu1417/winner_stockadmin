// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowFeeService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.BorrowFee;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class BorrowFeeService
  {
    public static BorrowFeeDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_fee` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowFeeDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][Find]" + ex.Message);
        return (BorrowFeeDto) null;
      }
    }

    public static List<BorrowFeeDto> FindByMemberFk(int member_fk)
    {
      string sql = "SELECT * FROM `borrow_fee` WHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.Query<BorrowFeeDto>(sql, (object) parameters).AsList<BorrowFeeDto>();
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][FindByMemberFk]" + ex.Message);
        return (List<BorrowFeeDto>) null;
      }
    }

    public static List<BorrowFeeDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_fee`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowFeeDto>(sql).AsList<BorrowFeeDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][FindAll]" + ex.Message);
        return (List<BorrowFeeDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowFeeDto source)
    {
      string sql = "INSERT INTO `borrow_fee` (\n\t\t\t\t`member_fk`, `sub_account`, `borrow_fk`, `type`, `borrow_fee`, `use_coupon`, `fee_received`, `borrow_duration`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @sub_account, @borrow_fk, @type, @borrow_fee, @use_coupon, @fee_received, @borrow_duration, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowFeeDto model)
    {
      string sql = "UPDATE `borrow_fee` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`borrow_fk` = @borrow_fk,\n\t\t\t\t`type` = @type,\n\t\t\t\t`borrow_fee` = @borrow_fee,\n\t\t\t\t`use_coupon` = @use_coupon,\n\t\t\t\t`fee_received` = @fee_received,\n\t\t\t\t`borrow_duration` = @borrow_duration,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_fee` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowFeeService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Insert(BorrowFeeDto model)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("INSERT INTO borrow_fee (sub_account, member_fk, borrow_fk, type, borrow_fee, use_coupon, fee_received, borrow_duration, create_time) VALUES(@sub_account, @member_fk, @borrow_fk, @type, @borrow_fee, @use_coupon, @fee_received, @borrow_duration, @create_time);", (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static (Decimal, DataCountBase<BorrowFeeList>) FindBorrowFeeList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                SELECT \n                    COUNT(*) AS count, SUM(borrow_fee) AS total_borrowfee\n                FROM `borrow_fee`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_fee.sub_account\n                INNER JOIN member on vw_trade_account.member_fk = member.pk\n                " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(631, 3);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_fee.create_time, borrow_fee.type, borrow_fee.borrow_fee, borrow_fee.sub_account, vw_trade_account.borrow_type, vw_trade_account.loan_type,\n                vw_trade_account.currency, borrow_fee.borrow_duration, vw_trade_account.account, vw_trade_account.member_name, member.is_test_account\n                FROM `borrow_fee`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_fee.sub_account\n                INNER JOIN member on vw_trade_account.member_fk = member.pk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY borrow_fee.create_time DESC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          CountAndTotalBorrowfee andTotalBorrowfee = readConnection.QuerySingle<CountAndTotalBorrowfee>(sql);
          List<BorrowFeeList> data = readConnection.Query<BorrowFeeList>(stringAndClear).AsList<BorrowFeeList>();
          return (andTotalBorrowfee.total_borrowfee, new DataCountBase<BorrowFeeList>(andTotalBorrowfee.count, (IEnumerable<BorrowFeeList>) data));
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][FindBorrowFeeList]" + ex.Message);
        return (0M, new DataCountBase<BorrowFeeList>());
      }
    }

    public static Decimal GetBorrowFeeSummary(string whereSql = "")
    {
      string sql = "SELECT SUM(borrow_fee) FROM `borrow_fee`\n                INNER JOIN `member` ON member.pk = borrow_fee.`member_fk`\n                " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<Decimal>(sql);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowFeeService][GetBorrowFeeSummary]" + ex.Message);
        return 0M;
      }
    }
  }
}
