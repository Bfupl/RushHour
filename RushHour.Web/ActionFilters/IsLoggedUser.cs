using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RushHour.Data.Services;
using RushHour.Data.Entities;
using RushHour.Web.Authentication;

namespace RushHour.Web.ActionFilters
{
    public class IsLoggedUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Authentication.AuthenticationManager.LoggedUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }


            base.OnActionExecuting(filterContext);
        }
    }
}