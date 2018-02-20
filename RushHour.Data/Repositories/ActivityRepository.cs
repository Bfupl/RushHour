using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Entities;

namespace RushHour.Data.Repositories
{
    class ActivityRepository : Repository<Activity>
    {
        private RushHourDbContext context;
        public ActivityRepository(RushHourDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
