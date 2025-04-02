// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminLogController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.AdminLog;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminLog")]
  public class AdminLogController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(240, 13)]
    public IActionResult Index(AdminLogFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (AdminLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (AdminLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AdminLogController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      AdminLogVm adminLogVm = new AdminLogVm()
      {
        filter = filter ?? new AdminLogFilter()
      };
      try
      {
        List<AdminLogList> adminLogList = AdminLogBiz.GetAdminLogList(adminLogVm.filter);
        adminLogVm.list = adminLogList.ToPagedList<AdminLogList>(page, pageSize);
        return (IActionResult) this.View((object) adminLogVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) adminLogVm);
      }
    }
  }
}
