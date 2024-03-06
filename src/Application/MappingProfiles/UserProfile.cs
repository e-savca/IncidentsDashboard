using Application.Models;
using AutoMapper;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    { 
        public UserProfile()
        {
            CreateMap<Domain.Users.User, UserDto>();
            CreateMap<Domain.Users.Role, RoleDto>();
            CreateMap<Domain.Users.UserRole, UserRoleDto>();
        }
    }
}
