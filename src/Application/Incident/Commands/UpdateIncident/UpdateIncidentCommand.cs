using Application.Interfaces;
using MediatR;
using System;
using System.Data.Entity.Migrations;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Commands.UpdateIncident
{
    public class UpdateIncidentCommand : IRequest<UpdateIncidentModel>
    {
        public UpdateIncidentModel IncidentModel { get; set; }
    }

    public class UpdateIncidentHandler : IRequestHandler<UpdateIncidentCommand, UpdateIncidentModel>
    {
        private readonly IDatabaseService _database;
        public UpdateIncidentHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<UpdateIncidentModel> Handle(UpdateIncidentCommand request, CancellationToken cancellationToken)
        {
            var model = request.IncidentModel;
            // get current incident from database
            var incident = await _database.Incidents
                           .FindAsync(cancellationToken, model.Id);
            if (incident == null)
            {
                return null;
            }
            // update incident
            incident.CallCode = model.CallCode;
            incident.SubsystemCode = model.SubsystemCode;
            // parse data from string
            incident.OpenedDate = DateTime.Parse(model.OpenedDate);
            incident.ClosedDate = DateTime.Parse(model.ClosedDate);
            incident.RequestType = model.RequestType;
            incident.ApplicationType = model.ApplicationType;
            incident.Urgency = model.Urgency;
            incident.SubCause = model.SubCause;
            incident.Summary = model.Summary;
            incident.Description = model.Description;
            incident.Solution = model.Solution;
            incident.OriginId = model.OriginId;
            incident.AmbitId = model.AmbitId;
            incident.ThreatId = model.ThreatId;
            incident.IncidentTypeId = model.IncidentTypeId;
            incident.ScenarioId = model.ScenarioId;
            incident.ThreatId = model.ThreatId;

            // update incident in database
            _database.Incidents.AddOrUpdate(incident);

            // save changes
            await _database.SaveAsync(cancellationToken);

            return model;
        }
    }
}
