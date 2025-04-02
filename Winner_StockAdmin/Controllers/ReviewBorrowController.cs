// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.ReviewBorrowController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using DB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.ReviewBorrow;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("ReviewBorrow")]
  public class ReviewBorrowController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (ReviewBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrow_type", typeof (ReviewBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ReviewBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) ReviewBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BorrowPlanBiz.GetBorrowTypes());
    }

    public void SetReviewSelect(BorrowDto borrowDto)
    {
      string account = MemberService.Find(borrowDto.member_fk).account;
      // ISSUE: reference to a compiler-generated field
      if (ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "member_account", typeof (ReviewBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, account);
      // ISSUE: reference to a compiler-generated field
      if (ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrow_type", typeof (ReviewBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) ReviewBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, BorrowPlanService.Find(borrowDto.borrow_plan_fk).name);
    }

    [MenuFilter(322, 3)]
    public IActionResult Index(ReviewBorrowFilter filter, int page = 1)
    {
      this.SetSelect();
      ReviewBorrowVm reviewBorrowVm = new ReviewBorrowVm()
      {
        filter = filter ?? new ReviewBorrowFilter()
      };
      try
      {
        List<ReviewBorrowList> reviewBorrowList = ReviewBorrowBiz.GetReviewBorrowList(reviewBorrowVm.filter);
        reviewBorrowVm.list = reviewBorrowList.ToPagedList<ReviewBorrowList>(page, this.pageSize);
        return (IActionResult) this.View((object) reviewBorrowVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) reviewBorrowVm);
      }
    }

    [MenuFilter(322, 3)]
    public IActionResult Review(int pk)
    {
      BorrowDto localTime = PublicTool.convertUtcToLocalTime<BorrowDto>(ReviewBorrowBiz.Get(pk));
      this.SetReviewSelect(localTime);
      return (IActionResult) this.View((object) localTime);
    }

    [MenuFilter(322, 3)]
    public IActionResult PostReview(BorrowDto req, bool result)
    {
      this.SetSelect();
      try
      {
        ReviewBorrowBiz.BorrowApplyVerify(req.pk, result);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) PublicTool.convertUtcToLocalTime<BorrowDto>(ReviewBorrowBiz.Get(req.pk)));
      }
    }
  }
}
