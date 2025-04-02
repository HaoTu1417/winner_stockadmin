// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.PromotionController
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
using stockadmin.ViewModels.Promotion;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Promotion")]
  public class PromotionController : BaseController
  {
    private void SetSelect()
    {
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      List<SelectListItem> selectListItemList1 = new List<SelectListItem>();
      selectListItemList1.Add(new SelectListItem()
      {
        Text = "請選擇顏色",
        Value = "0",
        Selected = false
      });
      selectListItemList1.Add(new SelectListItem()
      {
        Text = "紅",
        Value = "1",
        Selected = false
      });
      selectListItemList1.Add(new SelectListItem()
      {
        Text = "藍",
        Value = "2",
        Selected = false
      });
      selectListItemList1.Add(new SelectListItem()
      {
        Text = "綠",
        Value = "3",
        Selected = false
      });
      selectListItemList1.Add(new SelectListItem()
      {
        Text = "白",
        Value = "4",
        Selected = false
      });
      List<SelectListItem> selectListItemList2 = new List<SelectListItem>();
      selectListItemList2.Add(new SelectListItem()
      {
        Text = "請選擇大小",
        Value = "0",
        Selected = false
      });
      for (int index = 14; index <= 120; ++index)
        selectListItemList2.Add(new SelectListItem()
        {
          Text = index.ToString(),
          Value = index.ToString(),
          Selected = false
        });
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_colors", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, selectListItemList1);
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, selectListItemList2);
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) PromotionController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag, BaseController.filesite);
    }

    [MenuFilter(145, 7)]
    public IActionResult Index(PromotionFilter filter, int page = 1)
    {
      this.SetSelect();
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(this.pageSize));
      // ISSUE: reference to a compiler-generated field
      if (PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSize", typeof (PromotionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) PromotionController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, this.pageSize);
      PromotionVm promotionVm = new PromotionVm()
      {
        filter = filter ?? new PromotionFilter()
      };
      try
      {
        List<PromotionList> promotionList = PromotionBiz.GetPromotionList(promotionVm.filter);
        promotionVm.list = promotionList.ToPagedList<PromotionList>(page, this.pageSize);
        return (IActionResult) this.View((object) promotionVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) promotionVm);
      }
    }

    [UseFilter(145, 7)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      CmsPromotionDto localTime = PublicTool.convertUtcToLocalTime<CmsPromotionDto>(PromotionBiz.Get(pk));
      localTime.topic_content = UploadImageLib.AddHostName(localTime.topic_content);
      return (IActionResult) this.View((object) localTime);
    }

    public IActionResult PostEdit(CmsPromotionDto req)
    {
      this.SetSelect();
      try
      {
        req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
        req.topic_content = PromotionBiz.AppendTopicContentStyle(req.topic_content);
        PromotionBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(145, 7)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new CmsPromotionDto());
    }

    public IActionResult PostCreate(CmsPromotionDto req)
    {
      this.SetSelect();
      try
      {
        req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
        req.topic_content = PromotionBiz.AppendTopicContentStyle(req.topic_content);
        PromotionBiz.PostCreate(req, this.GetUser());
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
      PromotionController promotionController = this;
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
        promotionController.ShowError(ex.Message);
        return (IActionResult) promotionController.View();
      }
    }

    [UseFilter(145, 7)]
    public IActionResult Delete(int pk)
    {
      try
      {
        PromotionBiz.Delete(pk, this.GetUser());
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
