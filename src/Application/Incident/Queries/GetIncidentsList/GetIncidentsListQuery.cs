using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Incident.Queries.GetIncidentsList
{
    public class GetIncidentsListQuery : IRequest<List<IncidentsListItemModel>> { }
    public class GetIncidentsListHandler : IRequestHandler<GetIncidentsListQuery, List<IncidentsListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetIncidentsListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<IncidentsListItemModel>> Handle(GetIncidentsListQuery request, CancellationToken cancellationToken)
        {
            // Get all incidents from the database
            var incidents = await _database.Incidents.ToListAsync(cancellationToken);

            return _mapper.Map<List<IncidentsListItemModel>>(incidents);
        }
    }
}
