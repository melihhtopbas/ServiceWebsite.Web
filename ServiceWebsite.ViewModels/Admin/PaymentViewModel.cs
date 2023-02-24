using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAnnotations.Attributes;
using ServiceWebsite.Core.TypeCodes;

namespace ServiceWebsite.ViewModels.Admin
{

    public class CustomerPaymentListViewModel
    {
        public long Id { get; set; }
        public string WebsiteName { get; set; }
        public long CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public PostPaymentResultEnum PostPaymentResult { get; set; }  
    }
    public class CustomerPaymentListSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "PostPaymentResult")]
        public PostPaymentResultEnum? PostPaymentResult { get; set; } 
 

        [AssertThat("PaymentSearchEndDate == null || PaymentSearchStartDate <= PaymentSearchEndDate", ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StartDateMustBeSmallerThanOrEqualToEndDate")]
        [DataType(DataType.Date),
         Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "StartDate")]
        public DateTime? PaymentSearchStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "EndDate")]
        public DateTime? PaymentSearchEndDate { get; set; }
 
    }
}
