using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetRolesListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<List<RolesListItemModel>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _database.Roles.ToListAsync(cancellationToken);
            return _mapper.Map<List<RolesListItemModel>>(roles);
        }
    }


}
