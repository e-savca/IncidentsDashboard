using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserByIdModel> {
    public int Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserByIdModel> 
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<UserByIdModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // get data from db
            var user = await _database.Users.FindAsync(cancellationToken, request.Id);

            // Map to dto
            //var userDto = new UserByIdModel
            //{
            //    Id = user.Id,
            //    Username = user.Username,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    IsActive = user.IsActive,
            //    RoleIds = user.UserRoles.Select(ur => ur.RoleId).ToList()
            //};

            var userDto = _mapper.Map<UserByIdModel>(user);


            // return dto
            return userDto;
        }
    } 
}
