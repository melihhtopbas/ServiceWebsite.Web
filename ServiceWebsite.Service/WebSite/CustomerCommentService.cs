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
    public class CustomerCommentService
    {
        private readonly WebSiteContextContainer _context;
        public CustomerCommentService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CustomerCommentListViewModel> _getCustomerCommentListIQueryable(Expression<Func<Data.CustomerComments, bool>> expr)
        {
            return (from b in _context.CustomerComments.AsExpandable().Where(expr)
                select new CustomerCommentListViewModel()
                {

                    Name = b.Name,
                    Id = b.Id,
                    FileName = b.FileName,
                    Comment = b.Comment
                });
        }
        public IQueryable<CustomerCommentListViewModel> GetCustomerCommentListIQueryable()
        {
            var predicate = PredicateBuilder.New<Data.CustomerComments>(true);/*AND*/
            return _getCustomerCommentListIQueryable(predicate);
        }
        public IQueryable<CustomerCommentListViewModel> GetHomePageCustomerCommentListIQueryable()
        {
            var predicate = PredicateBuilder.New<Data.CustomerComments>(true);/*AND*/
            return _getCustomerCommentListIQueryable(predicate);
        }
    }
}
