using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Core.TypeCodes;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class CustomerPosPaymentViewModel
    {
        public CustomerPosPaymentViewModel()
        {
            KeywordListViewModels=new List<KeywordListViewModel>();
        }


        //[Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Amount")]
        public decimal TransactionAmount { get; set; }


        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        //[StringLength(16, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [RegularExpression(@"^[1-9][0-9]{3}([0-9]{4}){3}$", ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "CreditCardNumberNotValid")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "CardNumber")]
        public string CardNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        //[StringLength(3, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "CvvNotValid")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Cvv")]
        public string Cvv { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ExpiryDate")]
        public string ExpiryYear { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ExpiryDate")]
        public string ExpiryMonth { get; set; }

        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Installment")]
        public string Installment { get; set; }


        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Email")]
        public string Email { get; set; }
 
        public long WebsiteId { get; set; }
        public IEnumerable<KeywordListViewModel> KeywordListViewModels { get; set; }
    }

    public class CustomerPosPaymentModel
    {
        public long WebsiteId { get; set; }
        public PostPaymentResultEnum PostPaymentResultEnum { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Range(0.01, Double.MaxValue, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RangeMinError")]
        public Decimal Amount { get; set; }

        [StringLength(80, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        public string TransactionId { get; set; }

        [StringLength(50, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        public string ClientIp { get; set; }

        [StringLength(20, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        public string CreditCardMaskedNumber { get; set; }

        [StringLength(500, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        public string ResultMessage { get; set; }

        public DateTime PaymentDate { get; set; }

        public short ExpireYear { get; set; }

        public byte ExpireMonth { get; set; }

    }

    public class NestpayPaymentModel
    {  //user id (merchant id)
        public string clientid { get; set; }

        //store type (given fixed value 3d_pay)
        public string storetype { get; set; }

        //calculate some fields hashing data, see in the controller
        public string hash { get; set; }

        //process type (given fixed value Auth)
        public string islemtipi { get; set; }

        //amount
        public string amount { get; set; }

        //currency code (given fixed value 949)
        public string currency { get; set; }

        //order id
        public string oid { get; set; }

        //postback success url
        public string okUrl { get; set; }

        //postback fail url
        public string failUrl { get; set; }

        //lang 2 letter code (given fixed value tr)
        public string lang { get; set; }

        //random process number
        public string rnd { get; set; }

        //credit cart number
        public string pan { get; set; }

        //credit cart expire date year part
        public string Ecom_Payment_Card_ExpDate_Year { get; set; }

        //credit cart expire date mont part
        public string Ecom_Payment_Card_ExpDate_Month { get; set; }

        //credit cart cvv2 code
        public string cv2 { get; set; }

        //installment amount (for example 3 moths, give value 3)
        public string taksit { get; set; }

        //passing gateway url
        public string ActionUrl { get; set; }
    }
}
