using Application.Roles.Queries.GetRolesList;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using Application.User.Queries.GetUserById;
using Application.User.Queries.GetUsersList;
using FluentValidation;
using MediatR;
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
        #region Private Fields

        private readonly IValidator<CreateUserModel> _createUserValidator;
        private readonly IValidator<UpdateUserModel> _updateUserValidator;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public AdminController(
            IValidator<CreateUserModel> createUserValidator,
            IValidator<UpdateUserModel> updateUserValidator,
            IMediator mediator
            )
        {
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
            _mediator = mediator;
        }

        #endregion

        #region CRUD Operations

        #region Create User

        public async Task<ActionResult> GetCreateAsync()
        {
            var user = new CreateUserModel()
            {
                IsActive = true
            };
            user.RoleIds = new List<int> { 3 }; // Initialize RoleIds

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

            if (!validationResult.IsValid)
            {
                // If the model state is not valid, redisplay the form
                var errorsList = validationResult.Errors.Select(e => new
                {
                    message = e.ErrorMessage,
                    propertyName = e.PropertyName
                }).ToList();

                return new JsonResult
                {
                    Data = new
                    {
                        success = false,
                        errors = errorsList
                    }
                };
            }

            bool _success = true;
            var _errors = new List<(string Message, string PropertyName)>();
            try
            {
                await _mediator.Send(new CreateUserCommand { UserModel = model });
            }
            catch (Exception ex)
            {
                _success = false;
                _errors.Add((ex.Message, "liveAlertPlaceholder"));
            }

            var _errorsList = _errors.Select(e => new
            {
                message = e.Message,
                propertyName = e.PropertyName
            }).ToList();


            return new JsonResult
            {
                Data = new
                {
                    success = _success,
                    errors = _errorsList
                }
            };
        }


        #endregion

        #region Read
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> GetUsersListAsync()
        {
            var query = new GetUsersListQuery
            {
                Draw = Request["draw"],
                Start = Convert.ToInt32(Request["start"]),
                Length = Convert.ToInt32(Request["length"]),
                Search = Request["search[value]"],
                SortColumnName = Request["columns[" + Request["order[0][column]"] + "][data]"],
                SortDirection = Request["order[0][dir]"]
            };

            var response = await _mediator.Send(query);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetUpdateAsync(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });


            // Fetch the roles list asynchronously
            ViewBag.Roles = await GetRolesListAsync();

            if (user == null)
            {
                user = new UserByIdModel();
                return PartialView(user);
            }

            return PartialView(user);
        }


        public async Task<ActionResult> GetDetailsAsync(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });

            // Fetch the roles list asynchronously
            ViewBag.Roles = await GetRolesListAsync();

            if (user == null)
            {
                user = new UserByIdModel();
                return PartialView(user);
            }

            return PartialView(user);
        }

        private async Task<List<SelectListItem>> GetRolesListAsync()
        {
            var roles = await _mediator.Send(new GetRolesListQuery());

            // Convert the roles to a list of SelectListItem
            var roleList = roles.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }).ToList();

            return roleList;
        }

        #endregion

        #region Update 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(UpdateUserModel model)
        {
            // Validate the model
            var validationResult = _updateUserValidator.Validate(model);

            if (validationResult.IsValid)
            {
                await _mediator.Send(new UpdateUserCommand { UserModel = model });

                return new JsonResult
                {
                    Data = new
                    {
                        success = true
                    }
                };
            }

            // If the model state is not valid, redisplay the form
            var errorsList = validationResult.Errors.Select(e => new
            {
                message = e.ErrorMessage,
                propertyName = e.PropertyName
            }).ToList();

            return new JsonResult
            {
                Data = new
                {
                    success = false,
                    errors = errorsList
                }
            };
        }


        #endregion

        #region Delete
        // No delete operations in this controller
        #endregion

        #endregion

    }
}