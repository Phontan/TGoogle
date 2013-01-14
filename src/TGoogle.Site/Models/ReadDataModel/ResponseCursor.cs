namespace TGoogle.Site.Models.ReadDataModel
{
    public class ResponseCursor
    {
        public string ResultCount { get; set; }
        public ResponsePages[] Pages { get; set; }
    }
}