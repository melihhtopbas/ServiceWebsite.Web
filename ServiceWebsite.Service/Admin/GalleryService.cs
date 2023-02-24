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
    public class GalleryService
    {
        private readonly WebSiteContextContainer _context;
        public GalleryService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<GalleryListViewModel> _getGalleryListIQueryable(Expression<Func<Data.Gallery, bool>> expr)
        {
            return (from b in _context.Gallery.AsExpandable().Where(expr)
                    select new GalleryListViewModel()
                    {
                        Name = b.Name,
                        Id = b.Id,
                        Description = b.Description,
                        MainImage = b.FileName
                    });
        }
        public IQueryable<GalleryListViewModel> GetGalleryListIQueryable(GallerySearchViewModel model)
        {
            var predicate = PredicateBuilder.New<Data.Gallery>(true);/*AND*/
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                predicate.And(a => a.Name.Contains(model.Name));
            }

            return _getGalleryListIQueryable(predicate);
        }
        public async Task<GalleryListViewModel> GetGalleryListViewAsync(long galleryId)
        {

            var predicate = PredicateBuilder.New<Data.Gallery>(true);/*AND*/
            predicate.And(a => a.Id == galleryId);
            var property = await _getGalleryListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return property;
        }
        public async Task<ServiceCallResult> AddGalleryAsync(GalleryAddViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.Gallery.AnyAsync(a => a.Name == model.Name).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Fotograf bulunmaktadır.");
                return callResult;
            }

            var gallery = new Gallery()
            {
                Name = model.Name,
                FileName = model.FileName,
                Description = model.Description
            };
            _context.Gallery.Add(gallery);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetGalleryListViewAsync(gallery.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<GalleryEditViewModel> GetGalleryEditViewModelAsync(long galleryId)
        {
            var gallery = await (from b in _context.Gallery
                                 where b.Id == galleryId
                                 select new GalleryEditViewModel()
                                 {
                                     Name = b.Name,
                                     Id = b.Id,
                                     Description = b.Description

                                 }).FirstOrDefaultAsync();
            return gallery;
        }
        public async Task<ServiceCallResult> EditGalleryAsync(GalleryEditViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.Gallery.AnyAsync(a => a.Name == model.Name && a.Id != model.Id).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde Fotograf bulunmaktadır.");
                return callResult;
            }

            var gallery = await _context.Gallery.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (gallery == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Fotograf bulunamadı.");
                return callResult;
            }
            gallery.FileName = string.IsNullOrWhiteSpace(model.FileName) ? gallery.FileName : model.FileName;
            gallery.Description = model.Description;
            gallery.Name = model.Name;

            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    callResult.Success = true;
                    callResult.Item = await GetGalleryListViewAsync(gallery.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<ServiceCallResult> DeleteGalleryAsync(int galleryId)
        {
            var callResult = new ServiceCallResult() { Success = false };


            var gallery = await _context.Gallery.FirstOrDefaultAsync(a => a.Id == galleryId).ConfigureAwait(false);
            if (gallery == null)
            {
                callResult.ErrorMessages.Add("Böyle bir Fotograf bulunamadı.");
                return callResult;
            }
            _context.Gallery.Remove(gallery);
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
