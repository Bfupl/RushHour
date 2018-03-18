using RushHour.DataAccess.UnitOfWork;
using RushHour.RelationalServices.Domain.ActivityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.BaseService;

namespace RushHour.ActivityServices
{
    public class ActivityService : BaseService<Activity>

    {
        public ActivityService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
