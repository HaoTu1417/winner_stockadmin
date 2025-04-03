using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Tool;
using stockadmin.ViewModels.Banner;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("Banner")]
    public class BannerController : BaseController
    {
        public void SetSelect(string lang)
        {
            ViewBag.langDropdown = MultiLangBiz.FindSelectList();
            ViewBag.filesite = BaseController.filesite;

            ViewBag.sizes = new List<SelectListItem>
            {
                new SelectListItem { Text = lang == "EN" ? "PC" : "桌機", Value = "0" },
                new SelectListItem { Text = lang == "EN" ? "Phone" : "手機", Value = "1" }
            };

            ViewBag.watermark_colors = new List<SelectListItem>
            {
                new SelectListItem { Text = lang == "EN" ? "Select color" : "請選擇顏色", Value = "0" },
                new SelectListItem { Text = lang == "EN" ? "Red" : "紅", Value = "1" },
                new SelectListItem { Text = lang == "EN" ? "Blue" : "藍", Value = "2" },
                new SelectListItem { Text = lang == "EN" ? "Green" : "綠", Value = "3" },
                new SelectListItem { Text = lang == "EN" ? "White" : "白", Value = "4" }
            };

            var watermarkSizes = new List<SelectListItem>
            {
                new SelectListItem { Text = lang == "EN" ? "Select size" : "請選擇大小", Value = "0" }
            };
            for (int i = 14; i <= 120; i++)
            {
                watermarkSizes.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.watermark_sizes = watermarkSizes;
        }

        [MenuFilter(220, 7)]
        public IActionResult Index(BannerFilter filter, int page = 1, int pageSize = 20)
        {
            SetSelect(GetUser().lang);
            ViewBag.pageSizeOption = BaseController.getPageSizeSelectList(pageSize);
            ViewBag.pageSize = pageSize;

            var vm = new BannerVm
            {
                filter = filter ?? new BannerFilter()
            };

            try
            {
                var list = BannerBiz.GetBannerList(vm.filter, GetUser().lang);
                vm.list = list.ToPagedList(page, pageSize);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(220, 7)]
        public IActionResult Edit(int cms_files_fk)
        {
            SetSelect(GetUser().lang);
            var dto = PublicTool.convertUtcToLocalTime(BannerBiz.Get(cms_files_fk));
            return View(dto);
        }

        [HttpPost]
        public IActionResult PostEdit(CmsBannerDto req)
        {
            SetSelect(GetUser().lang);
            try
            {
                BannerBiz.PostEdit(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Edit", req);
            }
        }

        [UseFilter(220, 7)]
        public IActionResult Create()
        {
            SetSelect(GetUser().lang);
            return View(new CmsBannerDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(CmsBannerDto req)
        {
            SetSelect(GetUser().lang);
            try
            {
                await BannerBiz.PostCreate(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowError(ex.Message);
                return View("Create", req);
            }
        }

        [UseFilter(220, 7)]
        public async Task<IActionResult> Delete(int cms_files_fk)
        {
            try
            {
                await BannerBiz.Delete(cms_files_fk, GetUser());
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
