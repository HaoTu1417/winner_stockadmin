// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RequestStopController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.RequestStop;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RequestStop")]
  public class RequestStopController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(366, 3)]
    public IActionResult Index(RequestStopFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      RequestStopVm requestStopVm = new RequestStopVm()
      {
        filter = filter ?? new RequestStopFilter()
      };
      try
      {
        requestStopVm.list = RequestStopBiz.GetRequestStopList(requestStopVm.filter);
        return (IActionResult) this.View((object) requestStopVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) requestStopVm);
      }
    }

    [MenuFilter(366, 3)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<RequestStopReview>(RequestStopBiz.GetReview(pk)));
    }

    [MenuFilter(366, 3)]
    public IActionResult PostReview(BorrowRequestDto req, bool result)
    {
      try
      {
        RequestStopBiz.TerminateVerify(this.GetUser().pk, req.pk, result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) PublicTool.convertUtcToLocalTime<RequestStopReview>(RequestStopBiz.GetReview(req.pk)));
      }
    }
  }
}
