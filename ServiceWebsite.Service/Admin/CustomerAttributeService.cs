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
    public class CustomerAttributeService
    {
        private readonly WebSiteContextContainer _context;

        public CustomerAttributeService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CustomerAttributeListViewModel> _getCustomerAttributesListIQueryable(Expression<Func<Data.CustomerAttribute, bool>> expr)
        {
            return (from b in _context.CustomerAttribute.AsExpandable().Where(expr)
                    select new CustomerAttributeListViewModel()
                    {
                        Name = b.Name,
                        Id = b.Id,
                        ResourceValue = b.ResourceValue,
                        AttributeControlType = b.AttributeControlTypeId,
                        IsRequired = b.IsRequired,
                        DefaultValue = b.DefaultValue
                    });
        }
        public IQueryable<CustomerAttributeListViewModel> GetCustomerAttributesListIQueryable(CustomerAttributeSearchViewModel keywordSearchViewModel)
        {
            var predicate = PredicateBuilder.New<Data.CustomerAttribute>(true);/*AND*/

            //       predicate.And(a => a.LanguageId == keywordSearchViewModel.LanguageId);
            if (!string.IsNullOrWhiteSpace(keywordSearchViewModel.Name))
            {
                predicate.And(a => a.Name.Contains(keywordSearchViewModel.Name));
            }

            return _getCustomerAttributesListIQueryable(predicate);
        }
        public async Task<CustomerAttributeListViewModel> GetCustomerAttributeListViewAsync(long keywordId)
        {

            var predicate = PredicateBuilder.New<Data.CustomerAttribute>(true);/*AND*/
            predicate.And(a => a.Id == keywordId);
            var CustomerAttribute = await _getCustomerAttributesListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return CustomerAttribute;
        }
        public async Task<ServiceCallResult> AddCustomerAttributeAsync(CustomerAttributeAddViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.CustomerAttribute.AnyAsync(a => a.Name == model.Name
                                                                            //&& a.LanguageId == model.LanguageId
                                                                            ).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde değer bulunmaktadır.");
                return callResult;
            }

            var keyword = new CustomerAttribute()
            {
                Name = model.Name,
                ResourceValue = model.ResourceValue,
                AttributeControlTypeId = model.AttributeControlType,
                DisplayOrder = 0,
                IsRequired = model.IsRequired,
                DefaultValue = model.AttributeValue
            };


            _context.CustomerAttribute.Add(keyword);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetCustomerAttributeListViewAsync(keyword.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<CustomerAttributeEditViewModel> GetCustomerAttributeEditViewModelAsync(long keywordId)
        {
            var keyword = await (from b in _context.CustomerAttribute
                                 where b.Id == keywordId
                                 select new CustomerAttributeEditViewModel()
                                 {
                                     Name = b.Name,
                                     Id = b.Id,
                                     IsRequired = b.IsRequired,
                                     ResourceValue = b.ResourceValue,
                                     AttributeControlType = b.AttributeControlTypeId,
                                     AttributeValue = b.DefaultValue

                                 }).FirstOrDefaultAsync();
            return keyword;
        }
        public async Task<ServiceCallResult> EditCustomerAttributeAsync(CustomerAttributeEditViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.CustomerAttribute.AnyAsync(a => a.Name == model.Name
                                                                            // && a.LanguageId == model.LanguageId 
                                                                            && a.Id != model.Id).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde değer bulunmaktadır.");
                return callResult;
            }

            var keyword = await _context.CustomerAttribute.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (keyword == null)
            {
                callResult.ErrorMessages.Add("Böyle bir değer bulunamadı.");
                return callResult;
            }


            keyword.Name = model.Name;
            keyword.IsRequired = model.IsRequired;
            keyword.AttributeControlTypeId = model.AttributeControlType;
            keyword.ResourceValue = model.ResourceValue;
            keyword.DefaultValue = model.AttributeValue;
            keyword.DisplayOrder = 0;

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    callResult.Success = true;
                    callResult.Item = await GetCustomerAttributeListViewAsync(keyword.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }

        }
        public async Task<ServiceCallResult> DeleteCustomerAttributeAsync(int keywordId)
        {
            var callResult = new ServiceCallResult() { Success = false };


            var keyword = await _context.CustomerAttribute.FirstOrDefaultAsync(a => a.Id == keywordId).ConfigureAwait(false);
            if (keyword == null)
            {
                callResult.ErrorMessages.Add("Böyle bir değer bulunamadı.");
                return callResult;
            }

            _context.CustomerAttribute.Remove(keyword);
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
