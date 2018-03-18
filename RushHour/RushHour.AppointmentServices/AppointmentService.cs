using RushHour.BaseService;
using RushHour.DataAccess.UnitOfWork;
using RushHour.RelationalServices.Domain.AppointmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.AppointmentServices
{
    public class AppointmentService : BaseService<Appointment>

    {
        public AppointmentService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
