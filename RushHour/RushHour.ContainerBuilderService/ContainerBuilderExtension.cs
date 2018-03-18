using Autofac;
using RushHour.ActivityServices;
using RushHour.AppointmentServices;
using RushHour.Common.Interfaces;
using RushHour.DataAccess.Context;
using RushHour.DataAccess.Repositories.ActivityRepo;
using RushHour.DataAccess.Repositories.AppointmentRepo;
using RushHour.DataAccess.Repositories.UserRepo;
using RushHour.DataAccess.UnitOfWork;
using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.RelationalServices.Domain.AppointmentModels;
using RushHour.RelationalServices.Domain.UserModels;
using RushHour.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.ContainerBuilderService
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
