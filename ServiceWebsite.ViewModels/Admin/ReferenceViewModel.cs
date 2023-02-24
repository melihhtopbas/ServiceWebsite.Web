using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.Admin
{
    public class ReferenceListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
    public class ReferenceAddViewModel : ReferenceCrudBaseViewModel
    {


    }
    public class ReferenceEditViewModel : ReferenceCrudBaseViewModel
    {
        public long Id { get; set; }
    }
    public class ReferenceSearchViewModel
    {
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Language")]
        public long LanguageId { get; set; }
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages),
            ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
    }

    public class ReferenceCrudBaseViewModel
    {
        public ReferenceCrudBaseViewModel()
        {
            ImageViewModels = new List<ImageViewModel>();

        }

        [Required(ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "RequiredFieldError")]
        [StringLength(200, ErrorMessageResourceType = typeof(ServiceWebsite.Localization.Validation.ValidationMessages), ErrorMessageResourceName = "StringLengthMaxLengthError")]
        [Display(ResourceType = typeof(ServiceWebsite.Localization.ViewModel.ModelItems), Name = "Name")]
        public string Name { get; set; }
       
        public string FileName { get; set; }
       
        public IEnumerable<ImageViewModel> ImageViewModels { get; set; }

    }

}
