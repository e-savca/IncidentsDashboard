using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Commands.CreateIncident
{
    public class CreateIncidentCommand : IRequest<CreateIncidentModel>
    {
        public CreateIncidentModel IncidentModel { get; set; }
    }

    public class CreateIncidentHandler : IRequestHandler<CreateIncidentCommand, CreateIncidentModel>
    {
        private readonly IDatabaseService _database;
        public CreateIncidentHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<CreateIncidentModel> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            var incidentDto = request.IncidentModel;

            // check data 
            if (incidentDto == null)
            {
                return null;
            }
            // map data 
            var incident = new Domain.Incident.Incident() 
            {
                CallCode = incidentDto.CallCode,
                SubsystemCode = incidentDto.SubsystemCode,
                OpenedDate = DateTime.Parse(incidentDto.OpenedDate),
                ClosedDate = DateTime.Parse(incidentDto.ClosedDate),
                RequestType = incidentDto.RequestType,
                ApplicationType = incidentDto.ApplicationType,
                Urgency = incidentDto.Urgency,
                SubCause = incidentDto.SubCause,
                Summary = incidentDto.Summary,
                Description = incidentDto.Description,
                Solution = incidentDto.Solution,
                OriginId = incidentDto.OriginId,
                AmbitId = incidentDto.AmbitId,
                IncidentTypeId = incidentDto.IncidentTypeId,
                ScenarioId = incidentDto.ScenarioId,
                ThreatId = incidentDto.ThreatId
            };
            if (incident == null)
            {
                return null;
            }

            // add to database 
            _database.Incidents.Add(incident);

            // save changes
            await _database.SaveAsync(cancellationToken);

            return incidentDto;
        }
    }
}
