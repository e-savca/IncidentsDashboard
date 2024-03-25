using Application.Models;
using AutoMapper;

namespace Application.MappingProfiles
{
    public class UserProfile : Profile
    { 
        public UserProfile()
        {
            CreateMap<Domain.User.User, UserDto>();
            CreateMap<Domain.User.Role, RoleDto>();
            CreateMap<Domain.User.UserRole, UserRoleDto>();
        }
    }
}
