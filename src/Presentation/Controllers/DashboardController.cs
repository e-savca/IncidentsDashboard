using Application.AdditionalInformation.Queries.GetAmbitListByOriginId;
using Application.AdditionalInformation.Queries.GetIncidentTypeListByAmbitId;
using Application.AdditionalInformation.Queries.GetOriginList;
using Application.AdditionalInformation.Queries.GetScenarioList;
using Application.AdditionalInformation.Queries.GetThreatList;
using Application.Incident.Commands.UpdateIncident;
using Application.Incident.Queries.GetIncidentById;
using Application.Incident.Queries.GetIncidentDetailsById;
using Application.Incident.Queries.GetIncidentsList;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        #region Private Fields

        private readonly IMediator _mediator;
        private readonly IValidator<UpdateIncidentModel> _updateIncidentValidator;

        #endregion

        #region Constructor

        public DashboardController(
            IMediator mediator,
            IValidator<UpdateIncidentModel> updateIncidentValidator
            )
        {
            _mediator = mediator;
            _updateIncidentValidator = updateIncidentValidator;
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
            var incident = await _mediator.Send(new GetIncidentDetailsByIdQuery { Id = id });
            return PartialView(incident);
        }

        public async Task<ActionResult> GetUpdateAsync(int id)
        {
            var incident = await _mediator.Send(new GetIncidentByIdQuery { Id = id });

            ViewBag.OriginList = await _getOriginListAsync();
            ViewBag.AmbitList = await _getAmbitListByOriginIdAsync(incident.OriginId);
            ViewBag.IncidentTypeList = await _getIncidentTypeListByAmbitIdAsync(incident.AmbitId);

            ViewBag.ScenarioList = await GetScenarioListAsync();
            ViewBag.ThreatList = await GetThreatListAsync();

            return PartialView(incident);
        }

        public async Task<ActionResult> GetCreateAsync(int id)
        {
            var incident = await _mediator.Send(new GetIncidentByIdQuery { Id = id });

            ViewBag.OriginList = await _getOriginListAsync();
            ViewBag.ScenarioList = await GetScenarioListAsync();
            ViewBag.ThreatList = await GetThreatListAsync();

            return PartialView(incident);
        }

        private async Task<List<SelectListItem>> _getOriginListAsync()
        {
            var origins = await _mediator.Send(new GetOriginListQuery());

            // Convert to a list of SelectListItem
            var originList = origins.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            return originList;
        }
        private async Task<List<SelectListItem>> _getAmbitListByOriginIdAsync(int id)
        {
            var ambits = await _mediator.Send(new GetAmbitListByOriginIdQuery { OriginId = id });

            // Convert to a list of SelectListItem
            var ambitsList = ambits.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            return ambitsList;
        }
        public async Task<ActionResult> GetAmbitListByOriginIdAsync(int id)
        {
            var ambits = await _mediator.Send(new GetAmbitListByOriginIdQuery { OriginId = id });

            return Json(ambits, JsonRequestBehavior.AllowGet);
        }

        private async Task<List<SelectListItem>> _getIncidentTypeListByAmbitIdAsync(int id)
        {
            var incidentTypes = await _mediator.Send(new GetIncidentTypeListByAmbitIdQuery { AmbitId = id });

            // Convert to a list of SelectListItem
            var incidentTypesList = incidentTypes.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            return incidentTypesList;
        }

        public async Task<ActionResult> GetIncidentTypeListByAmbitIdAsync(int id)
        {
            var incidentTypes = await _mediator.Send(new GetIncidentTypeListByAmbitIdQuery { AmbitId = id });

            return Json(incidentTypes, JsonRequestBehavior.AllowGet);
        }


        private async Task<List<SelectListItem>> GetScenarioListAsync()
        {
            var scenarios = await _mediator.Send(new GetScenarioListQuery());

            // Convert to a list of SelectListItem
            var scenariosList = scenarios.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            return scenariosList;
        }

        private async Task<List<SelectListItem>> GetThreatListAsync()
        {
            var threats = await _mediator.Send(new GetThreatListQuery());

            // Convert to a list of SelectListItem
            var threatList = threats.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            return threatList;
        }

        #endregion

        #region Update 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(UpdateIncidentModel model)
        {
            // Validate the model
            var validationResult = _updateIncidentValidator.Validate(model);

            if (validationResult.IsValid)
            {
                await _mediator.Send(new UpdateIncidentCommand { IncidentModel = model });

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