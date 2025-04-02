// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowAddfinancingService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.Addfinancing;
using stockadmin.ViewModels.BorrowAddfinancing;
using stockadmin.ViewModels.HisAddfinancing;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class BorrowAddfinancingService
  {
    public static BorrowAddfinancingDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_addfinancing` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowAddfinancingDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][Find]" + ex.Message);
        return (BorrowAddfinancingDto) null;
      }
    }

    public static List<BorrowAddfinancingDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_addfinancing`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowAddfinancingDto>(sql).AsList<BorrowAddfinancingDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindAll]" + ex.Message);
        return (List<BorrowAddfinancingDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowAddfinancingDto source)
    {
      string sql = "INSERT INTO `borrow_addfinancing` (\n\t\t\t\t`sub_account`, `borrow_fk`, `member_fk`, `currency`, `money`, `exchange`, `freeze`, `multiple`, `borrow_interest`, `last_deposit_money`, `last_borrow_money`, `status`, `add_time`, `verify_time`, `target_uid`, `target_name`, `coupon`)\n\t\t\t\tVALUES (@sub_account, @borrow_fk, @member_fk, @currency, @money, @exchange, @freeze, @multiple, @borrow_interest, @last_deposit_money, @last_borrow_money, @status, @add_time, @verify_time, @target_uid, @target_name, @coupon);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowAddfinancingDto model)
    {
      string sql = "UPDATE `borrow_addfinancing` SET \n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`borrow_fk` = @borrow_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`money` = @money,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`freeze` = @freeze,\n\t\t\t\t`multiple` = @multiple,\n\t\t\t\t`borrow_interest` = @borrow_interest,\n\t\t\t\t`last_deposit_money` = @last_deposit_money,\n\t\t\t\t`last_borrow_money` = @last_borrow_money,\n\t\t\t\t`status` = @status,\n\t\t\t\t`add_time` = @add_time,\n\t\t\t\t`verify_time` = @verify_time,\n\t\t\t\t`target_uid` = @target_uid,\n\t\t\t\t`target_name` = @target_name,\n\t\t\t\t`coupon` = @coupon\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_addfinancing` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowAddfinancingService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<AddfinancingList> FindAddfinancingList(string whereSql = "")
    {
      string sql = "SELECT borrow_addfinancing.pk, vw_trade_account.status AS trade_status, borrow_addfinancing.sub_account, vw_trade_account.loan_type, vw_trade_account.end_time, vw_trade_account.market, vw_trade_account.balance, vw_trade_account.warningline, borrow_addfinancing.money, borrow_addfinancing.borrow_interest, borrow_addfinancing.freeze, borrow_addfinancing.last_deposit_money, vw_trade_account.member_fk, vw_trade_account.account, vw_trade_account.member_name, borrow_addfinancing.add_time, borrow_addfinancing.status FROM `borrow_addfinancing` INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account " + whereSql + " ORDER BY borrow_addfinancing.add_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AddfinancingList>(sql).AsList<AddfinancingList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindAddfinancingList]" + ex.Message);
        return (List<AddfinancingList>) null;
      }
    }

    public static AddfinancingReview FindAddfinancingReview(int pk)
    {
      string sql = "SELECT borrow_addfinancing.pk, vw_trade_account.status AS trade_status, borrow_addfinancing.sub_account, vw_trade_account.loan_type, vw_trade_account.end_time, vw_trade_account.market, vw_trade_account.balance, vw_trade_account.warningline, borrow_addfinancing.money, borrow_addfinancing.borrow_interest, borrow_addfinancing.freeze, borrow_addfinancing.last_deposit_money, vw_trade_account.member_fk, vw_trade_account.account, vw_trade_account.member_name, borrow_addfinancing.add_time, borrow_addfinancing.status FROM `borrow_addfinancing` INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account where `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AddfinancingReview>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindAddfinancingReview]" + ex.Message);
        return (AddfinancingReview) null;
      }
    }

    public static AddfinancingEditVm FindAddfinancingEditVm(int pk)
    {
      string sql = "SELECT borrow_addfinancing.pk, vw_trade_account.status AS trade_status, borrow_addfinancing.sub_account, vw_trade_account.loan_type, vw_trade_account.end_time, vw_trade_account.market, vw_trade_account.balance, vw_trade_account.warningline, borrow_addfinancing.money, borrow_addfinancing.borrow_interest, borrow_addfinancing.freeze, borrow_addfinancing.exchange, borrow_addfinancing.last_deposit_money, vw_trade_account.member_fk, vw_trade_account.account, vw_trade_account.member_name, borrow_addfinancing.add_time, borrow_addfinancing.status, borrow_addfinancing.verify_time, borrow_addfinancing.target_uid, borrow_addfinancing.target_name FROM `borrow_addfinancing` INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account where `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<AddfinancingEditVm>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindAddfinancingEditVm]" + ex.Message);
        return (AddfinancingEditVm) null;
      }
    }

    public static DataCountBase<HisAddfinancingList> FindHisAddfinancingList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "\n                            SELECT \n                                COUNT(0) AS count\n                            FROM `borrow_addfinancing`\n                            INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account\n                            INNER JOIN member on member.pk = vw_trade_account.member_fk\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(911, 3);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_addfinancing.status, vw_trade_account.account, vw_trade_account.member_name,\n                borrow_addfinancing.sub_account, vw_trade_account.market, vw_trade_account.borrow_type as loan_type, borrow_addfinancing.pk,\n                borrow_addfinancing.money, borrow_addfinancing.borrow_interest, borrow_addfinancing.exchange, borrow_addfinancing.freeze,\n                borrow_addfinancing.add_time, borrow_addfinancing.verify_time, member.is_test_account, borrow_plan.lang as lang\n                FROM `borrow_addfinancing`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account\n                INNER JOIN member on member.pk = vw_trade_account.member_fk\n\t\t\t\tINNER JOIN borrow_plan ON borrow_plan.pk = vw_trade_account.borrow_plan_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY borrow_addfinancing.add_time DESC\n\t\t\t    LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n\t\t\t    OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<HisAddfinancingList>(readConnection.QuerySingle<int>(sql), (IEnumerable<HisAddfinancingList>) readConnection.Query<HisAddfinancingList>(stringAndClear).AsList<HisAddfinancingList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[BorrowAddfinancingService][FindHisAddfinancingList]" + ex.Message);
        return new DataCountBase<HisAddfinancingList>();
      }
    }

    public static HisAddfinancingEditVm FindHisAddfinancingEditVm(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(617, 1);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_addfinancing.status, vw_trade_account.account, vw_trade_account.member_name, borrow_addfinancing.sub_account,\n                vw_trade_account.market, vw_trade_account.loan_type, borrow_addfinancing.pk, borrow_addfinancing.money, borrow_addfinancing.borrow_interest,\n                borrow_addfinancing.exchange, borrow_addfinancing.freeze, borrow_addfinancing.add_time, borrow_addfinancing.verify_time\n                FROM `borrow_addfinancing`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addfinancing.sub_account\n                WHERE borrow_addfinancing.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<HisAddfinancingEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][FindHisAddfinancingEditVm]" + ex.Message);
        return (HisAddfinancingEditVm) null;
      }
    }

    public static List<BorrowAddfinancingSearchList> GetAddFinancing(string where = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(590, 1);
      interpolatedStringHandler.AppendLiteral("SELECT a.pk AS pk, a.member_fk AS member_fk, m.real_name AS member_real_name, a.sub_account AS sub_account, a.multiple AS multiple, ");
      interpolatedStringHandler.AppendLiteral("a.last_deposit_money AS last_deposit_money, a.last_borrow_money AS last_borrow_money, a.money AS money, a.currency AS currency, a.exchange AS EXCHANGE, ");
      interpolatedStringHandler.AppendLiteral("a.freeze AS freeze, a.add_time AS add_time, a.borrow_interest AS borrow_interest, a.verify_time AS verify_time, a.target_name AS target_name, v.end_time AS end_time ");
      interpolatedStringHandler.AppendLiteral("FROM borrow_addfinancing AS a ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN member AS m ON m.pk = a.member_fk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN vw_trade_account AS v ON v.sub_account = a.sub_account ");
      interpolatedStringHandler.AppendFormatted(where);
      interpolatedStringHandler.AppendLiteral(" ;");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowAddfinancingSearchList>(stringAndClear).AsList<BorrowAddfinancingSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][GetAddFinancing]" + ex.Message);
        return (List<BorrowAddfinancingSearchList>) null;
      }
    }

    public static int UpdateState(int id, bool state)
    {
      string sql = "UPDATE `borrow_addfinancing` SET status = @status,verify_time=@verify_time WHERE pk=@pk;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = id,
            status = (state ? 1 : 2),
            verify_time = DateTime.UtcNow
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddfinancingService][UpdateState]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
