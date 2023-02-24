using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcPaging;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.Web.Areas.Admin.Controllers.Abstract;
using ServiceWebsite.Web.Filters;

namespace ServiceWebsite.Web.Areas.Admin.Controllers
{
    [Authorize] 
    public class CustomerAttributeSettingController : AdminBaseController
    {
        private readonly CustomerAttributeService _customerAttributeService;
        private readonly LanguageService _languageService;

        public CustomerAttributeSettingController(CustomerAttributeService customerAttributeService
            , LanguageService languageService)
        {
            _customerAttributeService = customerAttributeService;
            _languageService = languageService;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Değerler";
            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            return View("~/Areas/Admin/Views/CustomerAttributeSetting/Index.cshtml");
        }
        [AjaxOnly, HttpPost, ValidateInput(false)]
        public async Task<ActionResult> CustomerAttributeList(CustomerAttributeSearchViewModel model, int? page)
        {
            var currentCustomerAttributeIndex = page - 1 ?? 0;

            var result = _customerAttributeService.GetCustomerAttributesListIQueryable(model)
                .OrderBy(p => p.Name)
                .ToPagedList(currentCustomerAttributeIndex, SystemConstants.DefaultBlogPageSize);

            ViewBag.Languages = await _languageService.GetLanguageListViewAsync();

            ModelState.Clear();
            ViewBag.LanguageId = model.LanguageId;
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerAttributeSetting/CustomerAttributeList.cshtml", result)
                })
            };
        }
        [AjaxOnly]
        public ActionResult Add(long languageId)
        {

            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerAttributeAdd" };
            var model = new CustomerAttributeAddViewModel()
            {
                LanguageId = languageId,

            };
            return PartialView("~/Areas/Admin/Views/CustomerAttributeSetting/_CustomerAttributeAdd.cshtml", model);
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Prefix = "CustomerAttributeAdd")] CustomerAttributeAddViewModel model)
        {


            if (ModelState.IsValid)
            {
                var callResult = await _customerAttributeService.AddCustomerAttributeAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (CustomerAttributeListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerAttributeSetting/DisplayTemplates/CustomerAttributeListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerAttributeAdd" };
            return Json(
               new
               {
                   success = false,
                   responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerAttributeSetting/_CustomerAttributeAdd.cshtml", model)
               });

        }
        public async Task<ActionResult> Edit(int customerAttributeId)
        {
            var model = await _customerAttributeService.GetCustomerAttributeEditViewModelAsync(customerAttributeId);
            if (model != null)
            {
                ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerAttributeEdit" };
                return PartialView("~/Areas/Admin/Views/CustomerAttributeSetting/_CustomerAttributeEdit.cshtml", model);
            }

            return PartialView("~/Areas/Admin/Views/Shared/_ItemNotFoundPartial.cshtml", "Değer sistemde bulunamadı!");
        }
        [HttpPost, ValidateInput(false), ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Prefix = "CustomerAttributeEdit")] CustomerAttributeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var callResult = await _customerAttributeService.EditCustomerAttributeAsync(model);
                if (callResult.Success)
                {

                    ModelState.Clear();
                    var viewModel = (CustomerAttributeListViewModel)callResult.Item;
                    var jsonResult = Json(
                        new
                        {
                            success = true,
                            responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerAttributeSetting/DisplayTemplates/CustomerAttributeListViewModel.cshtml", viewModel),
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
            ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomerAttributeEdit" };
            return Json(
                new
                {
                    success = false,
                    responseText = RenderPartialViewToString("~/Areas/Admin/Views/CustomerAttributeSetting/_CustomerAttributeEdit.cshtml", model)
                });

        }

        [AjaxOnly, HttpPost]
        public async Task<ActionResult> Delete(int customerAttributeId)
        {
            var callResult = await _customerAttributeService.DeleteCustomerAttributeAsync(customerAttributeId);
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