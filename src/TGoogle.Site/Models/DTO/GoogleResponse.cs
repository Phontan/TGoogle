﻿namespace TGoogle.Site.Models.DTO
{
    public class GoogleResponse
    {
        public ResponseData ResponseData { get; set; }
        public ResponseCursor Cursor { get; set; }
        public int ResponseStatus { get; set; }
    }
}