using System;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels.WebSite;

namespace ServiceWebsite.Service.WebSite
{
    public class SliderService
    {
        private readonly WebSiteContextContainer _context;

        public SliderService(WebSiteContextContainer context)
        {
            _context = context;
        }


        private IQueryable<SliderListViewModel> _getSliderListIQueryable(Expression<Func<Data.Sliders, bool>> expr)
        {
            return (from s in _context.Sliders.AsExpandable().Where(expr)
                    select new SliderListViewModel()
                    {
                        FileName = s.FileName,
                        ButtonLink1 = s.ButtonLink1,
                        ButtonLink2 = s.ButtonLink2,
                        ButtonLink3 = s.ButtonLink3,
                        ButtonLink4 = s.ButtonLink4,
                        ButtonText1 = s.ButtonText1,
                        ButtonText2 = s.ButtonText2,
                        ButtonText3 = s.ButtonText3,
                        ButtonText4 = s.ButtonText4
                    });
        }

        public IQueryable<SliderListViewModel> GetSliderListIQueryable(string languageCode)
        {
            var predicate = PredicateBuilder.New<Data.Sliders>(true);/*AND*/
            predicate.And(a => a.Languages.ShortName == languageCode);
            predicate.And(a => a.Active);
            return _getSliderListIQueryable(predicate);
        }


    }
}