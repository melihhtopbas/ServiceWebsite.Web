using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers.Common
{
    public class CommonController : BaseController
    {
        private readonly LanguageService _languageService;
        private readonly CategoryService _categoryService;


        public CommonController(LanguageService languageService,
            CategoryService categoryService)
        {
            _languageService = languageService;
            _categoryService = categoryService;

        }
        // GET: Common
        [HttpGet]
        public ActionResult LanguageChange(string lang)
        {

            var model = _languageService.GetLanguageListView();
            return PartialView("~/Views/Common/LanguageChange.cshtml", model);
        }


        public ActionResult LanguageChanger(string lang)
        {
            return RedirectToAction("Index","Home");
        }
        [OutputCache(Duration = int.MaxValue, VaryByParam = "none", Location = OutputCacheLocation.Downstream, NoStore = true)]
        [HttpGet]
        public ActionResult TopMenuCategories(string lang)
        {
            var model = _categoryService.GetServiceCategoryListIQueryable(lang).ToList();
            return PartialView("~/Views/Common/TopMenuCategoriesPartial.cshtml", model);
        }
        public ActionResult NotFound(string lang)
        {

            var model = _languageService.GetLanguageListView();
            return View("~/Views/Common/NotFound.cshtml", model);
        }
    }
}