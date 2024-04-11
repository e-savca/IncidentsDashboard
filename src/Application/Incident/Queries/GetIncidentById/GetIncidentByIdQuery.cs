using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetIncidentByIdHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<IncidentByIdModel> Handle(GetIncidentByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the incident by id
            var incident = await _database.Incidents.FindAsync(cancellationToken, request.Id);
            if (incident == null)
            {
                return null;
            }

            // Map the incident
            var incidentModel = _mapper.Map<IncidentByIdModel>(incident);

            // Return the incident
            return incidentModel;
        }
    }
}
