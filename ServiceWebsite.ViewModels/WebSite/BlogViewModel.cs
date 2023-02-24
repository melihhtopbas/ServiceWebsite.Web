using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class BlogListViewModel
    {
       
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public ImageListViewModel MainImage { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public string ShortDesciription { get; set; }
    }
    public class BlogDetailViewModel
    {

        public BlogDetailViewModel()
        {
             
            ImageList = new List<ImageListViewModel>();
        }

        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Link { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public IEnumerable<ImageListViewModel> ImageList { get; set; }

        public DateTime Date { get; set; }


    }
}
