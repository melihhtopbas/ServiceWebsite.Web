﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;


namespace ServiceWebsite.ViewModels.Admin
{
    public class PropertyListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string MainIcon { get; set; }
        public string Link { get; set; }
    }
    public class PropertyAddViewModel : PropertyCrudBaseViewModel
    {

    }
    public class PropertyEditViewModel : PropertyCrudBaseViewModel
    {
        public long Id { get; set; }
    }

    public class PropertySearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }


        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }

    }

    public class PropertyCrudBaseViewModel
    {
        public PropertyCrudBaseViewModel()
        {
            ImageViewModels = new List<ImageViewModel>();

        }

        public long LanguageId { get; set; }
        public string PropertyUniqueTempId { get; set; }
 
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
        public string FileName { get; set; }
        public string Icon { get; set; }


        public IEnumerable<ImageViewModel> ImageViewModels { get; set; }

    }
}
