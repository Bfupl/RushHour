using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RushHour.RelationalServices.Domain.UserModels;
using RushHour.RelationalServices.Domain.ActivityModels;

namespace RushHour.Web.ViewModels.Appointment
{
    public class AppointmentCreateViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }

        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public List<Activity> ActivitiesList { get; set; }
        public List<ActivityViewModel> ListBoxActivities { get; set; }
    }
}