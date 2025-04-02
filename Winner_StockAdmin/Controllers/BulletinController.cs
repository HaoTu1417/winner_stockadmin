// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BulletinController
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
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.Bulletin;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Bulletin")]
  public class BulletinController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (BulletinController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (BulletinController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) BulletinController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
    }

    [MenuFilter(143, 7)]
    public IActionResult Index(BulletinFilter filter, int page = 1)
    {
      this.SetSelect();
      BulletinVm bulletinVm = new BulletinVm()
      {
        filter = filter ?? new BulletinFilter()
      };
      try
      {
        List<BulletinList> bulletinList = BulletinBiz.GetBulletinList(bulletinVm.filter);
        bulletinVm.list = bulletinList.ToPagedList<BulletinList>(page, this.pageSize);
        return (IActionResult) this.View((object) bulletinVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) bulletinVm);
      }
    }

    [UseFilter(143, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      CmsBulletinDto utcTime = PublicTool.convertLocalToUtcTime<CmsBulletinDto>(BulletinBiz.Get(pk));
      if (utcTime.topic_content != null)
        utcTime.topic_content = UploadImageLib.AddHostName(utcTime.topic_content);
      return (IActionResult) this.View((object) utcTime);
    }

    public IActionResult PostEdit(CmsBulletinDto req)
    {
      this.SetSelect();
      try
      {
        req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
        BulletinBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(143, 7)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsBulletinDto());
    }

    public IActionResult PostCreate(CmsBulletinDto req)
    {
      this.SetSelect();
      try
      {
        req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
        BulletinBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile upload)
    {
      BulletinController bulletinController = this;
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
        bulletinController.ShowError(ex.Message);
        return (IActionResult) bulletinController.View();
      }
    }

    [UseFilter(143, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        BulletinBiz.Delete(pk, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
    }
  }
}
