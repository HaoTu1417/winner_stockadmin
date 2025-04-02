// Decompiled with JetBrains decompiler
// Type: stockadmin.Controllers.BaseController
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: C:\Users\Administrator\Desktop\stockadmin\stockadmin\stockadmin.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CSharp.RuntimeBinder;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace stockadmin.Controllers
{
  public class BaseController : Controller
  {
    protected int pageSize = 20;
    protected static TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
    protected static string filesite = ConfigLib.Get(nameof (filesite));

    public static List<SelectListItem> getPageSizeSelectList(int sel)
    {
      List<SelectListItem> pageSizeSelectList = new List<SelectListItem>()
      {
        new SelectListItem()
        {
          Value = "20",
          Text = "20",
          Selected = false
        },
        new SelectListItem()
        {
          Value = "50",
          Text = "50",
          Selected = false
        },
        new SelectListItem()
        {
          Value = "100",
          Text = "100",
          Selected = false
        },
        new SelectListItem()
        {
          Value = "200",
          Text = "200",
          Selected = false
        },
        new SelectListItem()
        {
          Value = "500",
          Text = "500",
          Selected = false
        }
      };
      foreach (SelectListItem selectListItem in pageSizeSelectList)
      {
        if (selectListItem.Value == sel.ToString())
        {
          selectListItem.Selected = true;
          break;
        }
      }
      return pageSizeSelectList;
    }

    protected void ShowError(string message) => this.SetMessage(message, MessageLevelEnum.Error);

    protected void ShowWarning(string message)
    {
      this.SetMessage(message, MessageLevelEnum.warning);
    }

    protected void ShowMessage(string message) => this.SetMessage(message, MessageLevelEnum.Info);

    protected void SetMessage(string message, MessageLevelEnum level)
    {
      ErrorVm errorVm = new ErrorVm() { Message = message };
      switch (level)
      {
        case MessageLevelEnum.Info:
          errorVm.Css = "alert-info";
          break;
        case MessageLevelEnum.warning:
          errorVm.Css = "alert-warning";
          break;
        case MessageLevelEnum.Error:
          errorVm.Css = "alert-danger";
          break;
        default:
          errorVm.Css = "alert-success";
          break;
      }
      // ISSUE: reference to a compiler-generated field
      if (BaseController.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BaseController.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ErrorVm, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ShowAlter", typeof (BaseController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = BaseController.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) BaseController.\u003C\u003Eo__7.\u003C\u003Ep__0, this.ViewBag, errorVm);
    }

    public AdminSession GetUser()
    {
      try
      {
        string session = this.GetSession("token");
        if (string.IsNullOrEmpty(session))
          ((ControllerBase) this).HttpContext.Response.Redirect("/Login/Index");
        return PublicTool.FromJson<AdminSession>(session);
      }
      catch (Exception ex)
      {
        LogLib.Error(ex);
        ((ControllerBase) this).HttpContext.Response.Redirect("/Login/Index");
        return (AdminSession) null;
      }
    }

    public string GetLanguage()
    {
      AdminSession user = this.GetUser();
      return user == null ? string.Empty : user.lang;
    }

    protected string GetSession(string key)
    {
      return SessionExtensions.GetString(((ControllerBase) this).HttpContext.Session, key);
    }

    protected void SetSession(string key, object value)
    {
      string json = PublicTool.ToJson(value);
      SessionExtensions.SetString(((ControllerBase) this).HttpContext.Session, key, json);
    }

    protected void DeleteSession(string key)
    {
      ((ControllerBase) this).HttpContext.Session.Remove(key);
    }
  }
}
