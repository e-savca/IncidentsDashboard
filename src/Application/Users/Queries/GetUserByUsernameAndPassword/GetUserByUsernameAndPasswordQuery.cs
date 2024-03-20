using Application.Interfaces;
using Application.Models;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDatabaseService _database;

        public GetUserByUsernameAndPasswordQuery(
            IDatabaseService database
            )
        {
            _database = database;
        }

        public async Task<UserDto> ExecuteAsync(string username, string password)
        {
            var user = await _database
                .Users.Include(u => u.UserRoles.Select(ur => ur.Role))
                .FirstOrDefaultAsync(u => u.Username == username.ToUpper());

            if (user.Password != password)
                user = null;

            UserDto userDto = null;
            if (user != null)
            {
                userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    UserRoles = user.UserRoles.Select(ur => new UserRoleDto
                    {
                        Role = new RoleDto
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }
                    }).ToList()

                };
                return userDto;
            }

            return userDto;
        }
    }
}
