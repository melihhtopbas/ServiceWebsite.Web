using ServiceWebsite.Core.TypeCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWebsite.ViewModels.WebSite
{
    public class SearchModel
    {

    }

    public class SearchControlModel
    {
        public List<Keywords> Keywords { get; set; }

        public long WebsiteId { get; set; }
    }

    public class Keywords
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsAvailable { get; set; }
        public List<SearchKeywordModel> SearchKeywords { get; set; }
    }

    public class SearchKeywordModel
    {
        public string Name { get; set; }
        public SearchKeywordType Type { get; set; }
        public bool IsAvailable { get; set; }

    }

    public class SearchLink
    {
        public string Url { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class MainModel
    {
        public string Kaynak { get; set; }
        public SearchControlModel SearchControlModel { get; set; }
    }

}
