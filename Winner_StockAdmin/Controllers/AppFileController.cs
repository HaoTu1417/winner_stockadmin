// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AppFileController
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
using stockadmin.ViewModels.AppFile;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AppFile")]
  public class AppFileController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (AppFileController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "devices", typeof (AppFileController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) AppFileController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, new List<SelectListItem>()
      {
        new SelectListItem()
        {
          Text = "ios",
          Value = "0",
          Selected = false
        },
        new SelectListItem()
        {
          Text = "android",
          Value = "1",
          Selected = false
        }
      });
    }

    [MenuFilter(90, 9)]
    public IActionResult Index(AppFileFilter filter, int page = 1)
    {
      this.SetSelect();
      AppFileVm appFileVm = new AppFileVm()
      {
        filter = filter ?? new AppFileFilter()
      };
      try
      {
        List<AppFileList> appFileList = AppFileBiz.GetAppFileList(appFileVm.filter);
        appFileVm.list = appFileList.ToPagedList<AppFileList>(page, this.pageSize);
        return (IActionResult) this.View((object) appFileVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) appFileVm);
      }
    }

    [UseFilter(90, 9)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AppFileDto>(AppFileBiz.Get(pk)));
    }

    public IActionResult PostEdit(AppFileDto req)
    {
      this.SetSelect();
      try
      {
        AppFileBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(90, 9)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new AppFileDto());
    }

    public async Task<IActionResult> PostCreate(AppFileDto req)
    {
      AppFileController appFileController = this;
      appFileController.SetSelect();
      try
      {
        await AppFileBiz.PostCreate(req, appFileController.GetUser());
        return (IActionResult) ((ControllerBase) appFileController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        appFileController.ShowError(ex.Message);
        return (IActionResult) appFileController.View("Create", (object) req);
      }
    }

    [UseFilter(90, 9)]
    public async Task<IActionResult> Delete(int pk)
    {
      AppFileController appFileController = this;
      try
      {
        await AppFileBiz.Delete(pk, appFileController.GetUser());
        return (IActionResult) ((ControllerBase) appFileController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        appFileController.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) appFileController).RedirectToAction("Index");
      }
    }
  }
}
