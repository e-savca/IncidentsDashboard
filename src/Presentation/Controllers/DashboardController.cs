using Application.Incidents.Queries.GetIncidentById;
using Application.Incidents.Queries.GetIncidentsList;
using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        #region Private Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public DashboardController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        #endregion 

        #region CRUD Operations

        #region Create User

        //public async Task<ActionResult> GetCreateAsync()
        //{
        //    var user = new CreateUserModel()
        //    {
        //        IsActive = true
        //    };
        //    user.RoleIds = new List<int>(); // Initialize RoleIds

        //    // Fetch the roles list asynchronously
        //    ViewBag.Roles = await GetRolesListAsync();

        //    return PartialView(user);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAsync(CreateUserModel model)
        //{
        //    // Validate the model
        //    var validationResult = _createUserValidator.Validate(model);

        //    if (validationResult.IsValid)
        //    {
        //        //await _createUserCommand.ExecuteAsync(model);
        //        await _mediator.Send(new CreateUserCommand { UserModel = model });

        //        return new JsonResult
        //        {
        //            Data = new
        //            {
        //                success = true
        //            }
        //        };
        //    }

        //    // If the model state is not valid, redisplay the form
        //    var errorsList = validationResult.Errors.Select(e => new {
        //        message = e.ErrorMessage,
        //        propertyName = e.PropertyName
        //    }).ToList();

        //    return new JsonResult
        //    {
        //        Data = new
        //        {
        //            success = false,
        //            errors = errorsList,
        //            messageType = "danger"
        //        }
        //    };
        //}



        #endregion

        #region Read
        public ActionResult Index()
        {
            return PartialView();
        }

        public async Task<ActionResult> GetIncidentsListAsync()
        {
            var incidents = await _mediator.Send(new GetIncidentsListQuery());

            return Json(incidents, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetDetailsAsync(int id)
         {
            var incident = await _mediator.Send(new GetIncidentByIdQuery { Id = id });
            return PartialView(incident);
        }

        //public async Task<ActionResult> GetUpdateAsync(int id)
        //{
        //    var user = await _mediator.Send(new GetUserByIdQuery { Id = id });


        //    // Fetch the roles list asynchronously
        //    ViewBag.Roles = await GetRolesListAsync();

        //    if (user == null)
        //    {
        //        user = new UserByIdModel();
        //        return PartialView(user);
        //    }

        //    return PartialView(user);
        //}


        //public async Task<ActionResult> GetDetailsAsync(int id)
        //{
        //    var user = await _mediator.Send(new GetUserByIdQuery { Id = id });

        //    // Fetch the roles list asynchronously
        //    ViewBag.Roles = await GetRolesListAsync();

        //    if (user == null)
        //    {
        //        user = new UserByIdModel();
        //        return PartialView(user);
        //    }

        //    return PartialView(user);
        //}

        //private async Task<List<SelectListItem>> GetRolesListAsync()
        //{
        //    var roles = await _mediator.Send(new GetRolesListQuery());

        //    // Convert the roles to a list of SelectListItem
        //    var roleList = roles.Select(r => new SelectListItem
        //    {
        //        Value = r.Id.ToString(),
        //        Text = r.Name
        //    }).ToList();

        //    return roleList;
        //}

        #endregion

        #region Update 

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> UpdateAsync(UpdateUserModel model)
        //{
        //    // Validate the model
        //    var validationResult = _updateUserValidator.Validate(model);

        //    if (validationResult.IsValid)
        //    {
        //        await _mediator.Send(new UpdateUserCommand { UserModel = model });

        //        return new JsonResult
        //        {
        //            Data = new
        //            {
        //                success = true
        //            }
        //        };
        //    }

        //    // If the model state is not valid, redisplay the form
        //    var errorsList = validationResult.Errors.Select(e => new
        //    {
        //        message = e.ErrorMessage,
        //        propertyName = e.PropertyName
        //    }).ToList();

        //    return new JsonResult
        //    {
        //        Data = new
        //        {
        //            success = false,
        //            errors = errorsList
        //        }
        //    };
        //}


        #endregion

        #region Delete
        // No delete operations in this controller
        #endregion

        #endregion

    }
}