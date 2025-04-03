using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.AdminBank;
using System;
using System.Collections.Generic;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("AdminBank")]
    public class AdminBankController : BaseController
    {
        public void SetSelect(string lang)
        {
            var cardTypeList = lang == "EN"
                ? new List<SelectListItem>
                {
                    new SelectListItem { Text = "Bank account", Value = "1" },
                    new SelectListItem { Text = "Crypto address", Value = "2" }
                }
                : new List<SelectListItem>
                {
                    new SelectListItem { Text = "銀行帳號", Value = "1" },
                    new SelectListItem { Text = "虛擬貨幣地址", Value = "2" }
                };

            ViewBag.card_type = cardTypeList;
            ViewBag.filesite = BaseController.filesite;
        }

        [MenuFilter(302, 5)]
        public IActionResult Index(AdminBankFilter filter, int page = 1)
        {
            SetSelect(GetUser().lang);
            var vm = new AdminBankVm
            {
                filter = filter ?? new AdminBankFilter()
            };

            try
            {
                vm.list = AdminBankBiz.GetAdminBankList(vm.filter, GetUser().lang);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(303, 5)]
        public IActionResult Edit(int pk)
        {
            SetSelect(GetUser().lang);
            var dto = PublicTool.convertUtcToLocalTime(AdminBankBiz.Get(pk));
            return View(dto);
        }

        [HttpPost]
        public IActionResult PostEdit(AdminBankDto req)
        {
            SetSelect(GetUser().lang);
            try
            {
                AdminBankBiz.PostEdit(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Edit", req);
            }
        }

        [UseFilter(435, 5)]
        public IActionResult Create()
        {
            SetSelect(GetUser().lang);
            return View(new AdminBankDto());
        }

        [HttpPost]
        public IActionResult PostCreate(AdminBankDto req)
        {
            SetSelect(GetUser().lang);
            try
            {
                AdminBankBiz.PostCreate(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Create", req);
            }
        }

        [UseFilter(304, 5)]
        public IActionResult Delete(int pk)
        {
            try
            {
                AdminBankBiz.Delete(pk, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
