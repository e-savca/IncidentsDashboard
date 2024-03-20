using Application.Interfaces;
using Domain.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDatabaseService _database;
        public CreateUserCommand(
            IDatabaseService database)
        {
            _database = database;

        }

        public async Task<CreateUserModel> ExecuteAsync(CreateUserModel model)
        {            
            // add user
            if (model != null)
            {
                _database.Users.Add(new User
                {
                    Username = model.Username.ToUpperInvariant(),
                    Password = model.Password,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsActive = model.IsActive,
                    UserRoles = model.RoleIds.Select(x => new UserRole
                    {
                        RoleId = x
                    }).ToList()
                });
            }
            // save changes
            await _database.SaveAsync();

            return model;
        }
    }
}
