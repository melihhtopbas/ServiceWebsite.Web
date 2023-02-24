using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class PageController : BaseController
    {
        private readonly PageService _pageService;

        public PageController(PageService pageService)
        {
            _pageService = pageService;
        }
        // GET: About
        public ActionResult Index(string lang,string link)
        {
            var model = _pageService.GetPageDetail(lang,link);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Common", new { lang = lang });
            }
            return View(model);
        }
    }
}