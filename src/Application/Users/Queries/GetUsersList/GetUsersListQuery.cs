using Application.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IGetUsersListQuery
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetUsersListQuery(
            IDatabaseService database
            )
        {
            _database = database;
        }

        public async Task<List<UsersListItemModel>> ExecuteAsync()
        {
            // get users from database
            var users = await _database.Users
                .Include(u => u.UserRoles.Select(ur => ur.Role))
                .ToListAsync();

            // map to UserListItemModel
            var userDtos = users.Select(u => new UsersListItemModel
            {
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
