// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BorrowFeeController
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
using stockadmin.ViewModels.BorrowFee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("BorrowFee")]
  public class BorrowFeeController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(281, 5)]
    public IActionResult Index(BorrowFeeFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (BorrowFeeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (BorrowFeeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      BorrowFeeVm borrowFeeVm = new BorrowFeeVm()
      {
        filter = filter ?? new BorrowFeeFilter(),
        summary = new Summary()
      };
      try
      {
        (Decimal _, DataCountBase<BorrowFeeList> dataCountBase) = BorrowFeeBiz.GetBorrowFeeList(borrowFeeVm.filter, page, pageSize);
        StaticPagedList<BorrowFeeList> staticPagedList = new StaticPagedList<BorrowFeeList>(dataCountBase.data, page, pageSize, dataCountBase.count);
        borrowFeeVm.list = (IPagedList<BorrowFeeList>) staticPagedList;
        borrowFeeVm.summary.page_total_profit = dataCountBase.data.Sum<BorrowFeeList>((Func<BorrowFeeList, Decimal>) (l => l.borrow_fee));
        // ISSUE: reference to a compiler-generated field
        if (BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, Decimal, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "total", typeof (BorrowFeeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__2.Target((CallSite) BorrowFeeController.\u003C\u003Eo__1.\u003C\u003Ep__2, this.ViewBag, BorrowFeeBiz.GetBorrowFeeSummary(borrowFeeVm.filter));
        return (IActionResult) this.View((object) borrowFeeVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) borrowFeeVm);
      }
    }

    [UseFilter(282, 5)]
    public IActionResult Download(BorrowFeeFilter filter)
    {
      try
      {
        return (IActionResult) ((ControllerBase) this).File(BorrowFeeBiz.DownloadBorrowFeeList(filter), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BorrowFee.xlsx");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) filter);
      }
    }
  }
}
