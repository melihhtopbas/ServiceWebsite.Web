using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.WebSite;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.WebSite
{
    public class ReferenceService
    {
        private readonly WebSiteContextContainer _context;
        public ReferenceService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<ReferenceListViewModel> _getReferenceListIQueryable(Expression<Func<Data.References, bool>> expr)
        {
            return (from b in _context.References.AsExpandable().Where(expr)
                    select new ReferenceListViewModel()
                    {
                        FileName = b.FileName,
                        Name = b.Name,
                        Id = b.Id,

                    });
        }
        public IQueryable<ReferenceListViewModel> GetHomePageReferencesListIQueryable()
        {
            var predicate = PredicateBuilder.New<Data.References>(true);/*AND*/
            return _getReferenceListIQueryable(predicate);
        }

    }
}
