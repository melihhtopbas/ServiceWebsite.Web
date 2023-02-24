using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class CustomerCommentListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
    }
}
