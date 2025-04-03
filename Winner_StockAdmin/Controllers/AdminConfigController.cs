using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminConfig;
using System;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("AdminConfig")]
    public class AdminConfigController : BaseController
    {
        private void SetFilterSelect()
        {
            // TODO: implement filter options if needed
        }

        private void SetSelect()
        {
            var themeOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "藍色", Value = "blue" },
                new SelectListItem { Text = "紅色", Value = "red" },
                new SelectListItem { Text = "灰色", Value = "gray" },
                new SelectListItem { Text = "棕色", Value = "brown" },
                new SelectListItem { Text = "紫色", Value = "purple" },
                new SelectListItem { Text = "綠色", Value = "green" },
                new SelectListItem { Text = "黑色", Value = "black" }
            };

            ViewBag.themes = themeOptions;
        }

        [MenuFilter(89, 9)]
        public IActionResult Index(AdminConfigFilter filter, int page = 1, int pageSize = 20)
        {
            SetFilterSelect();
            ViewBag.pageSizeOption = BaseController.getPageSizeSelectList(pageSize);
            ViewBag.pageSize = pageSize;

            var vm = new AdminConfigVm
            {
                filter = filter ?? new AdminConfigFilter()
            };

            try
            {
                var list = AdminConfigBiz.GetCommonAdminConfigList(vm.filter, GetUser());
                vm.list = list.ToPagedList(page, pageSize);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(89, 9)]
        public IActionResult Edit(string name)
        {
            SetSelect();
            var config = AdminConfigBiz.Get(name);
            return View(PublicTool.convertUtcToLocalTime(config));
        }

        [HttpPost]
        public IActionResult PostEdit(AdminConfigDto req)
        {
            SetSelect();
            try
            {
                AdminConfigBiz.PostEdit(req, GetUser());
                ConfigLib.Reset();
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Edit", req);
            }
        }

        [UseFilter(89, 9)]
        public IActionResult Create()
        {
            SetSelect();
            return View(new AdminConfigDto());
        }

        [HttpPost]
        public IActionResult PostCreate(AdminConfigDto req)
        {
            SetSelect();
            try
            {
                AdminConfigBiz.PostCreate(req, GetUser());
                ConfigLib.Reset();
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Create", req);
            }
        }

        public IActionResult UpdateCache()
        {
            try
            {
                ConfigLib.Reset();
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
