using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<UsersListItemModel>> { }
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UsersListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetUsersListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<List<UsersListItemModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            // get users from database
            var users = await _database.Users.Include(u => u.UserRoles.Select(ur => ur.Role)).ToListAsync(cancellationToken);

            // map to UserListItemModel
            var userDtos = _mapper.Map<List<UsersListItemModel>>(users);

            return userDtos;
        }
    }
}
