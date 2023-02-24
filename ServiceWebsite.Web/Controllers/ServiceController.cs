using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using ServiceWebsite.Service.WebSite;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class ServiceController : BaseController
    {        // GET: Home
     
        private readonly ServiceService _serviceService;
  
        public ServiceController(ServiceService serviceService)
        {
         
            _serviceService = serviceService;
     
        }
        // GET: Service
        public ActionResult Index(string lang)
        {
            var model = _serviceService.GetServiceListIQueryable(lang).ToList();
            return View(model);
        }
        public ActionResult ServiceDetail(string lang, string link)
        {
            var model = _serviceService.GetServiceDetail(lang, link);
            return View(model);
        }
        public ActionResult ServiceDetailModal(string lang, string link)
        {
            var model = _serviceService.GetServiceDetail(lang, link);
            return PartialView("~/Views/Service/_ServiceDetailModal.cshtml", model);
        }
        public ActionResult ServiceRequestQuote(string lang, string name)
        {
            var model = new RequestQuoteViewModel
            {
                Service = name
            };
            return PartialView("~/Views/Service/_ServiceRequestQuote.cshtml",model);
        }
        public ActionResult ServicesList(string lang, string link)
        {
            var model = _serviceService.GetServicesList(lang, link).OrderByDescending(a => Guid.NewGuid()).Take(3)
                .ToList();
            return PartialView("~/Views/Service/ServicesList.cshtml", model);
        }

    }
}