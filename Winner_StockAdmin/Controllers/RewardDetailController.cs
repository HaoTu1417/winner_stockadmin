// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RewardDetailController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.RewardDetail;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RewardDetail")]
  public class RewardDetailController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(12, 12)]
    public IActionResult Index(RewardDetailFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      RewardDetailVm rewardDetailVm = new RewardDetailVm()
      {
        filter = filter ?? new RewardDetailFilter()
      };
      try
      {
        List<RewardDetailList> rewardDetailList = RewardDetailBiz.GetRewardDetailList(filter);
        rewardDetailVm.list = rewardDetailList.ToPagedList<RewardDetailList>(page, this.pageSize);
        return (IActionResult) this.View((object) rewardDetailVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((string) null);
      }
    }

    [UseFilter(16, 12)]
    public IActionResult Download(RewardDetailFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(RewardDetailBiz.DownloadRewardDetailList(filter), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RewardDetail.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }
  }
}
