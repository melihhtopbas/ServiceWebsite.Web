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
                        MainIcon = b.Icon,
                        MainImage = b.ServiceImages.FirstOrDefault().FileName

                    });
        }

        public IQueryable<ServiceListViewModel> GetServiceListIQueryable(ServiceSearchViewModel model)
        {
            var predicate = PredicateBuilder.New<Data.Services>(true);/*AND*/
            predicate.And(a => a.LanguageId == model.LanguageId);
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                predicate.And(a => a.Name.Contains(model.Name));

            }
            return _getServiceListIQueryable(predicate);
        }

        public async Task<ServiceListViewModel> GetServiceListViewAsync(long serviceId)
        {

            var predicate = PredicateBuilder.New<Data.Services>(true);/*AND*/
            predicate.And(a => a.Id == serviceId);
            var service = await _getServiceListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return service;
        }

        public async Task<ServiceCallResult> AddServiceAsync(ServiceAddViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.Services.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Servis bulunmaktadır.");
                return callResult;
            }

            var service = new Services()
            {
                Name = model.Name,
                LanguageId = model.LanguageId,
                Link = HelperMethods.UrlFriendly(model.Name),
                Active = model.Active,
                Icon = model.Icon,
                CategoryId = model.Category.CategoryId.GetValueOrDefault(),
                Description = model.Description,
                SeoDescription = model.SeoDescription,
                ShortDescription = model.ShortDescription,
                SeoKeywords = model.SeoDescription,
                SeoTitle = model.SeoTitle,
                SortOrder = model.SortOrder
            };
            var tempDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.ServiceServiceTempImagePath, model.ServiceUniqueTempId);
            var tempThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.ServiceServiceTempImageThumbPath, model.ServiceUniqueTempId);
            var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImagePath));
            var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImageThumbPath));

            if (!System.IO.Directory.Exists(imagesDirectory))
                System.IO.Directory.CreateDirectory(imagesDirectory);
            if (!System.IO.Directory.Exists(imagesThumbDirectory))
                System.IO.Directory.CreateDirectory(imagesThumbDirectory);


            foreach (var imageViewModel in model.ImageViewModels)
            {
                var sourceFile = System.IO.Path.Combine(tempDirectory, imageViewModel.FileName);
                var destFile = System.IO.Path.Combine(imagesDirectory, imageViewModel.FileName);
                File.Copy(sourceFile, destFile, true);

                var sourceThumbFile = System.IO.Path.Combine(tempThumbDirectory, imageViewModel.FileName);
                var destThumbFile = System.IO.Path.Combine(imagesThumbDirectory, imageViewModel.FileName);
                File.Copy(sourceThumbFile, destThumbFile, true);

                service.ServiceImages.Add(new ServiceImages()
                {
                    FileName = imageViewModel.FileName,
                    Title = imageViewModel.Title,
                    Alt = imageViewModel.Alt
                });
            }


            

            _context.Services.Add(service);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();


                    callResult.Success = true;
                    callResult.Item = await GetServiceListViewAsync(service.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }



        }

        public async Task<ServiceEditViewModel> GetServiceEditViewModelAsync(int serviceId)
        {
            var service = await (from p in _context.Services
                                 where p.Id == serviceId
                                 select new ServiceEditViewModel()
                                 {
                                     Name = p.Name,
                                     Id = p.Id,
                                     LanguageId = p.LanguageId,
                                     Category = new ServiceCategoryIdSelectModel()
                                     {
                                         CategoryId = p.CategoryId
                                     },
                                     SeoDescription = p.SeoDescription,
                                     Active = p.Active,
                                     ShortDescription = p.ShortDescription,
                                     Description = p.Description,
                                     SeoTitle = p.SeoTitle,
                                     SeoKeywords = p.SeoKeywords,
                                     
                                     ImageViewModels = from i in p.ServiceImages
                                                       select new ImageViewModel()
                                                       {
                                                           FileName = i.FileName,
                                                           Alt = i.Alt,
                                                           Title = i.Title
                                                       },
                                     SortOrder = p.SortOrder,
                                   
                                 }).FirstOrDefaultAsync();
            return service;
        }
        public async Task<ServiceCallResult> EditServiceAsync(ServiceEditViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.Services.AnyAsync(a => a.Id != model.Id && a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Servis bulunmaktadır.");
                return callResult;
            }

            var service = await _context.Services.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (service == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Servis bulunamadı.");
                return callResult;
            }

            service.SeoDescription = model.SeoDescription;
            service.Active = model.Active;
            service.CategoryId = Convert.ToInt32(model.Category.CategoryId);
            service.Description = model.Description;
            service.Name = model.Name;
            service.Icon = string.IsNullOrWhiteSpace(model.Icon) ? service.Icon : model.Icon;

            service.SeoKeywords = model.SeoKeywords;
            service.SeoTitle = model.SeoTitle;
            service.ShortDescription = model.ShortDescription;
            service.SortOrder = model.SortOrder;
            var deletedImagesList = new List<string>();


            foreach (var imageDb in service.ServiceImages.ToArray()
                .Where(imageDb => model.ImageViewModels.All(x => x.FileName != imageDb.FileName)))
            {
                deletedImagesList.Add(imageDb.FileName);
                service.ServiceImages.Remove(imageDb);
                _context.ServiceImages.Remove(imageDb);
            }


            var tempDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.ServiceServiceTempImagePath, model.ServiceUniqueTempId);
            var tempThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + SystemConstants.ServiceServiceTempImageThumbPath, model.ServiceUniqueTempId);
            var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImagePath));
            var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImageThumbPath));

            if (!System.IO.Directory.Exists(imagesDirectory))
                System.IO.Directory.CreateDirectory(imagesDirectory);
            if (!System.IO.Directory.Exists(imagesThumbDirectory))
                System.IO.Directory.CreateDirectory(imagesThumbDirectory);

            byte imageOrder = 0;
            foreach (var imageViewModel in model.ImageViewModels)
            {
                var imageExist = service.ServiceImages.Any(a => a.FileName == imageViewModel.FileName);
                if (!imageExist)
                {
                    var sourceFile = System.IO.Path.Combine(tempDirectory, imageViewModel.FileName);
                    var destFile = System.IO.Path.Combine(imagesDirectory, imageViewModel.FileName);
                    File.Copy(sourceFile, destFile, true);

                    var sourceThumbFile = System.IO.Path.Combine(tempThumbDirectory, imageViewModel.FileName);
                    var destThumbFile = System.IO.Path.Combine(imagesThumbDirectory, imageViewModel.FileName);
                    File.Copy(sourceThumbFile, destThumbFile, true);

                    service.ServiceImages.Add(new ServiceImages()
                    {
                        FileName = imageViewModel.FileName,
                        Title = imageViewModel.Title,
                        Alt = imageViewModel.Alt
                    });

                    imageOrder++;
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
                    callResult.Item = await GetServiceListViewAsync(service.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }

        }
        public async Task<ServiceCallResult> DeleteServiceAsync(int serviceId)
        {
            var callResult = new ServiceCallResult() { Success = false };


            var service = await _context.Services.FirstOrDefaultAsync(a => a.Id == serviceId).ConfigureAwait(false);
            if (service == null)
            {
                callResult.ErrorMessages.Add("Böyle bir servis bulunamadı.");
                return callResult;
            }


            var deletedImagesList = new List<string>();
            foreach (var imageDb in service.ServiceImages.ToList())
            {
                deletedImagesList.Add(imageDb.FileName);
                service.ServiceImages.Remove(imageDb);
                _context.ServiceImages.Remove(imageDb);
            }

             
            _context.Services.Remove(service);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    if (deletedImagesList.Any())
                    {
                        var imagesDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImagePath));
                        var imagesThumbDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + String.Format(SystemConstants.ServiceServiceImageThumbPath));

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
                    callResult.Item = await GetServiceListViewAsync(service.Id).ConfigureAwait(false);
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
