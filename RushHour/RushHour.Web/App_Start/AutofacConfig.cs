using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RushHour.ContainerBuilderService;

namespace RushHour.Web.App_Start
{
    public class AutofacConfig
    {
        private static Autofac.IContainer Container { get; set; }
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterServices();
            builder.RegisterRepositories();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}