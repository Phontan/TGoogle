namespace TGoogle.Site.Models.DTO
{
    public class ResponseCursor
    {
        public string ResultCount { get; set; }
        public ResponsePages[] Pages { get; set; }
    }
}