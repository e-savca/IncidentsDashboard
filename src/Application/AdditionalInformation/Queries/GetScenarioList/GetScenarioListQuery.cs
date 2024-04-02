using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AdditionalInformation.Queries.GetScenarioList
{
    public class GetScenarioListQuery : IRequest<List<ScenarioListItemModel>> { }
    public class GetScenarioListHandler : IRequestHandler<GetScenarioListQuery, List<ScenarioListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetScenarioListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<ScenarioListItemModel>> Handle(GetScenarioListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var scenarios = await _database.Scenarios.ToListAsync(cancellationToken);

            return _mapper.Map<List<ScenarioListItemModel>>(scenarios);
        }
    }
}
