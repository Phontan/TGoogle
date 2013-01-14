using System;

namespace TGoogle.Site.Models.ReadDataModel
{
    public class ResponseResult
    {
        public string GsearchResultClass { get; set; }
        public string UnescapedUrl { get; set; }
        public string Url { get; set; }
        public string VisibleUrl { get; set; }
        public string CacheUrl { get; set; }
        public string Title { get; set; }
        public string TitleNoFormatting { get; set; }
        public string Content { get; set; }

        private static readonly Random Random = new Random();

        public static ResponseResult Generate()
        {
            var randomNumber = Random.Next(1000);
            var responseResult = new ResponseResult
                                     {
                                         Url = string.Format("google.com/{0}", randomNumber),
                                         Content = string.Format("Some content {0}", randomNumber),
                                         Title = string.Format("Title {0}", randomNumber)
                                     };
            return responseResult;
        }
    }
}