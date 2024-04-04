using Application.AdditionalInformation.MappingProfiles;
using Application.AdditionalInformation.Queries.GetAmbitListByOriginId;
using Application.AdditionalInformation.Queries.GetIncidentTypeListByAmbitId;
using Application.AdditionalInformation.Queries.GetOriginList;
using Application.AdditionalInformation.Queries.GetScenarioList;
using Application.AdditionalInformation.Queries.GetThreatList;
using Application.Incident.Commands.CreateIncident;
using Application.Incident.Commands.DeleteIncident;
using Application.Incident.Commands.ImportIncident;
using Application.Incident.Commands.UpdateIncident;
using Application.Incident.MappingProfiles;
using Application.Incident.Queries.GetExportIncidentToFile;
using Application.Incident.Queries.GetIncidentById;
using Application.Incident.Queries.GetIncidentDetailsById;
using Application.Incident.Queries.GetIncidentsList;
using Application.Interfaces;
using Application.Roles.MappingProfiles;
using Application.Roles.Queries.GetRolesList;
using Application.Services;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using Application.User.MappingProfiles;
using Application.User.Queries.GetUserById;
using Application.User.Queries.GetUserByUsernameAndPassword;
using Application.User.Queries.GetUsersList;
using AutoMapper;
using Common.Dates;
using Common.Models;
using FluentValidation;
using MediatR;
using Ninject.Modules;
using Persistance;
using System.Collections.Generic;
using System.IO;

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

            #region User Commands

            Bind<IRequestHandler<UpdateUserCommand, UpdateUserModel>>().To<UpdateUserHandler>();
            Bind<IRequestHandler<CreateUserCommand, CreateUserModel>>().To<CreateUserHandler>();

            #endregion

            #region User Queries

            Bind<IRequestHandler<GetUserByUsernameAndPasswordQuery, UserByUsernameAndPasswordModel>>().To<GetUserByUsernameAndPasswordHandler>();
            Bind<IRequestHandler<GetUserByIdQuery, UserByIdModel>>().To<GetUserByIdHandler>();
            Bind<IRequestHandler<GetUsersListQuery, DataTableResponseModel<UsersListItemModel>>>().To<GetUsersListHandler>();

            #endregion

            #region Role Queries

            Bind<IRequestHandler<GetRolesListQuery, List<RolesListItemModel>>>().To<GetRolesListHandler>();

            #endregion

            #region Incident Queries

            Bind<IRequestHandler<GetIncidentsListQuery, DataTableResponseModel<IncidentsListItemModel>>>().To<GetIncidentsListHandler>();
            Bind<IRequestHandler<GetIncidentByIdQuery, IncidentByIdModel>>().To<GetIncidentByIdHandler>();
            Bind<IRequestHandler<GetIncidentDetailsByIdQuery, IncidentDetailsByIdModel>>().To<GetIncidentDetailsByIdHandler>();
            Bind<IRequestHandler<GetExportIncidentToFileQuery, byte[]>>().To<GetExportIncidentToFileHandler>();

            #endregion

            #region Incident Commands

            Bind<IRequestHandler<UpdateIncidentCommand, UpdateIncidentModel>>().To<UpdateIncidentHandler>();
            Bind<IRequestHandler<CreateIncidentCommand, CreateIncidentModel>>().To<CreateIncidentHandler>();
            Bind<IRequestHandler<DeleteIncidentCommand, bool>>().To<DeleteIncidentHandler>();
            Bind<IRequestHandler<ImportIncidentCommand, bool>>().To<ImportIncidentHandler>();

            #endregion

            #region Additional Information Queries

            Bind<IRequestHandler<GetOriginListQuery, List<OriginListItemModel>>>().To<GetOriginListHandler>();
            Bind<IRequestHandler<GetAmbitListByOriginIdQuery, List<AmbitListByOriginIdItemModel>>>().To<GetAmbitListByOriginIdHandler>();
            Bind<IRequestHandler<GetIncidentTypeListByAmbitIdQuery, List<IncidentTypeListByAmbitIdItemModel>>>().To<GetIncidentTypeListByAmbitIdHandler>();
            Bind<IRequestHandler<GetScenarioListQuery, List<ScenarioListItemModel>>>().To<GetScenarioListHandler>();
            Bind<IRequestHandler<GetThreatListQuery, List<ThreatListItemModel>>>().To<GetThreatListHandler>();

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

            #region Automapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdditionalInformationQueryMappingProfile>();

                cfg.AddProfile<IncidentCommandMappingProfile>();
                cfg.AddProfile<IncidentQueryMappingProfile>();

                cfg.AddProfile<RoleQueryMappingProfile>();

                cfg.AddProfile<UserQueryMappingProfile>();
                cfg.AddProfile<UserCommandMappingProfile>();
            });
            var mapper = config.CreateMapper();

            Bind<IMapper>().ToConstant(mapper);

            #endregion

            #endregion

        }
    }
}