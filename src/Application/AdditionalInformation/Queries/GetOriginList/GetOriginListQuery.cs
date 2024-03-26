using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdditionalInformation.Queries.GetOriginList
{
    public class GetOriginListQuery : IRequest<List<OriginListItemModel>> { }
    public class GetOriginListHandler : IRequestHandler<GetOriginListQuery, List<OriginListItemModel>>
    {
        private readonly IDatabaseService _database;
        public GetOriginListHandler(            
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<OriginListItemModel>> Handle(GetOriginListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var origins = await _database.Origins.ToListAsync(cancellationToken);

            // map data
            var originDtos = origins.ConvertAll(o => new OriginListItemModel
            {
                Id = o.Id,
                Name = o.Name
            });

            return originDtos;
        }
    }    
}
