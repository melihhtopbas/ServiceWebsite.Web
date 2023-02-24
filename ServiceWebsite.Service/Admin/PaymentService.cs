using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Admin;

namespace ServiceWebsite.Service.Admin
{
    public class PaymentService
    {
        private readonly WebSiteContextContainer _context;
        public PaymentService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CustomerPaymentListViewModel> _getCustomerPaymentsListIQueryable(Expression<Func<Data.CustomerPosPayment, bool>> expr)
        {
            return (from c in _context.CustomerPosPayments.AsExpandable().Where(expr)
                    select new CustomerPaymentListViewModel()
                    {
                        Id = c.Id, 
                        PaymentDate = c.PaymentDate,
                        PaymentAmount = c.PaymentAmount, 
                        PostPaymentResult = c.PaymentResult,
                        WebsiteName = c.Websites.Website
                    });
        }

        public IQueryable<CustomerPaymentListViewModel> GetCustomerPaymentsListIQueryable(CustomerPaymentListSearchViewModel searchModel)
        {
            var predicate = PredicateBuilder.New<Data.CustomerPosPayment>(true);/*AND*/ 
            if (searchModel.PostPaymentResult != null)
            {
                predicate = predicate.And(x => x.PaymentResult == searchModel.PostPaymentResult);
            }
            if (searchModel.PaymentSearchStartDate != null)
            {
                predicate = predicate.And(x => x.PaymentDate >= searchModel.PaymentSearchStartDate);
            }

            if (searchModel.PaymentSearchEndDate != null)
            {
                predicate = predicate.And(x => x.PaymentDate < searchModel.PaymentSearchEndDate);

            }
            return _getCustomerPaymentsListIQueryable(predicate);
        }
    }

  

}
