// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.CmsPopinfoController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using Models;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Data.Enums;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.CmsPopinfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("CmsPopinfo")]
  public class CmsPopinfoController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (CmsPopinfoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, IEnumerable<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sizeDropdown", typeof (CmsPopinfoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) CmsPopinfoController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, Enum.GetValues(typeof (CmsPopInfoEnum)).Cast<CmsPopInfoEnum>().Select<CmsPopInfoEnum, SelectListItem>((Func<CmsPopInfoEnum, SelectListItem>) (size => new SelectListItem()
      {
        Text = CmsPopInfoConvertEnum.ConvertSize((int) size),
        Value = ((int) size).ToString()
      })));
    }

    [MenuFilter(209, 7)]
    public IActionResult Index(CmsPopinfoFilter filter, int page = 1)
    {
      this.SetSelect();
      CmsPopinfoVm cmsPopinfoVm = new CmsPopinfoVm()
      {
        filter = filter ?? new CmsPopinfoFilter()
      };
      try
      {
        List<CmsPopinfoList> cmsPopinfoList = CmsPopinfoBiz.GetCmsPopinfoList(cmsPopinfoVm.filter);
        cmsPopinfoVm.list = cmsPopinfoList.ToPagedList<CmsPopinfoList>(page, this.pageSize);
        return (IActionResult) this.View((object) cmsPopinfoVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) cmsPopinfoVm);
      }
    }

    [UseFilter(209, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      CmsPopinfoDto localTime = PublicTool.convertUtcToLocalTime<CmsPopinfoDto>(CmsPopinfoBiz.Get(pk));
      if (localTime.info != null)
        localTime.info = UploadImageLib.AddHostName(localTime.info);
      return (IActionResult) this.View((object) localTime);
    }

    public IActionResult PostEdit(CmsPopinfoDto req)
    {
      this.SetSelect();
      try
      {
        CmsPopinfoBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(209, 7)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsPopinfoDto());
    }

    public IActionResult PostCreate(CmsPopinfoDto req)
    {
      this.SetSelect();
      try
      {
        if (req.info != null)
          req.info = UploadImageLib.RemoveHostName(req.info);
        CmsPopinfoBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(209, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        CmsPopinfoBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile upload)
    {
      CmsPopinfoController popinfoController = this;
      try
      {
        string str = await UploadBiz.UploadImage(upload, FileManagementLib.Folder.article);
        return (IActionResult) new JsonResult((object) new UploadSuccess()
        {
          uploaded = 1,
          url = str
        });
      }
      catch (AppException ex)
      {
        popinfoController.ShowError(ex.Message);
        return (IActionResult) popinfoController.View();
      }
    }
  }
}
