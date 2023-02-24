using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class ContactController : BaseController
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {

            _contactService = contactService;

        }
        // GET: Contact
        public ActionResult Index(string lang)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel model,string lang)
        {
            var result = _contactService.AddContactForm(model);
            if (result.Success)
            {
                return Json(new {success = result.Success, item = "başarılı"},JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {success = result.Success, item = result.ErrorMessages.FirstOrDefault()},JsonRequestBehavior.AllowGet);

            }
          
        }
    }
}