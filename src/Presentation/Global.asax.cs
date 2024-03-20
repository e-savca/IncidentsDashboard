using Ninject.Modules;
using Ninject.Web.Mvc;
using Ninject;
using Presentation.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using MediatR.Ninject;

namespace Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // FluentValidation setup
            FluentValidationModelValidatorProvider.Configure();


            // add dependencies
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            // Add MediatR
            kernel.BindMediatR();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
