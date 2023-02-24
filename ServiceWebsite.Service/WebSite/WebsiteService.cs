using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Common;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Service.WebSite
{
    public class WebsiteService
    {
        private readonly WebSiteContextContainer _context;

        public WebsiteService(WebSiteContextContainer context)
        {
            _context = context;
        }

        private IQueryable<WebSiteFileListViewModel> _getWebSiteFileListIQueryable(Expression<Func<Data.WebsiteFiles, bool>> expr)
        {
            return (from b in _context.WebsiteFiles.AsExpandable().Where(expr)
                    select new WebSiteFileListViewModel()
                    {

                        Link = b.FileName,
                        Id = b.Id,
                        Name = b.Keyword.Name

                    });
        }
        public IQueryable<WebSiteFileListViewModel> GetWebSiteFileListIQueryable(long websiteId)
        {
            var predicate = PredicateBuilder.New<Data.WebsiteFiles>(true);/*AND*/
            predicate.And(a => a.WebsiteId == websiteId);
            return _getWebSiteFileListIQueryable(predicate);
        }

        public long WebsiteAdd(string websiteUrl)
        { 
            var website = new Websites
            {
                Website = websiteUrl
            };
            _context.Websites.Add(website);
            _context.SaveChanges();
            return website.Id;

        }

        public ServiceCallResult WebsiteFileAdd(long websiteId, List<Keywords> keywords, string fileName)
        {
            var callResult = new ServiceCallResult()
            {
                Success = false
            };
            foreach (var keyword in keywords)
            {
                var website = new WebsiteFiles()
                {
                    FileName = fileName,
                    KeywordId = keyword.Id,
                    WebsiteId = websiteId,
                    Result = keyword.IsAvailable

                };
                _context.WebsiteFiles.Add(website);
            }

            try
            {
                _context.SaveChanges();
                callResult.Success = true;

            }
            catch (Exception e)
            {
                callResult.ErrorMessages.Add(e.GetBaseException().Message);
            }

            return callResult;
        }

        public void WebsiteFileUpdate(long websiteId, long keywordId, string fileName)
        {

            var website = _context.WebsiteFiles.FirstOrDefault(a => a.WebsiteId == websiteId && a.KeywordId == keywordId);
            if (website != null)
            {
                website.FileName = fileName;
                _context.SaveChanges();
            }

        }
    }
}
