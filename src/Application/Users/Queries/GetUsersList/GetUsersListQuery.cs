using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<UsersListItemModel>> { }
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<UsersListItemModel>>
    {
        private readonly IDatabaseService _database;

        public GetUsersListHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }

        public async Task<List<UsersListItemModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            // get users from database
            var users = await _database.Users.Include(u => u.UserRoles.Select(ur => ur.Role)).ToListAsync(cancellationToken);

            // map to UserListItemModel
            var userDtos = users.Select(u => new UsersListItemModel
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsActive = u.IsActive,
                UserRoles = u.UserRoles.Select(ur => ur.Role.Name).ToList()
            }).ToList();

            return userDtos;
        }
    }
}
