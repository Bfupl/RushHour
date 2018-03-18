using AutoMapper;
using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.RelationalServices.Domain.AppointmentModels;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Web.Mappings
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<User, ViewModels.UserViewModel>();
            CreateMap<Activity, ViewModels.ActivityViewModel>();
            CreateMap<Appointment, ViewModels.Appointment.AppointmentCreateViewModel>();
            CreateMap<Appointment, ViewModels.Appointment.AppointmentIndexViewModel>().ForMember(dest => dest.ActivitiesNames,
                opts => opts.MapFrom(src => src.Activities.Select(a => a.Name).ToList()));
            CreateMap<Appointment, ViewModels.Appointment.AppoitmentEditViewModel>().ForMember(dest => dest.Activities, opts => opts.MapFrom(src => src.Activities));
        }
    }
}