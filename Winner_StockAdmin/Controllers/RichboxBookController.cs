// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.RichboxBookController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.RichboxBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using tradeapi.Models.RichBox;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("RichboxBook")]
  public class RichboxBookController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(180, 15)]
    public IActionResult Index(
      RichboxBookFilter filter,
      string? account = null,
      string? real_name = null,
      int page = 1,
      int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (RichboxBookController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (RichboxBookController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) RichboxBookController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      RichboxBookVm richboxBookVm = new RichboxBookVm()
      {
        filter = filter ?? new RichboxBookFilter()
      };
      filter.account = string.IsNullOrEmpty(filter.account) ? account : filter.account;
      filter.real_name = string.IsNullOrEmpty(filter.real_name) ? real_name : filter.real_name;
      try
      {
        richboxBookVm.list = RichboxBookBiz.GetRichboxBookList(richboxBookVm.filter).ToPagedList<RichboxBookList>(page, pageSize);
        return (IActionResult) this.View((object) richboxBookVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) richboxBookVm);
      }
    }

    [MenuFilter(180, 15)]
    public IActionResult Detail(RichboxBookDetailFilter filter, int page = 1, string account = "")
    {
      this.SetFilterSelect();
      RichboxBookDetailVm richboxBookDetailVm = new RichboxBookDetailVm()
      {
        filter = filter ?? new RichboxBookDetailFilter()
      };
      richboxBookDetailVm.account = account;
      try
      {
        richboxBookDetailVm.list = RichboxBookBiz.GetHistory(account).Select<RichHistoryResponse, RichHistoryResponse>((Func<RichHistoryResponse, RichHistoryResponse>) (recommendReward => PublicTool.convertUtcToLocalTime<RichHistoryResponse>(recommendReward))).ToList<RichHistoryResponse>().ToPagedList<RichHistoryResponse>(page, this.pageSize);
        return (IActionResult) this.View((object) richboxBookDetailVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) richboxBookDetailVm);
      }
    }
  }
}
