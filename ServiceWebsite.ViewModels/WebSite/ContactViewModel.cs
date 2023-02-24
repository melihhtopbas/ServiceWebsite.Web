using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class ContactViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(1000, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(250, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Subject")]
        public string Subject { get; set; }

        [StringLength(20, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Email")]
        public string Email { get; set; }


        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Product")]
        public string Product { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Company")]
        public string Company { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "VatRate")]
        public string VatRate { get; set; }
    }
}
