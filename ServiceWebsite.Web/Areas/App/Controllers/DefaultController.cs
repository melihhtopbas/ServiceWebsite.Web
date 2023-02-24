using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceWebsite.Web.Areas.App.Controllers
{
    public class DefaultController : Controller
    {
        // GET: App/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}