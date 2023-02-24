using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Localization;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class BlogListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public string Link { get; set; }
    }

    public class BlogAddViewModel : BlogCrudBaseViewModel
    {

    }
    public class BlogEditViewModel : BlogCrudBaseViewModel
    {
        public long Id { get; set; }
        public BlogEditViewModel()
        {
            BlogTags = new List<string>();

        }
        public IEnumerable<string> BlogTags { get; set; }

    }

    public class BlogSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }


        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

    public class BlogCrudBaseViewModel
    {
        public BlogCrudBaseViewModel()
        {
            ImageViewModels = new List<ImageViewModel>();

        }

        public long LanguageId { get; set; }
        public string BlogUniqueTempId { get; set; }
        public string Tag { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Active")]
        public bool Active { get; set; }

        [StringLength(60, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoTitle")]
        public string SeoTitle { get; set; }

        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoKeywords")]
        public string SeoKeywords { get; set; }

        [StringLength(300, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoDescription")]
        public string SeoDescription { get; set; }

        public BlogCategoryIdSelectModel Category { get; set; }

        public IEnumerable<ImageViewModel> ImageViewModels { get; set; }

    }



}
