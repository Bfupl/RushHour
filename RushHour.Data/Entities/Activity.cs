using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RushHour.Data.Entities
{
    public class Activity : BaseEntity
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
