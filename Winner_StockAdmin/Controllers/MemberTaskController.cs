// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MemberTaskController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.MemberTask;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("MemberTask")]
  public class MemberTaskController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (MemberTaskController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MemberTaskController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (MemberTaskController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = MemberTaskController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) MemberTaskController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(67, 9)]
    public IActionResult Index(MemberTaskFilter filter, int page = 1)
    {
      this.SetSelect();
      MemberTaskVm memberTaskVm = new MemberTaskVm()
      {
        filter = filter ?? new MemberTaskFilter()
      };
      try
      {
        memberTaskVm.list = MemberTaskBiz.GetMemberTaskList(memberTaskVm.filter).ToPagedList<MemberTaskList>(page, this.pageSize);
        return (IActionResult) this.View((object) memberTaskVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) memberTaskVm);
      }
    }

    [UseFilter(67, 9)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) MemberTaskBiz.Get(pk));
    }

    public IActionResult PostEdit(MemberTaskDto req)
    {
      this.SetSelect();
      try
      {
        MemberTaskBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(67, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new MemberTaskDto());
    }

    public IActionResult PostCreate(MemberTaskDto req)
    {
      this.SetSelect();
      try
      {
        MemberTaskBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(67, 9)]
    public IActionResult Delete(int pk)
    {
      try
      {
        MemberTaskBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
