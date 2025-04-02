// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.WalletPaymentController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.WalletPayment;
using X.PagedList;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("WalletPayment")]
  public class WalletPaymentController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [MenuFilter(290, 5)]
    public IActionResult Index(WalletPaymentFilter filter, int page = 1)
    {
      this.SetFilterSelect();
      WalletPaymentVm walletPaymentVm = new WalletPaymentVm()
      {
        filter = filter ?? new WalletPaymentFilter()
      };
      try
      {
        walletPaymentVm.list = WalletPaymentBiz.GetWalletPaymentList(walletPaymentVm.filter).ToPagedList<WalletPaymentList>(page, this.pageSize);
        return (IActionResult) this.View((object) walletPaymentVm);
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) walletPaymentVm);
      }
    }

    public void SetSelect()
    {
    }

    [UseFilter(290, 5)]
    public IActionResult Edit(int pk)
    {
      this.SetSelect();
      return (IActionResult) this.View((object) PublicTool.convertUtcToLocalTime<WalletPaymentDto>(WalletPaymentBiz.Get(pk)));
    }

    public IActionResult PostEdit(WalletPaymentDto req)
    {
      this.SetSelect();
      try
      {
        WalletPaymentBiz.PostEdit(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Edit", (object) req);
      }
    }

    [UseFilter(290, 5)]
    public IActionResult Create()
    {
      this.SetSelect();
      return (IActionResult) this.View((object) new WalletPaymentDto()
      {
        status = true
      });
    }

    public IActionResult PostCreate(WalletPaymentDto req)
    {
      this.SetSelect();
      try
      {
        WalletPaymentBiz.PostCreate(req, this.GetUser());
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index");
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Create", (object) req);
      }
    }

    [UseFilter(289, 5)]
    public IActionResult Delete(int pk)
    {
      try
      {
        WalletPaymentBiz.Delete(pk, this.GetUser());
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
