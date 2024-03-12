using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public interface IGetUsersListQuery
    {
        Task<List<UsersListItemModel>> ExecuteAsync();
    }
}
