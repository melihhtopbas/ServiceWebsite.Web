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
    public class ServiceSettingController : AdminBaseController
    {
        private readonly ServiceService _serviceService;
        private readonly LanguageService _languageService;
        private readonly CategoryService _categoryService;

        public ServiceSettingController(ServiceService serviceService
            , LanguageService languageService,
            CategoryService categoryService)
        {
            _serviceService = serviceService;
            _languageService = languageService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Servisler";
            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            //     var model = new ServiceListSearchViewModel() { Code = stockCode, ServiceSearchVariantOption = ServiceSearchVariantEnum.All };
            return View("~/Areas/Admin/Views/ServiceSetting/Index.cshtml");
        }
        // GET: Admin/ServiceSetting
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> ServiceList(ServiceSearchViewModel searchViewModel, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _serviceService.GetServiceListIQueryable(searchViewModel)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultServicePageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();



            ModelState.Clear();
            ViewBag.LanguageId = searchViewModel.LanguageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/ServiceList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add(long languageId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceAdd" };
            ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(languageId).ToList();
            var model = new ServiceAddViewModel
            {
                LanguageId = languageId,
                ServiceUniqueTempId = Guid.NewGuid().ToString("N")
            };
            return PartialView("~/Areas/Admin/Views/ServiceSetting/_ServiceAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "ServiceAdd")] ServiceAddViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase IconFile = Files[0];
            if (IconFile != null && IconFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceImageThumbPath));

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(IconFile.FileName)}";

                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(IconFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerServiceImageSettings));
                ImageBuilder.Current.Build(IconFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerServiceThumbImageSettings));
                model.Icon = fileName;
            }

            List<string> tags = new List<string>();
 


            if (ModelState.IsValid)
            {
                var callResult = await _serviceService.AddServiceAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (ServiceListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/DisplayTemplates/ServiceListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceAdd" };
            foreach (var imageViewModel in model.ImageViewModels)
            {
                imageViewModel.ServiceUniqueTempId = model.ServiceUniqueTempId;
            }
            ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(model.LanguageId).ToList();
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/_ServiceAdd.cshtml", model)
                });

        }
        public async Task<ActionResult> Edit(int serviceId)
        {

            var model = await _serviceService.GetServiceEditViewModelAsync(serviceId);
            if (model != null)
            {
                model.ServiceUniqueTempId = Guid.NewGuid().ToString("N");
                ViewData["Categories"] = _categoryService.GetServiceCategoryListIQueryable(model.LanguageId).ToList();
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceEdit" };
                return PartialView("~/Areas/Admin/Views/ServiceSetting/_ServiceEdit.cshtml", model);
            }
            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Servis sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "ServiceEdit")] ServiceEditViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase IconFile = Files[0];
            if (IconFile != null && IconFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceImageThumbPath));

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(IconFile.FileName)}";

                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(IconFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerServiceImageSettings));
                ImageBuilder.Current.Build(IconFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerServiceThumbImageSettings));
                model.Icon = fileName;
            }


            List<string> tags = new List<string>();
 

            if (ModelState.IsValid)
            {
                var callResult = await _serviceService.EditServiceAsync(model);
                if (callResult.Success)
                {
    
                    ModelState.Clear();
                    var viewModel = (ServiceListViewModel)callResult.Item;


                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/DisplayTemplates/ServiceListViewModel.cshtml", viewModel),
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
            foreach (var imageViewModel in model.ImageViewModels)
            {
                imageViewModel.ServiceUniqueTempId = model.ServiceUniqueTempId;
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/_ServiceEdit.cshtml", model)
                });

        }
        [AjaxOnly]
        public ActionResult ServiceImageAdd(string htmlPrefix, string serviceUniqueTempId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "ServiceImageAdd" };
            var model = new ImageInsertViewModel()
            {
                HtmlPrefix = htmlPrefix,
                ServiceUniqueTempId = serviceUniqueTempId

            };

            return PartialView("~/Areas/Admin/Views/ServiceSetting/_ServiceImageAdd.cshtml", model);
        }


        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public ActionResult ServiceImageAdd([Bind(Prefix = "ServiceImageAdd")]ImageInsertViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            var resultModel = new ImageViewModel();
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceTempImagePath), model.ServiceUniqueTempId);
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.ServiceTempImageThumbPath), model.ServiceUniqueTempId);

                if (!System.IO.Directory.Exists(tempImageDirectory))
                    System.IO.Directory.CreateDirectory(tempImageDirectory);

                if (!System.IO.Directory.Exists(tempImageThumbDirectory))
                    System.IO.Directory.CreateDirectory(tempImageThumbDirectory);

                string fileName = $"{Guid.NewGuid().ToString("N")}{Path.GetExtension(ImageFile.FileName)}";

                string pathImage = System.IO.Path.Combine(tempImageDirectory, fileName);
                string pathImageThumb = System.IO.Path.Combine(tempImageThumbDirectory, fileName);

                ImageBuilder.Current.Build(ImageFile, pathImage, new ResizeSettings(SystemConstants.ImageResizerServiceImageSettings));
                ImageBuilder.Current.Build(ImageFile, pathImageThumb, new ResizeSettings(SystemConstants.ImageResizerServiceThumbImageSettings));
                resultModel.FileName = fileName;
                resultModel.Title = model.Title;
                resultModel.Alt = model.Alt;
                resultModel.ServiceUniqueTempId = model.ServiceUniqueTempId;
                if (string.IsNullOrWhiteSpace(model.Alt))
                {
                    resultModel.Alt = ImageFile.FileName.Substring(0, Math.Min(80, ImageFile.FileName.Length));
                }
            }
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = model.HtmlPrefix };

            var jsonResult = Json(
                new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/ServiceSetting/DisplayTemplates/ImageViewModel.cshtml", resultModel),
                    item = resultModel
                });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int serviceId)
        {
            var callResult = await _serviceService.DeleteServiceAsync(serviceId);
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