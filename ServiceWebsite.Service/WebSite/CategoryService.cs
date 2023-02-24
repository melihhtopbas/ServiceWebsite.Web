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
    public class CategoryService
    {
        private readonly WebSiteContextContainer _context;

        public CategoryService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<CategoryListModel> _getServiceCategoryListIQueryable(Expression<Func<Data.ServiceCategories, bool>> expr)
        {
            return (from b in _context.ServiceCategories.AsExpandable().Where(expr)
                select new CategoryListModel()
                {

                    Name = b.Name,
                    Link = b.Link,
                    Image = b.FileName
                     
                });
        }

        public IQueryable<CategoryListModel> GetServiceCategoryListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.ServiceCategories>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            return _getServiceCategoryListIQueryable(predicate);
        }
        public IQueryable<CategoryListModel> GetHomePageServiceCategoryListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.ServiceCategories>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            predicate.And(a => a.ShowOnHomePage);
            return _getServiceCategoryListIQueryable(predicate);
        }

        private IQueryable<CategoryListModel> _getBlogCategoryListIQueryable(Expression<Func<Data.BlogCategories, bool>> expr)
        {
            return (from b in _context.BlogCategories.AsExpandable().Where(expr)
                select new CategoryListModel()
                {

                    Name = b.Name,
                    Link = b.Link,
                  
                });
            
        }

        public IQueryable<CategoryListModel> GetBlogCategoryListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.BlogCategories>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            
            return _getBlogCategoryListIQueryable(predicate);
        }
    }
}
