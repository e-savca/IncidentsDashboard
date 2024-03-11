using Application.Interfaces;
using Application.MappingProfiles;
using Application.Users.Queries.GetUserByUsernameAndPassword;
using Application.Users.Queries.GetUsersList;
using AutoMapper;
using Common.Dates;
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
            // Queries
            Bind<IGetUsersListQuery>().To<GetUsersListQuery>();
            Bind<IGetUserByUsernameAndPasswordQuery>().To<GetUserByUsernameAndPasswordQuery>();


            // Commands 


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();

            Bind<IMapper>().ToConstant(mapper);
        }
    }
}