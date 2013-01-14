using System.Linq;
using TGoogle.Site.Models.ReadDataModel;

namespace TGoogle.Site.Models.ViewDataModel
{
    public class SearchViewResult
    {
        public SearchItem[] Results { get; set; }

        public SearchViewResult(ResponseData data)
        {
            Results = data.Results.Select(result => new SearchItem(result)).ToArray();
        }

        public SearchViewResult()
        {
        }
    }
}