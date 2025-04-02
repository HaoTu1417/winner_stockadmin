// Decompiled with JetBrains decompiler
// Type: DB.Services.BorrowAddmoneyService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.BorrowAddmoney;
using stockadmin.ViewModels.BorrowAddMoney;
using stockadmin.ViewModels.HisAddmoney;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class BorrowAddmoneyService
  {
    public static BorrowAddmoneyDto Find(int pk)
    {
      string sql = "SELECT * FROM `borrow_addmoney` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<BorrowAddmoneyDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][Find]" + ex.Message);
        return (BorrowAddmoneyDto) null;
      }
    }

    public static List<BorrowAddmoneyDto> FindAll()
    {
      string sql = "SELECT * FROM `borrow_addmoney`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowAddmoneyDto>(sql).AsList<BorrowAddmoneyDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindAll]" + ex.Message);
        return (List<BorrowAddmoneyDto>) null;
      }
    }

    public static int FindPkAfterInsert(BorrowAddmoneyDto source)
    {
      string sql = "INSERT INTO `borrow_addmoney` (\n\t\t\t\t`sub_account`, `member_fk`, `currency`, `exchange`, `money`, `freeze`, `status`, `add_time`, `verify_time`, `target_uid`, `target_name`)\n\t\t\t\tVALUES (@sub_account, @member_fk, @currency, @exchange, @money, @freeze, @status, @add_time, @verify_time, @target_uid, @target_name);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(BorrowAddmoneyDto model)
    {
      string sql = "UPDATE `borrow_addmoney` SET \n\t\t\t\t`sub_account` = @sub_account,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`exchange` = @exchange,\n\t\t\t\t`money` = @money,\n\t\t\t\t`freeze` = @freeze,\n\t\t\t\t`status` = @status,\n\t\t\t\t`add_time` = @add_time,\n\t\t\t\t`verify_time` = @verify_time,\n\t\t\t\t`target_uid` = @target_uid,\n\t\t\t\t`target_name` = @target_name\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `borrow_addmoney` WHERE `pk` = @pk";
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
        LogLib.Log("[BorrowAddmoneyService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<HisAddmoneyList> FindHisAddmoneyList(
      int page,
      int pageSize,
      string whereSql = "",
      string lang = "VN")
    {
      string sql = "\n                            SELECT \n                            COUNT(*) AS count\n                            FROM `borrow_addmoney`\n                            INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addmoney.sub_account\n                            INNER JOIN member on member.pk = borrow_addmoney.member_fk\n                            " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(782, 3);
      interpolatedStringHandler.AppendLiteral("SELECT vw_trade_account.account, vw_trade_account.member_name, borrow_addmoney.sub_account, vw_trade_account.borrow_type as loan_type,\n                vw_trade_account.market, borrow_addmoney.add_time, borrow_addmoney.money, borrow_addmoney.pk, borrow_addmoney.status,\n                borrow_addmoney.verify_time, borrow_addmoney.target_name, member.is_test_account\n                FROM `borrow_addmoney`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addmoney.sub_account\n\t\t\t\tINNER JOIN borrow_plan ON borrow_plan.pk=vw_trade_account.borrow_plan_fk\n                INNER JOIN member on member.pk = borrow_addmoney.member_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY borrow_addmoney.add_time DESC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<HisAddmoneyList>(readConnection.QuerySingle<int>(sql), (IEnumerable<HisAddmoneyList>) readConnection.Query<HisAddmoneyList>(stringAndClear).AsList<HisAddmoneyList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindHisAddmoneyList]" + ex.Message);
        return new DataCountBase<HisAddmoneyList>();
      }
    }

    public static HisAddmoneyEditVm FindHisAddmoneyEditVm(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(495, 1);
      interpolatedStringHandler.AppendLiteral("SELECT vw_trade_account.account, vw_trade_account.member_name, borrow_addmoney.sub_account, vw_trade_account.loan_type,\n                vw_trade_account.market, borrow_addmoney.add_time, borrow_addmoney.money, borrow_addmoney.status, borrow_addmoney.verify_time,\n                borrow_addmoney.target_name\n                FROM `borrow_addmoney`\n                INNER JOIN vw_trade_account on vw_trade_account.sub_account = borrow_addmoney.sub_account\n                WHERE borrow_addmoney.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<HisAddmoneyEditVm>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindHisAddmoneyEditVm]" + ex.Message);
        return (HisAddmoneyEditVm) null;
      }
    }

    public static List<BorrowAddmoneyList> FindBorrowAddmoneyList(string whereSql = "")
    {
      string sql = "SELECT borrow_addmoney.add_time, borrow_addmoney.sub_account, borrow_addmoney.money, borrow_addmoney.currency,\n                vw_trade_account.status as trade_status, vw_trade_account.end_time, vw_trade_account.market, vw_trade_account.init_money,\n                vw_trade_account.balance, vw_trade_account.warningline, vw_trade_account.breakline, vw_trade_account.loan_type,\n                borrow_addmoney.member_fk, vw_trade_account.account, vw_trade_account.member_name, borrow_addmoney.pk\n                FROM `borrow_addmoney`\n                INNER JOIN vw_trade_account ON vw_trade_account.sub_account = borrow_addmoney.sub_account\n                " + whereSql + "\n                ORDER BY borrow_addmoney.add_time DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<BorrowAddmoneyList>(sql).AsList<BorrowAddmoneyList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindBorrowAddmoneyList]" + ex.Message);
        return (List<BorrowAddmoneyList>) null;
      }
    }

    public static BorrowAddmoneyReview FindBorrowAddmoneyReview(int pk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(875, 1);
      interpolatedStringHandler.AppendLiteral("SELECT borrow_addmoney.add_time, borrow_addmoney.sub_account, borrow_addmoney.money, borrow_addmoney.currency,\n                vw_trade_account.status as trade_status, vw_trade_account.end_time, vw_trade_account.market, vw_trade_account.init_money,\n                vw_trade_account.balance, vw_trade_account.warningline, vw_trade_account.breakline, vw_trade_account.loan_type,\n                borrow_addmoney.member_fk, vw_trade_account.account, vw_trade_account.member_name, borrow_addmoney.pk, borrow_addmoney.exchange,\n                borrow_addmoney.freeze, borrow_addmoney.status, borrow_addmoney.verify_time, borrow_addmoney.target_uid,\n                borrow_addmoney.target_name\n                FROM `borrow_addmoney`\n                INNER JOIN vw_trade_account ON vw_trade_account.sub_account = borrow_addmoney.sub_account\n                where borrow_addmoney.pk = ");
      interpolatedStringHandler.AppendFormatted<int>(pk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<BorrowAddmoneyReview>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][FindBorrowAddmoneyReview]" + ex.Message);
        return (BorrowAddmoneyReview) null;
      }
    }

    public static List<AddMoneySearchList> GetAddMoney(string where)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(511, 1);
      interpolatedStringHandler.AppendLiteral("SELECT b.pk as pk, b.member_fk AS member_fk, m.real_name AS member_real_name, b.sub_account AS sub_account, b.status AS status, v.currency AS currency, b.money AS money, v.balance AS balance, v.warningline AS warningline, v.breakline AS breakline, b.exchange AS exchange, b.freeze AS freeze, b.add_time AS add_time, b.verify_time AS verify_time, b.target_name AS target_name ");
      interpolatedStringHandler.AppendLiteral("FROM borrow_addmoney AS b ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN member AS m ON m.pk = b.member_fk ");
      interpolatedStringHandler.AppendLiteral("LEFT JOIN vw_trade_account AS v ON v.sub_account = b.sub_account ");
      interpolatedStringHandler.AppendFormatted(where);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<AddMoneySearchList>(stringAndClear).AsList<AddMoneySearchList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][GetAddMoney]" + ex.Message);
        return (List<AddMoneySearchList>) null;
      }
    }

    public static int UpdateStatus(int id, bool state)
    {
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute("UPDATE `borrow_addmoney` SET status = @status, verify_time = @verify_time\nWHERE pk=@pk;", (object) new
          {
            pk = id,
            status = (state ? 1 : 2),
            verify_time = DateTime.UtcNow
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[BorrowAddmoneyService][UpdateStatus]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
