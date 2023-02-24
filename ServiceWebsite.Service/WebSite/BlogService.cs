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
    public class BlogService
    {
        private readonly WebSiteContextContainer _context;

        public BlogService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<BlogListViewModel> _getBlogsListIQueryable(Expression<Func<Data.Blogs, bool>> expr)
        {
            return (from b in _context.Blogs.AsExpandable().Where(expr)
                    select new BlogListViewModel()
                    {
                        CategoryName = b.BlogCategories.Name,
                        Name = b.Name,
                        Link = b.Link,
                        MainImage = new ImageListViewModel()
                        {
                            Title = b.BlogImages.FirstOrDefault().Title,
                            FileName = b.BlogImages.FirstOrDefault().FileName,
                            Alt = b.BlogImages.FirstOrDefault().Alt
                        },
                        Date = b.Date,
                        ShortDesciription = b.ShortDescription


                    });
        }

        public IQueryable<BlogListViewModel> GetHomePageBlogsListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.Blogs>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            return _getBlogsListIQueryable(predicate);
        }
        public IQueryable<BlogListViewModel> GetBlogsListIQueryable(string languageCode, string link)
        {
            var predicate = PredicateBuilder.New<Data.Blogs>(true);/*AND*/
            if (!string.IsNullOrWhiteSpace(link))
            {
                predicate.And(a => a.BlogCategories.Link == link);

            }
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            return _getBlogsListIQueryable(predicate);
        }
        public BlogDetailViewModel GetBlogDetail(string languageCode, string link)
        {

            return (
                from p in _context.Blogs
                where p.Link == link && p.Languages.ShortName == languageCode
                select new BlogDetailViewModel()
                {
                    Description = p.Description,
                    Name = p.Name,
                    CategoryName = p.BlogCategories.Name,
                    SeoDescription = p.SeoDescription,
                    SeoKeywords = p.SeoKeywords,
                    ShortDescription = p.ShortDescription,
                    SeoTitle = p.SeoTitle,
                    Date = p.Date,
                    Link = p.Link,
                    ImageList = from i in p.BlogImages
                                select new ImageListViewModel()
                                {
                                    Title = i.Title,
                                    FileName = i.FileName,
                                    Alt = i.Alt

                                }

                }).FirstOrDefault();
        }
    }
}
