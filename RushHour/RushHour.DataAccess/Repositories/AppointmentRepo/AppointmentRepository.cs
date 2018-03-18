using RushHour.DataAccess.Context;
using RushHour.RelationalServices.Domain.AppointmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DataAccess.Repositories.AppointmentRepo
{
   public class AppointmentRepository : Repository<Appointment>
    {
        private RushHourDbContext context;
        public AppointmentRepository(RushHourDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
