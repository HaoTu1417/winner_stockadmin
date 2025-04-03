using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.BorrowFee;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("BorrowFee")]
    public class BorrowFeeController : BaseController
    {
        private void SetFilterSelect()
        {
            // Add logic for filter dropdowns if needed
        }

        [MenuFilter(281, 5)]
        public IActionResult Index(BorrowFeeFilter filter, int page = 1, int pageSize = 20)
        {
            SetFilterSelect();
            ViewBag.pageSizeOption = BaseController.getPageSizeSelectList(pageSize);
            ViewBag.pageSize = pageSize;

            var vm = new BorrowFeeVm
            {
                filter = filter ?? new BorrowFeeFilter(),
                summary = new Summary()
            };

            try
            {
                (decimal _, DataCountBase<BorrowFeeList> dataCountBase) = BorrowFeeBiz.GetBorrowFeeList(vm.filter, page, pageSize);
                vm.list = new StaticPagedList<BorrowFeeList>(dataCountBase.data, page, pageSize, dataCountBase.count);
                vm.summary.page_total_profit = dataCountBase.data.Sum(l => l.borrow_fee);
                ViewBag.total = BorrowFeeBiz.GetBorrowFeeSummary(vm.filter);

                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(282, 5)]
        public IActionResult Download(BorrowFeeFilter filter)
        {
            try
            {
                var fileContent = BorrowFeeBiz.DownloadBorrowFeeList(filter);
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BorrowFee.xlsx");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return RedirectToAction("Index", filter);
            }
        }
    }
}
