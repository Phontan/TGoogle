using System;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TGoogle.Site.Models.DTO;
using TGoogle.Site.Models.Exceptions;
using TGoogle.Site.Models.Helper;

namespace TGoogle.Site.Models
{
    public class ContentGetter
    {
        private const string BaseUrl = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&safe=active&q={0}&start=0";

        private readonly JsonNetSettings _jsonNetSettings = new JsonNetSettings();

        public GoogleResponse GetResult(string keyWord)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format(BaseUrl, HttpUtility.UrlEncode(keyWord)));
            var response = request.GetResponseAsync().Result;
            var responseStream = response.GetResponseStream();

            if (responseStream == null)
                throw new ModelException("Unexpected response.");

            var content = new byte[65536];
            responseStream.ReadAsync(content, 0, content.Length);
            var stringResult = Encoding.UTF8.GetString(content);
            try
            {
                var jsonResult = JsonConvert.DeserializeObject<GoogleResponse>(stringResult, JsonNetSettings.Default);
                return jsonResult;
            }
            catch (JsonException exception)
            {
                throw new ModelException("Cannot deserialize body.", exception);
            }
            catch (Exception exception)
            {
                throw new ModelException("Unknown error.", exception);
            }
        }
    }
}