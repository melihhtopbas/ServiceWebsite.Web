using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Common;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Service.WebSite
{
    public class PaymentService
    {
        private readonly WebSiteContextContainer _context;
        public PaymentService(WebSiteContextContainer context)
        {
            _context = context;
        }
        public NestpayPaymentModel GetNestPayPaymentModel(CustomerPosPaymentViewModel model, string absoluteUrl,string guid)
        {
            //string amount = ((int)(model.TransactionAmount.GetValueOrDefault() * 100)).ToString();
            string amount = model.TransactionAmount.ToString(CultureInfo.GetCultureInfo("en-US"));


            string oid = Guid.NewGuid().ToString();
            string okUrl = $"{absoluteUrl}/App/Checkout/PaymentCallback?status=true&guid={guid}";
            string failUrl = $"{absoluteUrl}/App/Checkout/PaymentCallback?status=false&guid={guid}";
    

            string rnd = DateTime.Now.ToString();
            string Url = "https://entegrasyon.asseco-see.com.tr/fim/est3Dgate";
            string storeKey = "TRPS0200";
            string clientId = "400000200";
            string storeType = "3d_pay";
            string hashString = clientId + oid + amount + okUrl + failUrl + "Auth" + "1" + rnd + storeKey;
            System.Security.Cryptography.SHA1 sha = new
                System.Security.Cryptography.SHA1CryptoServiceProvider();
            string hash = Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(hashString)));

            var paymentModel = new NestpayPaymentModel
            {
                pan = model.CardNumber,
                cv2 = model.Cvv,
                Ecom_Payment_Card_ExpDate_Month = model.ExpiryMonth,
                Ecom_Payment_Card_ExpDate_Year = model.ExpiryYear,
                clientid = clientId,
                amount = amount,
                oid = oid,
                okUrl = okUrl,
                failUrl = failUrl,
                storetype = storeType,
                rnd = rnd,
                hash = hash,
                lang = "tr",
                currency = "949",
                ActionUrl = Url,
                islemtipi = "Auth",
                taksit = "1"

            };
            return paymentModel;

        }

        public async Task<ServiceCallResult> AddCustomerPosPaymentAsync(CustomerPosPaymentModel posPaymentViewModel)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var paymentModel = new CustomerPosPayment()
            {
                CreditCardMaskedNumber = posPaymentViewModel.CreditCardMaskedNumber,
                WebsitesId = posPaymentViewModel.WebsiteId,
                TransactionId = posPaymentViewModel.TransactionId,
                ResultMessage = posPaymentViewModel.ResultMessage,
                ClientIp = posPaymentViewModel.ClientIp,
                PaymentDate = DateTime.Now,
                ExpireMonth =posPaymentViewModel.ExpireMonth ,
                ExpireYear = posPaymentViewModel.ExpireYear,
                PaymentResult = posPaymentViewModel.PostPaymentResultEnum,
                PaymentAmount = posPaymentViewModel.Amount 

            };
 

            _context.CustomerPosPayments.Add(paymentModel);

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
 

                    callResult.Success = true;
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }



        }
    }
}
