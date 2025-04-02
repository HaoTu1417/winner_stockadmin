// Decompiled with JetBrains decompiler
// Type: DB.Services.RecommendRegisterService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.RecommendRegister;
using stockadmin.ViewModels.RecommendSummary;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RecommendRegisterService
  {
    public static RecommendRegisterDto Find(int invitee_fk)
    {
      string sql = "SELECT * FROM `recommend_register` WHERE `invitee_fk` = @invitee_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            invitee_fk = invitee_fk
          });
          return readConnection.QueryFirstOrDefault<RecommendRegisterDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][Find]" + ex.Message);
        return (RecommendRegisterDto) null;
      }
    }

    public static List<RecommendRegisterDto> FindAll()
    {
      string sql = "SELECT * FROM `recommend_register`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RecommendRegisterDto>(sql).AsList<RecommendRegisterDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][FindAll]" + ex.Message);
        return (List<RecommendRegisterDto>) null;
      }
    }

    public static RecommendRegisterDto FindByInviteeFk(int member_fk)
    {
      string sql = "SELECT * FROM `recommend_register` WHERE `invitee_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QueryFirstOrDefault<RecommendRegisterDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static int Insert(RecommendRegisterDto model)
    {
      string sql = "INSERT INTO `recommend_register` (\n\t\t\t\t`member_fk`, `invitee_fk`, `register_date`, `first_borrow_date`)\n\t\t\t\tVALUES (@member_fk, @invitee_fk, @register_date, @first_borrow_date); ";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][Insert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RecommendRegisterDto model)
    {
      string sql = "UPDATE `recommend_register` SET \n\t\t\t\t`register_date` = @register_date,\n\t\t\t\t`first_borrow_date` = @first_borrow_date\n\t\t\t\t WHERE `invitee_fk` = @invitee_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFirstBorrowDate(RecommendRegisterDto model)
    {
      string sql = "UPDATE `recommend_register` SET \n\t\t\t\t`first_borrow_date` = @first_borrow_date\n\t\t\t\t WHERE `invitee_fk` = @invitee_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) new
          {
            invitee_fk = model.invitee_fk,
            first_borrow_date = DateTime.UtcNow
          });
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][UpdateFirstBorrowDate]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int invitee_fk)
    {
      string sql = "DELETE FROM `recommend_register` WHERE `invitee_fk` = @invitee_fk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            invitee_fk = invitee_fk
          });
          return writeConntion.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static DataCountBase<RecommendSummaryList> FindRecommendSummaryList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                SELECT COUNT(0) AS count\n                FROM (\n                    SELECT \n                        COUNT(0) AS count\n                        FROM `recommend_reward_summary` r0\n                        LEFT JOIN `recommend_reward_summary` r1 ON r0.member_fk = r1.member_fk AND r1.layer = 1 AND r0.yymm = r1.yymm\n                        LEFT JOIN `recommend_reward_summary` r2 ON r0.member_fk = r2.member_fk AND r2.layer = 2 AND r0.yymm = r2.yymm\n                        LEFT JOIN `recommend_reward_summary` r3 ON r0.member_fk = r3.member_fk AND r3.layer = 3 AND r0.yymm = r3.yymm\n                        LEFT JOIN `member` ON member.pk = r0.member_fk\n                    " + whereSql + "\n                        GROUP BY account, r0.yymm\n                    ) AS subquery;";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1283, 3);
      interpolatedStringHandler.AppendLiteral("\n                SELECT member.account, member.real_name, (IFNULL(r1.monthly_reward,0) + IFNULL(r2.monthly_reward,0) + IFNULL(r3.monthly_reward,0)) AS total_profit, member.is_test_account,\n                CONCAT('20', SUBSTRING(r0.yymm, 1, 2), '-', SUBSTRING(r0.yymm, 3, 2)) AS profit_date, \n                       r1.monthly_members AS layer1_child_count, r1.monthly_reward AS layer1_profit,\n                       r2.monthly_members AS layer2_child_count, r2.monthly_reward AS layer2_profit,\n                       r3.monthly_members AS layer3_child_count, r3.monthly_reward AS layer3_profit\n                    FROM `recommend_reward_summary` r0\n                    LEFT JOIN `recommend_reward_summary` r1 ON r0.member_fk = r1.member_fk AND r1.layer = 1 AND r0.yymm = r1.yymm\n                    LEFT JOIN `recommend_reward_summary` r2 ON r0.member_fk = r2.member_fk AND r2.layer = 2 AND r0.yymm = r2.yymm\n                    LEFT JOIN `recommend_reward_summary` r3 ON r0.member_fk = r3.member_fk AND r3.layer = 3 AND r0.yymm = r3.yymm\n                    LEFT JOIN `member` ON member.pk = r0.member_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                GROUP BY account, r0.yymm\n                ORDER BY r0.yymm DESC, r0.layer ASC, `member`.Pk DESC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral("; ");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<RecommendSummaryList>(readConnection.QuerySingle<int>(sql), (IEnumerable<RecommendSummaryList>) readConnection.Query<RecommendSummaryList>(stringAndClear).AsList<RecommendSummaryList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][FindRecommendSummaryList]" + ex.Message);
        return new DataCountBase<RecommendSummaryList>();
      }
    }

    public static DataCountBase<RecommendRegisterList> FindRecommendRegisterList(
      int page,
      int pageSize,
      string whereSql = "")
    {
      string sql = "\n                SELECT \n                    COUNT(*) AS count\n                    FROM `recommend_register`\n                    LEFT JOIN `member` ON member.pk = recommend_register.invitee_fk\n                    LEFT JOIN `member` inviter ON inviter.pk = recommend_register.member_fk\n                " + whereSql + ";";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1124, 3);
      interpolatedStringHandler.AppendLiteral("\n                SELECT inviter.account AS inviter_account, member.account AS invitee_account, member.real_name AS invitee_realname,\n                       (SELECT SUM(borrow.total_interest) FROM borrow WHERE member.pk = borrow.member_fk AND (borrow.status = 1 OR borrow.status = 2)) AS total_management_fee,\n                       (SELECT SUM(if(wallet_recharge.status=1, wallet_recharge.wallet_amount, 0)) FROM wallet_recharge WHERE member.pk = wallet_recharge.member_fk) AS total_recharge,\n                       (SELECT SUM(if(wallet_withdraw.status=1, wallet_withdraw.wallet_amount, 0)) FROM wallet_withdraw WHERE member.pk = wallet_withdraw.member_fk) AS total_withdraw,\n                       member.create_time AS create_date, recommend_register.first_borrow_date, member.is_test_account\n                    FROM `recommend_register`\n                    LEFT JOIN `member` ON member.pk = recommend_register.invitee_fk\n                    LEFT JOIN `member` inviter ON inviter.pk = recommend_register.member_fk\n                ");
      interpolatedStringHandler.AppendFormatted(whereSql);
      interpolatedStringHandler.AppendLiteral("\n                ORDER BY create_date DESC\n                LIMIT ");
      interpolatedStringHandler.AppendFormatted<int>(pageSize);
      interpolatedStringHandler.AppendLiteral("\n                OFFSET ");
      interpolatedStringHandler.AppendFormatted<int>((page - 1) * pageSize);
      interpolatedStringHandler.AppendLiteral(";");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return new DataCountBase<RecommendRegisterList>(readConnection.QuerySingle<int>(sql), (IEnumerable<RecommendRegisterList>) readConnection.Query<RecommendRegisterList>(stringAndClear).AsList<RecommendRegisterList>());
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][FindRecommendRegisterList]" + ex.Message);
        return new DataCountBase<RecommendRegisterList>();
      }
    }

    public static RecommendRegisterList FindRecommendRegister(int beinvite)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(614, 1);
      interpolatedStringHandler.AppendLiteral("SELECT recommend_register.invitee_fk, member.create_time AS create_date, member.admin_user_fk, member.account, \n                    member.real_name, member.id_auth, member.level_id, member.invitation_code, recommend_register.first_borrow_date, \n                    invite.account AS Inviteaccount, invite.nickname AS Invitenickname \n                    FROM `recommend_register`\n                    INNER JOIN `member` ON member.pk = recommend_register.invitee_fk\n                    INNER JOIN `member` invite ON invite.pk = recommend_register.member_fk\n                    WHERE recommend_register.invitee_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(beinvite);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RecommendRegisterList>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][FindRecommendRegister]" + ex.Message);
        return (RecommendRegisterList) null;
      }
    }

    public static int GetTotalInvitations(int member_fk)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(53, 1);
      interpolatedStringHandler.AppendLiteral("SELECT COUNT(*) WHERE recommend_register.member_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(member_fk);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.ExecuteScalar<int>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRegisterService][GetTotalInvitations]" + ex.Message);
        return 0;
      }
    }
  }
}
