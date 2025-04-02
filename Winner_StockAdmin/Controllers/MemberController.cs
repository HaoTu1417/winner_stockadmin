// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MemberController
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
using stockadmin.Models;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Member")]
  public class MemberController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "levelIdDropdown", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MemberController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) MemberController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, new List<SelectListItem>()
      {
        new SelectListItem() { Value = "0", Text = "一般" },
        new SelectListItem() { Value = "1", Text = "黃金" },
        new SelectListItem() { Value = "2", Text = "白金" },
        new SelectListItem() { Value = "3", Text = "钻石" }
      });
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "withdrawSelfie", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MemberController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) MemberController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, new List<SelectListItem>()
      {
        new SelectListItem() { Value = "0", Text = "不需要" },
        new SelectListItem() { Value = "1", Text = "需要" }
      });
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = MemberController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) MemberController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "adminDropdown", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = MemberController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) MemberController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag, AdminUserBiz.GetSelectList());
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__0.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__0.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = MemberController.\u003C\u003Eo__0.\u003C\u003Ep__4.Target((CallSite) MemberController.\u003C\u003Eo__0.\u003C\u003Ep__4, this.ViewBag, BaseController.filesite);
    }

    [MenuFilter(250, 4)]
    public IActionResult Index(MemberFilter filter, bool fuzzy_search = false, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MemberController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) MemberController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MemberController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) MemberController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__1.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__1.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (fuzzy_search), typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = MemberController.\u003C\u003Eo__1.\u003C\u003Ep__2.Target((CallSite) MemberController.\u003C\u003Eo__1.\u003C\u003Ep__2, this.ViewBag, fuzzy_search);
      MemberVm memberVm = new MemberVm()
      {
        filter = filter ?? new MemberFilter()
      };
      try
      {
        DataCountBase<MemberList> memberList = MemberBiz.GetMemberList(memberVm.filter, fuzzy_search, page, pageSize, this.GetUser().lang);
        StaticPagedList<MemberList> staticPagedList = new StaticPagedList<MemberList>(memberList.data, page, pageSize, memberList.count);
        memberVm.list = (IPagedList<MemberList>) staticPagedList;
        memberVm.recommendCount = MemberBiz.GetRecommendMemberCount(memberVm.filter);
        memberVm.noRecommendCount = MemberBiz.GetNoRecommendMemberCount(memberVm.filter);
        return (IActionResult) this.View((object) memberVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) memberVm);
      }
    }

    [MenuFilter(441, 4)]
    public IActionResult PromotionIndex(
      MemberFilter filter,
      bool fuzzy_search = false,
      int page = 1,
      int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MemberController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) MemberController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MemberController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) MemberController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pageSize);
      // ISSUE: reference to a compiler-generated field
      if (MemberController.\u003C\u003Eo__2.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberController.\u003C\u003Eo__2.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (fuzzy_search), typeof (MemberController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = MemberController.\u003C\u003Eo__2.\u003C\u003Ep__2.Target((CallSite) MemberController.\u003C\u003Eo__2.\u003C\u003Ep__2, this.ViewBag, fuzzy_search);
      AdminSession user = this.GetUser();
      MemberVm memberVm = new MemberVm()
      {
        filter = filter ?? new MemberFilter()
      };
      try
      {
        DataCountBase<MemberList> promotionMemberList = MemberBiz.GetPromotionMemberList(memberVm.filter, user.invitation_code, fuzzy_search, page, pageSize);
        StaticPagedList<MemberList> staticPagedList = new StaticPagedList<MemberList>(promotionMemberList.data, page, pageSize, promotionMemberList.count);
        memberVm.list = (IPagedList<MemberList>) staticPagedList;
        memberVm.recommendCount = MemberBiz.GetRecommendMemberCount(memberVm.filter);
        memberVm.noRecommendCount = MemberBiz.GetNoRecommendMemberCount(memberVm.filter);
        return (IActionResult) this.View((object) memberVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) memberVm);
      }
    }

    [UseFilter(253, 4)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<MemberDto>(MemberBiz.Get(pk, this.GetUser())));
    }

    [UseFilter(253, 4)]
    public IActionResult PostEdit(MemberDto req)
    {
      this.SetSelect();
      try
      {
        MemberBiz.PostEdit(PublicTool.convertLocalToUtcTime<MemberDto>(req), this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(250, 4)]
    public IActionResult Block(int pk)
    {
      this.SetSelect();
      try
      {
        MemberBiz.Block(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.SetSelect();
        MemberVm memberVm = new MemberVm();
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Index", (object) memberVm);
      }
    }

    [UseFilter(250, 4)]
    public IActionResult Unblock(int pk)
    {
      this.SetSelect();
      try
      {
        MemberBiz.Unblock(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.SetSelect();
        MemberVm memberVm = new MemberVm();
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Index", (object) memberVm);
      }
    }

    [UseFilter(250, 4)]
    public IActionResult Delete(int pk)
    {
      try
      {
        MemberBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [UseFilter(250, 4)]
    public IActionResult EditInviter(int pk)
    {
      InviterVM inviterVm = new InviterVM();
      inviterVm.member_pk = pk;
      MemberDto memberDto = MemberService.Find(pk);
      inviterVm.member_pk = pk;
      if (memberDto.is_test_account)
      {
        this.ShowWarning("此帐号為測試帐号!");
        inviterVm.is_test_account = true;
      }
      else
        inviterVm.is_test_account = false;
      return (IActionResult) this.View((object) inviterVm);
    }

    [UseFilter(250, 4)]
    public IActionResult PostInviter(InviterVM vm)
    {
      try
      {
        MemberBiz.AddInviter(vm.member_pk, vm.Inviter, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("EditInviter", (object) vm);
      }
    }

    [UseFilter(440, 4)]
    public IActionResult Download(MemberFilter filter)
    {
      MemberVm memberVm = new MemberVm()
      {
        filter = filter ?? new MemberFilter()
      };
      try
      {
        bool hide_member_detail = true;
        if (AdminRoleBiz.VerifyPower(252, 4, this.GetUser().role))
          hide_member_detail = false;
        return (IActionResult) ((ControllerBase) this).File(MemberBiz.DownloadMemberList(memberVm.filter, hide_member_detail), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Member.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) memberVm);
      }
    }
  }
}
