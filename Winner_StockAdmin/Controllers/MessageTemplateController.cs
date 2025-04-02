// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MessageTemplateController
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
using stockadmin.Models.Dto;
using stockadmin.ViewModels.MessageTemplate;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("MessageTemplate")]
  public class MessageTemplateController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (MessageTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (MessageTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = MessageTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) MessageTemplateController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
    }

    [MenuFilter(31, 14)]
    public IActionResult Index(MessageTemplateFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (MessageTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (MessageTemplateController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) MessageTemplateController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      MessageTemplateVm messageTemplateVm = new MessageTemplateVm()
      {
        filter = filter ?? new MessageTemplateFilter()
      };
      try
      {
        DataCountBase<MessageTemplateList> messageTemplateList = MessageTemplateBiz.GetMessageTemplateList(messageTemplateVm.filter, page, pageSize);
        StaticPagedList<MessageTemplateList> staticPagedList = new StaticPagedList<MessageTemplateList>(messageTemplateList.data, page, pageSize, messageTemplateList.count);
        messageTemplateVm.list = (IPagedList<MessageTemplateList>) staticPagedList;
        return (IActionResult) this.View((object) messageTemplateVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) messageTemplateVm);
      }
    }

    [UseFilter(31, 14)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) MessageTemplateBiz.Get(pk));
    }

    public IActionResult PostEdit(MessageTemplateDto req)
    {
      this.SetSelect();
      try
      {
        MessageTemplateBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(31, 14)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new MessageTemplateDto());
    }

    public IActionResult PostCreate(MessageTemplateDto req)
    {
      this.SetSelect();
      try
      {
        MessageTemplateBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }
  }
}
