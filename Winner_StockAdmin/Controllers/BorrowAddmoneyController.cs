// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BorrowAddmoneyController
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
using stockadmin.Tool;
using stockadmin.ViewModels.BorrowAddmoney;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("BorrowAddmoney")]
  public class BorrowAddmoneyController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (BorrowAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BorrowAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "market", typeof (BorrowAddmoneyController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = BorrowAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) BorrowAddmoneyController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, SysMarketBiz.GetDropDownList(this.GetLanguage()));
    }

    [MenuFilter(329, 3)]
    public IActionResult Index(BorrowAddmoneyFilter filter, int page = 1)
    {
      this.SetSelect();
      BorrowAddmoneyVm borrowAddmoneyVm = new BorrowAddmoneyVm()
      {
        filter = filter ?? new BorrowAddmoneyFilter()
      };
      try
      {
        borrowAddmoneyVm.list = BorrowAddmoneyBiz.GetBorrowAddmoneyList(borrowAddmoneyVm.filter);
        return (IActionResult) this.View((object) borrowAddmoneyVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) borrowAddmoneyVm);
      }
    }

    [MenuFilter(329, 3)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<BorrowAddmoneyReview>(BorrowAddmoneyBiz.GetReview(pk)));
    }

    [MenuFilter(329, 3)]
    public IActionResult PostReview(BorrowAddmoneyDto req, bool result)
    {
      try
      {
        BorrowAddmoneyBiz.ReviewApprove(req.pk, result, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<BorrowAddmoneyReview>(BorrowAddmoneyBiz.GetReview(req.pk)));
      }
    }
  }
}
