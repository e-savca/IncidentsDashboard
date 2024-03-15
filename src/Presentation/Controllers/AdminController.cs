using Application.Roles.Queries.GetRolesList;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUsersList;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGetUsersListQuery _getUsersList;
        private readonly IGetRolesListQuery _getRolesListQuery;
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IValidator<CreateUserModel> _createUserValidator;

        public AdminController(
            IGetUsersListQuery getUsersList,
            IGetRolesListQuery getRolesListQuery,
            ICreateUserCommand createUserCommand,
            IValidator<CreateUserModel> createUserValidator
            )
        {
            _getUsersList = getUsersList;
            _getRolesListQuery = getRolesListQuery;
            _createUserCommand = createUserCommand;
            _createUserValidator = createUserValidator;
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
        public async Task<ActionResult> GetCreate()
        {
            var user = new CreateUserModel()
            {
                IsActive = true
            };
            user.RoleIds = new List<int>(); // Initialize RoleIds

            // Fetch the roles list asynchronously
            ViewBag.Roles = await GetRolesListAsync();

            return PartialView(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateUserModel model)
        {
            // Validate the model
            var validationResult = _createUserValidator.Validate(model);

            if (validationResult.IsValid)
            {
                await _createUserCommand.ExecuteAsync(model);

                return new JsonResult
                {
                    Data = new
                    {
                        success = true
                    }
                };
            }

            // If the model state is not valid, redisplay the form
            var errorsList = validationResult.Errors.Select(e => new {
                message = e.ErrorMessage,
                propertyName = e.PropertyName
            }).ToList();

            return new JsonResult
            {
                Data = new
                {
                    success = false,
                    errors = errorsList,
                    messageType = "danger"
                }                
            };
        }

        public async Task<List<SelectListItem>> GetRolesListAsync()
        {
            var roles = await _getRolesListQuery.ExecuteAsync();

            // Convert the roles to a list of SelectListItem
            var roleList = roles.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList();

            return roleList;
        }


    }
}