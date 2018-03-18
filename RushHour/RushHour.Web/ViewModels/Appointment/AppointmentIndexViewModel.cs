
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RushHour.Web.ViewModels.Appointment
{
    public class AppointmentIndexViewModel
    {
        public int Id { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int  UserId { get; set; }
        public string UserName { get; set; }
        public List<string> ActivitiesNames { get; set; }
        
    }
}