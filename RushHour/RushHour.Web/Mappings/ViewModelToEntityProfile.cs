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