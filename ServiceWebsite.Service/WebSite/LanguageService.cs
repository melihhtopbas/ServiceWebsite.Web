using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Data;
using ServiceWebsite.Infrastructure;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.WebSite
{
     public class LanguageService
    {
        private readonly WebSiteContextContainer _context;
        private readonly ICacheService _cacheService;
        public LanguageService(WebSiteContextContainer context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task<List<LanguageListModel>> GetLanguageListViewAsync()
        {

            return await (from l in _context.Languages
                select new LanguageListModel
                {
                    Name = l.Name,
                    ShortName = l.ShortName

                }).ToListAsync().ConfigureAwait(false);
        }
        public List<LanguageListModel> GetLanguageListView()
        {

            var model= _cacheService.Get("language", () => (from l in _context.Languages
                select new LanguageListModel
                {
                    Name = l.Name,
                    ShortName = l.ShortName

                }).ToList());
            return model;
        }
    }
}
