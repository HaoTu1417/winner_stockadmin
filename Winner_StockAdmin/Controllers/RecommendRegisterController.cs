// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RecommendRegisterController
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
using stockadmin.ViewModels.RecommendRegister;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RecommendRegister")]
  public class RecommendRegisterController : BaseController
  {
    private void SetFilterSelect()
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "一月", Value = "1" },
        new SelectListItem() { Text = "二月", Value = "2" },
        new SelectListItem() { Text = "三月", Value = "3" },
        new SelectListItem() { Text = "四月", Value = "4" },
        new SelectListItem() { Text = "五月", Value = "5" },
        new SelectListItem() { Text = "六月", Value = "6" },
        new SelectListItem() { Text = "七月", Value = "7" },
        new SelectListItem() { Text = "八月", Value = "8" },
        new SelectListItem() { Text = "九月", Value = "9" },
        new SelectListItem() { Text = "十月", Value = "10" },
        new SelectListItem() { Text = "十一月", Value = "11" },
        new SelectListItem() { Text = "十二月", Value = "12" }
      };
      // ISSUE: reference to a compiler-generated field
      if (RecommendRegisterController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RecommendRegisterController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "months", typeof (RecommendRegisterController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = RecommendRegisterController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) RecommendRegisterController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, selectListItemList);
    }

    [MenuFilter(10, 12)]
    public IActionResult Index(
      RecommendRegisterFilter filter,
      DateTime? begin_register_date = null,
      DateTime? end_register_date = null,
      string? account = null,
      string? real_name = null,
      string? inviteaccount = null,
      int page = 1,
      int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (RecommendRegisterController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (RecommendRegisterController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) RecommendRegisterController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      RecommendRegisterVm recommendRegisterVm = new RecommendRegisterVm()
      {
        filter = filter ?? new RecommendRegisterFilter()
      };
      RecommendRegisterFilter recommendRegisterFilter1 = filter;
      DateTime? nullable1 = filter.begin_register_date;
      DateTime? nullable2 = nullable1 ?? begin_register_date;
      recommendRegisterFilter1.begin_register_date = nullable2;
      RecommendRegisterFilter recommendRegisterFilter2 = filter;
      nullable1 = filter.end_register_date;
      DateTime? nullable3 = nullable1 ?? end_register_date;
      recommendRegisterFilter2.end_register_date = nullable3;
      filter.account = filter.account ?? account;
      filter.real_name = filter.real_name ?? real_name;
      filter.Inviteaccount = filter.Inviteaccount ?? inviteaccount;
      try
      {
        DataCountBase<RecommendRegisterList> recommendRegisterList = RecommendRegisterBiz.GetRecommendRegisterList(recommendRegisterVm.filter, page, pageSize);
        StaticPagedList<RecommendRegisterList> staticPagedList = new StaticPagedList<RecommendRegisterList>(recommendRegisterList.data, page, pageSize, recommendRegisterList.count);
        recommendRegisterVm.list = (IPagedList<RecommendRegisterList>) staticPagedList;
        return (IActionResult) this.View((object) recommendRegisterVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) recommendRegisterVm);
      }
    }

    public void SetSelect()
    {
    }

    [MenuFilter(10, 12)]
    public IActionResult Detail(int id)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<RecommendRegisterList>(RecommendRegisterBiz.GetDetailVm(id)));
    }
  }
}
