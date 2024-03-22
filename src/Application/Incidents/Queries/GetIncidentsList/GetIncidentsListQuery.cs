using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Incidents.Queries.GetIncidentsList
{
    public class GetIncidentsListQuery : IRequest<List<IncidentsListItemModel>> { }
    public class GetIncidentsListHandler : IRequestHandler<GetIncidentsListQuery, List<IncidentsListItemModel>>
    {
        private readonly IDatabaseService _database;
        public GetIncidentsListHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<IncidentsListItemModel>> Handle(GetIncidentsListQuery request, CancellationToken cancellationToken)
        {
            // Get all incidents from the database
            var incidents = await _database.Incidents
                .Select(incident => new IncidentsListItemModel
                {
                    Id = incident.Id,
                    CallCode = incident.CallCode,
                    SubsystemCode = incident.SubsystemCode,
                    OpenedDate = incident.OpenedDate,
                    ClosedDate = incident.ClosedDate,
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
                })
                .ToListAsync(cancellationToken);

            return incidents;
        }
    }
}
