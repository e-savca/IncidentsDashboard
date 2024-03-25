using Application.Incident.Queries.GetIncidentById;
using Application.Incident.Queries.GetIncidentsList;
using Application.Interfaces;
using Application.Roles.Queries.GetRolesList;
using Application.Services;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using Application.User.Queries.GetUserById;
using Application.User.Queries.GetUserByUsernameAndPassword;
using Application.User.Queries.GetUsersList;
using Common.Dates;
using FluentValidation;
using MediatR;
using Ninject.Modules;
using Persistance;
using System.Collections.Generic;

namespace Presentation.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {

            #region Persistance layer dependencies

            Bind<IDatabaseService>().To<DatabaseService>();

            #endregion

            #region Common layer dependencies

            Bind<IDateService>().To<DateService>();

            #endregion

            #region Application layer dependencies

            #region MediatR dependencies

            #region Users Commands

            //Bind<ICreateUserCommand>().To<CreateUserCommand>();
            //Bind<IUpdateUserCommand>().To<UpdateUserCommand>();
            Bind<IRequestHandler<UpdateUserCommand, UpdateUserModel>>().To<UpdateUserHandler>();
            Bind<IRequestHandler<CreateUserCommand, CreateUserModel>>().To<CreateUserHandler>();

            #endregion

            #region Users Queries

            Bind<IRequestHandler<GetUserByUsernameAndPasswordQuery, UserByUsernameAndPasswordModel>>().To<GetUserByUsernameAndPasswordHandler>();
            Bind<IRequestHandler<GetUserByIdQuery, UserByIdModel>>().To<GetUserByIdHandler>();
            Bind<IRequestHandler<GetUsersListQuery, List<UsersListItemModel>>>().To<GetUsersListHandler>();

            #endregion

            #region Incidents Queries

            Bind<IRequestHandler<GetIncidentsListQuery, List<IncidentsListItemModel>>>().To<GetIncidentsListHandler>();
            Bind<IRequestHandler<GetIncidentByIdQuery, IncidentByIdModel>>().To<GetIncidentByIdHandler>();
            //Bind<IRequestHandler<GetUsersListQuery, List<UsersListItemModel>>>().To<GetUsersListHandler>();

            #endregion

            #region Roles Queries

            Bind<IRequestHandler<GetRolesListQuery, List<RolesListItemModel>>>().To<GetRolesListHandler>();

            #endregion

            #endregion

            #region Validators dependencies

            // make a list of all validators in the assembly
            //var validatorsList = AssemblyScanner.FindValidatorsInAssemblyContaining<CreateUserModel>();
            var validatorsList = AssemblyScanner.FindValidatorsInAssemblyContaining<CreateUserModel>();

            // loop through the list of validators and bind them to their respective interfaces
            foreach (var validator in validatorsList)
            {
                Bind(validator.InterfaceType).To(validator.ValidatorType);
            }

            #endregion

            #region Services

            Bind<IPasswordEncryptionService>().To<PasswordEncryptionService>();

            #endregion

            #region Automapper -- currently isn't in use

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<UserProfile>();
            //});
            //var mapper = config.CreateMapper();

            //Bind<IMapper>().ToConstant(mapper);

            #endregion

            #endregion

        }
    }
}