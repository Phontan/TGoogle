using System.Web.Mvc;
using TGoogle.Site.Models.Helper;
using TGoogle.Site.Models.Statistics;

namespace TGoogle.Site.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistic/

        public ActionResult Index()
        {
            return View();
        }

        public JsonNetResult Changes(SortOption sortOption = SortOption.None, int pageSize = 10)
        {
            var search = new JsonNetResult(StatisticsHandler.GetCurrentState(sortOption, pageSize), JsonNetSettings.Default);
            return search;
        }

    }
}
