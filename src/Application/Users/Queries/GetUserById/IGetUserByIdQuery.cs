using Application.Models;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    public interface IGetUserByIdQuery
    {
        Task<UserByIdModel> ExecuteAsync(int id);
    }
}
