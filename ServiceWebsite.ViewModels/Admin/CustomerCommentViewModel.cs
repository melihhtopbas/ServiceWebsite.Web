using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class CustomerCommentListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string Comment { get; set; }
    }

    public class CustomerCommentAddViewModel : CustomerCommentCrudBaseViewModel
    {

    }
    public class CustomerCommentEditViewModel : CustomerCommentCrudBaseViewModel
    {
        public long Id { get; set; }
    }

    public class CustomerCommentSearchViewModel
    {
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

    public class CustomerCommentCrudBaseViewModel
    {
        public CustomerCommentCrudBaseViewModel()
        {
            ImageViewModels = new List<ImageViewModel>();

        }
        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Comment")]
        public string Comment { get; set; }

        public string FileName { get; set; }


        public IEnumerable<ImageViewModel> ImageViewModels { get; set; }

    }
}
