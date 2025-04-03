using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.BorrowAddmoney;
using System;
using System.Collections.Generic;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("BorrowAddmoney")]
    public class BorrowAddmoneyController : BaseController
    {
        public void SetSelect()
        {
            ViewBag.market = SysMarketBiz.GetDropDownList(GetLanguage());
        }

        [MenuFilter(329, 3)]
        public IActionResult Index(BorrowAddmoneyFilter filter, int page = 1)
        {
            SetSelect();
            var vm = new BorrowAddmoneyVm
            {
                filter = filter ?? new BorrowAddmoneyFilter()
            };

            try
            {
                vm.list = BorrowAddmoneyBiz.GetBorrowAddmoneyList(vm.filter);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [MenuFilter(329, 3)]
        public IActionResult Review(int pk)
        {
            var review = PublicTool.convertUtcToLocalTime(BorrowAddmoneyBiz.GetReview(pk));
            return View(review);
        }

        [MenuFilter(329, 3)]
        public IActionResult PostReview(BorrowAddmoneyDto req, bool result)
        {
            try
            {
                BorrowAddmoneyBiz.ReviewApprove(req.pk, result, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                var review = PublicTool.convertUtcToLocalTime(BorrowAddmoneyBiz.GetReview(req.pk));
                return View(review);
            }
        }
    }
}