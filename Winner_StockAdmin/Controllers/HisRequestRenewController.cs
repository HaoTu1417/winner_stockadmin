// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.HisRequestRenewController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.HisRequestRenew;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("HisRequestRenew")]
  public class HisRequestRenewController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(358, 3)]
    public IActionResult Index(HisRequestRenewFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      HisRequestRenewVm hisRequestRenewVm = new HisRequestRenewVm()
      {
        filter = filter ?? new HisRequestRenewFilter()
      };
      try
      {
        List<HisRequestRenewList> requestRenewList = HisRequestRenewBiz.GetHisRequestRenewList(hisRequestRenewVm.filter);
        hisRequestRenewVm.list = requestRenewList.ToPagedList<HisRequestRenewList>(page, this.pageSize);
        return (IActionResult) this.View((object) hisRequestRenewVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) hisRequestRenewVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(358, 3)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<BorrowRequestDto>(HisRequestRenewBiz.Get(pk)));
    }
  }
}
