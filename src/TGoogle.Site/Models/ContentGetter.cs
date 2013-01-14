using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using TGoogle.Site.Models.DTO;

namespace TGoogle.Site.Models
{
    public class ContentGetter
    {
        private const string BaseUrl = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&safe=active&q={0}&start=0";

        public object GetResult(string keyWord)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format(BaseUrl, HttpUtility.UrlEncode(keyWord)));
            var response = request.GetResponseAsync().Result;
            var responseStream = response.GetResponseStream();

            if (responseStream == null)
                return string.Empty;

            var content = new byte[65536];
            responseStream.ReadAsync(content, 0, content.Length);
            var stringResult = Encoding.UTF8.GetString(content);
            try
            {
                return  Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleResponse>(stringResult);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return new object();
            }
        }
    }
}