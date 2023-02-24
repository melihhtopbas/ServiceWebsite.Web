using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ImageResizer;
using MvcPaging;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Filters;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogSettingController : AdminBaseController
    {
        private readonly BlogService _blogService;
        private readonly LanguageService _languageService;
        private readonly CategoryService _categoryService;

        public BlogSettingController(BlogService blogService
        , LanguageService languageService,
            CategoryService categoryService)
        {
            _blogService = blogService;
            _languageService = languageService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Bloglar";
            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            return View("~/Areas/Admin/Views/BlogSetting/Index.cshtml");
        }
        // GET: Admin/BlogSetting
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> BlogList(long languageId, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _blogService.GetBlogsListIQueryable(languageId)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultBlogPageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();



            ModelState.Clear();
            ViewBag.LanguageId = languageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/BlogList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add(long languageId)
        {
            
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogAdd" };
            ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(languageId).ToList();
            var model = new BlogAddViewModel
            {
                LanguageId = languageId,
                BlogUniqueTempId = Guid.NewGuid().ToString("N")
            };
            return PartialView("~/Areas/Admin/Views/BlogSetting/_BlogAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "BlogAdd")] BlogAddViewModel model)
        {


            List<string> tags = new List<string>();

            if (!String.IsNullOrWhiteSpace(model.Tag))
            {
                tags = model.Tag.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

           
            if (ModelState.IsValid)
            {
                var callResult = await _blogService.AddBlogAsync(model, tags);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (BlogListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/DisplayTemplates/BlogListViewModel.cshtml", viewModel),
                            item = viewModel
                        });
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                foreach (var error in callResult.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogAdd" };
            foreach (var imageViewModel in model.ImageViewModels)
            {
                imageViewModel.BlogUniqueTempId = model.BlogUniqueTempId;
            }
            ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(model.LanguageId).ToList();
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/_BlogAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> Edit(int blogId)
        {
            var model = await _blogService.GetBlogEditViewModelAsync(blogId);
            if (model != null)
            {
                model.BlogUniqueTempId = Guid.NewGuid().ToString("N");
                ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(model.LanguageId).ToList();
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogEdit" };
                return PartialView("~/Areas/Admin/Views/BlogSetting/_BlogEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Servis sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "BlogEdit")] BlogEditViewModel model)
        {


            List<string> tags = new List<string>();

            if (!String.IsNullOrWhiteSpace(model.Tag))
            {
                tags = model.Tag.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }


            if (ModelState.IsValid)
            {                var callResult = await _blogService.EditBlogAsync(model, tags);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (BlogListViewModel)callResult.Item;


                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/DisplayTemplates/BlogListViewModel.cshtml", viewModel),
                            item = viewModel
                        });
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                foreach (var error in callResult.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(model.LanguageId).ToList();
            foreach (var imageViewModel in model.ImageViewModels)
            {
                imageViewModel.BlogUniqueTempId = model.BlogUniqueTempId;
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/_BlogEdit.cshtml", model)
                });

        }
        [AjaxOnly]
        public ActionResult BlogImageAdd(string htmlPrefix, string blogUniqueTempId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogImageAdd" };
            var model = new ImageInsertViewModel()
            {
                HtmlPrefix = htmlPrefix,
                BlogUniqueTempId = blogUniqueTempId

            };

            return PartialView("~/Areas/Admin/Views/BlogSetting/_BlogImageAdd.cshtml", model);
        }


        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult BlogImageAdd([Bind(Prefix = "BlogImageAdd")]ImageInsertViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            var resultModel = new ImageViewModel();
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.BlogTempImagePath), model.BlogUniqueTempId);
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.BlogTempImageThumbPath), model.BlogUniqueTempId);

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName =$"{Guid.NewGuid().ToString("N")}{Path.GetExtension(ImageFile.FileName)}" ;
             
                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(ImageFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerBlogImageSettings));
                ImageBuilder.Current.Build(ImageFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerBlogThumbImageSettings));
                resultModel.FileName = fileName;
                resultModel.Title = model.Title;
                resultModel.Alt = model.Alt;
                resultModel.BlogUniqueTempId = model.BlogUniqueTempId;
                if (string.IsNullOrWhiteSpace(model.Alt))
                {
                    resultModel.Alt = ImageFile.FileName.Substring(0,Math.Min(80,ImageFile.FileName.Length));
                }
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = model.HtmlPrefix };

            var jsonResult = Json(
                new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/BlogSetting/DisplayTemplates/ImageViewModel.cshtml", resultModel),
                    item = resultModel
                });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int blogId)
        {
            var callResult = await _blogService.DeleteBlogAsync(blogId);
            if (callResult.Success)
            {

                ModelState.Clear();

                return Json(
                    new
                    {
                        success = true,
                        warningMessages = callResult.WarningMessages,
                        successMessages = callResult.SuccessMessages,
                    });
            }

            return Json(
                new
                {
                    success = false,
                    errorMessages = callResult.ErrorMessages
                });

        }

    }
}