using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IRequest<UserByUsernameAndPasswordModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class GetUserByUsernameAndPasswordHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, UserByUsernameAndPasswordModel>        
    {
        private readonly IDatabaseService _database;
        private readonly IPasswordEncryptionService _passwordEncryptionService;
        private readonly IMapper _mapper;

        public GetUserByUsernameAndPasswordHandler(
            IDatabaseService database,
            IPasswordEncryptionService passwordEncryptionService,
            IMapper mapper
            )
        {
            _database = database;
            _passwordEncryptionService = passwordEncryptionService;
            _mapper = mapper;
        }

        public async Task<UserByUsernameAndPasswordModel> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _database
                .Users.Include(u => u.UserRoles.Select(ur => ur.Role))
                .FirstOrDefaultAsync(u => u.Username == request.Username.ToUpper(), cancellationToken);

            if (_passwordEncryptionService.VerifyPassword(request.Password, user.Password))
                user = null;

            //var userDto = new UserByUsernameAndPasswordModel
            //{
            //    Id = user.Id,
            //    Username = user.Username,
            //    Password = user.Password,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    IsActive = user.IsActive,
            //    UserRoles = user.UserRoles.Select(ur => new UserRoleModel
            //    {
            //        Role = new RoleModel
            //        {
            //            Id = ur.Role.Id,
            //            Name = ur.Role.Name
            //        }
            //    }).ToList()
            //};

            var userDto = _mapper.Map<UserByUsernameAndPasswordModel>(user);

            return userDto;
        }
    }
}
