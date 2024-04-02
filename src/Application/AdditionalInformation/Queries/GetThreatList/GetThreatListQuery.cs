using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdditionalInformation.Queries.GetThreatList
{
    public class GetThreatListQuery : IRequest<List<ThreatListItemModel>> { }

    public class GetThreatListHandler : IRequestHandler<GetThreatListQuery, List<ThreatListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetThreatListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<ThreatListItemModel>> Handle(GetThreatListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var threats = await _database.Threats.ToListAsync(cancellationToken);

            return _mapper.Map<List<ThreatListItemModel>>(threats);
        }
    }
}
