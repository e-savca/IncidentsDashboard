using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using AutoMapper;
using Domain.User;
using System.Linq;
using System.Security.Cryptography;

namespace Application.User.MappingProfiles
{
    public class UserCommandMappingProfile : Profile
    {
        public UserCommandMappingProfile()
        {
            CreateMap<CreateUserModel, Domain.User.User>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.RoleIds.Select(roleId => new UserRole
                {
                    RoleId = roleId
                })
                ));

            //CreateMap<UpdateUserModel, Domain.User.User>()
            //.ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.RoleIds.Select(roleId => new UserRole
            //{
            //    RoleId = roleId
            //})
            //));
            //CreateMap<UpdateUserModel, Domain.User.User>();
        }
    }
}