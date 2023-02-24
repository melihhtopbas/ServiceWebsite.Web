//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceWebsite.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Keyword
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Keyword()
        {
            this.SearchKeyword = new HashSet<SearchKeyword>();
            this.WebsiteFiles = new HashSet<WebsiteFiles>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string DocumentTemplate { get; set; }
        public long LanguageId { get; set; }
    
        public virtual Languages Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SearchKeyword> SearchKeyword { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WebsiteFiles> WebsiteFiles { get; set; }
    }
}
