using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceWebsite.Service.WebSite;

namespace ServiceWebsite.Web.Controllers
{
    public class BlogController : BaseController
    {
   
        private readonly CategoryService _categoryService;
        private readonly BlogService _blogService;

        public BlogController(
            CategoryService categoryService,
            BlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }
        // GET: Blog
        public ActionResult Index(string lang,string link)
        {
            ViewBag.Categories = _categoryService.GetBlogCategoryListIQueryable(lang).ToList();
            var model = _blogService.GetBlogsListIQueryable(lang,link).ToList();
            return View(model);
        }
        public ActionResult BlogDetail(string lang, string link)
        {
            ViewBag.Categories = _categoryService.GetBlogCategoryListIQueryable(lang).ToList();
            var model = _blogService.GetBlogDetail(lang, link);
            return View(model);
        }
    }
}