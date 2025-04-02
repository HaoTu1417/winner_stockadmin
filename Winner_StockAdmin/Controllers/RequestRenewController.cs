// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RequestRenewController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.RequestRenew;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RequestRenew")]
  public class RequestRenewController : BaseController
  {
    public void SetSelect()
    {
    }

    [MenuFilter(355, 3)]
    public IActionResult Index(RequestRenewFilter filter, int page = 1)
    {
      this.SetSelect();
      RequestRenewVm requestRenewVm = new RequestRenewVm()
      {
        filter = filter ?? new RequestRenewFilter()
      };
      try
      {
        requestRenewVm.list = RequestRenewBiz.GetRequestRenewList(requestRenewVm.filter);
        return (IActionResult) this.View((object) requestRenewVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) requestRenewVm);
      }
    }

    [UseFilter(355, 3)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<BorrowRequestDto>(RequestRenewBiz.Get(pk)));
    }

    public IActionResult PostEdit(BorrowRequestDto req)
    {
      this.SetSelect();
      try
      {
        RequestRenewBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [MenuFilter(355, 3)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<RequestRenewReview>(RequestRenewBiz.GetReview(pk)));
    }

    public IActionResult PostReview(BorrowRequestDto req, bool result)
    {
      try
      {
        RequestRenewBiz.RenewalVerify(req.pk, result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) req);
      }
    }
  }
}
