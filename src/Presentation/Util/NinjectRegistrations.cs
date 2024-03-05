using Application.Interfaces;
using Application.Users.Queries.GetUsersList;
using Ninject.Modules;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseService>().To<DatabaseService>();
            Bind<IGetUsersListQuery>().To<GetUsersListQuery>();
        }
    }
}