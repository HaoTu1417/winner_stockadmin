// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MutilangController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.MultiLang;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Mutilang")]
  public class MutilangController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (MutilangController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MutilangController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (MutilangController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = MutilangController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) MutilangController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(8, 9)]
    public IActionResult MultilangIndex(MultilangFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (MutilangController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (MutilangController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) MutilangController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      MultilangVm multilangVm = new MultilangVm()
      {
        filter = filter ?? new MultilangFilter()
      };
      try
      {
        multilangVm.list = MultiLangBiz.GetList(multilangVm.filter).ToPagedList<MultilangList>(page, pageSize);
        return (IActionResult) this.View((object) multilangVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) multilangVm);
      }
    }

    [MenuFilter(8, 9)]
    public IActionResult MultilangTranslate(
      string key,
      MultiLangCacheSearchFilter Filter,
      int page = 1)
    {
      this.SetSelect();
      MultiLangCacheSearchVm langCacheSearchVm1 = new MultiLangCacheSearchVm();
      MultiLangCacheSearchFilter cacheSearchFilter = Filter;
      if (cacheSearchFilter == null)
        cacheSearchFilter = new MultiLangCacheSearchFilter()
        {
          key = key
        };
      langCacheSearchVm1.filter = cacheSearchFilter;
      MultiLangCacheSearchVm langCacheSearchVm2 = langCacheSearchVm1;
      try
      {
        langCacheSearchVm2.filter.key = key;
        langCacheSearchVm2.list = MultiLangBiz.GetMultiLangCacheList(langCacheSearchVm2.filter).ToPagedList<MultiLangCacheSearchList>(page, this.pageSize);
        return (IActionResult) this.View((object) langCacheSearchVm2);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) langCacheSearchVm2);
      }
    }

    [MenuFilter(8, 9)]
    public IActionResult MultilangSync(string key, MultiLangCacheSearchFilter Filter, int page = 1)
    {
      this.SetSelect();
      MultiLangCacheSearchVm langCacheSearchVm1 = new MultiLangCacheSearchVm();
      MultiLangCacheSearchFilter cacheSearchFilter = Filter;
      if (cacheSearchFilter == null)
        cacheSearchFilter = new MultiLangCacheSearchFilter()
        {
          key = key
        };
      langCacheSearchVm1.filter = cacheSearchFilter;
      MultiLangCacheSearchVm langCacheSearchVm2 = langCacheSearchVm1;
      try
      {
        MultiLangBiz.MultilangSync(key, this.GetUser());
        langCacheSearchVm2.list = MultiLangBiz.GetMultiLangCacheList(langCacheSearchVm2.filter).ToPagedList<MultiLangCacheSearchList>(page, this.pageSize);
      }
      catch (Exception ex)
      {
        this.ShowWarning(ex.Message);
      }
      return (IActionResult) ((ControllerBase) this).RedirectToAction("MultilangTranslate", (object) new
      {
        key = key
      });
    }

    [MenuFilter(8, 9)]
    public IActionResult MultilangTranslateEdit(string key, string lang, string valKey)
    {
      return (IActionResult) this.View((object) MultiLangBiz.GetTranslateByKey(key, lang, valKey));
    }

    [MenuFilter(8, 9)]
    public IActionResult MultilangTranslateEditPost(MultiLangCacheEditVm req)
    {
      try
      {
        MultiLangBiz.EditMultilangTranslate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("MultilangTranslate", (object) new
        {
          key = req.key
        });
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("MultilangTranslateEdit", (object) new
        {
          key = req.key,
          lang = req.lang,
          valKey = req.translationKey
        });
      }
    }
  }
}
