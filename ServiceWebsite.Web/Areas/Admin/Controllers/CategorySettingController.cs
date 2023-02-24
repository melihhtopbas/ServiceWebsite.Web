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

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CategorySettingController : AdminBaseController
    {

        private readonly CategoryService _categoryService;
        private readonly LanguageService _languageService;


        public CategorySettingController(CategoryService categoryService
            , LanguageService languageService)
        {
            _categoryService = categoryService;
            _languageService = languageService;
        }

        public async Task<ActionResult> ServiceCategory()
        {
            ViewBag.Title = "Kategoriler";

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            //     var model = new ServiceListSearchViewModel() { Code = stockCode, ServiceSearchVariantOption = ServiceSearchVariantEnum.All };
            return View("~/Areas/Admin/Views/CategorySetting/ServiceCategory.cshtml");
        }
        public async Task<ActionResult> BlogCategory()
        {
            ViewBag.Title = "Kategoriler";

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            //     var model = new ServiceListSearchViewModel() { Code = stockCode, ServiceSearchVariantOption = ServiceSearchVariantEnum.All };
            return View("~/Areas/Admin/Views/CategorySetting/BlogCategory.cshtml");
        }
        public async Task<ActionResult> FaqCategory()
        {
            ViewBag.Title = "Kategoriler";

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            //     var model = new ServiceListSearchViewModel() { Code = stockCode, ServiceSearchVariantOption = ServiceSearchVariantEnum.All };
            return View("~/Areas/Admin/Views/CategorySetting/FaqCategory.cshtml");
        }
        // GET: Admin/BlogSetting
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> ServiceCategoryList(long languageId, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _categoryService.GetServiceCategoryListIQueryable(languageId)
                .OrderBy(p => p.Id)
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
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/ServiceCategoryList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult ServiceCategoryAdd(long languageId)
        {
            ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(languageId).ToList();
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceCategoryAdd" };
            var model = new ServiceCategoryCrudViewModel
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/CategorySetting/_ServiceCategoryAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceCategoryAdd([Bind(Prefix = "ServiceCategoryAdd")] ServiceCategoryCrudViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            if (Files == null)
            {
                ModelState.AddModelError("", "Resim boş olamaz");
                return Json(
                    new
                    {
                        success = false,
                        responseText = RenderPartialViewToString("~/Areas/Admin/Views/SliderSetting/_SliderAdd.cshtml", model)
                    });
            }

            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.SliderImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.SliderImageThumbPath));

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(ImageFile.FileName)}";

                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(ImageFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerServiceImageSettings));
                ImageBuilder.Current.Build(ImageFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerServiceThumbImageSettings));
                model.FileName = fileName;
            }

            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.AddServiceCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceCategoryAdd" };

            ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(model.LanguageId).ToList();
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_ServiceCategoryAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> ServiceCategoryEdit(long categoryId)
        {
            var model = await _categoryService.GetServiceCategoryEditViewModelAsync(categoryId);
            if (model != null)
            {

                ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(model.LanguageId).ToList();
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceCategoryEdit" };
                return PartialView("~/Areas/Admin/Views/CategorySetting/_ServiceCategoryEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Servis sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> ServiceCategoryEdit([Bind(Prefix = "ServiceCategoryEdit")] ServiceCategoryCrudViewModel model)
        {


            HttpFileCollectionBase Files = Request.Files;
            if (Files == null && string.IsNullOrWhiteSpace(model.FileName))
            {
                ModelState.AddModelError("", "Resim boş olamaz");
                return Json(
                    new
                    {
                        success = false,
                        responseText = RenderPartialViewToString("~/Areas/Admin/Views/SliderSetting/_SliderAdd.cshtml", model)
                    });
            }

            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.SliderImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.SliderImageThumbPath));

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(ImageFile.FileName)}";

                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(ImageFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerServiceImageSettings));
                ImageBuilder.Current.Build(ImageFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerServiceThumbImageSettings));
                model.FileName = fileName;
            }



            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.EditServiceCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;


                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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
            ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(model.LanguageId).ToList();
         
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceCategoryEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_ServiceCategoryEdit.cshtml", model)
                });

        }



        public async Task<ActionResult> BlogCategoryList(long languageId, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _categoryService.GetBlogCategoryListIQueryable(languageId)
                .OrderBy(p => p.Id)
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
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/BlogCategoryList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult BlogCategoryAdd(long languageId)
        {
            ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(languageId).ToList();
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogCategoryAdd" };
            var model = new BlogCategoryCrudViewModel
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/CategorySetting/_BlogCategoryAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false),ValidateAntiForgeryToken]
        public async Task<ActionResult> BlogCategoryAdd([Bind(Prefix = "BlogCategoryAdd")] BlogCategoryCrudViewModel model)
        {
            var dd=Request.Form;

            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.AddBlogCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogCategoryAdd" };

            ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(model.LanguageId).ToList();
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_BlogCategoryAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> BlogCategoryEdit(long categoryId)
        {
            var model = await _categoryService.GetBlogCategoryEditViewModelAsync(categoryId);
            if (model != null)
            {

                ViewData["Categories"] = _categoryService.GetBlogCategoryListIQueryable(model.LanguageId).ToList();
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogCategoryEdit" };
                return PartialView("~/Areas/Admin/Views/CategorySetting/_BlogCategoryEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Servis sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> BlogCategoryEdit([Bind(Prefix = "BlogCategoryEdit")] BlogCategoryCrudViewModel model)
        {


            List<string> tags = new List<string>();


            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.EditBlogCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;


                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BlogCategoryEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_BlogCategoryEdit.cshtml", model)
                });

        }

             public async Task<ActionResult> FaqCategoryList(long languageId, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _categoryService.GetFaqCategoryListIQueryable(languageId)
                .OrderBy(p => p.Id)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultPropertyPageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();



            ModelState.Clear();
            ViewBag.LanguageId = languageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/FaqCategoryList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult FaqCategoryAdd(long languageId)
        {
            ViewData["Categories"] = _categoryService.GetFaqCategoryListIQueryable(languageId).ToList();
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "FaqCategoryAdd" };
            var model = new FaqCategoryCrudViewModel
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/CategorySetting/_FaqCategoryAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false),ValidateAntiForgeryToken]
        public async Task<ActionResult> FaqCategoryAdd([Bind(Prefix = "FaqCategoryAdd")] FaqCategoryCrudViewModel model)
        {
            var dd=Request.Form;

            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.AddFaqCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "FaqCategoryAdd" };

            ViewData["Categories"] = _categoryService.GetFaqCategoryListIQueryable(model.LanguageId).ToList();
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_FaqCategoryAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> FaqCategoryEdit(long categoryId)
        {
            var model = await _categoryService.GetFaqCategoryEditViewModelAsync(categoryId);
            if (model != null)
            {

                ViewData["Categories"] = _categoryService.GetFaqCategoryListIQueryable(model.LanguageId).ToList();
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "FaqCategoryEdit" };
                return PartialView("~/Areas/Admin/Views/CategorySetting/_FaqCategoryEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Servis sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> FaqCategoryEdit([Bind(Prefix = "FaqCategoryEdit")] FaqCategoryCrudViewModel model)
        {


            List<string> tags = new List<string>();


            if (ModelState.IsValid)
            {
                var callResult = await _categoryService.EditFaqCategoryAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (CategoryListViewModel)callResult.Item;


                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/DisplayTemplates/CategoryListViewModel.cshtml", viewModel),
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
            ViewData["Categories"] = _categoryService.GetFaqCategoryListIQueryable(model.LanguageId).ToList();

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "FaqCategoryEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CategorySetting/_FaqCategoryEdit.cshtml", model)
                });

        }

    }
}