// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WarningMessageController
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
using stockadmin.Models.Dto;
using stockadmin.ViewModels.WarningMessage;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WarningMessage")]
  public class WarningMessageController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (WarningMessageController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WarningMessageController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (WarningMessageController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WarningMessageController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WarningMessageController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(439, 14)]
    public IActionResult Index(
      WarningMessageFilter filter,
      string lang = "CN",
      string search_text = "",
      int page = 1,
      int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (WarningMessageController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (WarningMessageController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WarningMessageController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      WarningMessageVm warningMessageVm = new WarningMessageVm()
      {
        filter = filter ?? new WarningMessageFilter()
      };
      warningMessageVm.filter.lang = string.IsNullOrEmpty(warningMessageVm.filter.lang) ? lang : filter.lang;
      warningMessageVm.filter.search_text = string.IsNullOrEmpty(filter.search_text) ? search_text : filter.search_text;
      try
      {
        DataCountBase<WarningMessageList> warningMessageList = WarningMessageBiz.GetWarningMessageList(warningMessageVm.filter, page, pageSize);
        StaticPagedList<WarningMessageList> staticPagedList = new StaticPagedList<WarningMessageList>(warningMessageList.data, page, pageSize, warningMessageList.count);
        warningMessageVm.list = (IPagedList<WarningMessageList>) staticPagedList;
        return (IActionResult) this.View((object) warningMessageVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) warningMessageVm);
      }
    }

    [UseFilter(439, 14)]
    public IActionResult Edit(string lang, string key)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) WarningMessageBiz.GetTranslateByKey(lang, key));
    }

    [UseFilter(439, 14)]
    public IActionResult PostEdit(WarningMessageDto req)
    {
      this.SetSelect();
      try
      {
        WarningMessageBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }
  }
}
