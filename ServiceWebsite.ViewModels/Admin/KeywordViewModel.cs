using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class KeywordListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class KeywordAddViewModel : KeywordCrudBaseViewModel
    {

    }
    public class KeywordEditViewModel : KeywordCrudBaseViewModel
    {
        public long Id { get; set; }


    }

    public class KeywordSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }


        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

    public class KeywordCrudBaseViewModel
    {
        public KeywordCrudBaseViewModel()
        {
            SearchKeywordViewModels = new List<SearchKeywordViewModel>();
        }

        public long LanguageId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string DocumentTemplate { get; set; }


        [Required(ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Range(0.0, Double.MaxValue, ErrorMessageResourceType = typeof(Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RangeMinError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Price")]
        public decimal? Price { get; set; }

        public IEnumerable<SearchKeywordViewModel> SearchKeywordViewModels { get; set; }
    }

    public class SearchKeywordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        public ServiceWebsite.Core.TypeCodes.SearchKeywordType KeywordType { get; set; }
    }

}