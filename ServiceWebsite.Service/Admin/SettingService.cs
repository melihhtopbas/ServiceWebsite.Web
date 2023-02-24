using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceWebsite.Data;
using ServiceWebsite.Infrastructure;
using ServiceWebsite.ViewModels.Admin;
using ServiceWebsite.ViewModels.Common;

namespace ServiceWebsite.Service.Admin
{
    public class SettingService
    {
        private readonly WebSiteContextContainer _context;
        private readonly ICacheService _cacheService;
        public SettingService(WebSiteContextContainer context,
            ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }
        public async Task<AboutViewModel> GetAboutViewModel(long languageId)
        {
            var model = await (from a in _context.About
                               where a.LanguageId == languageId
                               select new AboutViewModel()
                               {
                                   Description = a.Description,
                                   Title = a.Title,
                                   Vision = a.Vision,
                                   Mission = a.Mission,
                                   FileName = a.FileName,
                                   FileName2 = a.FileName2,
                                   LanguageId = a.LanguageId
                               }).SingleOrDefaultAsync().ConfigureAwait(false);
            if (model == null)
            {
                model = new AboutViewModel()
                {
                    LanguageId = languageId
                };

            }
            return model;

        }

        public async Task<ServiceCallResult> AddorEditAbout(AboutViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            var about = await _context.About.FirstOrDefaultAsync(a => a.LanguageId == model.LanguageId);

            if (about == null)
            {
                about = new About()
                {
                    LanguageId = model.LanguageId,
                    Description = model.Description,
                    Vision = model.Vision,
                    Mission = model.Mission,
                    FileName = model.FileName,
                    FileName2 = model.FileName2,
                    Title = model.Description

                };
                _context.About.Add(about);
            }
            else
            {
                about.Description = model.Description;
                about.Vision = model.Vision;
                about.Mission = model.Mission;
                about.FileName = string.IsNullOrWhiteSpace(model.FileName) ? about.FileName : model.FileName;
                about.FileName2 = string.IsNullOrWhiteSpace(model.FileName2) ? about.FileName2 : model.FileName2;
                about.Title = model.Title;
            }
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

        public bool Login(LoginViewModel login)
        {
            return _context.User.Any(x => x.Password == login.Password && x.UserName == login.UserName);
        }
        public async Task<SettingViewModel> GetSettingViewModel(long languageId)
        {
            var model = await (from a in _context.Settings
                               where a.LanguageId == languageId
                               select new SettingViewModel()
                               {
                                   Adress = a.Adress,
                                   Analytics = a.Analytics,
                                   Email = a.Email,
                                   Facebook = a.Facebook,
                                   Gplus = a.Gplus,
                                   Instagram = a.Instagram,
                                   Maps = a.Maps,
                                   Meta = a.Meta,
                                   Phone = a.Phone,
                                   Phone2 = a.Phone2,
                                   SeoDescription = a.Description,
                                   SeoKeywords = a.Keywords,
                                   SeoTitle = a.Title,
                                   Twitter = a.Twitter,
                                   Youtube = a.Youtube,
                                   LanguageId = languageId,
                                   Logo = a.Logo,
                                   Favicon = a.Favicon

                               }).SingleOrDefaultAsync().ConfigureAwait(false);

            if (model == null)
            {
                model = new SettingViewModel()
                {
                    LanguageId = languageId
                };

            }
            return model;

        }
        public async Task<ServiceCallResult> AddorEditSetting(SettingViewModel model)
        {
            var callResult = new ServiceCallResult() { Success = false };
            var setting = await _context.Settings.FirstOrDefaultAsync(a => a.LanguageId == model.LanguageId);
            if (setting == null)
            {
                setting = new Settings()
                {
                    LanguageId = model.LanguageId,
                    Description = model.SeoDescription,
                    Title = model.SeoTitle,
                    Twitter = model.Twitter,
                    Youtube = model.Youtube,
                    Adress = model.Adress,
                    Analytics = model.Analytics,
                    Email = model.Email,
                    Facebook = model.Facebook,
                    Gplus = model.Gplus,
                    Instagram = model.Instagram,
                    Keywords = model.SeoKeywords,
                    Maps = model.Maps,
                    Phone = model.Phone,
                    Phone2 = model.Phone2,
                    Meta = model.Meta,
                    Logo = model.Logo,
                    Favicon = model.Favicon


                };
                _context.Settings.Add(setting);
            }
            else
            {
                setting.Description = model.SeoDescription;
                setting.Title = model.SeoDescription;
                setting.Twitter = model.Twitter;
                setting.Youtube = model.Youtube;
                setting.Adress = model.Adress;
                setting.Analytics = model.Analytics;
                setting.Email = model.Email;
                setting.Facebook = model.Facebook;
                setting.Gplus = model.Gplus;
                setting.Instagram = model.Instagram;
                setting.Keywords = model.SeoKeywords;
                setting.Maps = model.Maps;
                setting.Phone = model.Phone;
                setting.Phone2 = model.Phone2;
                setting.Meta = model.Meta;
                setting.Logo = string.IsNullOrWhiteSpace(model.Logo) ? setting.Logo : model.Logo;
                setting.Favicon = string.IsNullOrWhiteSpace(model.Favicon) ? setting.Favicon : model.Favicon;
            }
            using (var dbtransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbtransaction.Commit();
                    _cacheService.Remove("setting");

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
