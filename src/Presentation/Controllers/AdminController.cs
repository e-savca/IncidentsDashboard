using Application.Users.Queries.GetUsersList;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGetUsersListQuery _getUsersList;

        public AdminController(
            IGetUsersListQuery getUsersList
            )
        {
            _getUsersList = getUsersList;
        }
        // GET: User
        public ActionResult Index()
        {
            return PartialView();
        }
        public async Task<ActionResult> GetUsersListAsync()
        {
            var users = await _getUsersList.ExecuteAsync();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}