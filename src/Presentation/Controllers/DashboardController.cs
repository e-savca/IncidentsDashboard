using System.Web.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}