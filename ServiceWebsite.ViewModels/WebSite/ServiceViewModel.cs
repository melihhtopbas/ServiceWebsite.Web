using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class ServiceListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string CategoryName { get; set; }
        public ImageListViewModel MainImage { get; set; }
        public string ShortDescription { get; set; }
        public string Link { get; set; }
    }
    public class ServiceDetailViewModel
    {

        public ServiceDetailViewModel()
        {
            SimilarServices=new List<ServiceListViewModel>();
            ImageList=new List<ImageListViewModel>();
        }

        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Link { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public IEnumerable<ServiceListViewModel> SimilarServices { get; set; }
        public IEnumerable<ImageListViewModel> ImageList { get; set; }



    }
    public class RequestQuoteViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(1000, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Message")]
        public string Message { get; set; }

    

        [StringLength(20, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Service")]
        public string Service { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "Company")]
        public string Company { get; set; }

        [StringLength(100, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.WebSiteViewItems.WebSiteViewItems), Name = "VatRate")]
        public string VatRate { get; set; }

    }

}
