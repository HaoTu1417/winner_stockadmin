// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MessageRecordController
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
using stockadmin.Models.Dto;
using stockadmin.Tool;
using stockadmin.ViewModels.MessageRecord;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("MessageRecord")]
  public class MessageRecordController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(85, 6)]
    public IActionResult Index(MessageRecordFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetFilterSelect();
      // ISSUE: reference to a compiler-generated field
      if (MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (MessageRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (MessageRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) MessageRecordController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      MessageRecordVm messageRecordVm = new MessageRecordVm()
      {
        filter = filter ?? new MessageRecordFilter()
      };
      try
      {
        DataCountBase<MessageRecordList> messageRecordList = MessageRecordBiz.GetMessageRecordList(messageRecordVm.filter, page, pageSize);
        StaticPagedList<MessageRecordList> staticPagedList = new StaticPagedList<MessageRecordList>(messageRecordList.data, page, pageSize, messageRecordList.count);
        messageRecordVm.list = (IPagedList<MessageRecordList>) staticPagedList;
        return (IActionResult) this.View((object) messageRecordVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) messageRecordVm);
      }
    }

    public void SetSelect()
    {
      List<SelectListItem> selectListItemList1 = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "無", Value = "0" },
        new SelectListItem() { Text = "會員", Value = "1" },
        new SelectListItem() { Text = "管理員", Value = "2" },
        new SelectListItem() { Text = "營運商", Value = "3" }
      };
      // ISSUE: reference to a compiler-generated field
      if (MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AccountType", typeof (MessageRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, selectListItemList1);
      List<SelectListItem> selectListItemList2 = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "站内信", Value = "1" },
        new SelectListItem() { Text = "郵箱", Value = "2" },
        new SelectListItem() { Text = "簡訊", Value = "3" }
      };
      // ISSUE: reference to a compiler-generated field
      if (MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SendType", typeof (MessageRecordController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) MessageRecordController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, selectListItemList2);
    }

    [MenuFilter(85, 6)]
    public IActionResult Detail(int pk)
    {
      this.SetSelect();
      MessageRecordEditVm localTime = PublicTool.convertUtcToLocalTime<MessageRecordEditVm>(MessageRecordBiz.GetEditVm(pk));
      localTime.info = UploadImageLib.AddHostName(localTime.info);
      return (IActionResult) this.View((object) localTime);
    }

    [UseFilter(85, 6)]
    public IActionResult Create(int member)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) MessageRecordBiz.GetAppendVm(member));
    }

    public IActionResult PostCreate(MessageRecordDto req)
    {
      this.SetSelect();
      try
      {
        req.info = UploadImageLib.RemoveHostName(req.info);
        MessageRecordBiz.PostCreate(req, this.GetUser());
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
      MessageRecordController recordController = this;
      try
      {
        string str = await UploadBiz.UploadImage(upload, FileManagementLib.Folder.message);
        return (IActionResult) new JsonResult((object) new UploadSuccess()
        {
          uploaded = 1,
          url = str
        });
      }
      catch (AppException ex)
      {
        recordController.ShowError(ex.Message);
        return (IActionResult) recordController.View();
      }
    }

    [UseFilter(85, 6)]
    public IActionResult Delete(int pk)
    {
      try
      {
        MessageRecordBiz.Delete(pk, this.GetUser());
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
