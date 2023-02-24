using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class ServiceListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public string MainIcon { get; set; }
        public string Link { get; set; }
    }
    public class ServiceAddViewModel : ServiceCrudBaseViewModel
    {
       

    }
    public class ServiceEditViewModel : ServiceCrudBaseViewModel
    {
        public long Id { get; set; }
        
    }
    public class ServiceSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }


        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

    public class ServiceCrudBaseViewModel
    {
        public ServiceCrudBaseViewModel()
        {
            Attributes = new List<ServiceAttributeViewModel>();
            ImageViewModels = new List<ImageViewModel>();

        }
 
        public long LanguageId { get; set; }
        public string ServiceUniqueTempId { get; set; }

        
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(500, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Active")]
        public bool Active { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SortOrder")]
        public int SortOrder { get; set; }
        [StringLength(60, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoTitle")]
        public string SeoTitle { get; set; }

        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoKeywords")]
        public string SeoKeywords { get; set; }

        [StringLength(300, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoDescription")]
        public string SeoDescription { get; set; }
        public string Icon { get; set; }
        public ServiceCategoryIdSelectModel Category { get; set; }
        public IEnumerable<ServiceAttributeViewModel> Attributes { get; set; }
        public IEnumerable<ImageViewModel> ImageViewModels { get; set; }


    }

    public class ServiceAttributeViewModel
    {
        public  int AttributeId { get; set; }
        public  string AttributeValue { get; set; }

    }
}
