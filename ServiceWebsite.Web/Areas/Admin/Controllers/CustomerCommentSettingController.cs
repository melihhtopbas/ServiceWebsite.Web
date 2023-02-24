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
    public class CustomerCommentSettingController : AdminBaseController
    {
        private readonly CustomerCommentService _customercommentService;

        public CustomerCommentSettingController(CustomerCommentService customercommentService)
        {
            _customercommentService = customercommentService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Yorumlar";

            return View("~/Areas/Admin/Views/CustomerCommentSetting/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public ActionResult CustomerCommentsList(CustomerCommentSearchViewModel model, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _customercommentService.GetCustomerCommentsListIQueryable(model)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, SystemConstants.DefaultPropertyPageSize);

 
            ModelState.Clear();
             return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerCommentSetting/CustomerCommentList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add()
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerCommentAdd" };
           
            return PartialView("~/Areas/Admin/Views/CustomerCommentSetting/_CustomerCommentAdd.cshtml");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "CustomerCommentAdd")] CustomerCommentAddViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.CustomerCommentImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.CustomerCommentImageThumbPath));

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
                var callResult = await _customercommentService.AddCustomerCommentsAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (CustomerCommentListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerCommentSetting/DisplayTemplates/CustomerCommentListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerCommentAdd" };
            return Json(
               new
               {
                   success = false,
                   responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerCommentSetting/_CustomerCommentAdd.cshtml", model)
               });
        }
        public async Task<ActionResult> Edit(int customercommentId)
        {
            var model = await _customercommentService.GetCustomerCommentsEditViewModelAsync(customercommentId);
            if (model != null)
            {
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerCommentEdit" };
                return PartialView("~/Areas/Admin/Views/CustomerCommentSetting/_CustomerCommentEdit.cshtml", model);
            }
            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Yorum sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "customercommentEdit")] CustomerCommentEditViewModel model)
        {
            HttpFileCollectionBase Files = Request.Files;
            HttpPostedFileBase ImageFile = Files[0];
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var tempImageDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.CustomerCommentImagePath));
                var tempImageThumbDirectory = System.IO.Path.Combine(Server.MapPath(SystemConstants.CustomerCommentImageThumbPath));

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
                var callResult = await _customercommentService.EditCustomerCommentsAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (CustomerCommentListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerCommentSetting/DisplayTemplates/CustomerCommentListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "customercommentEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerCommentSetting/_CustomerCommentEdit.cshtml", model)
                });

        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int customercommentId)
        {
            var callResult = await _customercommentService.DeleteCustomerCommentsAsync(customercommentId);
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