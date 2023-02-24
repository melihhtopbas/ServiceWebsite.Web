using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.Utils.Helpers;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.Admin
{
    public class CustomerCommentService
    {
        private readonly WebSiteContextContainer _context;
        public CustomerCommentService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CustomerCommentListViewModel> _getCustomerCommentsListIQueryable(Expression<Func<Data.CustomerComments, bool>> expr)
        {
            return (from b in _context.CustomerComments.AsExpandable().Where(expr)
                    select new CustomerCommentListViewModel()
                    {
                        Name = b.Name,
                        Id = b.Id,
                        Comment = b.Comment,
                        MainImage = b.FileName,
                    });
        }
        public IQueryable<CustomerCommentListViewModel> GetCustomerCommentsListIQueryable(CustomerCommentSearchViewModel model)
        {
            var predicate = PredicateBuilder.New<Data.CustomerComments>(true);/*AND*/
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                predicate.And(a => a.Name.Contains(model.Name));
            }

            return _getCustomerCommentsListIQueryable(predicate);
        }
        public async Task<CustomerCommentListViewModel> GetCustomerCommentsListViewAsync(long customerCommentId)
        {

            var predicate = PredicateBuilder.New<Data.CustomerComments>(true);/*AND*/
            predicate.And(a => a.Id == customerCommentId);
            var custumercomment = await _getCustomerCommentsListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return custumercomment;
        }
        public async Task<ServiceCallResult> AddCustomerCommentsAsync(CustomerCommentAddViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.CustomerComments.AnyAsync(a => a.Name == model.Name).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Yorum bulunmaktadır.");
                return callResult;
            }

            var customercomment = new CustomerComments()
            {
                Name = model.Name,
                FileName = model.FileName,
                Comment = model.Comment,

            };
            _context.CustomerComments.Add(customercomment);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetCustomerCommentsListViewAsync(customercomment.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<CustomerCommentEditViewModel> GetCustomerCommentsEditViewModelAsync(int customercommentsId)
        {
            var customercomments = await (from b in _context.CustomerComments
                                          where b.Id == customercommentsId
                                          select new CustomerCommentEditViewModel()
                                          {
                                              Name = b.Name,
                                              Id = b.Id,
                                              Comment = b.Comment

                                          }).FirstOrDefaultAsync();
            return customercomments;
        }
        public async Task<ServiceCallResult> EditCustomerCommentsAsync(CustomerCommentEditViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.CustomerComments.AnyAsync(a => a.Name == model.Name && a.Id != model.Id).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Yorum bulunmaktadır.");
                return callResult;
            }

            var customercomments = await _context.CustomerComments.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (customercomments == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Yorum bulunamadı.");
                return callResult;
            }

            customercomments.FileName = string.IsNullOrWhiteSpace(model.FileName) ? customercomments.FileName : model.FileName;
            customercomments.Comment = model.Comment;
            customercomments.Name = model.Name;

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    callResult.Success = true;
                    callResult.Item = await GetCustomerCommentsListViewAsync(customercomments.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<ServiceCallResult> DeleteCustomerCommentsAsync(int customercommentsId)
        {
            var callResult = new ServiceCallResult() { Success = false };


            var customercomments = await _context.CustomerComments.FirstOrDefaultAsync(a => a.Id == customercommentsId).ConfigureAwait(false);
            if (customercomments == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Yorum bulunamadı.");
                return callResult;
            }
            _context.CustomerComments.Remove(customercomments);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
    }
}
