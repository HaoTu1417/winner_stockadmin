// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.MemberBankController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.ViewModels.MemberBank;
using System.Collections.Generic;

#nullable enable
namespace stockadmin.Controllers
{
  [TranslatorUIFilter("MemberBank")]
  public class MemberBankController : BaseController
  {
    private void SetFilterSelect()
    {
    }

    [UseFilter(272, 5)]
    public IActionResult Index(int member)
    {
      this.SetFilterSelect();
      try
      {
        return (IActionResult) this.View((object) MemberBankBiz.GetMemberBankList(member));
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View((object) new List<MemberBankList>());
      }
    }

    [UseFilter(272, 5)]
    public IActionResult Review(string card_pk)
    {
      return (IActionResult) this.View((object) MemberBankBiz.GetReview(card_pk));
    }

    public IActionResult PostReview(MemberBankDto req, bool result)
    {
      try
      {
        int temp_id = result ? 110 : 111;
        if (result)
        {
          MemberBankBiz.PostEditIsConfirm(req, true, this.GetUser());
          MemberBankBiz.PostEditIsDelete(req, false, this.GetUser());
          MemberTaskLib.MemberTaskFinish(req.member_fk, 7);
          SendMessageLib.Send(req.member_fk, temp_id, (object) req.card_type, (object) req.card);
        }
        else
        {
          MemberBankBiz.PostEditIsConfirm(req, false, this.GetUser());
          MemberBankBiz.PostEditIsDelete(req, true, this.GetUser());
          SendMessageLib.Send(req.member_fk, temp_id, (object) req.card_type, (object) req.card);
        }
        return (IActionResult) ((ControllerBase) this).RedirectToAction("Index", (object) new
        {
          member = req.member_fk
        });
      }
      catch (AppException ex)
      {
        this.ShowWarning(ex.Message);
        return (IActionResult) this.View("Review", (object) req);
      }
    }
  }
}
