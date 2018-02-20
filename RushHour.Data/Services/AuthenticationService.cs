using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Entities;


namespace RushHour.Data.Services
{
    public class AuthenticationService
    {
        public User LoggedUser { get; set; }
        private RushHourDbContext context;

        public void AuthenticateUser(string email, string password)
        {
            context = new RushHourDbContext();

            List<User> users = context.Users.Where((u) => u.Email == email && u.Password == password).ToList();

            this.LoggedUser = users.Count > 0 ? users[0] : null;
        }
    }
}
