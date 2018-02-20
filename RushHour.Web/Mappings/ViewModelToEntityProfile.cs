using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RushHour.Data.Entities;
using System.Linq.Expressions;

namespace RushHour.Web.Mappings
{

    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<ViewModels.UserViewModel, User>();
            CreateMap<ViewModels.ActivityViewModel, Activity>();
            CreateMap<ViewModels.Appointment.AppointmentCreateViewModel, Appointment>().ForMember(dest => dest.Activities,
                opts => opts.MapFrom(src => src.ActivitiesList));
            CreateMap<ViewModels.Appointment.AppointmentIndexViewModel, Appointment>();
            CreateMap<ViewModels.Appointment.AppoitmentEditViewModel, Appointment>();
        }
    }
}