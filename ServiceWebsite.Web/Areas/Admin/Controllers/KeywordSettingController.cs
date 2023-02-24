using System;
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
    [Authorize] 
    public class KeywordSettingController : AdminBaseController
    {
        private readonly KeywordService _keywordService;
        private readonly LanguageService _languageService;

        public KeywordSettingController(KeywordService keywordService
            , LanguageService languageService)
        {
            _keywordService = keywordService;
            _languageService = languageService;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Anahtar Kelimeler";
            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            return View("~/Areas/Admin/Views/KeywordSetting/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> KeywordList(KeywordSearchViewModel model, int? keyword)
        {
            var currentKeywordIndex = keyword - 1 ?? 0;

            var result = _keywordService.GetKeywordsListIQueryable(model)
                .OrderBy(p => p.Name)
                .ToPagedList(currentKeywordIndex, SystemConstants.DefaultKeywordPageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            ModelState.Clear();
            ViewBag.LanguageId = model.LanguageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/KeywordSetting/KeywordList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add(long languageId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "KeywordAdd" };
            var model = new KeywordAddViewModel()
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/KeywordSetting/_KeywordAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "KeywordAdd")] KeywordAddViewModel model)
        {


            if (ModelState.IsValid)
            {
                var callResult = await _keywordService.AddKeywordAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (KeywordListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/KeywordSetting/DisplayTemplates/KeywordListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "KeywordAdd" };
            return Json(
               new
               {
                   success = false,
                   responseText = RenderPartialViewToString("~/Areas/Admin/Views/KeywordSetting/_KeywordAdd.cshtml", model)
               });

        }
        public async Task<ActionResult> Edit(int keywordId)
        {
            var model = await _keywordService.GetKeywordEditViewModelAsync(keywordId);
            if (model != null)
            {
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "KeywordEdit" };
                return PartialView("~/Areas/Admin/Views/KeywordSetting/_KeywordEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Anahtar Kelime sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "KeywordEdit")] KeywordEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var callResult = await _keywordService.EditKeywordAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (KeywordListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/KeywordSetting/DisplayTemplates/KeywordListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "KeywordEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/KeywordSetting/_KeywordEdit.cshtml", model)
                });

        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int keywordId)
        {
            var callResult = await _keywordService.DeleteKeywordAsync(keywordId);
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
        public ActionResult SearchKeywordViewModelPartial(string htmlPrefix)
        {
            var model = new List<SearchKeywordViewModel>() { new SearchKeywordViewModel() };
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = htmlPrefix };

            return PartialView("~/Areas/Admin/Views/KeywordSetting/SearchKeywords.cshtml", model);
        }
    }
}