// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AdvertiseController
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
using stockadmin.ViewModels.Advertise;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Advertise")]
  public class AdvertiseController : BaseController
  {
    public void SetSelect(string lang)
    {
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "langDropdown", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, MultiLangBiz.FindSelectList());
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "filesite", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, BaseController.filesite);
      List<SelectListItem> selectListItemList1 = new List<SelectListItem>();
      if (lang == "VN")
      {
        selectListItemList1.Add(new SelectListItem()
        {
          Text = "Máy tính để bàn",
          Value = "0",
          Selected = false
        });
        selectListItemList1.Add(new SelectListItem()
        {
          Text = "điện thoại di động",
          Value = "1",
          Selected = false
        });
      }
      else
      {
        selectListItemList1.Add(new SelectListItem()
        {
          Text = "桌機",
          Value = "0",
          Selected = false
        });
        selectListItemList1.Add(new SelectListItem()
        {
          Text = "手機",
          Value = "1",
          Selected = false
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sizes", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, selectListItemList1);
      List<SelectListItem> selectListItemList2 = new List<SelectListItem>();
      if (lang == "VN")
      {
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "Hãy chọn một màu nhé",
          Value = "0",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "màu đỏ",
          Value = "1",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "màu xanh da trời",
          Value = "2",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "màu xanh lá",
          Value = "3",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "trắng",
          Value = "4",
          Selected = false
        });
      }
      else
      {
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "請選擇顏色",
          Value = "0",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "紅",
          Value = "1",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "藍",
          Value = "2",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "綠",
          Value = "3",
          Selected = false
        });
        selectListItemList2.Add(new SelectListItem()
        {
          Text = "白",
          Value = "4",
          Selected = false
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_colors", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag, selectListItemList2);
      List<SelectListItem> selectListItemList3 = new List<SelectListItem>();
      if (lang == "VN")
        selectListItemList3.Add(new SelectListItem()
        {
          Text = "Xin vui lòng chọn kích cỡ",
          Value = "0",
          Selected = false
        });
      else
        selectListItemList3.Add(new SelectListItem()
        {
          Text = "請選擇大小",
          Value = "0",
          Selected = false
        });
      for (int index = 14; index <= 120; ++index)
        selectListItemList3.Add(new SelectListItem()
        {
          Text = index.ToString(),
          Value = index.ToString(),
          Selected = false
        });
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "watermark_sizes", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__4.Target((CallSite) AdvertiseController.\u003C\u003Eo__0.\u003C\u003Ep__4, this.ViewBag, selectListItemList3);
    }

    [MenuFilter(221, 7)]
    public IActionResult Index(AdvertiseFilter filter, int page = 1, int pageSize = 20)
    {
      this.SetSelect(this.GetUser().lang);
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pageSizeOption", typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, BaseController.getPageSizeSelectList(pageSize));
      // ISSUE: reference to a compiler-generated field
      if (AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, nameof (pageSize), typeof (AdvertiseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) AdvertiseController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, pageSize);
      AdvertiseVm advertiseVm = new AdvertiseVm()
      {
        filter = filter ?? new AdvertiseFilter()
      };
      try
      {
        List<AdvertiseList> advertiseList = AdvertiseBiz.GetAdvertiseList(advertiseVm.filter);
        advertiseVm.list = advertiseList.ToPagedList<AdvertiseList>(page, pageSize);
        return (IActionResult) this.View((object) advertiseVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) advertiseVm);
      }
    }

    [UseFilter(221, 7)]
    public IActionResult Edit(int cms_files_fk)
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<CmsAdvertiseDto>(AdvertiseBiz.Get(cms_files_fk)));
    }

    public IActionResult PostEdit(CmsAdvertiseDto req)
    {
      this.SetSelect(this.GetUser().lang);
      try
      {
        AdvertiseBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(221, 7)]
    public IActionResult Create()
    {
      this.SetSelect(this.GetUser().lang);
      return (IActionResult) this.View((object) new CmsAdvertiseDto());
    }

    public async Task<IActionResult> PostCreate(CmsAdvertiseDto req)
    {
      AdvertiseController advertiseController = this;
      advertiseController.SetSelect(advertiseController.GetUser().lang);
      try
      {
        await AdvertiseBiz.PostCreate(req, advertiseController.GetUser());
        return (IActionResult) ((ControllerBase) advertiseController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        advertiseController.ShowError(ex.Message);
        return (IActionResult) advertiseController.View("Create", (object) req);
      }
    }

    [UseFilter(221, 7)]
    public async Task<IActionResult> Delete(int cms_files_fk)
    {
      AdvertiseController advertiseController = this;
      try
      {
        await AdvertiseBiz.Delete(cms_files_fk, advertiseController.GetUser());
        return (IActionResult) ((ControllerBase) advertiseController).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        advertiseController.ShowWarning(ex.Message);
        return (IActionResult) ((ControllerBase) advertiseController).RedirectToAction("Index");
      }
    }
  }
}
