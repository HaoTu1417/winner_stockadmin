using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Dto;
using stockadmin.Business;
using stockadmin.Filter;
using stockadmin.Internal;
using stockadmin.Libs;
using stockadmin.Tool;
using stockadmin.ViewModels.Bulletin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

#nullable enable

namespace stockadmin.Controllers
{
    [TranslatorUIFilter("Bulletin")]
    public class BulletinController : BaseController
    {
        public void SetSelect()
        {
            ViewBag.langDropdown = MultiLangBiz.FindSelectList();
            ViewBag.filesite = BaseController.filesite;
        }

        [MenuFilter(143, 7)]
        public IActionResult Index(BulletinFilter filter, int page = 1)
        {
            SetSelect();
            var vm = new BulletinVm
            {
                filter = filter ?? new BulletinFilter()
            };

            try
            {
                var list = BulletinBiz.GetBulletinList(vm.filter);
                vm.list = list.ToPagedList(page, pageSize);
                return View(vm);
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View(vm);
            }
        }

        [UseFilter(143, 7)]
        public IActionResult Edit(int pk)
        {
            SetSelect();
            var dto = PublicTool.convertLocalToUtcTime(BulletinBiz.Get(pk));
            if (!string.IsNullOrEmpty(dto.topic_content))
            {
                dto.topic_content = UploadImageLib.AddHostName(dto.topic_content);
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult PostEdit(CmsBulletinDto req)
        {
            SetSelect();
            try
            {
                req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
                BulletinBiz.PostEdit(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Edit", req);
            }
        }

        [UseFilter(143, 7)]
        public IActionResult Create()
        {
            SetSelect();
            return View(new CmsBulletinDto());
        }

        [HttpPost]
        public IActionResult PostCreate(CmsBulletinDto req)
        {
            SetSelect();
            try
            {
                req.topic_content = UploadImageLib.RemoveHostName(req.topic_content);
                BulletinBiz.PostCreate(req, GetUser());
                return RedirectToAction("Index");
            }
            catch (AppException ex)
            {
                ShowWarning(ex.Message);
                return View("Create", req);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            try
            {
                var url = await UploadBiz.UploadImage(upload, FileManagementLib.Folder.article);
                return Json(new UploadSuccess
                {
                    uploaded = 1,
                    url = url
                });
            }
            catch (AppException ex)
            {
                ShowError(ex.Message);
                return View();
            }
        }

        [UseFilter(143, 7)]
        public IActionResult Delete(int pk)
        {
            try
            {
                BulletinBiz.Delete(pk, GetUser());
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
