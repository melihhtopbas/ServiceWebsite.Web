using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class FaqController : BaseController
    {
        private readonly FaqService _faqService;

        public FaqController(FaqService faqService)
        {
            _faqService = faqService;
        }
        public ActionResult Index(string lang)
        {
            var model = _faqService.GetFaqListIQueryable(lang).OrderByDescending(a => a.Id).ToList();
            return View(model);
        }
    }
}