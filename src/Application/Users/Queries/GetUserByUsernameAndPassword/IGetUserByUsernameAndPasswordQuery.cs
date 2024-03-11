using Application.Models;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByUsernameAndPassword
{
    public interface IGetUserByUsernameAndPasswordQuery
    {
        Task<UserDto> ExecuteAsync(string username, string password);
    }
}
