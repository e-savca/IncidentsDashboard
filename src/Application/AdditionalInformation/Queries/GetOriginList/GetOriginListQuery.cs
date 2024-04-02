using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetOriginListHandler(            
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<OriginListItemModel>> Handle(GetOriginListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var origins = await _database.Origins.ToListAsync(cancellationToken);

            return _mapper.Map<List<OriginListItemModel>>(origins);
        }
    }    
}
