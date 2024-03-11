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
        private readonly IMapper _mapper;

        public GetUserByUsernameAndPasswordQuery(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<UserDto> ExecuteAsync(string username, string password)
        {
            var user = await _database
                .Users.Include(u => u.UserRoles.Select(ur => ur.Role))
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            UserDto userDto = null;
            if (user != null)
            {
                userDto = _mapper.Map<UserDto>(user);
            }

            return userDto;
        }
    }
}
