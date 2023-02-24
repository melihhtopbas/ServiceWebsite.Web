
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using ServiceWebsite.Data;
using ServiceWebsite.Web.LightInject;
using ServiceWebsite.Web.LightInject.Mvc;

namespace ServiceWebsite.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new LightInject.ServiceContainer();
            container.RegisterControllers();
            container.Register(typeof(WebSiteContextContainer), new PerRequestLifeTime());
            container.Register<Infrastructure.ICacheService, Infrastructure.Web.InMemoryCache>(new PerRequestLifeTime());
            System.Net.ServicePointManager.SecurityProtocol |=
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            container.Register(typeof(ServiceWebsite.Service.Admin.BlogService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.CategoryService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.ServiceService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.SettingService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.SliderService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.LanguageService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.ContactService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.FaqService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.PropertyService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.ReferenceService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.GalleryService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.CustomerCommentService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.PageService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.KeywordService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.CustomerAttributeService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.Admin.PaymentService), new PerRequestLifeTime());




            container.Register(typeof(ServiceWebsite.Service.WebSite.LanguageService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.SliderService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.ServiceService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.CategoryService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.BlogService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.SettingService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.ContactService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.PropertyService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.FaqService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.ReferenceService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.PropertyService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.CustomerCommentService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.PageService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.WebsiteService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.CheckService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.KeywordService), new PerRequestLifeTime());
            container.Register(typeof(ServiceWebsite.Service.WebSite.PaymentService), new PerRequestLifeTime());
            container.EnableMvc();

        }

    }
}
