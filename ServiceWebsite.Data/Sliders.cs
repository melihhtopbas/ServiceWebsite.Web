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
    
    public partial class Sliders
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
        public bool Active { get; set; }
        public long LanguageId { get; set; }
        public string ButtonText1 { get; set; }
        public string ButtonText2 { get; set; }
        public string ButtonText3 { get; set; }
        public string ButtonText4 { get; set; }
        public string ButtonLink1 { get; set; }
        public string ButtonLink2 { get; set; }
        public string ButtonLink3 { get; set; }
        public string ButtonLink4 { get; set; }
    
        public virtual Languages Languages { get; set; }
    }
}
