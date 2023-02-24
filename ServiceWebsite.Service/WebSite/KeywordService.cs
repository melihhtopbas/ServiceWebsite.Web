using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Service.WebSite
{
    public class KeywordService
    {
        private readonly WebSiteContextContainer _context;

        public KeywordService(WebSiteContextContainer context)
        {
            _context = context;
        }
        public List<KeywordListViewModel> GetKeywordList()
        {
            var list = (from k in _context.Keyword
                
                select new KeywordListViewModel
                {
                    Id = k.Id,
                    DocumentTemplate = k.DocumentTemplate,
                    
                }).ToList();
            return list;

        }
        public List<KeywordListViewModel> GetKeywordListForWebsite(long websiteId)
        {
            var list = (from k in _context.WebsiteFiles
                        where k.WebsiteId == websiteId
                        select new KeywordListViewModel
                        {
                            Id = k.Id,
                            ImageUrl = k.Keyword.ImageUrl,
                            Name = k.Keyword.Name,
                            Price = k.Keyword.Price,
                            Result = k.Result.Value
                        }).ToList();
            return list;

        }
    }
}
