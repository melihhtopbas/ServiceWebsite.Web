using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using ServiceWebsite.Data;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Service.WebSite;
using ServiceWebsite.ViewModels.Admin;
using BlogService = ServiceWebsite.Service.WebSite.BlogService;
using CategoryService = ServiceWebsite.Service.WebSite.CategoryService;
using CustomerCommentService = ServiceWebsite.Service.WebSite.CustomerCommentService;
using LanguageService = ServiceWebsite.Service.WebSite.LanguageService;
using PageService = ServiceWebsite.Service.WebSite.PageService;
using PropertyService = ServiceWebsite.Service.WebSite.PropertyService;
using ReferenceService = ServiceWebsite.Service.WebSite.ReferenceService;
using ServiceService = ServiceWebsite.Service.WebSite.ServiceService;
using SettingService = ServiceWebsite.Service.WebSite.SettingService;
using SliderService = ServiceWebsite.Service.WebSite.SliderService;

namespace ServiceWebsite.Web.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        private readonly LanguageService _languageService;
        private readonly SliderService _sliderService;
        private readonly ServiceService _serviceService;
        private readonly CategoryService _categoryService;
        private readonly BlogService _blogService;
        private readonly ReferenceService _referenceService;
        private readonly PropertyService _propertyService;
        private readonly CustomerCommentService _customercommentService;
        private readonly SettingService _settingService;
        private readonly PageService _pageService;
        private readonly WebsiteService _websiteService;
        private readonly CheckService _checkService;
        private readonly CustomerAttributeService _customerAttributeService;


        public HomeController(LanguageService languageService,
            SliderService sliderService,
            ServiceService serviceService,
            CategoryService categoryService,
            BlogService blogService,
            ReferenceService referenceService,
            PropertyService propertyService,
            CustomerCommentService customercommentService,
            SettingService settingService,
            WebsiteService websiteService,
            CheckService checkService,
            CustomerAttributeService customerAttributeService,
            PageService pageService
            )
        {
            _languageService = languageService;
            _sliderService = sliderService;
            _serviceService = serviceService;
            _categoryService = categoryService;
            _blogService = blogService;
            _referenceService = referenceService;
            _propertyService = propertyService;
            _customercommentService = customercommentService;
            _settingService = settingService;
            _websiteService = websiteService;
            _pageService = pageService;
            _checkService = checkService;
            _customerAttributeService = customerAttributeService;
        }
        
        public ActionResult Index(string lang)
        {
            return View();
        }
        public ActionResult SliderPartial()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _sliderService.GetSliderListIQueryable(lang).ToList();
            return PartialView("~/Views/Home/SliderPartial.cshtml", model);
        }
        public ActionResult NewServicesPartial()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _serviceService.GetNewServiceListIQueryable(lang).OrderBy(a => Guid.NewGuid()).Take(6).ToList();
            return PartialView("~/Views/Home/NewServicesPartial.cshtml", model);
        }
        public ActionResult HomePageCategories()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _categoryService.GetHomePageServiceCategoryListIQueryable(lang).ToList();
            return PartialView("~/Views/Home/HomePageCategoriesPartial.cshtml", model);
        }
        public ActionResult HomePageBlogs()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _blogService.GetHomePageBlogsListIQueryable(lang).OrderByDescending(a => a.Date).ToPagedList(0, 3);
            return PartialView("~/Views/Home/HomePageBlogsPartial.cshtml", model);
        }

        public ActionResult HomePageReferences()
        {
            var model = _referenceService.GetHomePageReferencesListIQueryable().ToList();
            return PartialView("~/Views/Home/HomePageReferencesPartial.cshtml", model);
        }
        public ActionResult HomePageProperties()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _propertyService.GetHomePagePropertyListIQueryable(lang).OrderBy(a => Guid.NewGuid()).ToList();
            return PartialView("~/Views/Home/HomePagePropertyPartial.cshtml", model);
        }
        public ActionResult HomePageCustomerComments()
        {
            var model = _customercommentService.GetHomePageCustomerCommentListIQueryable().ToList();
            return PartialView("~/Views/Home/HomePageCustomerCommentPartial.cshtml", model);
        }
        public ActionResult HomePageAbout()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _settingService.GetAboutViewModel(lang);
            return PartialView("~/Views/Home/HomePageAboutPartial.cshtml", model);
        }
        public ActionResult HomePage()
        {
            string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var model = _pageService.GetHomePageListIQueryable(lang).ToList();
            return PartialView("~/Views/Home/HomePagePartial.cshtml", model);
        }
        public async Task<ActionResult> Analysis(string websiteUrl)
        {
            var result = await _checkService.GezAsync(websiteUrl);
            var webSiteId = _websiteService.WebsiteAdd(websiteUrl);
            var callResult = _websiteService.WebsiteFileAdd(webSiteId, result.Keywords, string.Empty);
            if (callResult.Success)
            {
                result.WebsiteId = webSiteId;

                return Json(new { success = true, item = RenderPartialViewToString("~/Areas/App/Views/Start/Result.cshtml", result) });

            }
            else
            {
                result.WebsiteId = webSiteId;

                return Json(new { success = false });
            }

        }


    }
}