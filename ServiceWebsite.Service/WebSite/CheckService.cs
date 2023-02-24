
using System;
using ServiceWebsite.Data;
using ServiceWebsite.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ServiceWebsite.ViewModels.WebSite;
using ServiceWebsite.Core.TypeCodes;

namespace ServiceWebsite.Service.WebSite
{
    public class CheckService
    {
        private readonly WebSiteContextContainer _context;
        public CheckService(WebSiteContextContainer context)
        {
            _context = context;
        }
        public async Task<SearchControlModel> GezAsync(string url)
        {

            // Aranacak Başlıkların Databaseden Çekilmesi
            var keywords = await _context.Keyword.Include(i => i.SearchKeyword).ToListAsync().ConfigureAwait(false);
            var searchControlModel = new SearchControlModel();
            List<Keywords> keywordList = new List<Keywords>();
            foreach (var item in keywords)
            {
                List<SearchKeywordModel> searchKeywords = new List<SearchKeywordModel>();
                foreach (var item2 in item.SearchKeyword)
                {
                    var searchKeyword = new SearchKeywordModel()
                    {
                        IsAvailable = false,
                        Name = item2.Name,
                        Type = item2.KeywordType
                    };
                    searchKeywords.Add(searchKeyword);
                }
                var model = new Keywords()
                {
                    Name = item.Name,
                    IsAvailable = false,
                    SearchKeywords = searchKeywords,
                    Id = item.Id
                };
                keywordList.Add(model);
            }
            searchControlModel.Keywords = keywordList;
            // End of Aranacak Başlıkların Databaseden Çekilmesi

            bool gezici = true;
            List<SearchLink> searchLinks = new List<SearchLink>();
            SearchLink searchLink = new SearchLink()
            {
                IsAvailable = false,
                Url = url
            };
            searchLinks.Add(searchLink);

            Uri uriAddress = new Uri(url);
            var host = uriAddress.GetLeftPart(UriPartial.Authority);
            var mainModel = new MainModel();
            int j = 0;
            while (gezici)
            {
                j++;
                if (j == 3)
                    gezici = false;
                try
                {
                    List<SearchLink> newList = new List<SearchLink>();
                    if (searchLinks.Any(i => i.IsAvailable == false))
                    {
                        var searchLinksNotAvaible = searchLinks.Where(i => i.IsAvailable == false).ToList();
                        foreach (var item in searchLinksNotAvaible)
                        {
                            if (item.Url.Length > 0)
                            {
                                mainModel = await KaynakAlAsync(item.Url, searchControlModel).ConfigureAwait(false);
                                searchControlModel = mainModel.SearchControlModel;
                                newList = LinkAl(mainModel.Kaynak, host);
                                foreach (var list in newList)
                                {
                                    if (searchLinks.All(i => i.Url != list.Url))
                                    {
                                        searchLinks.Add(list);
                                    }
                                }
                                item.IsAvailable = true;
                            }
                        }
                    }
                    else
                    {
                        gezici = false;
                        searchLinks.Clear();
                    }
                }
                catch (Exception e)
                {

                }
            }
            return searchControlModel;

        }


        private async Task<MainModel> KaynakAlAsync(string url, SearchControlModel model)
        {
            try
            {

                var mainModel = new MainModel();
                WebRequest request = WebRequest.Create(url);
                WebResponse response = await request.GetResponseAsync().ConfigureAwait(false);
                Stream str = response.GetResponseStream();
                StreamReader reader = new StreamReader(str);
                string kaynak = (await reader.ReadToEndAsync().ConfigureAwait(false)).ToLower();
                url = url.ToLower();
                var keywords = model.Keywords.Where(i => i.IsAvailable == false).ToList();
                foreach (var item in keywords)
                {
                    bool contentknt = false;
                    var contentKeywords = item.SearchKeywords.Where(i => i.Type == SearchKeywordType.Content).ToList();
                    foreach (var item2 in contentKeywords)
                    {
                        if (kaynak.Contains(item2.Name))
                        {
                            contentknt = true;
                        }
                    }
                    if (contentknt)
                    {
                        if (item.SearchKeywords.Any(i => i.Type == SearchKeywordType.Url))
                        {
                            contentknt = false;
                        }

                        var urlKeywords = item.SearchKeywords.Where(i => i.Type == SearchKeywordType.Url).ToList();
                        foreach (var item2 in urlKeywords)
                        {
                            if (url.Contains(item2.Name))
                            {
                                contentknt = true;
                                item2.IsAvailable = true;
                            }
                        }
                    }


                    if (contentknt)
                    {
                        item.IsAvailable = true;
                        item.Url = url;
                    }

                }

                mainModel.Kaynak = kaynak;
                mainModel.SearchControlModel = model;
                return mainModel;
            }
            catch (Exception e)
            {
                var returnmodel = new MainModel { SearchControlModel = model };
                return returnmodel;
            }
        }





        private List<SearchLink> LinkAl(string kaynak, string host)
        {
            try
            {
                var rootDocument = new HtmlAgilityPack.HtmlDocument();
                rootDocument.LoadHtml(kaynak);
                //HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
                //HtmlAgilityPack.HtmlDocument rootDocument = await website.LoadFromWebAsync(url).ConfigureAwait(false);
                var links = rootDocument.DocumentNode.SelectNodes("//a").Where(element => element.Attributes["href"] != null && (!element.Attributes["href"].Value.Contains("#") &&
                                                                                                                               !element.Attributes["href"].Value.Contains("tel:") &&
                                                                                                                               !element.Attributes["href"].Value.Contains("mailto:") &&
                                                                                                                               !element.Attributes["href"].Value.Contains("@"))).Select(a => a.Attributes["href"].Value).ToList();
                List<SearchLink> liste = new List<SearchLink>();
                foreach (var element in links)
                {
                    //if (liste.Any(element.Attributes["href"].Value!=null ? element.Attributes["href"].Value : " "))
                    //{

                    //}
                    if (!element.Contains(host) && !element.Contains(host.Replace("http://", "https://")))
                    {
                        if (!element.Contains("http://") &&
                            !element.Contains("https://")
                            )
                        {
                            SearchLink newlistitem = new SearchLink()
                            {
                                Url = host + "/" + element,
                                IsAvailable = false
                            };
                            liste.Add(newlistitem);
                        }

                    }
                    else
                    {
                        SearchLink newlistitem = new SearchLink()
                        {
                            Url = element,
                            IsAvailable = false
                        };
                        liste.Add(newlistitem);
                    }


                }

                return liste;
            }
            catch (Exception e)
            {
                return new List<SearchLink>();
            }

        }

    }
}
