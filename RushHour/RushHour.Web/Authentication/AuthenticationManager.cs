using RushHour.AuthenticationService;
using RushHour.RelationalServices.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Web.Authentication
{
    public class AuthenticationManager
    {
        public static User LoggedUser
        {
            get
            {
                AuthenticationService.AuthenticationService authenticationService = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                    HttpContext.Current.Session["LoggedUser"] = new AuthenticationService.AuthenticationService();

                authenticationService = (AuthenticationService.AuthenticationService)HttpContext.Current.Session["LoggedUser"];
                return authenticationService.LoggedUser;
            }
        }

        public static void Authenticate(string email, string password)
        {
            AuthenticationService.AuthenticationService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                HttpContext.Current.Session["LoggedUser"] = new AuthenticationService.AuthenticationService();

            authenticationService = (AuthenticationService.AuthenticationService)HttpContext.Current.Session["LoggedUser"];
            authenticationService.AuthenticateUser(email, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}