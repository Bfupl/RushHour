using RushHour.BaseService.Domain;
using RushHour.RelationalServices.Domain.AppointmentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.RelationalServices.Domain.ActivityModels
{
   public  class Activity :BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
