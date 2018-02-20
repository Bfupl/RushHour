using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Entities;

namespace RushHour.Data.Repositories
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
