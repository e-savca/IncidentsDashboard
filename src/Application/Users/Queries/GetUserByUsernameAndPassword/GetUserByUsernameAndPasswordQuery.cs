using Application.Interfaces;
using Application.Models;
using MediatR;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IRequest<UserByUsernameAndPasswordModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class GetUserByUsernameAndPasswordHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, UserByUsernameAndPasswordModel>        
    {
        private readonly IDatabaseService _database;

        public GetUserByUsernameAndPasswordHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }

        public async Task<UserByUsernameAndPasswordModel> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _database
                .Users.Include(u => u.UserRoles.Select(ur => ur.Role))
                .FirstOrDefaultAsync(u => u.Username == request.Username.ToUpper(), cancellationToken);

            if (user.Password != request.Password)
                user = null;

            UserByUsernameAndPasswordModel userDto = null;
            if (user != null)
            {
                userDto = new UserByUsernameAndPasswordModel
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
