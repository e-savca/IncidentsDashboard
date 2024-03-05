using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IGetUsersListQuery
    {
        private readonly IDatabaseService _database;
        public GetUsersListQuery(IDatabaseService database)
        {
            _database = database;
        }
        public List<UsersListItemModel> Execute()
        {
            var users = _database.Users
                .Select(p => new UsersListItemModel()
                {
                    UserId = p.Id,
                    Username = p.Username,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    Email = p.Email,
                    IsActive = p.IsActive
                });

            return users.ToList();
        }
    }
}
