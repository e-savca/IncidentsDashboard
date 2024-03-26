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
                .ToListAsync(cancellationToken);


            // map data
            var ambitDtos = ambits.Where(a => a.originToAmbits.Any(aa => aa.OriginId == request.OriginId))
                .Select(a => new AmbitListByOriginIdItemModel
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return ambitDtos;
        }
    }
}
