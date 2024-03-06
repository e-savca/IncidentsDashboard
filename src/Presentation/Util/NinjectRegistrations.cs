using Application.Interfaces;
using Application.MappingProfiles;
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
            Bind<IDatabaseService>().To<DatabaseService>();
            Bind<IDateService>().To<DateService>();
            Bind<IGetUsersListQuery>().To<GetUsersListQuery>();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
            var mapper = config.CreateMapper();

            Bind<IMapper>().ToConstant(mapper);
        }
    }
}