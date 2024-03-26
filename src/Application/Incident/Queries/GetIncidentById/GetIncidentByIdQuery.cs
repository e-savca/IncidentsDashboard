using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Queries.GetIncidentById
{
    public class GetIncidentByIdQuery : IRequest<IncidentByIdModel>
    {
        public int Id { get; set; }
    }
    public class GetIncidentByIdHandler : IRequestHandler<GetIncidentByIdQuery, IncidentByIdModel>
    {
        private readonly IDatabaseService _database;
        public GetIncidentByIdHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<IncidentByIdModel> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the incident by id
            var incident = await _database.Incidents.FindAsync(cancellationToken, request.Id);
            if (incident == null)
            {
                return null;
            }

            // Map and return the DTO
            return new IncidentByIdModel
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
                OriginId = incident.OriginId,
                AmbitId = incident.AmbitId,
                IncidentTypeId = incident.IncidentTypeId,
                ScenarioId = incident.ScenarioId,
                ThreatId = incident.ThreatId
            };
        }
    }
}
