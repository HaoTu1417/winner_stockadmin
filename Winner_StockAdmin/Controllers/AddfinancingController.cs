// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.AddfinancingController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels.Addfinancing;
using System.Collections.Generic;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("Addfinancing")]
  public class AddfinancingController : BaseController
  {
    public void SetSelect()
    {
    }

    [MenuFilter(325, 3)]
    public IActionResult Index(AddfinancingFilter filter, int page = 1)
    {
      this.SetSelect();
      AddfinancingVm addfinancingVm = new AddfinancingVm()
      {
        filter = filter ?? new AddfinancingFilter()
      };
      try
      {
        List<AddfinancingList> addfinancingList = AddfinancingBiz.GetAddfinancingList(addfinancingVm.filter);
        addfinancingVm.list = addfinancingList.ToPagedList<AddfinancingList>(page, this.pageSize);
        return (IActionResult) this.View((object) addfinancingVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) addfinancingVm);
      }
    }

    [UseFilter(325, 3)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<BorrowAddfinancingDto>(AddfinancingBiz.Get(pk)));
    }

    public IActionResult PostEdit(BorrowAddfinancingDto req)
    {
      this.SetSelect();
      try
      {
        AdminSession user = this.GetUser();
        AddfinancingBiz.PostEdit(req, user);
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(325, 3)]
    public IActionResult Review(int pk)
    {
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<AddfinancingReview>(AddfinancingBiz.GetReview(pk)));
    }

    [UseFilter(325, 3)]
    public IActionResult PostReview(BorrowAddfinancingDto req, bool result)
    {
      try
      {
        AddfinancingBiz.ExpandBorrowVerify(req.pk, result, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) PublicTool.convertUtcToLocalTime<AddfinancingReview>(AddfinancingBiz.GetReview(req.pk)));
      }
    }
  }
}
