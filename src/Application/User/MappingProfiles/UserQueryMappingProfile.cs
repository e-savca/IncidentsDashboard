using Application.User.Queries.GetUserById;
using Application.User.Queries.GetUserByUsernameAndPassword;
using Application.User.Queries.GetUsersList;
using AutoMapper;
using System.Linq;

namespace Application.User.MappingProfiles
{
    public class UserQueryMappingProfile : Profile
    {
        public UserQueryMappingProfile()
        {
            // GetUsersList Models mapping
            CreateMap<Domain.User.User, UsersListItemModel>()
            .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Name)));

            // GetUserByUsernameAndPassword Models mapping
            CreateMap<Domain.User.Role, RoleModel>();
            CreateMap<Domain.User.UserRole, UserRoleModel>();

            CreateMap<Domain.User.User, UserByUsernameAndPasswordModel>()
            .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles));

            // GetUserById Models mapping
            CreateMap<Domain.User.User, UserByIdModel>()
            .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId)));

        }
    }
}
