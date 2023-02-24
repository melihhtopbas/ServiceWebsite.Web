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
    public class CategoryService
    {
        private readonly WebSiteContextContainer _context;

        public CategoryService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CategoryListViewModel> _getBlogCategoryListIQueryable(Expression<Func<Data.BlogCategories, bool>> expr)
        {
            return (from b in _context.BlogCategories.AsExpandable().Where(expr)
                    select new CategoryListViewModel()
                    {

                        Name = b.Name,
                        Id = b.Id,
                        CategoryType = CategoryTypes.Blog
                        
                    });
        }

        public IQueryable<CategoryListViewModel> GetBlogCategoryListIQueryable(long languageId)
        {
            var predicate = PredicateBuilder.New<Data.BlogCategories>(true);/*AND*/
            predicate.And(a => a.LanguageId == languageId);
            return _getBlogCategoryListIQueryable(predicate);
        }
        public async Task<CategoryListViewModel> GetBlogCategoryListViewAsync(long blogId)
        {

            var predicate = PredicateBuilder.New<Data.BlogCategories>(true);/*AND*/
            predicate.And(a => a.Id == blogId);
            var blog = await _getBlogCategoryListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return blog;
        }

        public async Task<ServiceCallResult> AddBlogCategoryAsync(BlogCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.BlogCategories.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Blog Kategorisi bulunmaktadır.");
                return callResult;
            }

            var blogCategory = new BlogCategories()
            {
                Name = model.Name,
                Active = model.Active,
                LanguageId = model.LanguageId,
                Link = HelperMethods.UrlFriendly(model.Name),
                SortOrder = model.SortOrder
            };
            _context.BlogCategories.Add(blogCategory);

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetBlogCategoryListViewAsync(blogCategory.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }

        public async Task<BlogCategoryCrudViewModel> GetBlogCategoryEditViewModelAsync(long blogCategoryId)
        {
            var blogCategory = await (from b in _context.BlogCategories where b.Id==blogCategoryId
                              select new BlogCategoryCrudViewModel()
                              {
                                  Name = b.Name,
                                  Id = b.Id,
                                  LanguageId = b.LanguageId,
                                  Active = b.Active,
                                  SortOrder = b.SortOrder

                              }).FirstOrDefaultAsync();
            return blogCategory;
        }
        public async Task<ServiceCallResult> EditBlogCategoryAsync(BlogCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.BlogCategories.AnyAsync(a =>a.Id!=model.Id&&a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Blog Kategorisi bulunmaktadır.");
                return callResult;
            }
            var blogCategory = await _context.BlogCategories.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (blogCategory == null)
            {
                callResult.ErrorMessages.Add("Böyle bir blog kategorisi bulunamadı.");
                return callResult;
            }

            blogCategory.Name = model.Name;
            blogCategory.Active = model.Active;
            blogCategory.SortOrder = model.SortOrder;
          

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetBlogCategoryListViewAsync(blogCategory.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        private IQueryable<CategoryListViewModel> _getFaqCategoryListIQueryable(Expression<Func<Data.FAQCategories, bool>> expr)
        {
            return (from b in _context.FAQCategories.AsExpandable().Where(expr)
                    select new CategoryListViewModel()
                    {

                        Name = b.Name,
                        Id = b.Id,
                        CategoryType = CategoryTypes.FAQ

                    });
        }

        public IQueryable<CategoryListViewModel> GetFaqCategoryListIQueryable(long languageId)
        {
            var predicate = PredicateBuilder.New<Data.FAQCategories>(true);/*AND*/
            predicate.And(a => a.LanguageId == languageId);
            return _getFaqCategoryListIQueryable(predicate);
        }
        public async Task<CategoryListViewModel> GetFaqCategoryListViewAsync(long faqId)
        {

            var predicate = PredicateBuilder.New<Data.FAQCategories>(true);/*AND*/
            predicate.And(a => a.Id == faqId);
            var faq = await _getFaqCategoryListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return faq;
        }

        public async Task<ServiceCallResult> AddFaqCategoryAsync(FaqCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.FAQCategories.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Faq Kategorisi bulunmaktadır.");
                return callResult;
            }

            var faqCategory = new FAQCategories()
            {
                Name = model.Name,
                Active = model.Active,
                LanguageId = model.LanguageId,
                Link = HelperMethods.UrlFriendly(model.Name),
                SortOrder = model.SortOrder
            };
            _context.FAQCategories.Add(faqCategory);

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetFaqCategoryListViewAsync(faqCategory.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }

        public async Task<FaqCategoryCrudViewModel> GetFaqCategoryEditViewModelAsync(long faqCategoryId)
        {
            var faqCategory = await (from b in _context.FAQCategories
                                      where b.Id == faqCategoryId
                                      select new FaqCategoryCrudViewModel()
                                      {
                                          Name = b.Name,
                                          Id = b.Id,
                                          LanguageId = b.LanguageId,
                                          Active = b.Active,
                                          SortOrder = b.SortOrder

                                      }).FirstOrDefaultAsync();
            return faqCategory;
        }
        public async Task<ServiceCallResult> EditFaqCategoryAsync(FaqCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.FAQCategories.AnyAsync(a => a.Id != model.Id && a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Faq Kategorisi bulunmaktadır.");
                return callResult;
            }
            var faqCategory = await _context.FAQCategories.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (faqCategory == null)
            {
                callResult.ErrorMessages.Add("Böyle bir faq kategorisi bulunamadı.");
                return callResult;
            }

            faqCategory.Name = model.Name;
            faqCategory.Active = model.Active;
            faqCategory.SortOrder = model.SortOrder;


            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetFaqCategoryListViewAsync(faqCategory.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }

        private IQueryable<CategoryListViewModel> _getServiceCategoryListIQueryable(Expression<Func<Data.ServiceCategories, bool>> expr)
        {
            return (from b in _context.ServiceCategories.AsExpandable().Where(expr)
                    select new CategoryListViewModel()
                    {

                        Name = b.Name,
                        Id = b.Id,
                        CategoryType = CategoryTypes.Service



                    });
        }

        public IQueryable<CategoryListViewModel> GetServiceCategoryListIQueryable(long languageId)
        {
            var predicate = PredicateBuilder.New<Data.ServiceCategories>(true);/*AND*/
            predicate.And(a => a.LanguageId == languageId);
            return _getServiceCategoryListIQueryable(predicate);
        }
        public async Task<CategoryListViewModel> GetServiceCategoryListViewAsync(long serviceId)
        {

            var predicate = PredicateBuilder.New<Data.ServiceCategories>(true);/*AND*/
            predicate.And(a => a.Id == serviceId);
            var service = await _getServiceCategoryListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return service;
        }

        public async Task<ServiceCallResult> AddServiceCategoryAsync(ServiceCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.ServiceCategories.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Service Kategorisi bulunmaktadır.");
                return callResult;
            }

            var serviceCategory = new ServiceCategories()
            {
                Name = model.Name,
                Active = model.Active,
                LanguageId = model.LanguageId,
                Link = HelperMethods.UrlFriendly(model.Name),
                SortOrder = model.SortOrder,
                ParentId = model.Category.CategoryId,
                ShowOnHomePage = model.ShowOnHomePage,
                FileName = model.FileName
            };
            _context.ServiceCategories.Add(serviceCategory);

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetServiceCategoryListViewAsync(serviceCategory.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }

        public async Task<ServiceCategoryCrudViewModel> GetServiceCategoryEditViewModelAsync(long serviceCategoryId)
        {
            var serviceCategory = await (from b in _context.ServiceCategories
                                         where b.Id == serviceCategoryId
                                         select new ServiceCategoryCrudViewModel()
                                         {
                                             Name = b.Name,
                                             Id = b.Id,
                                             LanguageId = b.LanguageId,
                                             Active = b.Active,
                                             SortOrder = b.SortOrder,
                                             Category = new ServiceCategoryIdSelectModel()
                                             {
                                                 CategoryId = b.ServiceCategories2.Id
                                             },
                                             FileName = b.FileName,
                                             ShowOnHomePage = b.ShowOnHomePage

                                         }).FirstOrDefaultAsync();
            return serviceCategory;
        }
        public async Task<ServiceCallResult> EditServiceCategoryAsync(ServiceCategoryCrudViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.ServiceCategories.AnyAsync(a =>a.Id!=model.Id&&a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Servis Kategorisi bulunmaktadır.");
                return callResult;
            }
            var serviceCategory = await _context.ServiceCategories.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (serviceCategory == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Servis kategorisi bulunamadı.");
                return callResult;
            }

            serviceCategory.Name = model.Name;
            serviceCategory.Active = model.Active;
            serviceCategory.SortOrder = model.SortOrder;
            serviceCategory.ParentId = model.Category.CategoryId;
            serviceCategory.FileName = model.FileName;
            serviceCategory.ShowOnHomePage = model.ShowOnHomePage;

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetServiceCategoryListViewAsync(serviceCategory.Id).ConfigureAwait(false);
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
