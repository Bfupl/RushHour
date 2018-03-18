using RushHour.DataAccess.Context;
using RushHour.RelationalServices.Domain.ActivityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DataAccess.Repositories.ActivityRepo
{
    public class ActivityRepository : Repository<Activity>
    {
        private RushHourDbContext context;
        public ActivityRepository(RushHourDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
