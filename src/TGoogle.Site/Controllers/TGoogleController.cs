using System.Web.Mvc;
using TGoogle.Site.Models;

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

        public JsonResult Search(string keyWord)
        {
            var contentGetter = new ContentGetter();
            var content = contentGetter.GetResult(keyWord);
            return Json(content, JsonRequestBehavior.AllowGet);
        }
    }
}
