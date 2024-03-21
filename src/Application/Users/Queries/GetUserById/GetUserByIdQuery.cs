using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserByIdModel> {
    public int Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserByIdModel> 
    {
        private readonly IDatabaseService _database;
        public GetUserByIdHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<UserByIdModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // get data from db
            var user = await _database.Users.FindAsync(cancellationToken, request.Id);

            // Map to dto
            var userDto = new UserByIdModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
                RoleIds = user.UserRoles.Select(ur => ur.RoleId).ToList()
            };


            // return dto
            return userDto;
        }
    } 
}
