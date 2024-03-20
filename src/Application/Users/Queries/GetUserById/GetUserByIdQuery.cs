using Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDatabaseService _database;

        public GetUserByIdQuery(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<UserByIdModel> ExecuteAsync(int id)
        {
            // get data from db
            var user = await _database.Users.FindAsync(id);

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
