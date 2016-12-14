using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;


namespace Garage.Filters
{
    public class LoginAuthorize : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = System.Web.HttpContext.Current.Session["User"];

            if (user == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Home");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
                this.OnActionExecuting(filterContext);
            }

            this.OnActionExecuting(filterContext);
        }
    }
}