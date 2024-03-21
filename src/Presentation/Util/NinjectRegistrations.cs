﻿using Application.Interfaces;
using Application.Roles.Queries.GetRolesList;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.GetUserByUsernameAndPassword;
using Application.Users.Queries.GetUsersList;
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

            #region Users

            #region Queries

            Bind<IRequestHandler<GetUserByUsernameAndPasswordQuery, UserByUsernameAndPasswordModel>>().To<GetUserByUsernameAndPasswordHandler>();
            Bind<IRequestHandler<GetUserByIdQuery, UserByIdModel>>().To<GetUserByIdHandler>();
            Bind<IRequestHandler<GetUsersListQuery, List<UsersListItemModel>>>().To<GetUsersListHandler>();

            #endregion

            #region Commands

            Bind<ICreateUserCommand>().To<CreateUserCommand>();
            Bind<IUpdateUserCommand>().To<UpdateUserCommand>();

            #endregion

            #endregion

            #region Roles

            #region Queries

            Bind<IRequestHandler<GetRolesListQuery, List<RolesListItemModel>>>().To<GetRolesListHandler>();

            #endregion


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