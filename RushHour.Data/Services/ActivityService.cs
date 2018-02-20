using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Repositories;
using RushHour.Data.Entities;

namespace RushHour.Data.Services
{
   public class ActivityService : DataService<Activity>

    {
        public ActivityService(UnitOfWork unitOfWork) : base (unitOfWork)
        {

        }
    }
}
