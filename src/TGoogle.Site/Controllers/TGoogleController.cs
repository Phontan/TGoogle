using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TGoogle.Site.Models;
using TGoogle.Site.Models.Exceptions;
using TGoogle.Site.Models.Helper;
using TGoogle.Site.Models.ReadDataModel;

namespace TGoogle.Site.Controllers
{
    public class TGoogleController : Controller
    {
        //
        // GET: /TGoogle/

        public ActionResult Index()
        {
            return View();
        }

        public JsonNetResult Search(string keyWord)
        {
            var contentGetter = new ContentGetter();
            try
            {
                var content =  contentGetter.GetResult(keyWord);
                var search = new JsonNetResult(content, JsonNetSettings.Default);
                return search;
            }
            catch (ModelException exception)
            {
                throw new HttpException(httpCode: (int) HttpStatusCode.InternalServerError, message:exception.Message, innerException:exception.InnerException);
            }
            catch (Exception)
            {
                throw new HttpException(httpCode:(int) HttpStatusCode.InternalServerError, message:"Unknown error.");
            }
        }
    }
}
