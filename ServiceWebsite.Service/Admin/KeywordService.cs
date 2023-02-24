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
    public class KeywordService
    {
        private readonly WebSiteContextContainer _context;

        public KeywordService(WebSiteContextContainer context)
        {
            _context = context;
        }
        private IQueryable<KeywordListViewModel> _getKeywordsListIQueryable(Expression<Func<Data.Keyword, bool>> expr)
        {
            return (from b in _context.Keyword.AsExpandable().Where(expr)
                    select new KeywordListViewModel()
                    {
                        Name = b.Name,
                        Id = b.Id,
                        Price = b.Price
                    });
        }
        public IQueryable<KeywordListViewModel> GetKeywordsListIQueryable(KeywordSearchViewModel keywordSearchViewModel)
        {
            var predicate = PredicateBuilder.New<Data.Keyword>(true);/*AND*/

            predicate.And(a => a.LanguageId == keywordSearchViewModel.LanguageId);
            if (!string.IsNullOrWhiteSpace(keywordSearchViewModel.Name))
            {
                predicate.And(a => a.Name.Contains(keywordSearchViewModel.Name));
            }

            return _getKeywordsListIQueryable(predicate);
        }
        public async Task<KeywordListViewModel> GetKeywordListViewAsync(long keywordId)
        {

            var predicate = PredicateBuilder.New<Data.Keyword>(true);/*AND*/
            predicate.And(a => a.Id == keywordId);
            var Keyword = await _getKeywordsListIQueryable(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            return Keyword;
        }
        public async Task<ServiceCallResult> AddKeywordAsync(KeywordAddViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };

            bool nameExist = await _context.Keyword.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde kelime bulunmaktadır.");
                return callResult;
            }

            var keyword = new Keyword()
            {
                LanguageId = model.LanguageId,
                Name = model.Name,
                Price = model.Price ?? 0,
                DocumentTemplate = model.DocumentTemplate
            };

            foreach (var searchKeyword in model.SearchKeywordViewModels)
            {
                keyword.SearchKeyword.Add(new SearchKeyword()
                {
                    Name = searchKeyword.Name,
                    KeywordType = searchKeyword.KeywordType
                });
            }
            _context.Keyword.Add(keyword);
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = await GetKeywordListViewAsync(keyword.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
        public async Task<KeywordEditViewModel> GetKeywordEditViewModelAsync(long keywordId)
        {
            var keyword = await (from b in _context.Keyword
                                 where b.Id == keywordId
                                 select new KeywordEditViewModel()
                                 {
                                     Name = b.Name,
                                     Id = b.Id,
                                     LanguageId = b.LanguageId,
                                     Price = b.Price,
                                     DocumentTemplate = b.DocumentTemplate,
                                     SearchKeywordViewModels = from s in b.SearchKeyword
                                                               select new SearchKeywordViewModel()
                                                               {
                                                                   KeywordType = s.KeywordType,
                                                                   Name = s.Name
                                                               }

                                 }).FirstOrDefaultAsync();
            return keyword;
        }
        public async Task<ServiceCallResult> EditKeywordAsync(KeywordEditViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            bool nameExist = await _context.Keyword.AnyAsync(a => a.Name == model.Name && a.LanguageId == model.LanguageId && a.Id != model.Id).ConfigureAwait(false);
            if (nameExist)
            {
                callResult.ErrorMessages.Add("Bu isimde kelime bulunmaktadır.");
                return callResult;
            }

            var keyword = await _context.Keyword.FirstOrDefaultAsync(a => a.Id == model.Id).ConfigureAwait(false);
            if (keyword == null)
            {
                callResult.ErrorMessages.Add("Böyle bir kelime bulunamadı.");
                return callResult;
            }


            keyword.Name = model.Name;
            keyword.Price = model.Price ?? 0;
            keyword.DocumentTemplate = model.DocumentTemplate;
            var searchKeywords = keyword.SearchKeyword.ToList();
            foreach (var searchKeyword in searchKeywords)
            {
                keyword.SearchKeyword.Remove(searchKeyword);
                _context.SearchKeyword.Remove(searchKeyword);
            }
            foreach (var searchKeyword in model.SearchKeywordViewModels)
            {
                keyword.SearchKeyword.Add(new SearchKeyword()
                {
                    Name = searchKeyword.Name,
                    KeywordType = searchKeyword.KeywordType
                });
            }
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();

                    callResult.Success = true;
                    callResult.Item = await GetKeywordListViewAsync(keyword.Id).ConfigureAwait(false);
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }

        }
        public async Task<ServiceCallResult> DeleteKeywordAsync(int keywordId)
        {
            var callResult = new ServiceCallResult() { Success = false };


            var keyword = await _context.Keyword.FirstOrDefaultAsync(a => a.Id == keywordId).ConfigureAwait(false);
            if (keyword == null)
            {
                callResult.ErrorMessages.Add("Böyle bir kelime bulunamadı.");
                return callResult;
            }
            var searchKeywords = keyword.SearchKeyword.ToList();
            foreach (var searchKeyword in searchKeywords)
            {
                keyword.SearchKeyword.Remove(searchKeyword);
                _context.SearchKeyword.Remove(searchKeyword);
            }
            _context.Keyword.Remove(keyword);
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
