using Application.Users.Queries.GetUsersList;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUsersListQuery _getUsersList;

        public UserController(
            IGetUsersListQuery getUsersList
            )
        {
            _getUsersList = getUsersList;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _getUsersList.Execute();
            return PartialView(users);
        }
    }
}