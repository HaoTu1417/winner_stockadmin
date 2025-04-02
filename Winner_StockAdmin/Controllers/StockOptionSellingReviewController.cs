// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.StockOptionSellingReviewController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.StockOptionRecord;
using stockadmin.ViewModels.StockOptionSellingReview;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("StockOptionReview")]
  public class StockOptionSellingReviewController : BaseController
  {
    [MenuFilter(373, 2)]
    public IActionResult Index(StockOptionSellingReviewFilter filter, int page = 1, int pageSize = 20)
    {
      StockOptionSellingReviewVm optionSellingReviewVm = new StockOptionSellingReviewVm()
      {
        filter = filter ?? new StockOptionSellingReviewFilter()
      };
      // ISSUE: reference to a compiler-generated field
      if (StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (StockOptionSellingReviewController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (StockOptionSellingReviewController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) StockOptionSellingReviewController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, pageSize);
      try
      {
        List<StockOptionRecordList> sellingReviewList = StockOptionSellingReviewBiz.GetStockOptionSellingReviewList(optionSellingReviewVm.filter);
        optionSellingReviewVm.list = sellingReviewList.ToPagedList<StockOptionRecordList>(page, pageSize);
        return (IActionResult) this.View((object) optionSellingReviewVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) optionSellingReviewVm);
      }
    }

    [MenuFilter(373, 2)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<StockOptionRecordList>(StockOptionSellingReviewBiz.GetReview(pk)));
    }

    [MenuFilter(373, 2)]
    public IActionResult PostReview(StockOptionRecordList req, bool result)
    {
      try
      {
        StockOptionSellingReviewBiz.Review(req, result, this.GetUser(), req.reject_result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) req.pk);
      }
    }
  }
}
