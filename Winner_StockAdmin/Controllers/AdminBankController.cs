// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdminBankController
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
using stockadmin.ViewModels.AdminBank;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("AdminBank")]
  public class AdminBankController : BaseController
  {
    public void SetSelect(string lang)
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>()
      {
        new SelectListItem()
        {
          Text = "銀行帳號",
          Value = "1",
          Selected = false
        },
        new SelectListItem()
        {
          Text = "虛擬貨幣地址",
          Value = "2",
          Selected = false
        }
      };
      if (lang == "EN")
        selectListItemList = new List<SelectListItem>()
        {
          new SelectListItem()
          {
            Text = "Bank account",
            Value = "1",
            Selected = false
          },
          new SelectListItem()
          {
            Text = "Crypto address",
            Value = "2",
            Selected = false
          }
        };
      // ISSUE: reference to a compiler-generated field
      if (AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "card_type", typeof (AdminBankController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, selectListItemList);
      // ISSUE: reference to a compiler-generated field
      if (AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (AdminBankController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) AdminBankController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
    }

    [MenuFilter(302, 5)]
    public IActionResult Index(AdminBankFilter filter, int page = 1)
    {
      this.SetSelect(this.GetUser().lang);
      AdminBankVm adminBankVm = new AdminBankVm()
      {
        filter = filter ?? new AdminBankFilter()
      };
      try
      {
        adminBankVm.list = AdminBankBiz.GetAdminBankList(adminBankVm.filter, this.GetUser().lang);
        return (IActionResult) this.View((object) adminBankVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) adminBankVm);
      }
    }

    [UseFilter(303, 5)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AdminBankDto>(AdminBankBiz.Get(pk)));
    }

    public IActionResult PostEdit(AdminBankDto req)
    {
      this.SetSelect(this.GetUser().lang);
      try
      {
        AdminBankBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(435, 5)]
    public IActionResult Create()
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) new AdminBankDto());
    }

    public IActionResult PostCreate(AdminBankDto req)
    {
      this.SetSelect(this.GetUser().lang);
      try
      {
        AdminBankBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(304, 5)]
    public IActionResult Delete(int pk)
    {
      try
      {
        AdminBankBiz.Delete(pk, this.GetUser());
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
