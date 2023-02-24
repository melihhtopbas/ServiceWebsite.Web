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
    public class FaqService
    {
        private readonly WebSiteContextContainer _context;
        public FaqService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<FaqListViewModel> _getFaqListIQueryable(Expression<Func<Data.FAQ, bool>> expr)
        {
            return (from b in _context.FAQ.AsExpandable().Where(expr)
                select new FaqListViewModel()
                {
                    CategoryName = b.FAQCategories.Name,
                    Name = b.Name,
                    Id = b.Id,
                    Link = b.Link,
                    Description = b.Description
                });
        }
        public IQueryable<FaqListViewModel> GetFaqListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.FAQ>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            return _getFaqListIQueryable(predicate);
        }
    
    }
}