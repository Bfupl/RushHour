using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using RushHour.Data.Services;
using RushHour.Web.Controllers;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

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