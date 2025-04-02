// Decompiled with JetBrains decompiler
// Type: DB.Services.RecommendRewardService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.RecommendReward;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RecommendRewardService
  {
    public static RecommendRewardDto Find(int pk)
    {
      string sql = "SELECT * FROM `recommend_reward` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RecommendRewardDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][Find]" + ex.Message);
        return (RecommendRewardDto) null;
      }
    }

    public static List<RecommendRewardDto> FindAll()
    {
      string sql = "SELECT * FROM `recommend_reward`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RecommendRewardDto>(sql).AsList<RecommendRewardDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][FindAll]" + ex.Message);
        return (List<RecommendRewardDto>) null;
      }
    }

    public static RecommendRewardDto FindByMemberAndYYMM(int member, string yymm)
    {
      string sql = "SELECT * FROM `recommend_reward` WHERE `member_fk` = @mem AND yymm = @yymm";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            mem = member,
            yymm = yymm
          });
          return readConnection.QueryFirstOrDefault<RecommendRewardDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][FindByMemberAndYYMM]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static int FindPkAfterInsert(RecommendRewardDto source)
    {
      string sql = "INSERT INTO `recommend_reward` (\n\t\t\t\t`member_fk`, `year`, `month`, `yymm`, `currency`, `total_reward`, `state`, `withdraw`, `paydate`, `note`, `create_time`)\n\t\t\t\tVALUES (@member_fk, @year, @month, @yymm, @currency, @total_reward, @state, @withdraw, @paydate, @note, @create_time);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RecommendRewardDto model)
    {
      string sql = "UPDATE `recommend_reward` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`year` = @year,\n\t\t\t\t`month` = @month,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`total_reward` = @total_reward,\n\t\t\t\t`state` = @state,\n\t\t\t\t`withdraw` = @withdraw,\n\t\t\t\t`paydate` = @paydate,\n\t\t\t\t`note` = @note,\n\t\t\t\t`create_time` = @create_time\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `recommend_reward` WHERE `pk` = @pk";
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
        LogLib.Log("[RecommendRewardService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<RecommendRewardList> FindRecommendRewardList(string whereSql = "")
    {
      string sql = "SELECT recommend_reward.pk, member.account, member.nickname, recommend_reward.year, recommend_reward.month, \n                recommend_reward.currency, recommend_reward.total_reward, recommend_reward.state, recommend_reward.withdraw, \n                recommend_reward.paydate, recommend_reward.create_time \n                FROM `recommend_reward`\n                INNER JOIN `member` on member.pk = recommend_reward.member_fk\n                " + whereSql;
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RecommendRewardList>(sql).AsList<RecommendRewardList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][FindRecommendRewardList]" + ex.Message);
        return (List<RecommendRewardList>) null;
      }
    }

    public static Decimal GetTotalRewardByMemberFk(int member_fk)
    {
      string sql = "\nSELECT IFNULL(SUM(total_reward), 0) \nFROM `recommend_reward` \nWHERE `member_fk` = @member_fk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            member_fk = member_fk
          });
          return readConnection.QuerySingle<Decimal>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static RecommendRewardDto FindByYearMonth(int member_fk, string yymm)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(69, 2);
      interpolatedStringHandler.AppendLiteral("SELECT * FROM `recommend_reward` WHERE `member_fk` = ");
      interpolatedStringHandler.AppendFormatted<int>(member_fk);
      interpolatedStringHandler.AppendLiteral(" AND `yymm` = '");
      interpolatedStringHandler.AppendFormatted(yymm);
      interpolatedStringHandler.AppendLiteral("'");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RecommendRewardDto>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][FindByYearMonth]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    internal static void UpdateReward(int member, string yymm)
    {
      string sql = "UPDATE `recommend_reward` SET total_reward = \n            (SELECT SUM(recommend_reward_detail.reward) FROM recommend_reward_detail\n              WHERE recommend_reward_detail.parent = @member\n              AND recommend_reward_detail.yymm = @yymm)\n            WHERE yymm = @yymm AND member_fk = @member AND state <= 0";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            yymm = yymm,
            member = member
          });
          readConnection.Execute(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardService][UpdateReward]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
