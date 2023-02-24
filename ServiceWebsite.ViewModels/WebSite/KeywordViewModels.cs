using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ServiceWebsite.ViewModels.WebSite
{
    public class KeywordListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentTemplate { get; set; }
        public decimal Price { get; set; }
        public bool Result { get; set; }
        public bool Checked { get; set; }


    }
    public class WebSiteFileListViewModel
    {
        public long Id { get; set; } 
        public string Link { get; set; }
        public string Name { get; set; }
    }
}
