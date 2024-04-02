using Application.Interfaces;
using AutoMapper;
using Domain.User;
using MediatR;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserModel>
    {
        public UpdateUserModel UserModel { get; set; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserModel>
    {
        private readonly IDatabaseService _database;
        public UpdateUserHandler(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<UpdateUserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = request.UserModel;
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

            await _database.SaveAsync(cancellationToken);

            return updatedUser;
        }

    }
}
