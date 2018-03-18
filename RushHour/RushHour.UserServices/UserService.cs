using RushHour.BaseService;
using RushHour.DataAccess.UnitOfWork;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.UserServices
{
    public class UserService : BaseService<User>
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
