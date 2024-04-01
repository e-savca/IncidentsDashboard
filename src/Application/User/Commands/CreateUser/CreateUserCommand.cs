using Application.Interfaces;
using Domain.User;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserModel>
    {
        public CreateUserModel UserModel { get; set; }
    }
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserModel>
    {
        private readonly IDatabaseService _database;
        private readonly IPasswordEncryptionService _passwordEncryptionService;
        public CreateUserHandler(
            IDatabaseService database,
            IPasswordEncryptionService passwordEncryptionService
            )
        {
            _database = database;
            _passwordEncryptionService = passwordEncryptionService;

        }
        public async Task<CreateUserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = request.UserModel;

            if (model == null)
            {
                return null;
            }

            // check if user already exists
            bool thereIsUser = _database.Users.Any(x => x.Username == model.Username);

            // handle the case where user already exists
            if (thereIsUser)
            {
                // throw an exception
                throw new Exception("User already exists");
            }


            // encrypt password
            model.Password = _passwordEncryptionService.HashPassword(model.Password);

            // add user
            _database.Users.Add(new Domain.User.User
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
            // save changes
            await _database.SaveAsync(cancellationToken);

            return model;
        }
    }
}
