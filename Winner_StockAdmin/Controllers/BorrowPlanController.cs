using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.BorrowPlan;
using System;
using System.Collections.Generic;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("BorrowPlan")]
    public class BorrowPlanController : BaseController
    {
        public void SetSelect()
        {
            ViewBag.market = SysMarketBiz.GetDropDownList(GetLanguage());
        }

        [MenuFilter(1, 3)]
        public IActionResult Index(BorrowPlanFilter filter, int page = 1)
        {
            SetSelect();
            var vm = new BorrowPlanVm
            {
                filter = filter ?? new BorrowPlanFilter()
            };

            try
            {
                vm.list = BorrowPlanBiz.GetBorrowPlanList(vm.filter);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(1, 3)]
        public IActionResult Edit(int pk)
        {
            SetSelect();
            var dto = PublicTool.convertUtcToLocalTime(BorrowPlanBiz.Get(pk));
            return View(dto);
        }

        [HttpPost]
        public IActionResult PostEdit(BorrowPlanDto req)
        {
            SetSelect();
            try
            {
                BorrowPlanBiz.PostEdit(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Edit", req);
            }
        }
    }
}