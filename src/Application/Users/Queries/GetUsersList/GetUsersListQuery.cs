using Application.Interfaces;
using Application.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IGetUsersListQuery
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetUsersListQuery(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }
        public List<UserDto> Execute()
        {
            // get users from database
            var users = _database.Users.
                Include(u => u.UserRoles.Select(ur => ur.Role))
                .ToList();

            // map to UserDto
            var userDtos = users.Select(u => _mapper.Map<UserDto>(u)).ToList();


            return userDtos;
        }
    }
}
