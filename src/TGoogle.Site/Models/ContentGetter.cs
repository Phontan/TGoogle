using System;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using TGoogle.Site.Models.Exceptions;
using TGoogle.Site.Models.Helper;
using TGoogle.Site.Models.ReadDataModel;
using TGoogle.Site.Models.ViewDataModel;

namespace TGoogle.Site.Models
{
    public class ContentGetter
    {
        private const string BaseUrl = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&safe=active&q={0}&start=0";

        public SearchViewResult GetResult(string keyWord)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format(BaseUrl, HttpUtility.UrlEncode(keyWord)));
            var response = request.GetResponseAsync().Result;
            var responseStream = response.GetResponseStream();

            if (responseStream == null)
                throw new ModelException("Unexpected response.");

            var content = new byte[65536];
            responseStream.ReadAsync(content, 0, content.Length);
            var stringResult = Encoding.UTF8.GetString(content);
            GoogleResponse jsonResult;
            try
            {
                jsonResult = JsonConvert.DeserializeObject<GoogleResponse>(stringResult, JsonNetSettings.Default);
            }
            catch (JsonException exception)
            {
                throw new ModelException("Cannot deserialize body.", exception);
            }
            catch (Exception exception)
            {
                throw new ModelException("Unknown error.", exception);
            }

            if (jsonResult.ResponseStatus != 200)
            {
                jsonResult.ResponseData = ResponseData.Generate();
                //throw new ModelException(string.Format("Unexpected response from google server. Status code is {0}", jsonResult.ResponseStatus));
            }

            return new SearchViewResult(jsonResult.ResponseData);
        }
    }
}