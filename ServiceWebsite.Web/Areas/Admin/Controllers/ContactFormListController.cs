using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcPaging;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Filters;
using ServiceWebsite.ViewModels.Admin;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ContactFormListController : AdminBaseController
    {
        private readonly ContactService _contactService;


        public ContactFormListController(ContactService contactService)
        {
            _contactService = contactService;

        }

        public  ActionResult Index()
        {
            ViewBag.Title = "İletişim Form";
 
            return View("~/Areas/Admin/Views/ContactFormList/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public ActionResult ContactList(ContactViewModel contactViewModel, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _contactService.GetContactListIQueryable(contactViewModel).OrderByDescending(a => a.Id)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultServicePageSize);

             
            ModelState.Clear();
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/ContactFormList/ContactList.cshtml", result)
                })
            };
        }

        [AjaxOnly]
        public async Task<ActionResult> ContactDetailAsync(int contactId)
        {
            var model =await _contactService.GetContactDetailModelAsync(contactId).ConfigureAwait(false);
            return PartialView("~/Areas/Admin/Views/ContactFormList/_MessageView.cshtml", model);
        }
    }
}