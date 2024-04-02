using Application.Roles.Queries.GetRolesList;
using AutoMapper;

namespace Application.Roles.MappingProfiles
{
    public class RoleQueryMappingProfile : Profile
    {
        public RoleQueryMappingProfile()
        {
            CreateMap<Domain.User.Role, RolesListItemModel>();
        }
    }
}
