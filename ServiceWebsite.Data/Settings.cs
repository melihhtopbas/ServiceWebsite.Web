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
    
    public partial class Settings
    {
        public long Id { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
        public string Meta { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Maps { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Gplus { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Analytics { get; set; }
        public string Copyright { get; set; }
        public long LanguageId { get; set; }
    
        public virtual Languages Languages { get; set; }
    }
}
