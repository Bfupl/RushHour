using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RushHour.Data.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RushHour.Data
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
