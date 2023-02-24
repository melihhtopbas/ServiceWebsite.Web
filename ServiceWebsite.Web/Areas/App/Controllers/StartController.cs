using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using ServiceWebsite.Service.WebSite;


namespace ServiceWebsite.Web.Areas.App.Controllers
{
    public class StartController : Controller
    {
        private readonly WebsiteService _websiteService;
        private readonly CheckService _checkService;
        public StartController(WebsiteService websiteService, CheckService checkService)
        {
            _websiteService = websiteService;
            _checkService = checkService;

        }
        // GET: Start
        public ActionResult Index()
        {
            return View();
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


        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}