﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebSiteContextContainer : DbContext
    {
        public WebSiteContextContainer()
            : base("name=WebSiteContextContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<BlogCategories> BlogCategories { get; set; }
        public virtual DbSet<BlogImages> BlogImages { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<BlogTagMapping> BlogTagMapping { get; set; }
        public virtual DbSet<BlogTags> BlogTags { get; set; }
        public virtual DbSet<ContactForm> ContactForm { get; set; }
        public virtual DbSet<CustomerAttribute> CustomerAttribute { get; set; }
        public virtual DbSet<CustomerComments> CustomerComments { get; set; }
        public virtual DbSet<FAQ> FAQ { get; set; }
        public virtual DbSet<FAQCategories> FAQCategories { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<References> References { get; set; }
        public virtual DbSet<SearchKeyword> SearchKeyword { get; set; }
        public virtual DbSet<ServiceCategories> ServiceCategories { get; set; }
        public virtual DbSet<ServiceImages> ServiceImages { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Sliders> Sliders { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WebsiteFiles> WebsiteFiles { get; set; }
        public virtual DbSet<Websites> Websites { get; set; }
        public virtual DbSet<CustomerPosPayment> CustomerPosPayments { get; set; }
    }
}