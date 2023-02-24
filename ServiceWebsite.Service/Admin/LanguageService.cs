using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.Admin
{
    public class LanguageService
    {
        private readonly WebSiteContextContainer _context;

        public LanguageService(WebSiteContextContainer context)
        {
            _context = context;
        }

        public async Task<List<LanguageListModel>> GetLanguageListViewAsync()
        {
            
            return await (from l in  _context.Languages select new LanguageListModel
            {
                Name = l.Name,
                Id = l.Id

            }).ToListAsync().ConfigureAwait(false);
        }
        public List<LanguageListModel> GetLanguageListView()
        {

            return  (from l in _context.Languages
                select new LanguageListModel
                {
                    Name = l.Name,
                    Id = l.Id

                }).ToList();
        }
    }
}
