using Application.Interfaces;
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
        public GetScenarioListHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<ScenarioListItemModel>> Handle(GetScenarioListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var scenarios = await _database.Scenarios.ToListAsync(cancellationToken);
            // map data
            var scenarioDtos = scenarios.ConvertAll(s => new ScenarioListItemModel
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name
            });
            return scenarioDtos;
        }
    }
}
