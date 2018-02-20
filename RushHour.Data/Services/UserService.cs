using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Services;
using RushHour.Data.Entities;
using RushHour.Data.Repositories;

namespace RushHour.Data.Services
{
    class UserService : DataService<User>
    {
        public UserService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
