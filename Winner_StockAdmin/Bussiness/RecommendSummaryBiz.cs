// Decompiled with JetBrains decompiler
// Type: stockadmin.Business.RecommendSummaryBiz
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using stockadmin.Libs;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.RecommendSummary;

#nullable enable
namespace stockadmin.Business
{
  public class RecommendSummaryBiz
  {
    public static DataCountBase<RecommendSummaryList> GetRecommendSummaryList(
      RecommendSummaryFilter? filter,
      int page,
      int pageSize)
    {
      string whereSql = SqlTool.Build<RecommendSummaryFilter>(filter).Must("member.is_del = 0 and member.is_test_account = 0");
      DataCountBase<RecommendSummaryList> recommendSummaryList = RecommendRegisterService.FindRecommendSummaryList(page, pageSize, whereSql);
      return new DataCountBase<RecommendSummaryList>(recommendSummaryList.count, recommendSummaryList.data);
    }

    public static byte[]? DownloadRecommendSummaryList(RecommendSummaryFilter? filter)
    {
      return Exportlib.ExportExcel<RecommendSummaryList>(RecommendSummaryBiz.GetRecommendSummaryList(filter, 1, int.MaxValue).data);
    }
  }
}
