using RushHour.DataAccess.Context;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DataAccess.Repositories.UserRepo
{
    public class UserRepository : Repository<User>
    {
        private RushHourDbContext context;
        public UserRepository(RushHourDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
