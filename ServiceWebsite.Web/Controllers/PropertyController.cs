using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class PropertyController : BaseController
    {

        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {

            _propertyService = propertyService;

        }
        public ActionResult Index(string lang)
        {

            var model = _propertyService.GetPropertyListIQueryable(lang).OrderByDescending(a => a.Id).ToList();
            return View(model);
        }
        
    }
}