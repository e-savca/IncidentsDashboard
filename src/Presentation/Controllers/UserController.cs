using Application.Users.Queries.GetUsersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUsersListQuery _getUsersListQuery;
        public UserController(IGetUsersListQuery getUsersListQuery)
        {
            _getUsersListQuery = getUsersListQuery;
        }
        // GET: UserDto
        public ActionResult Index()
        {
            var userList = _getUsersListQuery.Execute();
            return View(userList);
        }
    }
}