namespace TGoogle.Site.Models.DTO
{
    public class ResponseCursor
    {
        public string resultCount { get; set; }
        public ResponsePages[] pages { get; set; }
    }
}