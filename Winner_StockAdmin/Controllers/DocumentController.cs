// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.DocumentController
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
using stockadmin.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Document")]
  public class DocumentController : BaseController
  {
    public void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (DocumentController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (DocumentController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) DocumentController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(158, 7)]
    public IActionResult Index(DocumentFilter filter, int page = 1)
    {
      this.SetSelect();
      DocumentVm documentVm = new DocumentVm()
      {
        filter = filter ?? new DocumentFilter()
      };
      try
      {
        documentVm.list = DocumentBiz.GetDocumentList(documentVm.filter).ToPagedList<DocumentList>(page, this.pageSize);
        return (IActionResult) this.View((object) documentVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) documentVm);
      }
    }

    [UseFilter(158, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      CmsDocumentDto cmsDocumentDto = DocumentBiz.Get(pk);
      if (cmsDocumentDto.content != null)
        cmsDocumentDto.content = UploadImageLib.AddHostName(cmsDocumentDto.content);
      return (IActionResult) this.View((object) cmsDocumentDto);
    }

    public IActionResult PostEdit(CmsDocumentDto req)
    {
      this.SetSelect();
      try
      {
        if (req.content != null)
          req.content = UploadImageLib.RemoveHostName(req.content);
        DocumentBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(158, 7)]
    public IActionResult Copy(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) DocumentBiz.Get(pk));
    }

    public IActionResult PostCopy(CmsDocumentDto req)
    {
      this.SetSelect();
      try
      {
        req.content = UploadImageLib.RemoveHostName(req.content);
        DocumentBiz.PostCopy(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Copy", (object) req);
      }
    }

    [UseFilter(158, 7)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsDocumentDto()
      {
        status = true
      });
    }

    public IActionResult PostCreate(CmsDocumentDto req)
    {
      this.SetSelect();
      try
      {
        if (req.content != null)
          req.content = UploadImageLib.RemoveHostName(req.content);
        DocumentBiz.PostCreate(req, this.GetUser());
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
      DocumentController documentController = this;
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
        documentController.ShowError(ex.Message);
        return (IActionResult) documentController.View();
      }
    }

    [UseFilter(158, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        DocumentBiz.Delete(pk, this.GetUser());
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
