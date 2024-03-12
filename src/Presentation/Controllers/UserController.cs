using Application.Users.Queries.GetUsersList;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var users = await _getUsersList.ExecuteAsync();
            return PartialView(users);
        }
    }
}