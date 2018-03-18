using RushHour.RelationalServices.Domain.ActivityModels;
using RushHour.RelationalServices.Domain.AppointmentModels;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DataAccess.Context
{
    public class RushHourDbContext : DbContext
    {
        public RushHourDbContext() : base("RushHourDbContext")
        {
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Appointment> Appointments { get; set; }
        public IDbSet<Activity> Activities { get; set; }
    }
}
