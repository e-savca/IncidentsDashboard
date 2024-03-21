using Application.Interfaces;
using Domain.Users;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserModel>
    {
        public CreateUserModel UserModel { get; set; }
    }
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserModel>
    {
        private readonly IDatabaseService _database;
        public CreateUserHandler(
            IDatabaseService database)
        {
            _database = database;
        }
        public async Task<CreateUserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = request.UserModel;
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
            await _database.SaveAsync(cancellationToken);

            return model;
        }
    }
}
