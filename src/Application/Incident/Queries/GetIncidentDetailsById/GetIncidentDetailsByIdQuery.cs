using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Data.Entity;
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
        private readonly IMapper _mapper;

        public GetIncidentDetailsByIdHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<IncidentDetailsByIdModel> Handle(GetIncidentDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the incident by id
            var incident = await _database.Incidents
                .Include(i => i.Origin)
                .Include(i => i.Ambit)
                .Include(i => i.IncidentType)
                .Include(i => i.Scenario)
                .Include(i => i.Threat)
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (incident == null)
                return null;

            return _mapper.Map<IncidentDetailsByIdModel>(incident);
        }
    }
}