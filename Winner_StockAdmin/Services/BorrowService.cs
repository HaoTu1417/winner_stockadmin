// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels;
using stockadmin.ViewModels.HisBorrow;
using stockadmin.ViewModels.ReviewBorrow;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class BorrowService
  {
    public static BorrowDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][Find]" + ex.Message);
        return (BorrowDto) null;
      }
    }

    public static List<BorrowDto> FindFirstTrade(int member)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(112, 1);
      interpolatedStringHandler.AppendLiteral("SELECT * FROM `borrow` WHERE `member_fk` = ");
      interpolatedStringHandler.AppendFormatted<int>(member);
      interpolatedStringHandler.AppendLiteral(" AND `borrow_type` <> 'trial' AND `status` = 2 ORDER BY `create_time`");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowDto>(stringAndClear).AsList<BorrowDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][FindFirstTrade]" + ex.Message);
        return (List<BorrowDto>) null;
      }
    }

    public static List<BorrowDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowDto>(sql).AsList<BorrowDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][FindAll]" + ex.Message);
        return (List<BorrowDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowDto source)
    {
      string sql = "INSERT INTO `borrow` (\n\t\t\t\t`sub_account`, `borrow_plan_fk`, `member_fk`, `agent_fk`, `order_id`, `status`, `market`, `borrow_type`, `currency`, `deposit_money`, `init_money`, `multiple`, `auto_renewal`, `borrow_money`, `borrow_interest`, `repayment_type`, `borrow_duration`, `position`, `rate`, `total`, `trading_time`, `loss_warn_sms_send`, `stock_money`, `total_coupon`, `total_fee`, `total_interest`, `create_time`, `begin_time`, `end_time`, `verify_time`)\n\t\t\t\tVALUES (@sub_account, @borrow_plan_fk, @member_fk, @agent_fk, @order_id, @status, @market, @borrow_type, @currency, @deposit_money, @init_money, @multiple, @auto_renewal, @borrow_money, @borrow_interest, @repayment_type, @borrow_duration, @position, @rate, @total, @trading_time, @loss_warn_sms_send, @stock_money, @total_coupon, @total_fee, @total_interest, @create_time, @begin_time, @end_time, @verify_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowDto model)
    {
      string sql = "UPDATE `borrow` SET \n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`borrow_plan_fk` = @borrow_plan_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`agent_fk` = @agent_fk,\n\t\t\t\t`order_id` = @order_id,\n\t\t\t\t`status` = @status,\n\t\t\t\t`market` = @market,\n\t\t\t\t`borrow_type` = @borrow_type,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`deposit_money` = @deposit_money,\n\t\t\t\t`init_money` = @init_money,\n\t\t\t\t`multiple` = @multiple,\n\t\t\t\t`auto_renewal` = @auto_renewal,\n\t\t\t\t`borrow_money` = @borrow_money,\n\t\t\t\t`borrow_interest` = @borrow_interest,\n\t\t\t\t`repayment_type` = @repayment_type,\n\t\t\t\t`borrow_duration` = @borrow_duration,\n\t\t\t\t`position` = @position,\n\t\t\t\t`rate` = @rate,\n\t\t\t\t`total` = @total,\n\t\t\t\t`trading_time` = @trading_time,\n\t\t\t\t`loss_warn_sms_send` = @loss_warn_sms_send,\n\t\t\t\t`stock_money` = @stock_money,\n\t\t\t\t`total_coupon` = @total_coupon,\n\t\t\t\t`total_fee` = @total_fee,\n\t\t\t\t`total_interest` = @total_interest,\n\t\t\t\t`create_time` = @create_time,\n\t\t\t\t`begin_time` = @begin_time,\n\t\t\t\t`end_time` = @end_time,\n\t\t\t\t`verify_time` = @verify_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateRenewal(int pk, bool auto_renewal)
    {
      string sql = "UPDATE `borrow` SET \n\t\t\t\t`auto_renewal` = @auto_renewal\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        DynamicParameters parameters = DapperMysql.GetParameters((object) new
        {
          auto_renewal = auto_renewal,
          pk = pk
        });
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) parameters);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static HisBorrowEditVm FindHisBorrowEditVm(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(541, 1);
      interpolatedStringHandler.AppendLiteral("SELECT vw_trade_account.account, vw_trade_account.member_name, borrow.sub_account, borrow.status, borrow.market, \n            borrow.borrow_type, borrow.init_money, vw_trade_account.balance, borrow.deposit_money, borrow.multiple, borrow.auto_renewal, \n            borrow.pk, borrow.order_id, borrow.borrow_interest, borrow.begin_time, borrow.end_time, borrow.create_time, borrow.verify_time \n            FROM `borrow`\n            INNER JOIN vw_trade_account ON vw_trade_account.sub_account = borrow.sub_account\n            WHERE borrow.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<HisBorrowEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][FindHisBorrowEditVm]" + ex.Message);
        return (HisBorrowEditVm) null;
      }
    }

    public static DataCountBase<HisBorrowList> FindHisBorrowList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\nSELECT COUNT(0) AS count\nFROM\n(SELECT vw_trade_account.account, member.is_test_account as is_test_account, member.is_del as is_del, vw_trade_account.member_name, borrow.sub_account, borrow.status, borrow.market, \n            borrow.borrow_type, borrow.init_money, vw_trade_account.balance, borrow.deposit_money, borrow.multiple, borrow.auto_renewal, \n            borrow.pk, borrow.order_id, borrow.borrow_interest, borrow.begin_time, borrow.end_time, borrow.create_time, borrow.verify_time \n            FROM `borrow`\n            INNER JOIN vw_trade_account ON vw_trade_account.sub_account = borrow.sub_account\n            INNER JOIN `member` ON member.pk = vw_trade_account.member_fk\n\t    WHERE borrow.sub_account IS NOT NULL AND vw_trade_account.status < 2\nUNION\nSELECT     member.account, member.is_test_account as is_test_account, member.is_del as is_del, member.nickname AS member_name, borrow.sub_account, borrow.status, borrow.market, \n            borrow.borrow_type, borrow.init_money, 0 AS balance, borrow.deposit_money, borrow.multiple, borrow.auto_renewal, \n            borrow.pk, borrow.order_id, borrow.borrow_interest, borrow.begin_time, borrow.end_time, borrow.create_time, borrow.verify_time\n            FROM `borrow`\n\t    INNER JOIN `member` ON member.pk = borrow.member_fk\n\t    WHERE borrow.sub_account IS NULL\n) AS t\n" + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1363, 3);
      interpolatedStringHandler.AppendLiteral("SELECT * FROM\n(SELECT vw_trade_account.account, member.is_test_account as is_test_account, member.is_del as is_del, vw_trade_account.member_name, borrow.sub_account, borrow.status, borrow.market, \n            borrow.borrow_type, borrow.init_money, vw_trade_account.balance, borrow.deposit_money, borrow.multiple, borrow.auto_renewal, \n            borrow.pk, borrow.order_id, borrow.borrow_interest, borrow.begin_time, borrow.end_time, borrow.create_time, borrow.verify_time \n            FROM `borrow`\n            INNER JOIN vw_trade_account ON vw_trade_account.sub_account = borrow.sub_account\n            INNER JOIN `member` ON member.pk = vw_trade_account.member_fk\n\t    WHERE borrow.sub_account IS NOT NULL AND vw_trade_account.status < 2\nUNION\nSELECT     member.account, member.is_test_account as is_test_account, member.is_del as is_del, member.nickname AS member_name, borrow.sub_account, borrow.status, borrow.market, \n            borrow.borrow_type, borrow.init_money, 0 AS balance, borrow.deposit_money, borrow.multiple, borrow.auto_renewal, \n            borrow.pk, borrow.order_id, borrow.borrow_interest, borrow.begin_time, borrow.end_time, borrow.create_time, borrow.verify_time\n            FROM `borrow`\n\t    INNER JOIN `member` ON member.pk = borrow.member_fk\n\t    WHERE borrow.sub_account IS NULL\n) AS t\n");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\nORDER BY t.create_time DESC\nLIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\nOFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<HisBorrowList>(readConnection.QuerySingle<int>(sql), (IEnumerable<HisBorrowList>) readConnection.Query<HisBorrowList>(stringAndClear).AsList<HisBorrowList>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        LogLib.Log("[BorrowService][FindHisBorrowList]" + ex.Message);
        return new DataCountBase<HisBorrowList>();
      }
    }

    public static List<ReviewBorrowList> FindReviewBorrowList(string whereSql = "")
    {
      string sql = "SELECT member_fk, member.account, member.nickname, borrow.pk, order_id, market, borrow_type, deposit_money, \n                borrow_money, borrow_interest, borrow.create_time, begin_time, end_time \n                FROM `borrow`\n                INNER JOIN `member` ON member.pk = borrow.member_fk \n                " + whereSql + "  order by borrow.create_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<ReviewBorrowList>(sql).AsList<ReviewBorrowList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][FindReviewBorrowList]" + ex.Message);
        return (List<ReviewBorrowList>) null;
      }
    }

    public static int InAdvanceReset(int id, string subAccount)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE `borrow` SET stock_money = (select sum(total_amount) from trade_deal WHERE sub_account = @subAccount),\ntotal_fee=(select sum(total_cost) from trade_deal WHERE sub_account = @subAccount),\ntotal_coupon=(select sum(use_coupon) from  borrow_fee WHERE sub_account = @subAccount),\ntotal_interest=(select sum(borrow_fee) from borrow_fee WHERE sub_account = @subAccount)\nWHERE pk=@pk;", (object) new
          {
            pk = id,
            subAccount = subAccount
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][InAdvanceReset]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<BorrowSearchList> GetBorrowApplyList(string where)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(622, 1);
      interpolatedStringHandler.AppendLiteral("SELECT b.pk AS pk, b.member_fk AS member_fk, m.username AS member_username, m.real_name AS member_real_name, b.order_id AS order_id, b.`status` AS `status`, b.borrow_type AS borrow_type, b.market AS market, b.borrow_duration AS borrow_duration, b.auto_renewal AS auto_renewal, b.begin_time AS begin_time, b.end_time AS end_time, b.deposit_money AS deposit_money, b.borrow_money AS borrow_money, b.multiple AS multiple, b.rate AS rate, b.borrow_interest AS borrow_interest, b.init_money AS init_money, b.create_time AS create_time, b.verify_time AS verify_time ");
      interpolatedStringHandler.AppendLiteral("FROM borrow AS b ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN member AS m ON m.pk = b.member_fk ");
      interpolatedStringHandler.AppendFormatted(where);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowSearchList>(stringAndClear).AsList<BorrowSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][GetStopTradingList]" + ex.Message);
        return (List<BorrowSearchList>) null;
      }
    }

    public static BorrowApply GetBorrowApply(int id)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(891, 1);
      interpolatedStringHandler.AppendLiteral("SELECT m.time_zone AS time_zone, p.warning_line AS warning_line, ");
      interpolatedStringHandler.AppendLiteral("p.break_line AS break_line, b.pk AS pk, b.member_fk AS member_fk, b.borrow_plan_fk AS borrow_plan_fk, ");
      interpolatedStringHandler.AppendLiteral("m.account AS member_username, m.real_name AS member_real_name, ");
      interpolatedStringHandler.AppendLiteral("b.order_id AS order_id, b.`status` AS `status`, b.borrow_type AS borrow_type, b.currency AS currency, ");
      interpolatedStringHandler.AppendLiteral("b.market AS market, b.borrow_duration AS borrow_duration, b.auto_renewal AS auto_renewal, ");
      interpolatedStringHandler.AppendLiteral("b.begin_time AS begin_time, b.end_time AS end_time, b.deposit_money AS deposit_money, ");
      interpolatedStringHandler.AppendLiteral("b.borrow_money AS borrow_money, b.multiple AS multiple, b.rate AS rate, b.borrow_interest AS borrow_interest, ");
      interpolatedStringHandler.AppendLiteral("b.init_money AS init_money, b.total_coupon AS total_coupon, b.total_fee AS total_fee, b.create_time AS create_time, b.verify_time AS verify_time ");
      interpolatedStringHandler.AppendLiteral("FROM borrow AS b ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN member AS m ON m.pk = b.member_fk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN borrow_plan AS p ON p.pk = b.borrow_plan_fk ");
      interpolatedStringHandler.AppendLiteral("WHERE b.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(id);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = id
          });
          return readConnection.QueryFirstOrDefault<BorrowApply>(stringAndClear, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][GetBorrowApply]" + ex.Message);
        return (BorrowApply) null;
      }
    }

    public static int UpdateStatus(int id, BorrowStatus state)
    {
      string sql = "UPDATE `borrow` SET status = @status, verify_time = @verify_time WHERE pk=@pk;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = id,
            status = (int) state,
            verify_time = DateTime.UtcNow
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][UpdateStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateSubAccount(int id, string subAccount)
    {
      string sql = "UPDATE `borrow` SET sub_account = @subAccount WHERE pk=@pk;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            pk = id,
            subAccount = subAccount
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowService][UpdateStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
