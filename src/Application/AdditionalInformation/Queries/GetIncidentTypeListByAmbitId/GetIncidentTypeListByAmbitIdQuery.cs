using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdditionalInformation.Queries.GetIncidentTypeListByAmbitId
{
    public class GetIncidentTypeListByAmbitIdQuery : IRequest<List<IncidentTypeListByAmbitIdItemModel>>
    {
        public int AmbitId { get; set; }
    }

    public class GetIncidentTypeListByAmbitIdHandler : IRequestHandler<GetIncidentTypeListByAmbitIdQuery, List<IncidentTypeListByAmbitIdItemModel>>
    {
        private readonly IDatabaseService _database;
        public GetIncidentTypeListByAmbitIdHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }

        public async Task<List<IncidentTypeListByAmbitIdItemModel>> Handle(GetIncidentTypeListByAmbitIdQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var incidentTypes = await _database.IncidentTypes
                .Include(aa => aa.ambitsToTypes)
                .Where(i => i.ambitsToTypes.Any(c => c.AmbitId == request.AmbitId))
                .ToListAsync(cancellationToken);

            // map data
            var incidentTypeDtos = incidentTypes.ConvertAll(i => new IncidentTypeListByAmbitIdItemModel
            {
                Id = i.Id,
                Name = i.Name
            });
            return incidentTypeDtos;
        }
    }
}
