using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdditionalInformation.Queries.GetAmbitListByOriginId
{
    public class GetAmbitListByOriginIdQuery : IRequest<List<AmbitListByOriginIdItemModel>>
    {
        public int OriginId { get; set; }
    }
    public class GetAmbitListByOriginIdHandler : IRequestHandler<GetAmbitListByOriginIdQuery, List<AmbitListByOriginIdItemModel>>
    {
        private readonly IDatabaseService _database;
        public GetAmbitListByOriginIdHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<AmbitListByOriginIdItemModel>> Handle(GetAmbitListByOriginIdQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var ambits = await _database.Ambits.
                Include(i => i.originToAmbits)
                .Where(w => w.originToAmbits.Any(a => a.OriginId == request.OriginId))
                .ToListAsync(cancellationToken);


            // map data
            var ambitDtos = ambits
                .Select(a => new AmbitListByOriginIdItemModel
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return ambitDtos;
        }
    }
}
