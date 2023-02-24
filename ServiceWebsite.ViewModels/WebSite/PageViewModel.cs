using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class PageListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
    public class PageDetailViewModel
    {

        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

    }
}
