using DB.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Tree;
using stockadmin.Tool;
using stockadmin.ViewModels;
using stockadmin.ViewModels.AdminRole;
using System;
using System.Collections.Generic;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("AdminRole")]
    public class AdminRoleController : BaseController
    {
        [MenuFilter(408, 10)]
        public IActionResult Index(ErrorVm? err = null)
        {
            try
            {
                if (err != null)
                    ViewBag.ShowAlter = err;

                var adminRoleList = AdminRoleBiz.GetAdminRoleList(GetUser().is_super);
                TimeTool.ConvertTimeZone(adminRoleList, BaseController.tz);
                return View(adminRoleList);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View();
            }
        }

        [UseFilter(411, 10)]
        public IActionResult Edit(int id)
        {
            try
            {
                var roleDto = PublicTool.convertUtcToLocalTime(AdminRoleService.Find(id));
                ViewBag.tree = PublicTool.ToJson(AdminRoleBiz.AdminMenuToTree(roleDto.admin_menu));
                ViewBag.admin_module_list = AdminModuleBiz.GetEnabledList();
                return View(roleDto);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult PostEdit(AdminRoleDto req, string tree)
        {
            try
            {
                req.admin_menu = AdminRoleBiz.TreeToAdminMenu(tree);
                AdminRoleBiz.PostEdit(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Edit", new { id = req.pk });
            }
        }

        [UseFilter(411, 10)]
        public IActionResult Create(AdminRoleDto? req)
        {
            try
            {
                var roleDto = req ?? new AdminRoleDto();
                ViewBag.tree = PublicTool.ToJson(AdminRoleBiz.AdminMenuToTree(string.Empty));
                ViewBag.admin_module_list = AdminModuleBiz.GetEnabledList();
                return View(roleDto);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult PostCreate(AdminRoleDto req, string tree)
        {
            try
            {
                req.admin_menu = AdminRoleBiz.TreeToAdminMenu(tree);
                AdminRoleBiz.PostCreate(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Create", req);
            }
        }

        [UseFilter(411, 10)]
        public IActionResult Delete(int id)
        {
            try
            {
                AdminRoleBiz.Delete(id, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowError(ex.Message);
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
