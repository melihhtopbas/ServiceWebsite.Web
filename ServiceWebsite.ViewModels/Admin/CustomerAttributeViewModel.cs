using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAnnotations.Attributes;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class CustomerAttributeListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ResourceValue { get; set; }
        public string DefaultValue { get; set; }
        public bool IsRequired { get; set; }
        public ServiceWebsite.Core.TypeCodes.AttributeControlType AttributeControlType { get; set; }
    }

    public class CustomerAttributeAddViewModel : CustomerAttributeCrudBaseViewModel
    {

    }
    public class CustomerAttributeEditViewModel : CustomerAttributeCrudBaseViewModel
    {
        public long Id { get; set; }


    }

    public class CustomerAttributeSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }

        [StringLength(400, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
        [StringLength(400, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ResourceValue")]
        public string ResourceValue { get; set; }
    }

    public class CustomerAttributeCrudBaseViewModel
    {

        public long LanguageId { get; set; }


        [StringLength(400, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        [StringLength(400, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]

        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ResourceValue")]
        public string ResourceValue { get; set; }

        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "IsRequired")]
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        public bool IsRequired { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "AttributeControlType")]
        public ServiceWebsite.Core.TypeCodes.AttributeControlType AttributeControlType { get; set; }
        [RequiredIf("AttributeControlType==3", ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "AttributeValue")]
        public string AttributeValue { get; set; }

    }


}