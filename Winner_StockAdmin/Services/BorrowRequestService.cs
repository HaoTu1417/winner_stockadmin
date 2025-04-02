// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowRequestService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.BorrowRequest;
using stockadmin.ViewModels.HisRequestRenew;
using stockadmin.ViewModels.RequestRenew;
using stockadmin.ViewModels.RequestStop;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class BorrowRequestService
  {
    public static BorrowRequestDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_request` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowRequestDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][Find]" + ex.Message);
        return (BorrowRequestDto) null;
      }
    }

    public static List<BorrowRequestDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_request`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowRequestDto>(sql).AsList<BorrowRequestDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindAll]" + ex.Message);
        return (List<BorrowRequestDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowRequestDto source)
    {
      string sql = "INSERT INTO `borrow_request` (\n\t\t\t\t`borrow_plan_fk`, `sub_account`, `borrow_fk`, `member_fk`, `type`, `borrow_fee`, `use_coupon`, `fee_received`, `borrow_duration`, `new_end_time`, `status`, `add_time`, `verify_time`)\n\t\t\t\tVALUES (@borrow_plan_fk, @sub_account, @borrow_fk, @member_fk, @type, @borrow_fee, @use_coupon, @fee_received, @borrow_duration, @new_end_time, @status, @add_time, @verify_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowRequestDto model)
    {
      string sql = "UPDATE `borrow_request` SET \n\t\t\t\t`borrow_plan_fk` = @borrow_plan_fk,\n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`borrow_fk` = @borrow_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`type` = @type,\n\t\t\t\t`borrow_fee` = @borrow_fee,\n\t\t\t\t`use_coupon` = @use_coupon,\n\t\t\t\t`fee_received` = @fee_received,\n\t\t\t\t`borrow_duration` = @borrow_duration,\n\t\t\t\t`new_end_time` = @new_end_time,\n\t\t\t\t`status` = @status,\n\t\t\t\t`add_time` = @add_time,\n\t\t\t\t`verify_time` = @verify_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_request` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowRequestService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<HisRequestRenewList> FindHisRequestRenewList(string whereSql = "")
    {
      string sql = "SELECT borrow_request.verify_time, borrow_request.status, borrow_request.borrow_fee, vw_trade_account.account, \n                vw_trade_account.member_name, borrow_request.add_time, borrow_request.sub_account, vw_trade_account.market, \n                vw_trade_account.loan_type, borrow_request.pk, borrow_request.borrow_duration, vw_trade_account.end_time, \n                borrow_request.new_end_time \n                FROM `borrow_request`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                " + whereSql + "\n                ORDER BY borrow_request.add_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<HisRequestRenewList>(sql).AsList<HisRequestRenewList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindHisRequestRenewList]" + ex.Message);
        return (List<HisRequestRenewList>) null;
      }
    }

    public static HisRequestRenewEditVm FindHisRequestRenewEditVm(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(616, 1);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_request.verify_time, borrow_request.status, borrow_request.borrow_fee, vw_trade_account.account, \n                vw_trade_account.member_name, borrow_request.add_time, borrow_request.sub_account, vw_trade_account.market, \n                vw_trade_account.loan_type, borrow_request.member_fk, borrow_request.pk, borrow_request.borrow_duration, \n                vw_trade_account.end_time, borrow_request.new_end_time \n                FROM `borrow_request`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                WHERE borrow_request.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<HisRequestRenewEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindHisRequestRenewEditVm]" + ex.Message);
        return (HisRequestRenewEditVm) null;
      }
    }

    public static List<RequestStopList> FindRequestStopList(string whereSql = "")
    {
      string sql = "SELECT borrow_request.pk, borrow_request.add_time, borrow_request.sub_account, vw_trade_account.loan_type, \n                vw_trade_account.init_money, vw_trade_account.balance, vw_trade_account.end_time, borrow_request.member_fk, \n                vw_trade_account.account, vw_trade_account.member_name, vw_trade_account.warningline, vw_trade_account.breakline \n                FROM `borrow_request`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                " + whereSql + " order by borrow_request.add_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RequestStopList>(sql).AsList<RequestStopList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindRequestStopList]" + ex.Message);
        return (List<RequestStopList>) null;
      }
    }

    public static RequestStopReview FindRequestStopReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(599, 1);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_request.add_time, borrow_request.sub_account, vw_trade_account.loan_type, vw_trade_account.init_money, \n                vw_trade_account.balance, vw_trade_account.end_time, borrow_request.member_fk, vw_trade_account.account, vw_trade_account.member_name, \n                borrow_request.pk, vw_trade_account.warningline, vw_trade_account.breakline, borrow_request.status, borrow_request.verify_time \n                FROM `borrow_request`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                WHERE borrow_request.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RequestStopReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindRequestStopReview]" + ex.Message);
        return (RequestStopReview) null;
      }
    }

    public static List<RequestRenewList> FindRequestRenewList(string whereSql = "")
    {
      string sql = "SELECT borrow_request.add_time, borrow_request.sub_account, vw_trade_account.loan_type, borrow_request.member_fk, \n                vw_trade_account.account, vw_trade_account.member_name, borrow_request.pk, borrow_request.borrow_duration, vw_trade_account.end_time, \n                borrow_request.new_end_time, borrow_request.borrow_fee, vw_trade_account.market, vw_trade_account.margin, vw_trade_account.balance, \n                vw_trade_account.warningline, vw_trade_account.breakline \n                FROM `borrow_request`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                " + whereSql + " order by borrow_request.add_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RequestRenewList>(sql).AsList<RequestRenewList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindRequestRenewList]" + ex.Message);
        return (List<RequestRenewList>) null;
      }
    }

    public static RequestRenewReview FindRequestRenewReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(771, 1);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_request.add_time, borrow_request.sub_account, vw_trade_account.loan_type, borrow_request.member_fk, \n                    vw_trade_account.account, vw_trade_account.member_name, borrow_request.pk, borrow_request.borrow_duration, \n                    vw_trade_account.end_time, borrow_request.new_end_time, borrow_request.borrow_fee, vw_trade_account.market, \n                    vw_trade_account.margin, vw_trade_account.balance, vw_trade_account.warningline, vw_trade_account.breakline, \n                    borrow_request.status, borrow_request.verify_time \n                    FROM `borrow_request` \n                    INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_request.sub_account\n                    WHERE borrow_request.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RequestRenewReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][FindRequestRenewReview]" + ex.Message);
        return (RequestRenewReview) null;
      }
    }

    public static List<StopTradingSearchList> GetStopTradingList(string where = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(432, 1);
      interpolatedStringHandler.AppendLiteral("SELECT  b.pk AS pk, b.member_fk AS member_fk, m.real_name AS member_real_name, b.sub_account AS sub_account, b.`status` AS status, ");
      interpolatedStringHandler.AppendLiteral("t.end_time AS trade_account_end_time, b.add_time AS add_time, b.verify_time AS verify_time, p.name AS borrow_plane_name FROM borrow_request AS b ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN `member` AS m ON b.member_fk = m.pk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN `trade_account` AS t ON m.pk = t.member_fk LEFT JOIN `borrow_plan` AS p ON b.borrow_plan_fk = p.pk ");
      interpolatedStringHandler.AppendFormatted(where);
      interpolatedStringHandler.AppendLiteral(" ");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StopTradingSearchList>(stringAndClear).AsList<StopTradingSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][GetStopTradingList]" + ex.Message);
        return (List<StopTradingSearchList>) null;
      }
    }

    public static int UpdateState(int id, bool state)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE `borrow_request` SET status = @status,verify_time=@verify_time\n                                WHERE pk=@pk;", (object) new
          {
            pk = id,
            status = (state ? 1 : 2),
            verify_time = DateTime.UtcNow
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][UpdateState]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<StockRenewalSearchList> GetRenewal(string where = "")
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(476, 1);
      interpolatedStringHandler.AppendLiteral("SELECT ");
      interpolatedStringHandler.AppendLiteral("b.member_fk AS member_fk, m.real_name AS member_real_name, b.sub_account AS sub_account, b.`status` AS status, t.end_time AS trade_account_end_time, b.add_time AS add_time, b.verify_time AS verify_time, p.name AS borrow_plan_name, b.borrow_fee AS borrow_fee, b.use_coupon AS use_coupon ");
      interpolatedStringHandler.AppendLiteral("FROM `borrow_request` AS b ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN `member` AS m ON b.member_fk = m.pk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN `trade_account` AS t ON m.pk = t.member_fk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN `borrow_plan` AS p ON p.pk = b.borrow_plan_fk ");
      interpolatedStringHandler.AppendFormatted(where);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<StockRenewalSearchList>(stringAndClear).AsList<StockRenewalSearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowRequestService][GetRenewal]" + ex.Message);
        return (List<StockRenewalSearchList>) null;
      }
    }
  }
}
