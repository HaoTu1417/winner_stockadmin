// Decompiled with JetBrains decompiler
// Type: DB.Services.RecommendRewardDetailService
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Dapper;
using Models.Dto;
using MySqlConnector;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models.ReCommend;
using stockadmin.ViewModels.RewardDetail;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace DB.Services
{
  public class RecommendRewardDetailService
  {
    public static RecommendRewardDetailDto Find(int pk)
    {
      string sql = "SELECT * FROM `recommend_reward_detail` WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
        {
          DynamicParameters parameters = DapperMysql.GetParameters((object) new
          {
            pk = pk
          });
          return readConnection.QueryFirstOrDefault<RecommendRewardDetailDto>(sql, (object) parameters);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][Find]" + ex.Message);
        return (RecommendRewardDetailDto) null;
      }
    }

    public static List<RecommendRewardDetailDto> FindAll()
    {
      string sql = "SELECT * FROM `recommend_reward_detail`";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RecommendRewardDetailDto>(sql).AsList<RecommendRewardDetailDto>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][FindAll]" + ex.Message);
        return (List<RecommendRewardDetailDto>) null;
      }
    }

    public static int FindPkAfterInsert(RecommendRewardDetailDto source)
    {
      string sql = "INSERT INTO `recommend_reward_detail` (\n\t\t\t\t`recommend_reward_fk`, `member_fk`, `parent`, `borrow_fee_fk`, `yymm`, `borrow_date`, `currency`, `management_fee`, `generation`, `rate`, `reward`)\n\t\t\t\tVALUES (@recommend_reward_fk, @member_fk, @parent, @borrow_fee_fk, @yymm, @borrow_date, @currency, @management_fee, @generation, @rate, @reward); \n\n\t\t\tselect @@IDENTITY;";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.ExecuteScalar<int>(sql, (object) source);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][FindPkAfterInsert]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int UpdateFull(RecommendRewardDetailDto model)
    {
      string sql = "UPDATE `recommend_reward_detail` SET \n\t\t\t\t`recommend_reward_fk` = @recommend_reward_fk,\n\t\t\t\t`member_fk` = @member_fk,\n\t\t\t\t`parent` = @parent,\n\t\t\t\t`borrow_fee_fk` = @borrow_fee_fk,\n\t\t\t\t`borrow_date` = @borrow_date,\n\t\t\t\t`currency` = @currency,\n\t\t\t\t`management_fee` = @management_fee,\n\t\t\t\t`generation` = @generation,\n\t\t\t\t`rate` = @rate,\n\t\t\t\t`reward` = @reward\t\t\t\t\n\t\t\t\t WHERE `pk` = @pk";
      try
      {
        using (MySqlConnection writeConntion = DapperMysql.GetWriteConntion())
          return writeConntion.Execute(sql, (object) model);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][UpdateFull]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static int Remove(int pk)
    {
      string sql = "DELETE FROM `recommend_reward_detail` WHERE `pk` = @pk";
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
        LogLib.Log("[RecommendRewardDetailService][Remove]" + ex.Message);
        throw new AppException(1030, "write_db_exception");
      }
    }

    public static List<RewardDetailList> FindRewardDetailList(string whereSql)
    {
      string sql = "SELECT m2.account AS recommend_account, recommend_reward_detail.borrow_date, m1.account, m1.real_name, borrow_fee.sub_account, \n                recommend_reward_detail.generation AS generation, recommend_reward_detail.management_fee, recommend_reward_detail.rate, \n                recommend_reward_detail.reward, borrow_fee.type \n                FROM `recommend_reward_detail`\n                LEFT JOIN `member` m1 ON m1.pk = recommend_reward_detail.member_fk\n                LEFT JOIN `member` m2 ON m2.pk = recommend_reward_detail.parent\n                LEFT JOIN borrow_fee ON borrow_fee.pk = recommend_reward_detail.borrow_fee_fk\n                " + whereSql + "\n                ORDER BY recommend_reward_detail.borrow_date DESC";
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.Query<RewardDetailList>(sql).AsList<RewardDetailList>();
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][FindRewardDetailList]" + ex.Message);
        return (List<RewardDetailList>) null;
      }
    }

    public static MonthProfitModel FindProfit(string yymm, int member, int deep)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(531, 3);
      interpolatedStringHandler.AppendLiteral("SELECT generation, COUNT(DISTINCT(recommend_reward_detail.member_fk)) AS monthly_members, SUM(management_fee) AS `monthly_borrow_fee`, SUM(reward) AS monthly_reward \n                FROM recommend_reward_detail \n                INNER JOIN recommend_reward ON recommend_reward_detail.parent = recommend_reward.member_fk AND recommend_reward_detail.yymm = recommend_reward.yymm\n                WHERE recommend_reward_detail.yymm = '");
      interpolatedStringHandler.AppendFormatted(yymm);
      interpolatedStringHandler.AppendLiteral("' AND recommend_reward_detail.parent = ");
      interpolatedStringHandler.AppendFormatted<int>(member);
      interpolatedStringHandler.AppendLiteral(" AND generation = ");
      interpolatedStringHandler.AppendFormatted<int>(deep);
      interpolatedStringHandler.AppendLiteral("\n                GROUP BY parent, generation");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      try
      {
        using (MySqlConnection readConnection = DapperMysql.GetReadConnection())
          return readConnection.QueryFirstOrDefault<MonthProfitModel>(stringAndClear);
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendRewardDetailService][FindProfit]" + ex.Message);
        throw new AppException(1040, "read_db_exception");
      }
    }
  }
}
