namespace TGoogle.Site.Models.DTO
{
    public class GoogleResponse
    {
        public ResponseData responseData { get; set; }
        public ResponseCursor cursor { get; set; }
        public int responseStatus { get; set; }
    }
}