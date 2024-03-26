using Application.Interfaces;
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
        public GetThreatListHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<ThreatListItemModel>> Handle(GetThreatListQuery request, CancellationToken cancellationToken)
        {
            // get data from database
            var threats = await _database.Threats.ToListAsync(cancellationToken);

            // map data
            var threatDtos = threats.ConvertAll(t => new ThreatListItemModel
            {
                Id = t.Id,
                Code = t.Code,
                Name = t.Name
            });
            return threatDtos;
        }
    }
}
