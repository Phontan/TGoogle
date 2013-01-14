namespace TGoogle.Site.Models.ReadDataModel
{
    public class ResponsePages
    {
        public string Start { get; set; }
        public int Lable { get; set; }
        public string EstimatedResultCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public string MoreResultsUrl { get; set; }
        public string SearchResultTime { get; set; }
    }
}