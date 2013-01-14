namespace TGoogle.Site.Models.DTO
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
    }
}