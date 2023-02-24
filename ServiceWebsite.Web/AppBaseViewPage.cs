using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Web.Controllers;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Web
{
    public abstract class AppBaseViewPage<TModel> : WebViewPage<TModel>
    {
        protected SettingViewModel SettingViewModel
        {
            get
            {
                if (ViewContext.Controller is BaseController baseController)
                    return baseController.SettingViewModel ?? new SettingViewModel();
                return null;
            }
        }

       
    }

    public abstract class AppBaseViewPage : AppBaseViewPage<dynamic>
    {
    }
}