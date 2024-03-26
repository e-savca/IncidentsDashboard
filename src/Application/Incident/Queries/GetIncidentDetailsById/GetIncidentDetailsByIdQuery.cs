using Application.Incident.Queries.GetIncidentById;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Queries.GetIncidentDetailsById
{
    public class GetIncidentDetailsByIdQuery : IRequest<IncidentDetailsByIdModel>
    {
        public int Id { get; set; }
    }
    public class GetIncidentDetailsByIdHandler : IRequestHandler<GetIncidentDetailsByIdQuery, IncidentDetailsByIdModel>
    {
        private readonly IDatabaseService _database;
        public GetIncidentDetailsByIdHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<IncidentDetailsByIdModel> Handle(GetIncidentDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the incident by id
            var incident = await _database.Incidents
                .FindAsync(cancellationToken, request.Id);
            if (incident == null)
            {
                return null;
            }

            var origin = await _database.Origins.FindAsync(cancellationToken, incident.OriginId);
            var originName = origin.Name;

            var ambit = await _database.Ambits.FindAsync(cancellationToken, incident.AmbitId);
            var ambitName = ambit.Name;

            var incidentType = await _database.IncidentTypes.FindAsync(cancellationToken, incident.IncidentTypeId);
            var incidentTypeName = incidentType.Name;

            var scenario = await _database.Scenarios.FindAsync(cancellationToken, incident.ScenarioId);
            var scenarioName = scenario.Name;            

            var threat = await _database.Threats.FindAsync(cancellationToken, incident.ThreatId);
            var threatName = threat.Name;

            // Map and return the DTO
            return new IncidentDetailsByIdModel
            {
                Id = incident.Id,
                CallCode = incident.CallCode,
                SubsystemCode = incident.SubsystemCode,
                OpenedDate = incident.OpenedDate.ToString(),
                ClosedDate = incident.ClosedDate.ToString(),
                RequestType = incident.RequestType,
                ApplicationType = incident.ApplicationType,
                Urgency = incident.Urgency,
                SubCause = incident.SubCause,
                Summary = incident.Summary,
                Description = incident.Description,
                Solution = incident.Solution,
                Origin = originName,
                Ambit = ambitName,
                IncidentType = incidentTypeName,
                Scenario = scenarioName,
                Threat = threatName
            };
        }
    }
}