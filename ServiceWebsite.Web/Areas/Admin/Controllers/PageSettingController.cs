﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcPaging;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Filters;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    public class PageSettingController : AdminBaseController
    {
        private readonly PageService _pageService;
        private readonly LanguageService _languageService;

        public PageSettingController(PageService pageService
            , LanguageService languageService)
        {
            _pageService = pageService;
            _languageService = languageService;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Sayfalar";
            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            return View("~/Areas/Admin/Views/PageSetting/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> PageList(PageSearchViewModel model, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _pageService.GetPagesListIQueryable(model)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultPropertyPageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            ModelState.Clear();
            ViewBag.LanguageId = model.LanguageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/PageSetting/PageList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add(long languageId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "PageAdd" };
             var model = new PageAddViewModel()
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/PageSetting/_PageAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "PageAdd")] PageAddViewModel model)
        {


            if (ModelState.IsValid)
            {
                var callResult = await _pageService.AddPageAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (PageListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/PageSetting/DisplayTemplates/PageListViewModel.cshtml", viewModel),
                            item = viewModel
                        });
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                foreach (var error in callResult.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "PageAdd" };
             return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/PageSetting/_PageAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> Edit(int pageId)
        {
            var model = await _pageService.GetPageEditViewModelAsync(pageId);
            if (model != null)
            {
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "PageEdit" };
                return PartialView("~/Areas/Admin/Views/PageSetting/_PageEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Sayfa sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "PageEdit")] PageEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var callResult = await _pageService.EditPageAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (PageListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/PageSetting/DisplayTemplates/PageListViewModel.cshtml", viewModel),
                            item = viewModel
                        });
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                foreach (var error in callResult.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
             ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "PageEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/PageSetting/_PageEdit.cshtml", model)
                });

        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int pageId)
        {
            var callResult = await _pageService.DeletePageAsync(pageId);
            if (callResult.Success)
            {

                ModelState.Clear();

                return Json(
                    new
                    {
                        success = true,
                        warningMessages = callResult.WarningMessages,
                        successMessages = callResult.SuccessMessages,
                    });
            }

            return Json(
                new
                {
                    success = false,
                    errorMessages = callResult.ErrorMessages
                });

        }
    }
}