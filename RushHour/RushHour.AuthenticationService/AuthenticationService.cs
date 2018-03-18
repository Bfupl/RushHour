using RushHour.DataAccess.Context;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RushHour.AuthenticationService
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
