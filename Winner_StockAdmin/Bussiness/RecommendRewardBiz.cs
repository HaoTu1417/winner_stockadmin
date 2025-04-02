// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RecommendRewardBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.RecommendReward;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class RecommendRewardBiz
  {
    public static List<RecommendRewardList> GetRecommendRewardList(RecommendRewardFilter? filter)
    {
      List<RecommendRewardList> recommendRewardList = RecommendRewardService.FindRecommendRewardList(SqlTool.Build<RecommendRewardFilter>(filter));
      return recommendRewardList == null ? (List<RecommendRewardList>) null : recommendRewardList.Select<RecommendRewardList, RecommendRewardList>((Func<RecommendRewardList, RecommendRewardList>) (recommendReward => PublicTool.convertUtcToLocalTime<RecommendRewardList>(recommendReward))).ToList<RecommendRewardList>();
    }

    public static RecommendRewardDto Get(int pk) => RecommendRewardService.Find(pk);

    public static void PostCreate(RecommendRewardDto req)
    {
      if (RecommendRewardService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(RecommendRewardDto req)
    {
      if (RecommendRewardService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => RecommendRewardService.Remove(pk);
  }
}
