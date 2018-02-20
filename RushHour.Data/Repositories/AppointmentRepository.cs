using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Entities;

namespace RushHour.Data.Repositories
{
    class AppointmentRepository : Repository<Appointment>
    {
        private RushHourDbContext context;
        public AppointmentRepository(RushHourDbContext context) : base(context)
        {
            this.context = context;
        }
        
    }
}
