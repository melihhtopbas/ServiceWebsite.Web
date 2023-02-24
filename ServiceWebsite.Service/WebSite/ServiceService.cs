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
    public class ServiceService
    {
        private readonly WebSiteContextContainer _context;
        public ServiceService(WebSiteContextContainer context)
        {
            _context = context;
        }


        private IQueryable<ServiceListViewModel> _getServiceListIQueryable(Expression<Func<Data.Services, bool>> expr)
        {
            return (from b in _context.Services.AsExpandable().Where(expr)
                select new ServiceListViewModel()
                {
                    CategoryName = b.ServiceCategories.Name,
                    Name = b.Name,
                    Id = b.Id,
                    Link = b.Link,
                    Icon = b.Icon,
                    MainImage = new ImageListViewModel()
                    {
                        Title = b.ServiceImages.FirstOrDefault().Title,
                        FileName = b.ServiceImages.OrderByDescending(x=>x.Id).FirstOrDefault().FileName,
                        Alt = b.ServiceImages.FirstOrDefault().Alt
                    }
                    ,ShortDescription=b.ShortDescription
                });
        }

        public IQueryable<ServiceListViewModel> GetServiceListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.Services>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            return _getServiceListIQueryable(predicate);
        }
        public IQueryable<ServiceListViewModel> GetNewServiceListIQueryable(string languageCode)
        {
           
            var predicate = PredicateBuilder.New<Data.Services>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            return _getServiceListIQueryable(predicate);
        }
        public ServiceDetailViewModel GetServiceDetail(string languageCode, string link)
        {
         
            return (
                from p in _context.Services where p.Link==link&&p.Languages.ShortName==languageCode 
                                                  select  new ServiceDetailViewModel()
                                                  {
                                                      Description = p.Description,
                                                      Name = p.Name,
                                                      CategoryName = p.ServiceCategories.Name,
                                                      SeoDescription = p.SeoDescription,
                                                      SeoKeywords = p.SeoKeywords,
                                                      ShortDescription = p.ShortDescription,
                                                      SeoTitle = p.SeoTitle,
                                                      Link=p.Link,
                                                      ImageList = from i in p.ServiceImages select new ImageListViewModel()
                                                      {
                                                          Title = i.Title,
                                                          FileName = i.FileName,
                                                          Alt = i.Alt
                                                          
                                                      },
                                                      SimilarServices = from sp in p.ServiceCategories.Services select new ServiceListViewModel()
                                                      {
                                                          Link = sp.Link,
                                                          Name = sp.Name,
                                                          CategoryName = sp.Name,
                                                          MainImage = new ImageListViewModel()
                                                          {
                                                              Title = sp.ServiceImages.FirstOrDefault().Title,
                                                              FileName = sp.ServiceImages.FirstOrDefault().FileName,
                                                              Alt = sp.ServiceImages.FirstOrDefault().Alt
                                                          }
                                                      }
                                                  }
                                                      
                                                      
                  ).FirstOrDefault();
        }

        public IQueryable<ServiceListViewModel> GetServicesList(string languageCode, string link)
        {
            var predicate = PredicateBuilder.New<Data.Services>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            return _getServiceListIQueryable(predicate);
        }
    }
}
