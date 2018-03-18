using RushHour.BaseService.Domain;
using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.RelationalServices.Domain.AppointmentModels
{
    public class Appointment : BaseModel
    {
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
