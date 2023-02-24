using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.Utils.Constants;
using ServiceWebsite.Utils.Helpers;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.Admin
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
                        Id = b.Id,
                        Link = b.Link,
                        MainImage = b.BlogImages.FirstOrDefault().FileName

                    });
        }

        public IQueryable<BlogListViewModel> GetBlogsListIQueryable(long languageId)
        {
            var predicate = PredicateBuilder.New<Data.Blogs>(true);/*AND*/
            predicate.And(a => a.LanguageId == languageId);
            return _getBlogsListIQueryable(predicate);
        }

        public async Task<BlogListViewModel> GetBlogListViewAsync(long blogId)
        {

            var predicate = PredicateBuilder.New<Data.Blogs>(true);/*AND*/
            predicate.And(a => a.Id == blogId);
            var blog = await _getBlogsListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return blog;
        }

        public async Task<ServiceCallResult> AddBlogAsync(BlogAddViewModel model, List<string> blogTags)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.Blogs.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Blog bulunmaktadır.");
                return callResult;
            }

            var blog = new Blogs()
            {
                Name = model.Name,
                LanguageId = model.LanguageId,
                Link = HelperMethods.UrlFriendly(model.Name),
                Active = model.Active,
                CategoryId = model.Category.CategoryId,
                Date = DateTime.Now,
                Description = model.Description,
                SeoDescription = model.SeoDescription,
                ShortDescription = model.ShortDescription,
                SeoKeywords = model.SeoDescription,
                SeoTitle = model.SeoTitle


            };

            var tempDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.BlogServiceTempImagePath, model.BlogUniqueTempId);
            var tempThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.BlogServiceTempImageThumbPath, model.BlogUniqueTempId);
            var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImagePath));
            var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImageThumbPath));

            if (!System.IO.Directory.Exists(imagesDirectory))
                System.IO.Directory.CreateDirectory(imagesDirectory);
            if (!System.IO.Directory.Exists(imagesThumbDirectory))
                System.IO.Directory.CreateDirectory(imagesThumbDirectory);

            byte imageOrder = 0;
            foreach (var imageViewModel in model.ImageViewModels)
            {
                var sourceFile = System.IO.Path.Combine(tempDirectory, imageViewModel.FileName);
                var destFile = System.IO.Path.Combine(imagesDirectory, imageViewModel.FileName);
                File.Copy(sourceFile, destFile, true);

                var sourceThumbFile = System.IO.Path.Combine(tempThumbDirectory, imageViewModel.FileName);
                var destThumbFile = System.IO.Path.Combine(imagesThumbDirectory, imageViewModel.FileName);
                File.Copy(sourceThumbFile, destThumbFile, true);

                blog.BlogImages.Add(new BlogImages()
                {
                    FileName = imageViewModel.FileName,
                    Title = imageViewModel.Title,
                    Alt = imageViewModel.Alt
                });

                imageOrder++;
            }


            
            foreach (var blogTag in blogTags)
            {
                var tag = await _context.BlogTags.FirstOrDefaultAsync(a => a.Name == blogTag && a.LanguageId == model.LanguageId).ConfigureAwait(false);
                if (tag == null)
                {
                    tag = new BlogTags()
                    {
                        Name = blogTag,
                        LanguageId = model.LanguageId,
                        Link = HelperMethods.UrlFriendly(blogTag)

                    };
                }

                blog.BlogTagMapping.Add(new BlogTagMapping()
                {

                    BlogTags = tag
                });
            }

            _context.Blogs.Add(blog);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    
                    callResult.Success = true;
                    callResult.Item = await GetBlogListViewAsync(blog.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }



        }

        public async Task<BlogEditViewModel> GetBlogEditViewModelAsync(int blogId)
        {
            var blog = await (from b in _context.Blogs where  b.Id==blogId
                              select new BlogEditViewModel()
                              {
                                  Name = b.Name,
                                  Id = b.Id,
                                  LanguageId = b.LanguageId,
                                  Category = new BlogCategoryIdSelectModel()
                                  {
                                      CategoryId = b.CategoryId
                                  },
                                  SeoDescription = b.SeoDescription,
                                  Active = b.Active,
                                  ShortDescription = b.ShortDescription,
                                  Description = b.Description,
                                  SeoTitle = b.SeoDescription,
                                  SeoKeywords = b.SeoKeywords,
                                  BlogTags = b.BlogTagMapping.Select(a => a.BlogTags.Name).ToList(),
                                  ImageViewModels = from i in b.BlogImages
                                                    select new ImageViewModel()
                                                    {
                                                        FileName = i.FileName,
                                                        Alt = i.Alt,
                                                        Title = i.Title
                                                    }

                              }).FirstOrDefaultAsync();
            return blog;
        }

        public async Task<ServiceCallResult> EditBlogAsync(BlogEditViewModel model, List<string> blogTags)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.Blogs.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId&&a.Id!=model.Id).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Blog bulunmaktadır.");
                return callResult;
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (blog == null)
            {
                callResult.ErrorMessages.Add("Böyle bir blog bulunamadı.");
                return callResult;
            }

            blog.SeoDescription = model.SeoDescription;
            blog.Active = model.Active;
            blog.CategoryId = Convert.ToInt32(model.Category.CategoryId);
            blog.Description = model.Description;
            blog.Name = model.Name;
            blog.SeoKeywords = model.SeoKeywords;
            blog.SeoTitle = model.SeoTitle;
            blog.ShortDescription = model.ShortDescription;

            var deletedImagesList = new List<string>();
          

            foreach (var imageDb in blog.BlogImages.ToArray()
                .Where(imageDb => model.ImageViewModels.All(x => x.FileName != imageDb.FileName)))
            {
                deletedImagesList.Add(imageDb.FileName);
                blog.BlogImages.Remove(imageDb);
                _context.BlogImages.Remove(imageDb);
            }



            var tempDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.BlogServiceTempImagePath, model.BlogUniqueTempId);
            var tempThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.BlogServiceTempImageThumbPath, model.BlogUniqueTempId);
            var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImagePath));
            var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImageThumbPath));

            if (!System.IO.Directory.Exists(imagesDirectory))
                System.IO.Directory.CreateDirectory(imagesDirectory);
            if (!System.IO.Directory.Exists(imagesThumbDirectory))
                System.IO.Directory.CreateDirectory(imagesThumbDirectory);

            byte imageOrder = 0;
            foreach (var imageViewModel in model.ImageViewModels)
            {
                var imageExist = blog.BlogImages.Any(a => a.FileName == imageViewModel.FileName);
                if (!imageExist)
                {
                    var sourceFile = System.IO.Path.Combine(tempDirectory, imageViewModel.FileName);
                    var destFile = System.IO.Path.Combine(imagesDirectory, imageViewModel.FileName);
                    File.Copy(sourceFile, destFile, true);

                    var sourceThumbFile = System.IO.Path.Combine(tempThumbDirectory, imageViewModel.FileName);
                    var destThumbFile = System.IO.Path.Combine(imagesThumbDirectory, imageViewModel.FileName);
                    File.Copy(sourceThumbFile, destThumbFile, true);

                    blog.BlogImages.Add(new BlogImages()
                    {
                        FileName = imageViewModel.FileName,
                        Title = imageViewModel.Title,
                        Alt = imageViewModel.Alt
                    });

                    imageOrder++;
                }
              
            }
            foreach (var blogtagDb in blog.BlogTagMapping.ToList())
            {

                var blogTagExist = blogTags.Contains(blogtagDb.Blogs.Name);
                if (!blogTagExist)
                {
                    blog.BlogTagMapping.Remove(blogtagDb);
                    _context.BlogTagMapping.Remove(blogtagDb);
                }

            }
            foreach (var blogTagModel in blogTags)
            {
                var blogTagDb = blog.BlogTagMapping.FirstOrDefault(a => a.Blogs.Name == blogTagModel);
                if (blogTagDb == null)
                {
                    var tag = await _context.BlogTags.FirstOrDefaultAsync(a => a.Name == blogTagModel && a.LanguageId == model.LanguageId).ConfigureAwait(false);
                    if (tag == null)
                    {
                        tag = new BlogTags()
                        {
                            Name = blogTagModel,
                            LanguageId = model.LanguageId,
                            Link = HelperMethods.UrlFriendly(blogTagModel)

                        };
                    }

                    blog.BlogTagMapping.Add(new BlogTagMapping()
                    {

                        BlogTags = tag
                    });
                }


            }

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    if (deletedImagesList.Any())
                    {

                        foreach (var deletedImage in deletedImagesList)
                        {
                            var physicalPath = System.IO.Path.Combine(imagesDirectory, deletedImage);
                            var physicalThumbPath = System.IO.Path.Combine(imagesThumbDirectory, deletedImage);

                            try
                            {
                                if (System.IO.File.Exists(physicalPath)) { System.IO.File.Delete(physicalPath); }
                                if (System.IO.File.Exists(physicalThumbPath)) { System.IO.File.Delete(physicalThumbPath); }
                            }
                            catch (Exception) { }
                        }

                    }

                    callResult.Success = true;
                    callResult.Item = await GetBlogListViewAsync(blog.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }

        }

        public async Task<ServiceCallResult> DeleteBlogAsync(int blogId)
        {
            var callResult = new ServiceCallResult() {Success = false};
      

            var blog = await _context.Blogs.FirstOrDefaultAsync(a => a.Id == blogId).ConfigureAwait(false);
            if (blog == null)
            {
                callResult.ErrorMessages.Add("Böyle bir blog bulunamadı.");
                return callResult;
            }


            var deletedImagesList = new List<string>();
            foreach (var imageDb in blog.BlogImages.ToList())
            {
                deletedImagesList.Add(imageDb.FileName);
                blog.BlogImages.Remove(imageDb);
                _context.BlogImages.Remove(imageDb);
            }

            foreach (var blogTagMappingDb in blog.BlogTagMapping.ToList())
            {
                 blog.BlogTagMapping.Remove(blogTagMappingDb);
                _context.BlogTagMapping.Remove(blogTagMappingDb);
            }

            _context.Blogs.Remove(blog);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    if (deletedImagesList.Any())
                    {
                        var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImagePath));
                        var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.BlogServiceImageThumbPath));

                        foreach (var deletedImage in deletedImagesList)
                        {
                            var physicalPath = System.IO.Path.Combine(imagesDirectory, deletedImage);
                            var physicalThumbPath = System.IO.Path.Combine(imagesThumbDirectory, deletedImage);

                            try
                            {
                                if (System.IO.File.Exists(physicalPath)) { System.IO.File.Delete(physicalPath); }
                                if (System.IO.File.Exists(physicalThumbPath)) { System.IO.File.Delete(physicalThumbPath); }
                            }
                            catch (Exception) { }
                        }

                    }

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
