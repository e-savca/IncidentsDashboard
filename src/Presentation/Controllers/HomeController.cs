using Presentation.Extensions;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return PartialView();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = User.Identity.GetUserRole();

            return PartialView();
        }

        [Authorize(Roles = "Operator")]
        public ActionResult Contact()
        {
            int id = User.Identity.GetUserId<int>();
            ViewBag.Message = "Your id: " + id.ToString();

            return PartialView();
        }
    }
}