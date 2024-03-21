using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Roles.Queries.GetRolesList
{
    public class GetRolesListQuery : IRequest<List<RolesListItemModel>> { }
    public class GetRolesListHandler : IRequestHandler<GetRolesListQuery, List<RolesListItemModel>>
    {
        private readonly IDatabaseService _database;
        public GetRolesListHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<RolesListItemModel>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _database.Roles.ToListAsync(cancellationToken);
            var roleDtos = roles.ConvertAll(r => new RolesListItemModel
            {
                Id = r.Id,
                Name = r.Name
            });
            return roleDtos;
        }
    }


}
