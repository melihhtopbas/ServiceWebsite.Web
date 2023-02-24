using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class AboutController : BaseController
    {
       
        private readonly SettingService _settingService;

        public AboutController(SettingService settingService)
        {
            _settingService = settingService;
        }
        // GET: About
        public ActionResult Index(string lang)
        {
            var model = _settingService.GetAboutViewModel(lang);
            if (model==null)
            {
                return RedirectToAction("NotFound", "Common",new{lang=lang});
            }
            return View(model);
        }
    }
}