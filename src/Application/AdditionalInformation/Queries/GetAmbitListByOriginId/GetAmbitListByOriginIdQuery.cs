using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetAmbitListByOriginIdHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<AmbitListByOriginIdItemModel>> Handle(GetAmbitListByOriginIdQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var ambits = await _database.Ambits.
                Include(i => i.originToAmbits)
                .Where(w => w.originToAmbits.Any(a => a.OriginId == request.OriginId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<AmbitListByOriginIdItemModel>>(ambits);
        }
    }
}
