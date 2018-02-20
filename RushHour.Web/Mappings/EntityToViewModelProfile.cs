using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RushHour.Data.Entities;

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