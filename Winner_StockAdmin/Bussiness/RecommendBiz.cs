// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RecommendBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Libs;
using stockadmin.Models.ReCommend;
using System;

#nullable enable
namespace stockadmin.Business
{
  public class RecommendBiz
  {
    public static void Profit(BorrowFeeDto rec)
    {
      if (rec == null || rec.fee_received == 0M)
        return;
      int pk = rec.pk;
      DateTime createTime = rec.create_time;
      RecommendProfitModel data = new RecommendProfitModel()
      {
        org = rec.member_fk,
        dt = createTime,
        yymm = createTime.ToString("yyMM"),
        money = (double) rec.fee_received,
        borrow_fee_fk = pk,
        currency = ConfigLib.Get("wallet_currency")
      };
      RecommendBiz.AssignProfit(1, rec.member_fk, data);
    }

    private static void AssignProfit(int deep, int man, RecommendProfitModel data)
    {
      if (deep > 3)
        return;
      try
      {
        MemberDto parent = MemberService.FindParent(man);
        if (parent == null)
          return;
        if (parent.is_test_account)
        {
          LogLib.Log("parent account " + parent.account + " is test account, no recommend profit");
        }
        else
        {
          RecommendRewardDetailDto source = new RecommendRewardDetailDto()
          {
            member_fk = data.org,
            parent = parent.pk,
            borrow_fee_fk = data.borrow_fee_fk,
            yymm = data.yymm,
            borrow_date = data.dt,
            currency = data.currency,
            management_fee = data.money,
            generation = deep,
            rate = RecommendBiz.GetProfitRate(deep)
          };
          source.reward = source.rate * source.management_fee;
          RecommendRewardDetailService.FindPkAfterInsert(source);
          RecommendBiz.SaveRecommendReward(data.yymm, parent.pk, (Decimal) source.reward);
          RecommendBiz.UpdateSummary(data.yymm, parent.pk, deep);
          RecommendBiz.AssignProfit(deep + 1, parent.pk, data);
        }
      }
      catch (Exception ex)
      {
        LogLib.Log("[RecommendBusiness][AssignProfit]" + ex.Message);
      }
    }

    private static void SaveRecommendReward(string yymm, int member, Decimal reward)
    {
      if (RecommendRewardService.FindByMemberAndYYMM(member, yymm) == null)
      {
        int int32 = Convert.ToInt32(yymm);
        int num1 = 2000 + int32 / 100;
        int num2 = int32 % 100;
        RecommendRewardService.FindPkAfterInsert(new RecommendRewardDto()
        {
          member_fk = member,
          yymm = yymm,
          year = num1,
          month = num2,
          currency = ConfigLib.Get("wallet_currency"),
          total_reward = reward,
          state = -1,
          create_time = DateTime.UtcNow
        });
      }
      else
        RecommendRewardService.UpdateReward(member, yymm);
    }

    private static void UpdateSummary(string yymm, int pk, int deep)
    {
      RecommendRewardSummaryDto byYymmAndDeep = RecommendRewardSummaryService.FindByYymmAndDeep(yymm, pk, deep);
      if (byYymmAndDeep == null)
      {
        RecommendRewardSummaryService.InertAgent(yymm);
      }
      else
      {
        MonthProfitModel profit = RecommendRewardDetailService.FindProfit(yymm, pk, deep);
        if (profit == null)
          return;
        RecommendRewardSummaryService.UpdateByYymmAndDeep(profit, byYymmAndDeep.pk);
      }
    }

    private static double GetProfitRate(int deep)
    {
      switch (deep)
      {
        case 1:
          return Convert.ToDouble(ConfigLib.Get("layer_rate_1"));
        case 2:
          return Convert.ToDouble(ConfigLib.Get("layer_rate_2"));
        case 3:
          return Convert.ToDouble(ConfigLib.Get("layer_rate_3"));
        default:
          return 0.0;
      }
    }
  }
}
