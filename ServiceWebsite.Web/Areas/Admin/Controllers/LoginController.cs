using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.ViewModels.Admin;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    public class LoginController : AdminBaseController
    {
        private readonly SettingService _settingService;
        public LoginController(SettingService settingService)
        {
            _settingService = settingService;

        }
        // GET: Admin/Login

        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Title = "Giriş";
            return View();
        }

        //
        // POST: /User/Login
        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _settingService.Login(model);
                if (loginResult)
                {
                    FormsAuthentication.SetAuthCookie("test", false);

                    return RedirectToLocalOr(returnUrl, () => RedirectToAction("Index", "ServiceSetting", new { Area = String.Empty }));
                   
                }

                

            }

            // If we got this far, something failed, redisplay form
            ViewBag.Title = "PraPazar | Giriş";
            return View(model);
        }
    }
}