﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServiceWebsite.ViewModels.Common
{
    public class ServiceCallResult
    {
        public ServiceCallResult()
        {
            ErrorMessages = new List<string>();
            WarningMessages = new List<string>();
            SuccessMessages = new List<string>();
        }
        public bool Success { get; set; }
        public object Item { get; set; }

        public IList<string> ErrorMessages { get; set; }
        public IList<string> SuccessMessages { get; set; }
        public IList<string> WarningMessages { get; set; }
    }

    public class LanguageListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

    }

    public class ImageViewModel
    {
        public string FileName { get; set; }
        public string BlogUniqueTempId { get; set; }
        public string ServiceUniqueTempId { get; set; }


        [StringLength(80, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoTitle")]
        public string Title { get; set; }

        [StringLength(80, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Alt")]
        public string Alt { get; set; }
    }
    public class ImageListViewModel
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }

    }

    public class ImageInsertViewModel
    {
        public string BlogUniqueTempId { get; set; }
        public string ServiceUniqueTempId { get; set; }
        public string HtmlPrefix { get; set; }
        [StringLength(80, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "SeoTitle")]
        public string Title { get; set; }

        [StringLength(80, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Alt")]
        public string Alt { get; set; }
    }
    public static class CategoryTypes
    {
        public const string Blog = "Blog";
        public const string Service = "Service";
        public const string FAQ = "FAQ";


    }
}
