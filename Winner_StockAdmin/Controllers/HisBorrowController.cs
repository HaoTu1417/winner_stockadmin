// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.HisBorrowController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.HisBorrow;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("HisBorrow")]
  public class HisBorrowController : BaseController
  {
    private void SetFilterSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "borrow_type", typeof (HisBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, BorrowPlanBiz.GetBorrowTypes());
      // ISSUE: reference to a compiler-generated field
      if (HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (HisBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) HisBorrowController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
    }

    [MenuFilter(324, 3)]
    public IActionResult Index(HisBorrowFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (HisBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (HisBorrowController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) HisBorrowController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      HisBorrowVm hisBorrowVm = new HisBorrowVm()
      {
        filter = filter ?? new HisBorrowFilter()
      };
      try
      {
        DataCountBase<HisBorrowList> hisBorrowList = HisBorrowBiz.GetHisBorrowList(hisBorrowVm.filter, page, pageSize);
        StaticPagedList<HisBorrowList> staticPagedList = new StaticPagedList<HisBorrowList>(hisBorrowList.data, page, pageSize, hisBorrowList.count);
        hisBorrowVm.list = (IPagedList<HisBorrowList>) staticPagedList;
        return (IActionResult) this.View((object) hisBorrowVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) hisBorrowVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(324, 3)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<HisBorrowEditVm>(HisBorrowBiz.GetDetailVm(pk)));
    }

    [UseFilter(324, 3)]
    public IActionResult EditRenewal(HisBorrowEditVm vm)
    {
      HisBorrowBiz.EditRenewal(vm.pk, vm.auto_renewal);
      return (IActionResult) this.View("Edit", (object) vm);
    }
  }
}
