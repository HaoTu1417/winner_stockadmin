// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RecommendRewardController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.RecommendReward;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RecommendReward")]
  public class RecommendRewardController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(11, 12)]
    public IActionResult Index(RecommendRewardFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      RecommendRewardVm recommendRewardVm = new RecommendRewardVm()
      {
        filter = filter ?? new RecommendRewardFilter()
      };
      try
      {
        List<RecommendRewardList> recommendRewardList = RecommendRewardBiz.GetRecommendRewardList(recommendRewardVm.filter);
        recommendRewardVm.list = recommendRewardList.ToPagedList<RecommendRewardList>(page, this.pageSize);
        return (IActionResult) this.View((object) recommendRewardVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) recommendRewardVm);
      }
    }
  }
}
