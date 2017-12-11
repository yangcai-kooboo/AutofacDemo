using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Reflection;
using Autofacs.Models;

namespace Autofacs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<StudentRepository2>().As<IStudentRepository>();
            builder.RegisterType<StudentQuery>().As<IStudentQuery>();

            //builder.RegisterType<StudentQuery>().As<IStudentQuery>()
            //    .WithParameter(new Autofac.Core.ResolvedParameter(
            //        (pi, ctx) => pi.ParameterType == typeof(IStudentRepository[]) && pi.Name == "engines",
            //        (pi, ctx) => new[]
            //        {
            //            ctx.ResolveNamed<IStudentRepository>("StudentRepository1"),
            //            ctx.ResolveNamed<IStudentRepository>("StudentRepository2")

            //        })).InstancePerLifetimeScope();
        }
    }
}
