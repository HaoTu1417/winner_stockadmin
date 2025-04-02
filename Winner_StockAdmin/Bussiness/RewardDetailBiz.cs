// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RewardDetailBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Models.Dto;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.RewardDetail;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace stockadmin.Business
{
  public class RewardDetailBiz
  {
    public static List<RewardDetailList> GetRewardDetailList(RewardDetailFilter filter)
    {
      List<RewardDetailList> rewardDetailList = RecommendRewardDetailService.FindRewardDetailList(SqlTool.Build<RewardDetailFilter>(filter));
      return rewardDetailList == null ? (List<RewardDetailList>) null : rewardDetailList.Select<RewardDetailList, RewardDetailList>((Func<RewardDetailList, RewardDetailList>) (recommendReward => PublicTool.convertUtcToLocalTime<RewardDetailList>(recommendReward))).ToList<RewardDetailList>();
    }

    public static RecommendRewardDetailDto Get(int pk) => RecommendRewardDetailService.Find(pk);

    public static void PostCreate(RecommendRewardDetailDto req)
    {
      if (RecommendRewardDetailService.FindPkAfterInsert(req) == 0)
        throw new AppException(3020, "insert_record_false");
    }

    public static void PostEdit(RecommendRewardDetailDto req)
    {
      if (RecommendRewardDetailService.UpdateFull(req) == 0)
        throw new AppException(3010, "record_update_false");
    }

    public static void Delete(int pk) => RecommendRewardDetailService.Remove(pk);

    public static byte[]? DownloadRewardDetailList(RewardDetailFilter? filter)
    {
      return Exportlib.ExportExcel<RewardDetailList>((IEnumerable<RewardDetailList>) RewardDetailBiz.GetRewardDetailList(filter));
    }

    public void Test()
    {
    }
  }
}
