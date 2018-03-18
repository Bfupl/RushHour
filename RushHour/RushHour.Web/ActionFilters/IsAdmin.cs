using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RushHour.Web.ActionFilters
{
    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Authentication.AuthenticationManager.LoggedUser.IsAdmin != true)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }

            base.OnActionExecuting(filterContext);
        }

    }
}