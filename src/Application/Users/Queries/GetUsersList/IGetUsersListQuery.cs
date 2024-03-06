using Application.Models;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUsersList
{
    public interface IGetUsersListQuery
    {
        List<UserDto> Execute();
    }
}
