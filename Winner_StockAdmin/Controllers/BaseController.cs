using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using stockadmin.Libs;
using stockadmin.Models;
using stockadmin.Tool;
using stockadmin.ViewModels;
using System;
using System.Collections.Generic;

#nullable enable

namespace stockadmin.Controllers
{
    public class BaseController : Controller
    {
        protected int pageSize = 20;
        protected static TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
        protected static string filesite = ConfigLib.Get(nameof(filesite));

        public static List<SelectListItem> getPageSizeSelectList(int sel)
        {
            var options = new List<SelectListItem>
            {
                new SelectListItem { Value = "20", Text = "20" },
                new SelectListItem { Value = "50", Text = "50" },
                new SelectListItem { Value = "100", Text = "100" },
                new SelectListItem { Value = "200", Text = "200" },
                new SelectListItem { Value = "500", Text = "500" }
            };

            foreach (var item in options)
            {
                if (item.Value == sel.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }

            return options;
        }

        protected void ShowError(string message) => SetMessage(message, MessageLevelEnum.Error);
        protected void ShowWarning(string message) => SetMessage(message, MessageLevelEnum.warning);
        protected void ShowMessage(string message) => SetMessage(message, MessageLevelEnum.Info);

        protected void SetMessage(string message, MessageLevelEnum level)
        {
            var errorVm = new ErrorVm
            {
                Message = message,
                Css = level switch
                {
                    MessageLevelEnum.Info => "alert-info",
                    MessageLevelEnum.warning => "alert-warning",
                    MessageLevelEnum.Error => "alert-danger",
                    _ => "alert-success"
                }
            };

            ViewBag.ShowAlter = errorVm;
        }

        public AdminSession? GetUser()
        {
            try
            {
                var session = GetSession("token");
                if (string.IsNullOrEmpty(session))
                {
                    HttpContext.Response.Redirect("/Login/Index");
                    return null;
                }

                return PublicTool.FromJson<AdminSession>(session);
            }
            catch (Exception ex)
            {
                LogLib.Error(ex);
                HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
        }

        public string GetLanguage()
        {
            var user = GetUser();
            return user?.lang ?? string.Empty;
        }

        protected string GetSession(string key)
        {
            return HttpContext.Session.GetString(key) ?? string.Empty;
        }

        protected void SetSession(string key, object value)
        {
            var json = PublicTool.ToJson(value);
            HttpContext.Session.SetString(key, json);
        }

        protected void DeleteSession(string key)
        {
            HttpContext.Session.Remove(key);
        }
    }
}
