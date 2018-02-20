using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using RushHour.Data.Entities;
using RushHour.Data.Repositories;


namespace RushHour.Data.Services
{
    public static class ContainerBuilderExtension
    {
        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<ActivityService>().As<IService<Activity>>().InstancePerRequest();
            builder.RegisterType<AppointmentService>().As<IService<Appointment>>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IService<User>>().InstancePerRequest();

        }

        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<UnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<RushHourDbContext>().AsSelf();
            builder.RegisterType<ActivityRepository>().As<IRepository<Activity>>().InstancePerRequest();
            builder.RegisterType<AppointmentRepository>().As<IRepository<Appointment>>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IRepository<User>>().InstancePerRequest();
        }
    }
}
