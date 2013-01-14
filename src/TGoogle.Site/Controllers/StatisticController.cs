using System.Web.Mvc;
using TGoogle.Site.Models.Helper;

namespace TGoogle.Site.Controllers
{
    public class StatisticController : Controller
    {
        //
        // GET: /Statistic/

        public ActionResult Index()
        {
            return View();
        }

        public JsonNetResult StatisticChanges()
        {
            var content = "SomeData";
            var search = new JsonNetResult(content, JsonNetSettings.Default);
            return search;
        }

    }
}
