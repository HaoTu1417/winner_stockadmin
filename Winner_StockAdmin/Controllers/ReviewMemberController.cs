// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.ReviewMemberController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.ReviewMember;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("ReviewMember")]
  public class ReviewMemberController : BaseController
  {
    public static List<SelectListItem> GetAuthStatusList(string lang)
    {
      return new List<SelectListItem>()
      {
        new SelectListItem()
        {
          Value = IdAuthStatusConvertEnum.ConvertIdAuthStatus(0, lang),
          Text = IdAuthStatusConvertEnum.ConvertIdAuthStatus(0, lang) ?? ""
        },
        new SelectListItem()
        {
          Value = IdAuthStatusConvertEnum.ConvertIdAuthStatus(3, lang),
          Text = IdAuthStatusConvertEnum.ConvertIdAuthStatus(3, lang) ?? ""
        }
      };
    }

    public void SetSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "admin", typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, AdminUserBiz.GetSelectList());
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "authStatusOption", typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) ReviewMemberController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, ReviewMemberController.GetAuthStatusList(lang));
    }

    [MenuFilter(249, 4)]
    public IActionResult Index(ReviewMemberFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) ReviewMemberController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pageSize);
      ReviewMemberVm reviewMemberVm = new ReviewMemberVm()
      {
        filter = filter ?? new ReviewMemberFilter(),
        summary = new Summary()
      };
      try
      {
        DataCountBase<ReviewMemberList> reviewMemberList = ReviewMemberBiz.GetReviewMemberList(reviewMemberVm.filter, page, pageSize, this.GetUser().lang);
        Summary summary = ReviewMemberBiz.GetSummary();
        StaticPagedList<ReviewMemberList> staticPagedList = new StaticPagedList<ReviewMemberList>(reviewMemberList.data, page, pageSize, reviewMemberList.count);
        reviewMemberVm.list = (IPagedList<ReviewMemberList>) staticPagedList;
        reviewMemberVm.summary = summary;
        return (IActionResult) this.View((object) reviewMemberVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) reviewMemberVm);
      }
    }

    [MenuFilter(251, 4)]
    public IActionResult IndexFail(ReviewMemberFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (ReviewMemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) ReviewMemberController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, pageSize);
      ReviewMemberVm reviewMemberVm = new ReviewMemberVm()
      {
        filter = filter ?? new ReviewMemberFilter(),
        summary = new Summary()
      };
      try
      {
        DataCountBase<ReviewMemberList> reviewMemberFailList = ReviewMemberBiz.GetReviewMemberFailList(reviewMemberVm.filter, page, pageSize, this.GetUser().lang);
        Summary summary = ReviewMemberBiz.GetSummary();
        StaticPagedList<ReviewMemberList> staticPagedList = new StaticPagedList<ReviewMemberList>(reviewMemberFailList.data, page, pageSize, reviewMemberFailList.count);
        reviewMemberVm.list = (IPagedList<ReviewMemberList>) staticPagedList;
        reviewMemberVm.summary = summary;
        return (IActionResult) this.View((object) reviewMemberVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) reviewMemberVm);
      }
    }

    [UseFilter(249, 4)]
    public IActionResult Delete(int pk)
    {
      try
      {
        ReviewMemberBiz.Delete(pk);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [MenuFilter(249, 4)]
    public IActionResult Review(int pk)
    {
      this.SetSelect(this.GetUser().lang);
      ReviewMemberReview localTime = PublicTool.convertUtcToLocalTime<ReviewMemberReview>(ReviewMemberBiz.GetReview(pk));
      localTime.card_pic_front = !string.IsNullOrEmpty(localTime.card_pic_front) ? ConfigLib.Get("filesite") + localTime.card_pic_front : "";
      return (IActionResult) this.View((object) localTime);
    }

    [MenuFilter(249, 4)]
    public IActionResult PostReview(ReviewMemberReview req, bool result)
    {
      try
      {
        AdminSession user = this.GetUser();
        ReviewMemberBiz.VerifyMember(req, result, user.pk);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.SetSelect(this.GetUser().lang);
        this.ShowWarning(ex.Message);
        ReviewMemberReview localTime = PublicTool.convertUtcToLocalTime<ReviewMemberReview>(ReviewMemberBiz.GetReview(req.pk));
        localTime.card_pic_front = !string.IsNullOrEmpty(localTime.card_pic_front) ? ConfigLib.Get("filesite") + localTime.card_pic_front : "";
        return (IActionResult) this.View("Review", (object) localTime);
      }
    }
  }
}
