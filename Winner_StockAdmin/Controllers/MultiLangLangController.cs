// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MultiLangLangController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.ViewModels.MultiLang;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  public class MultiLangLangController : BaseController
  {
    private void SetPermissions()
    {
      this.ViewData["multilang_lang_edit_btn"] = (object) AdminRoleBiz.VerifyPower(427, 9, this.GetUser().role);
    }

    [MenuFilter(426, 9)]
    public IActionResult Index()
    {
      MultiLangLangSearchVm langLangSearchVm = new MultiLangLangSearchVm();
      try
      {
        langLangSearchVm.list = MultiLangBiz.GetSearchList().ToPagedList<MultiLangLanghList>(langLangSearchVm.page, this.pageSize);
        this.SetPermissions();
        return (IActionResult) this.View(nameof (Index), (object) langLangSearchVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View(nameof (Index), (object) langLangSearchVm);
      }
    }

    [UseFilter(427, 9)]
    public IActionResult Edit(string lang)
    {
      MutilangSubjectDto byLang = MultiLangBiz.GetByLang(lang);
      return (IActionResult) this.View((object) new MultiLangLangVm()
      {
        lang = byLang.lang,
        title = byLang.title,
        enable = byLang.enable,
        admin_default = byLang.admin_default,
        app_default = byLang.app_default
      });
    }

    public IActionResult PostEdit(MultiLangLangVm req)
    {
      try
      {
        MultiLangBiz.Edit(req);
        return !req.isSucceed ? (IActionResult) this.View("Edit", (object) req) : (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }
  }
}
