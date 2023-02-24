using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcPaging;
using ServiceWebsite.Core.TypeCodes;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Controllers;
using ServiceWebsite.Web.Filters;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class PaymentController : AdminBaseController   
    {
        private readonly PaymentService _paymentService;
     
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public ActionResult AllPayments()
        {
            var model = new CustomerPaymentListSearchViewModel()
            {
                PaymentSearchStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                PostPaymentResult = PostPaymentResultEnum.Success
            };
 
            return View("~/Areas/Admin/Views/Payment/AllPayments.cshtml", model);
        }

        [AjaxOnly, HttpPost, ValidateInput(false)]
        public ActionResult CustomerPaymentList(CustomerPaymentListSearchViewModel searchmodel, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;
            var result = _paymentService.GetCustomerPaymentsListIQueryable(searchmodel)
                .OrderByDescending(c => c.PaymentDate)
                .ToPagedList(currentPageIndex, 15);

            ModelState.Clear();
            ViewBag.CustomerPaymentSearchModel = searchmodel; 
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/Payment/_CustomerPaymentList.cshtml", result)
                })
            };
        }

    }
}