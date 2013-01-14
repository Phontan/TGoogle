namespace TGoogle.Site.Models.DTO
{
    public class ResponsePages
    {
        public string start { get; set; }
        public int lable { get; set; }
        public string estimatedResultCount { get; set; }
        public int currentPageIndex { get; set; }
        public string moreResultsUrl { get; set; }
        public string searchResultTime { get; set; }
    }
}