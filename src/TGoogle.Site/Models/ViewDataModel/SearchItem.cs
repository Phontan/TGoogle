using TGoogle.Site.Models.ReadDataModel;

namespace TGoogle.Site.Models.ViewDataModel
{
    public class SearchItem
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public SearchItem(){}

        public SearchItem(ResponseResult responseResult)
        {
            Url = responseResult.Url;
            Title = responseResult.Title;
            Content = responseResult.Content;
        }
    }
}