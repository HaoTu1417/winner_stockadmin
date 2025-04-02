// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.HisAddmoneyController
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
using stockadmin.ViewModels.HisAddmoney;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("HisAddmoney")]
  public class HisAddmoneyController : BaseController
  {
    private void SetFilterSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (HisAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (HisAddmoneyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HisAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) HisAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
    }

    [MenuFilter(332, 3)]
    public IActionResult Index(HisAddmoneyFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (HisAddmoneyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (HisAddmoneyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) HisAddmoneyController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      HisAddmoneyVm hisAddmoneyVm = new HisAddmoneyVm()
      {
        filter = filter ?? new HisAddmoneyFilter()
      };
      try
      {
        DataCountBase<HisAddmoneyList> hisAddmoneyList = HisAddmoneyBiz.GetHisAddmoneyList(hisAddmoneyVm.filter, page, pageSize, this.GetUser().lang);
        StaticPagedList<HisAddmoneyList> staticPagedList = new StaticPagedList<HisAddmoneyList>(hisAddmoneyList.data, page, pageSize, hisAddmoneyList.count);
        hisAddmoneyVm.list = (IPagedList<HisAddmoneyList>) staticPagedList;
        return (IActionResult) this.View((object) hisAddmoneyVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) hisAddmoneyVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(332, 3)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<HisAddmoneyEditVm>(HisAddmoneyBiz.GetEditVm(pk)));
    }
  }
}
