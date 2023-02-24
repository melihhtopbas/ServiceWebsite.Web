using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Core.TypeCodes;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class CustomerAttributeViewModel
    {
        public string Name { get; set; }
        public string ResourceValue { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public AttributeControlType AttributeControlType { get; set; }

    }
   
}
