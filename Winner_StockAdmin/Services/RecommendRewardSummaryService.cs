// Decompiled with JetBrains decompiler
// Type: DB.Services.RecommendRewardSummaryService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.ReCommend;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RecommendRewardSummaryService
  {
    public static RecommendRewardSummaryDto Find(int pk)
    {
      string sql = "SELECT * FROM `recommend_reward_summary` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RecommendRewardSummaryDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][Find]" + ex.Message);
        return (RecommendRewardSummaryDto) null;
      }
    }

    public static List<RecommendRewardSummaryDto> FindAll()
    {
      string sql = "SELECT * FROM `recommend_reward_summary`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RecommendRewardSummaryDto>(sql).AsList<RecommendRewardSummaryDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][FindAll]" + ex.Message);
        return (List<RecommendRewardSummaryDto>) null;
      }
    }

    public static int FindPkAfterInsert(RecommendRewardSummaryDto source)
    {
      string sql = "INSERT INTO `recommend_reward_summary` (\n\t\t\t\t`member_fk`, `recommend_reward_fk`, `layer`, `year`, `month`, `monthly_members`, `monthly_borrow_fee`, `monthly_reward`)\n\t\t\t\tVALUES (@member_fk, @recommend_reward_fk, @layer, @year, @month, @monthly_members, @monthly_borrow_fee, @monthly_reward);\n\n                select @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RecommendRewardSummaryDto model)
    {
      string sql = "UPDATE `recommend_reward_summary` SET \n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`recommend_reward_fk` = @recommend_reward_fk,\n\t\t\t\t`layer` = @layer,\n\t\t\t\t`year` = @year,\n\t\t\t\t`month` = @month,\n\t\t\t\t`monthly_members` = @monthly_members,\n\t\t\t\t`monthly_borrow_fee` = @monthly_borrow_fee,\n\t\t\t\t`monthly_reward` = @monthly_reward\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `recommend_reward_summary` WHERE `pk` = @pk";
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
        LogLib.Log("[RecommendRewardSummaryService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    internal static int InertAgent(string yymm)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(650, 2);
      interpolatedStringHandler.AppendLiteral("INSERT INTO `recommend_reward_summary` (`member_fk`, `recommend_reward_fk`, `layer`, `yymm`, `monthly_members`, `monthly_borrow_fee`, `monthly_reward`)\n                (SELECT parent AS member_fk, recommend_reward.pk AS recommend_reward_fk, generation AS layer, '");
      interpolatedStringHandler.AppendFormatted(yymm);
      interpolatedStringHandler.AppendLiteral("' AS yymm, \n                COUNT(*) AS monthly_members, SUM(management_fee) AS `monthly_borrow_fee`, SUM(reward) AS monthly_reward \n                FROM recommend_reward_detail \n                INNER JOIN recommend_reward ON recommend_reward.member_fk = recommend_reward_detail.parent\n                Where recommend_reward_detail.yymm = '");
      interpolatedStringHandler.AppendFormatted(yymm);
      interpolatedStringHandler.AppendLiteral("'\n                GROUP BY parent, generation) ");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][InertAgent]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static RecommendRewardSummaryDto FindByYymmAndDeep(string yymm, int member, int deep)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(86, 3);
      interpolatedStringHandler.AppendLiteral("SELECT * FROM `recommend_reward_summary` WHERE member_fk = ");
      interpolatedStringHandler.AppendFormatted<int>(member);
      interpolatedStringHandler.AppendLiteral(" AND yymm = '");
      interpolatedStringHandler.AppendFormatted(yymm);
      interpolatedStringHandler.AppendLiteral("' AND layer = ");
      interpolatedStringHandler.AppendFormatted<int>(deep);
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<RecommendRewardSummaryDto>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][FindByYymmAndDeep]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }

    public static void UpdateByYymmAndDeep(MonthProfitModel data, int id)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(194, 4);
      interpolatedStringHandler.AppendLiteral("UPDATE `recommend_reward_summary` SET \n                   `monthly_members` = ");
      interpolatedStringHandler.AppendFormatted<int>(data.monthly_members);
      interpolatedStringHandler.AppendLiteral(",\n                   `monthly_borrow_fee` = ");
      interpolatedStringHandler.AppendFormatted<Decimal>(data.monthly_borrow_fee);
      interpolatedStringHandler.AppendLiteral(",\n                   `monthly_reward` = ");
      interpolatedStringHandler.AppendFormatted<Decimal>(data.monthly_reward);
      interpolatedStringHandler.AppendLiteral("\n                 WHERE `pk` = ");
      interpolatedStringHandler.AppendFormatted<int>(id);
      interpolatedStringHandler.AppendLiteral(" ");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          writeConntion.Execute(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardSummaryService][UpdateByYymmAndDeep]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }
  }
}
