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

        public JsonNetResult Changes(SortOption sortOption = 0x0, int pageNumber = 0, int pageSize = 10)
        {
            var search = new JsonNetResult(StatisticsHandler.GetCurrentState(sortOption, pageNumber, pageSize), JsonNetSettings.Default);
            return search;
        }

    }
}
