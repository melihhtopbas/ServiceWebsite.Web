using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class FaqListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Link { get; set; }
    }
    public class FaqAddViewModel : FaqCrudBaseViewModel
    {


    }
    public class FaqEditViewModel : FaqCrudBaseViewModel
    {
        public long Id { get; set; }

    }
    public class FaqCrudBaseViewModel
    { 

        public long LanguageId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Description")]
        public string Description { get; set; }

        public FaqCategoryIdSelectModel Category { get; set; }
    
    }

    public class FaqSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

}
