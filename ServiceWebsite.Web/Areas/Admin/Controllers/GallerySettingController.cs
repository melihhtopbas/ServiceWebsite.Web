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
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Filters;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class GallerySettingController : AdminBaseController
    {
        private readonly GalleryService _galleryService;
        public GallerySettingController(GalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public  ActionResult Index()
        {
            ViewBag.Title = "Fotograflar";
 
            return View("~/Areas/Admin/Views/GallerySetting/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public ActionResult GalleriesList(GallerySearchViewModel model, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _galleryService.GetGalleryListIQueryable(model)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultPropertyPageSize);
            ModelState.Clear();
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/GallerySetting/GalleryList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add()
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "GalleryAdd" };
           
            return PartialView("~/Areas/Admin/Views/GallerySetting/_GalleryAdd.cshtml");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "GalleryAdd")] GalleryAddViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.GalleryImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.GalleryImageThumbPath));

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
                var callResult = await _galleryService.AddGalleryAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (GalleryListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/GallerySetting/DisplayTemplates/GalleryListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "GalleryAdd" };
            return Json(
               new
               {
                   success = false,
                   responseText = RenderPartialViewToString("~/Areas/Admin/Views/GallerySetting/_GalleryAdd.cshtml", model)
               });
        }
        public async Task<ActionResult> Edit(int galleryId)
        {
            var model = await _galleryService.GetGalleryEditViewModelAsync(galleryId);
            if (model != null)
            {
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "GalleryEdit" };
                return PartialView("~/Areas/Admin/Views/GallerySetting/_GalleryEdit.cshtml", model);
            }
            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Fotograf sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "GalleryEdit")] GalleryEditViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.GalleryImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.GalleryImageThumbPath));

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
                var callResult = await _galleryService.EditGalleryAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (GalleryListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/GallerySetting/DisplayTemplates/GalleryListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "GalleryEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/GallerySetting/_GalleryEdit.cshtml", model)
                });
        }
        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int galleryId)
        {
            var callResult = await _galleryService.DeleteGalleryAsync(galleryId);
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