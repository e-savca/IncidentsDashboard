using Application.Interfaces;
using Domain.Users;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDatabaseService _database;
        public UpdateUserCommand(
            IDatabaseService database)
        {
            _database = database;
        }

        public async Task<UpdateUserModel> ExecuteAsync(UpdateUserModel updatedUser)
        {
            if (updatedUser == null)
                return null;

            var user = await _database.Users.FindAsync(updatedUser.Id);
            if (user == null)
                return null;

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.IsActive = updatedUser.IsActive;
            user.UserRoles.Clear();
            user.UserRoles = updatedUser.RoleIds.Select(x => new UserRole
            {
                RoleId = x
            }).ToList();

            _database.Users.AddOrUpdate(user);
            await _database.SaveAsync();

            return updatedUser;
        }
    }
}
