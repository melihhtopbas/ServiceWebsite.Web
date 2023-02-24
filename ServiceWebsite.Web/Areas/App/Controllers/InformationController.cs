using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using MariGold.OpenXHTML;
using ServiceWebsite.Core.TypeCodes;
using ServiceWebsite.Service.Admin;
using ServiceWebsite.Service.WebSite;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.WebSite;
using KeywordService = ServiceWebsite.Service.WebSite.KeywordService;

namespace ServiceWebsite.Web.Areas.App.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        // GET: Checkout
        private readonly WebsiteService _websiteService;
        private readonly CustomerAttributeService _customerAttributeService;
        private readonly KeywordService _keywordService;
        public InformationController(WebsiteService websiteService, CustomerAttributeService customerAttributeService, KeywordService keywordService)
        {
            _websiteService = websiteService;
            _customerAttributeService = customerAttributeService;
            _keywordService = keywordService;
        }
        public ActionResult Index(long websiteId)
        {
            var model = new InformationAddViewModel
            {
                WebsiteId = websiteId

            };

            ViewBag.CustomerAttributes = _customerAttributeService
                .GetCustomerAttributesListIQueryable(new CustomerAttributeSearchViewModel() { }).ToList();
            return View();
        }
        public ActionResult Add(InformationAddViewModel model)
        {
            try
            {
                var customerFilesTempDirectory = Server.MapPath($"/temp/");
                var form = Request.Form;
                if (!System.IO.Directory.Exists(customerFilesTempDirectory))
                    System.IO.Directory.CreateDirectory(customerFilesTempDirectory);
                var keywords = _keywordService.GetKeywordList();
                var attributes = _customerAttributeService
                    .GetCustomerAttributesListIQueryable(new CustomerAttributeSearchViewModel() { }).ToList();
                ViewBag.CustomerAttributes = attributes;
                foreach (var keyword in keywords)
                {
                    string newFileName = $"{Guid.NewGuid():N}";

                    string pathTempReport =
                        System.IO.Path.Combine(customerFilesTempDirectory, $"CustomerReport_{newFileName}.docx");
                    var template = keyword.DocumentTemplate;
                    var defaultAttributes = attributes
                        .Where(a => a.AttributeControlType == AttributeControlType.Checkboxes).ToList();
                    foreach (var attribute in defaultAttributes)
                    {
                        if (form[$"attribute_{attribute.Id}"]=="on")
                        {
                            template = template.Replace(attribute.ResourceValue, attribute.DefaultValue);
                        }
                        else
                        {
                            template = template.Replace(attribute.ResourceValue, string.Empty); 
                        }
                    }
                    var inputAttributes = attributes
                        .Where(a => a.AttributeControlType == AttributeControlType.MultilineTextbox || a.AttributeControlType == AttributeControlType.TextBox).ToList();
                    foreach (var attribute in inputAttributes)
                    {
                        template = template.Replace(attribute.ResourceValue, form[$"attribute_{attribute.Id}"]);
                    }
                    //Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    //Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add();
                    //wordDoc.Content.Text = template;
                    //wordDoc.SaveAs(pathTempReport);

                    WordDocument doc = new WordDocument(pathTempReport);
 
                    doc.Process(new HtmlParser(Regex.Replace(template, @"(<.+?)\s+style\s*=\s*([""']).*?\2(.*?>)",string.Empty)));
                    doc.Save();
                    
                    //     return File(mem.ToArray(), "application/msword", "sample.docx");

                    _websiteService.WebsiteFileUpdate(model.WebsiteId, keyword.Id, $"CustomerReport_{newFileName}.docx");

                }

                return RedirectToAction("Index", "Checkout", new { websiteId = model.WebsiteId });

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message); 
                return View("Index", model);
            }

        }
    }
}