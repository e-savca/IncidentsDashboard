using Application.Interfaces;
using Application.MappingProfiles;
using Application.Roles.Queries.GetRolesList;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.GetUserByUsernameAndPassword;
using Application.Users.Queries.GetUsersList;
using AutoMapper;
using Common.Dates;
using FluentValidation;
using Ninject.Modules;
using Persistance;

namespace Presentation.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            // Persistance layer dependencies
            Bind<IDatabaseService>().To<DatabaseService>();

            // Common layer dependencies
            Bind<IDateService>().To<DateService>();

            // Application layer dependencies
            // Users Queries
            Bind<IGetUsersListQuery>().To<GetUsersListQuery>();
            Bind<IGetUserByUsernameAndPasswordQuery>().To<GetUserByUsernameAndPasswordQuery>();

            // Roles Queries
            Bind<IGetRolesListQuery>().To<GetRolesListQuery>();
            Bind<IGetUserByIdQuery>().To<GetUserByIdQuery>();


            // Commands 
            Bind<ICreateUserCommand>().To<CreateUserCommand>();


            // Validators
            var validators = AssemblyScanner.FindValidatorsInAssemblyContaining<CreateUserModel>();
            foreach (var validator in validators)
            {
                Bind(validator.InterfaceType).To(validator.ValidatorType);
            }



            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<UserProfile>();
            //});
            //var mapper = config.CreateMapper();

            //Bind<IMapper>().ToConstant(mapper);
        }
    }
}