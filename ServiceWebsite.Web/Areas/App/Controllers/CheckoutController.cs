using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Wordprocessing;
using ServiceWebsite.Core.TypeCodes;
using ServiceWebsite.Service.WebSite;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Web.Areas.App.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private readonly KeywordService _keywordService;
        private readonly PaymentService _paymentService;
        private readonly SettingService _settingService;
        private readonly WebsiteService _websiteService;
        public CheckoutController(KeywordService keywordService, PaymentService paymentService, SettingService settingService, WebsiteService websiteService)
        {
            _keywordService = keywordService;
            _paymentService = paymentService;
            _settingService = settingService;
            _websiteService = websiteService;
        }
        public ActionResult Index(long websiteId)
        {
            var keywordList = _keywordService.GetKeywordListForWebsite(websiteId);

            var model = new CustomerPosPaymentViewModel()
            {
                WebsiteId = websiteId,
                KeywordListViewModels = keywordList
            };
            return View("~/Areas/App/Views/Checkout/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Payment(CustomerPosPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.KeywordListViewModels.Any(a=>a.Checked))
                {
                    ViewBag.Title = "Kredi Kartı ile Kontör Yükle";
                    ModelState.AddModelError("","Lütfen satın almak istediğiniz dökümanları seçiniz");
                    return View("~/Areas/App/Views/Checkout/Index.cshtml", model);
                }
                string absoluteUrl = Request.Url?.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.AbsolutePath, StringComparison.Ordinal));
                model.TransactionAmount = model.KeywordListViewModels.Where(a => a.Checked).Sum(a => a.Price);
                string guid = Guid.NewGuid().ToString();
                _settingService.GetCustomerCreditPackagePaymentViewModel(guid, model);
                var paymentModel = _paymentService.GetNestPayPaymentModel(model, absoluteUrl, guid);

                return View("~/Areas/App/Views/Checkout/CustomerCreditPostPayment.cshtml", paymentModel);
            }

            ViewBag.Title = "Kredi Kartı ile Kontör Yükle";
            return View("~/Areas/App/Views/Checkout/Index.cshtml", model);

        }
        public async Task<ActionResult> PaymentCallback(bool status, string guid)
        {
            var response = HttpContext.Request.Form["Response"];
            var procReturnCode = HttpContext.Request.Form["ProcReturnCode"];

            //string testAmonut = HttpContext.Request.Form["amount"];

            decimal amount = Convert.ToDecimal(HttpContext.Request.Form["amount"], CultureInfo.GetCultureInfo("en-US"));

            var model = _settingService.GetCustomerCreditPackagePaymentViewModel(guid, null);
            string transactionId = HttpContext.Request.Form["TransId"];
            var customerPosPaymentViewModel = new CustomerPosPaymentModel
            {
                WebsiteId = model.WebsiteId,
                PostPaymentResultEnum = PostPaymentResultEnum.Declined,
                Amount = amount,
                ClientIp = HttpContext.Request.Form["clientIp"],
                ExpireMonth = Convert.ToByte(HttpContext.Request.Form["Ecom_Payment_Card_ExpDate_Month"]),
                ExpireYear = Convert.ToInt16(HttpContext.Request.Form["Ecom_Payment_Card_ExpDate_Year"]),
                CreditCardMaskedNumber = HttpContext.Request.Form["maskedCreditCard"].Trim(),
                PaymentDate = DateTime.Now,
                TransactionId = transactionId,
                ResultMessage = HttpContext.Request.Form["ErrMsg"]

            };
            string newGuid = Guid.NewGuid().ToString();
            _settingService.GetCustomerCreditPackagePaymentViewModel(newGuid, model);
            _settingService.RemoveCustomerCreditPackagePaymentViewModelCache(guid);
            if (status)
            {

                if (response == "Approved" && procReturnCode == "00")
                {
                    customerPosPaymentViewModel.PostPaymentResultEnum = PostPaymentResultEnum.Success;
                    var callResult = await _paymentService.AddCustomerPosPaymentAsync(customerPosPaymentViewModel);
                    if (!callResult.Success)
                    {
                        TempData[StringConstants.Notification] = new NotificationModel
                        {
                            Title = "Kredi Kartı Ödemesi",
                            Message = $"Ödeme Gerçekleştirildi. Fakat Aboneliğiniz Başlatılamadı. Lütfen İrtibata Geçiniz. İşlem Numarası:{transactionId}",
                        };
                    }
                    return RedirectToAction("PaymentSuccess", "Checkout", new { guid = newGuid });
                }
                else
                {
                    TempData[StringConstants.Notification] = new NotificationModel
                    {
                        Title = "Kredi Kartı Ödemesi",
                        Message = $"Ödeme Gerçekleştirilemedi. Hata:{HttpContext.Request.Form["ErrMsg"]}. İşlem Numarası:{transactionId}",
                    };
                    var callResult = await _paymentService.AddCustomerPosPaymentAsync(customerPosPaymentViewModel);
                    return RedirectToAction("PaymentError", "Checkout");

                }
            }
            else
            {
                TempData[StringConstants.Notification] = new NotificationModel
                {
                    Title = "Kredi Kartı Ödemesi",
                    Message = $"Ödeme Gerçekleştirilemedi. Hata:{HttpContext.Request.Form["ErrMsg"]}. İşlem Numarası:{transactionId}",
                };
                var callResult = await _paymentService.AddCustomerPosPaymentAsync(customerPosPaymentViewModel);
                return RedirectToAction("PaymentError", "Checkout");

            }
        }

        public ActionResult PaymentSuccess(string guid)
        {
            var model = _settingService.GetCustomerCreditPackagePaymentViewModel(guid, null);
            var files = _websiteService.GetWebSiteFileListIQueryable(model.WebsiteId).ToList();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(model.Email));

            using (SmtpClient client2 = new SmtpClient("ms.guzel.net.tr", 587))
            {
                msg.From = new MailAddress("info@prapazar.com");
                msg.Subject = "Dökümanlar";
                msg.IsBodyHtml = true;
                msg.Body = "Satın Almış olduğunuz dökümanlar ektedir.";
                foreach (var webSiteFileListViewModel in files)
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(Server.MapPath($"/temp/{webSiteFileListViewModel.Link}")));
                }
                client2.UseDefaultCredentials = false;
                client2.Credentials = new System.Net.NetworkCredential("info@prapazar.com", "SKoZD4znbe37");

                client2.EnableSsl = true;
                //client2.Port = 465;
                //client2.Host = "ms.guzel.net.tr";
                client2.DeliveryMethod = SmtpDeliveryMethod.Network;
                client2.Send(msg);
            }
            return View("~/Areas/App/Views/Checkout/PaymentSuccess.cshtml", files);
        }

        public ActionResult PaymentError()
        {
            return View("~/Areas/App/Views/Checkout/PaymentError.cshtml");
        }
    }
}