using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Models.Dto;
using stockadmin.ViewModels.ClosedTradeAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("ClosedTradeAccount")]
    public class ClosedTradeAccountController : BaseController
    {
        public void SetSelect()
        {
            ViewBag.market = SysMarketBiz.GetDropDownList(GetLanguage());
            ViewBag.borrowType = BorrowPlanBiz.GetSelectListItems();
            ViewBag.status = Enum
                .GetValues(typeof(FilterAccountStatusType))
                .Cast<FilterAccountStatusType>()
                .Select(status => new SelectListItem
                {
                    Text = ConvertEnum.ConvertAccountStatus((int)status, GetUser().lang),
                    Value = ((int)status).ToString()
                })
                .ToList();
        }

        [MenuFilter(389, 2)]
        public IActionResult Index(ClosedTradeAccountFilter filter, int page = 1, int pageSize = 20)
        {
            SetSelect();
            ViewBag.pageSizeOption = getPageSizeSelectList(pageSize);
            ViewBag.pageSize = pageSize;

            var vm = new ClosedTradeAccountVm
            {
                filter = filter ?? new ClosedTradeAccountFilter()
            };

            try
            {
                var result = ClosedTradeAccountBiz.GetClosedTradeAccountLists(vm.filter, page, pageSize);
                vm.list = new StaticPagedList<ClosedTradeAccountList>(result.data, page, pageSize, result.count);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(new ClosedTradeAccountVm());
            }
        }
    }
}